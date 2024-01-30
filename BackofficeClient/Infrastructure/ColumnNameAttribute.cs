namespace BackofficeClient.Infrastructure;

public class Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute : Attribute
    {
        public ColumnNameAttribute(string Name) => this.Name = Name;
        public string Name { get; set; }
    }
}
