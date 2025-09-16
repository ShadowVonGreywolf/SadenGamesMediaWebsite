namespace Back_end.Models;

public class Game : Product
{
    public int game_id { get; set; }
    public string platform { get; set; }
    public string studio { get; set; }
}