namespace Demo01.Entities
{
    public class GamePlayer
    {
        public int PlayerId { get; set; }
        public int GameId { get; set;}
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}