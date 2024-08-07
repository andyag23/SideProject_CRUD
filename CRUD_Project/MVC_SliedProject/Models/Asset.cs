namespace MVC_SliedProject.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }

    public class AssetViewModel
    {
        public List<Asset> Assets { get; set; }
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }

}
