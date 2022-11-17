using System.Collections;

namespace Serialization
{
    public class HighScores : ICollection<Score>
    {
        private List<Score> _scores;

        public HighScores(IEnumerable<Score> scores) {
            _scores = new List<Score>(scores);
            _scores.Sort();
        }

        public int Count => _scores.Count;

        public bool IsReadOnly => false;

        public void Add(Score newScore) {
            if (_scores.Contains(newScore)) {
                var oldScore = _scores.Find(s => s == newScore);
                if (newScore.Points > oldScore.Points) {
                    _scores.Remove(oldScore);
                    _scores.Add(newScore);
                }
            }
            else {
                _scores.Add(newScore);
            }

            _scores.Sort();
        }
        public bool Contains(Score item) => _scores.Contains(item);
        public bool Remove(Score item) => _scores.Remove(item);

        public void Clear() {
            _scores.Clear();
        }
        public void CopyTo(Score[] array, int arrayIndex) {
            _scores.CopyTo(array, arrayIndex);
        }
        public IEnumerator<Score> GetEnumerator() => _scores.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _scores.GetEnumerator();

        public Score this[int index] => _scores[index]; 
    }

    public struct Score: IComparable<Score>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Score(string name, int points) {
            Name = name;
            Points = points;
        }


        public override bool Equals(object? obj) {
            if (obj is not Score) return false;
            
            Score score = (Score)obj;
            return score.Name.Equals(Name);
        }

        public int CompareTo(Score other) {
            return other.Points - Points;
        }
        public static bool operator ==(Score a, Score b) => a.Equals(b);
        public static bool operator !=(Score a, Score b) => !(a == b);

        public static bool operator <(Score a, Score b) => a.Points < b.Points;
        public static bool operator >(Score a, Score b) => a.Points > b.Points;

    }
}
