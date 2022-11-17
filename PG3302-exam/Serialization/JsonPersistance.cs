using System.Diagnostics;
using System.IO.Abstractions;
using System.Text;

using Newtonsoft.Json;

namespace Serialization
{

    public class JsonPersistance : IPersistance
    {
        private string _fileName;
        private readonly IFileSystem _fileSystem;

        public JsonPersistance(string filename) : this(filename, new FileSystem()) { }

        public JsonPersistance(string filename, IFileSystem fileSystem) {
            _fileName = filename;
            _fileSystem = fileSystem;
        }

        public HighScores LoadHighScores() {
            if (!_fileSystem.File.Exists(_fileName))
                return new(new List<Score>());

            string jsonScores = _fileSystem.File.ReadAllText(_fileName, Encoding.UTF8);
            if (string.IsNullOrEmpty(jsonScores))
                return new(new List<Score>());

            List<Score>? data = JsonConvert.DeserializeObject<List<Score>>(jsonScores);
            HighScores scores = new HighScores(data ?? new List<Score>());

            return scores;
        }

        public void SaveHighScores(HighScores highScores) {
            string jsonScores = JsonConvert.SerializeObject(highScores);
            try {
                _fileSystem.File.WriteAllText(_fileName, jsonScores);
            }
            catch (UnauthorizedAccessException) {
                Trace.TraceError("The application does not have access to the highscore file");
            }
        }
    }
}
