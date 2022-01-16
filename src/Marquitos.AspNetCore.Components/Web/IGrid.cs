namespace Marquitos.AspNetCore.Components.Web
{
    public interface IGrid
    {
        //void AddItem(IGridItem gridItem);
        //void RemoveItem(IGridItem gridItem);
        void SetColumnDefinitions(ColumnDefinitions columnDefinitions);
        void SetRowDefinitions(RowDefinitions rowDefinitions);
    }
}
