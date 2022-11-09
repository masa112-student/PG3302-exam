namespace Serialization
{
    public interface IPersistance
    {
        public HighScores LoadHighScores();
        public void SaveHighScores(HighScores highScores);

    }
}
