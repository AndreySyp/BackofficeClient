using System.Collections;
using System.Collections.Specialized;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace BackofficeClient.Views.MainWindowPages;

public class Extension : DependencyObject
{
    public static readonly DependencyProperty IsSubscribedToSelectionChangedProperty = DependencyProperty.RegisterAttached(
        "IsSubscribedToSelectionChanged", typeof(bool), typeof(Extension), new PropertyMetadata(default(bool)));

    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached(
        "SelectedItems", typeof(IList), typeof(Extension), new PropertyMetadata(default(IList), OnSelectedItemsChanged));

    public static void SetIsSubscribedToSelectionChanged(DependencyObject element, bool value) =>
        element.SetValue(IsSubscribedToSelectionChangedProperty, value);

    public static bool GetIsSubscribedToSelectionChanged(DependencyObject element) =>
        (bool)element.GetValue(IsSubscribedToSelectionChangedProperty);

    public static void SetSelectedItems(DependencyObject element, IList value) =>
        element.SetValue(SelectedItemsProperty, value);

    public static IList GetSelectedItems(DependencyObject element) =>
        (IList)element.GetValue(SelectedItemsProperty);

    /// <summary>
    /// Attaches a list or observable collection to the grid or listbox, syncing both lists (one way sync for simple lists).
    /// </summary>
    /// <param name="d">The DataGrid or ListBox</param>
    /// <param name="e">The list to sync to.</param>
    private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not (ListBox or MultiSelector))
        {
            throw new ArgumentException("Somehow this got attached to an object I don't support. ListBoxes and Multiselectors (DataGrid), people. Geesh =P!");
        }

        if (d is not Selector selector)
        {
            return;
        }

        if (e.OldValue is IList oldList)
        {
            if (oldList is INotifyCollectionChanged obs)
            {
#pragma warning disable CS8622 
                obs.CollectionChanged -= OnCollectionChanged;
#pragma warning restore CS8622 
            }
            // If we're orphaned, disconnect lb/dg events.
            if (e.NewValue == null)
            {
                selector.SelectionChanged -= OnSelectorSelectionChanged;
                SetIsSubscribedToSelectionChanged(selector, false);
            }
        }

        if (e.NewValue is IList newList)
        {
            if (newList is INotifyCollectionChanged obs)
            {
#pragma warning disable CS8622 
                obs.CollectionChanged += OnCollectionChanged;
#pragma warning restore CS8622
            }

            PushCollectionDataToSelectedItems(newList, selector);
            var isSubscribed = GetIsSubscribedToSelectionChanged(selector);

            if (!isSubscribed)
            {
                selector.SelectionChanged += OnSelectorSelectionChanged;
                SetIsSubscribedToSelectionChanged(selector, true);
            }
        }
    }

    /// <summary>
    /// Initially set the selected items to the items in the newly connected collection,
    /// unless the new collection has no selected items and the listbox/grid does, in which case
    /// the flow is reversed. The data holder sets the state. If both sides hold data, then the
    /// bound IList wins and dominates the helpless wpf control.
    /// </summary>
    /// <param name="obs">The list to sync to</param>
    /// <param name="selector">The grid or listbox</param>
    private static void PushCollectionDataToSelectedItems(IList obs, DependencyObject selector)
    {
        switch (selector)
        {
            case ListBox listBox:
                {
                    if (obs.Count > 0)
                    {
                        listBox.SelectedItems.Clear();
                        foreach (var ob in obs)
                        {
                            listBox.SelectedItems.Add(ob);
                        }
                        return;
                    }
                    else
                    {
                        foreach (var ob in listBox.SelectedItems)
                        {
                            obs.Add(ob);
                        }
                    }
                    return;
                }
            // Maybe other things will use the multiselector base... who knows =P
            case MultiSelector grid:
                {
                    if (obs.Count > 0)
                    {
                        grid.SelectedItems.Clear();
                        foreach (var ob in obs)
                        {
                            grid.SelectedItems.Add(ob);
                        }
                    }
                    else
                    {
                        foreach (var ob in grid.SelectedItems)
                        {
                            obs.Add(ob);
                        }
                    }
                    return;
                }
            default:
                throw new ArgumentException("Somehow this got attached to an object I don't support. ListBoxes and Multiselectors (DataGrid), people. Geesh =P!");
        }
    }
    /// <summary>
    /// When the listbox or grid fires a selectionChanged even, we update the attached list to
    /// match it.
    /// </summary>
    /// <param name="sender">The listbox or grid</param>
    /// <param name="e">Items added and removed.</param>
    private static void OnSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not DependencyObject dep)
        {
            return;
        }
        var items = GetSelectedItems(dep);
        var col = items as INotifyCollectionChanged;

        // Remove the events so we don't fire back and forth, then re-add them.
        if (col != null)
        {
#pragma warning disable CS8622
            col.CollectionChanged -= OnCollectionChanged;
#pragma warning restore CS8622
        }

        foreach (var oldItem in e.RemovedItems)
        {
            items.Remove(oldItem);
        }

        foreach (var newItem in e.AddedItems)
        {
            items.Add(newItem);
        }

        if (col != null)
        {
#pragma warning disable CS8622
            col.CollectionChanged += OnCollectionChanged;
#pragma warning restore CS8622
        }
    }

    /// <summary>
    /// When the attached object implements INotifyCollectionChanged, the attached listbox
    /// or grid will have its selectedItems adjusted by this handler.
    /// </summary>
    /// <param name="sender">The listbox or grid</param>
    /// <param name="e">The added and removed items</param>
    private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e == null || e.OldItems == null || e.NewItems == null)
        {
            return;
        }

        // Push the changes to the selected item.
        if (sender is ListBox listbox)
        {
            listbox.SelectionChanged -= OnSelectorSelectionChanged;
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                listbox.SelectedItems.Clear();
            }
            else
            {
                foreach (var oldItem in e.OldItems)
                {
                    listbox.SelectedItems.Remove(oldItem);
                }

                foreach (var newItem in e.NewItems)
                {
                    listbox.SelectedItems.Add(newItem);
                }
            }
            listbox.SelectionChanged += OnSelectorSelectionChanged;
        }
        if (sender is MultiSelector grid)
        {
            grid.SelectionChanged -= OnSelectorSelectionChanged;
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                grid.SelectedItems.Clear();
            }
            else
            {
                foreach (var oldItem in e.OldItems)
                {
                    grid.SelectedItems.Remove(oldItem);
                }

                foreach (var newItem in e.NewItems)
                {
                    grid.SelectedItems.Add(newItem);
                }
            }
            grid.SelectionChanged += OnSelectorSelectionChanged;
        }
    }
}
