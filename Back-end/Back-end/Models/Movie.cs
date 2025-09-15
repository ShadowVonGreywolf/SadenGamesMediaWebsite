namespace Back_end.Models;

public class Movie : Product
{
    public int movie_id { get; set; }
    public string director { get; set; }
    public int duration { get; set; }
}