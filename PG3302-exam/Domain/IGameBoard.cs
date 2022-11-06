using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes;

namespace Domain
{
    public interface IGameBoard
    {
        public int Score { get; set; }
        public bool IsGameActive { get; set; }
        public void Update();
        public List<Sprite> GetSprites();
    }
}
