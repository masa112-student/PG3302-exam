using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serialization
{

    internal class Serializer
    {
        string fileName = "highScores.json";

        public List<Score> LoadHighScores() {
            if(!File.Exists(fileName))
                return new List<Score>();

            string jsonScores = File.ReadAllText(fileName, Encoding.UTF8);
            if (jsonScores == null || jsonScores.Equals(""))
                return new List<Score>();

            List<Score>? data = JsonSerializer.Deserialize<List<Score>>(jsonScores);

            return data ?? new List<Score>();
        }

        public void SaveScore(List<Score> scores) {
            string jsonScores = JsonSerializer.Serialize(scores);

            File.WriteAllText(fileName, jsonScores);
        }
    }
}
