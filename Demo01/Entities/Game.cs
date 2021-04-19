using System.Collections.Generic;

namespace Demo01.Entities
{
    public class Game
    {
        // public Game(){
        //     GamePlayers = new List<GamePlayer>();
        // }
        public int Id { get; set; }
        public int Round { get; set; }
        public System.DateTimeOffset? StartTime { get; set; }
        public List<GamePlayer> GamePlayers { get; set; }
    }
}