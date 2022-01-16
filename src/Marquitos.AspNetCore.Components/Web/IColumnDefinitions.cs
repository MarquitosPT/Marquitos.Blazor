namespace Marquitos.AspNetCore.Components.Web
{
    public interface IColumnDefinitions
    {
        void AddColumnDefinition(ColumnDefinition definition);
        void RemoveColumnDefinition(ColumnDefinition definition);
    }
}
