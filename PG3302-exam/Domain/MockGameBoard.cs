using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;

namespace Domain
{
    public class MockGameBoard : IGameBoard
    {
        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        public MockGameBoard() {
            IsGameActive = true;
        }

        public List<Sprite> GetSprites() {
            return new List<Sprite>();
        }

        public void Update() {
            
        }
    }
}
