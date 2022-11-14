using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Serialization
{

    public class JsonPersistance : IPersistance
    {
        private string _fileName;

        public JsonPersistance(string filename) {
            _fileName = filename;
        }

        public HighScores LoadHighScores() {
            if (!File.Exists(_fileName))
                return new(new List<Score>());

            string jsonScores = File.ReadAllText(_fileName, Encoding.UTF8);
            if (jsonScores == null || jsonScores.Equals(""))
                return new(new List<Score>());

            List<Score>? data = JsonSerializer.Deserialize<List<Score>>(jsonScores);
            HighScores scores = new HighScores(data ?? new List<Score>());
            return scores;
        }

        public void SaveHighScores(HighScores highScores) {
            string jsonScores = JsonSerializer.Serialize(highScores.Scores);
            try {
                File.WriteAllText(_fileName, jsonScores);
            }
            catch (UnauthorizedAccessException) {
                Trace.TraceError("The application does not have access to the highscore file");
            }
        }
    }
}
