﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Serialization
{
    internal class HighScores {
        private List<Score> _scores;
        public List<Score> Scores { get { return _scores; } }

        public HighScores(List<Score> scores) {
            _scores = scores;
        }
        public void UpdateScore(Score newScore) {
            if (_scores.Contains(newScore)) {
                var a = _scores.Find(s => s.Equals(newScore));
                if (a != null)
                    if (newScore.Points > a.Points)
                        a.Points = newScore.Points;
            }
            else {
                _scores.Add(newScore);
            }
        }

        public bool DeleteScore(string name) {
            Score? scoreToDelete = _scores.Find(score => score.Name.Equals(name));
            if (scoreToDelete == null) return false;
            return _scores.Remove(scoreToDelete);   
        }
    }
    internal class Score
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Score(string name, int points) {
            Name = name;
            Points = points;
        }


        public override bool Equals(object? obj) {
            if (obj == null) return false;
            if(obj.GetType() != typeof(Score)) return false;
            Score score = (Score)obj;
            if (score == this) return true;
            return score.Name.Equals(Name);
        }

    }
}
