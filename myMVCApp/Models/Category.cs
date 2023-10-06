namespace myMVCApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<int>? ProductIds { get; set; }


    }
}
