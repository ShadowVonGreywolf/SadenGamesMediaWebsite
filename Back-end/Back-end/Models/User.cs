namespace Back_end.Models;

public class User
{
    public int user_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }
    public string created_at { get; set; }
    public string image_path { get; set; }
    
}