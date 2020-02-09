namespace Boggle.Core
{
    public class GameWinner
    {
        public string Name { get; }
        public PlayerScore Score { get; }

        public GameWinner(string name, PlayerScore score)
        {
            Name = name;
            Score = score;
        }
    }
}