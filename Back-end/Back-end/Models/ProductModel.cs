namespace Back_end.Models;
public class ProductModel
{
    public int id { get; set; }
    public string title { get; set; }
    public string genre { get; set; }
    public float rating { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public string image_path { get; set; }
    public int stock { get; set; }
    public string product_type { get; set; }
}