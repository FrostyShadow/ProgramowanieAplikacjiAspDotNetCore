using AspDotNetAppsProgramming.Entities;

namespace AspDotNetAppsProgramming.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public static class ItemModelExtensions
    {
        public static ItemEntity ToEntity(this ItemModel model) => new ItemEntity
        {
            Name = model.Name,
            Description = model.Description,
            IsVisible = model.IsVisible
        };
    }
}