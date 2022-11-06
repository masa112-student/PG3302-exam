using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void MovePlayer(IGameBoard.MoveDir dir) {
            Trace.WriteLine($"Moving player to the {dir}");
        }

        public void PlayerAttack() {
            throw new NotImplementedException();
        }
    }
}
