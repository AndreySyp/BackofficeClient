namespace BackofficeClient.Views.MainWindowPages;

public partial class Requests
{
    public class ColumnNameAttribute : Attribute
    {
        public ColumnNameAttribute(string Name) { this.Name = Name; }
        public string Name { get; set; }
    }
}
