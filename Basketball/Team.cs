using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            this.players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public int Count => players.Count;
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.players.Add(player);
            this.OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Name == name)
                {
                    this.players.RemoveAt(i);
                    this.OpenPositions++;
                    return true;
                }
            }
            
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int counter = 0;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.players[i].Position == position)
                {
                    counter++;
                    this.OpenPositions++;
                    this.players.RemoveAt(i);
                }
            }

            return counter;
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player in this.players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }

            return default;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayers = new List<Player>();

            foreach (var player in this.players)
            {
                if (player.Games >= games)
                {
                    awardedPlayers.Add(player);
                }
            }

            return awardedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in this.players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
