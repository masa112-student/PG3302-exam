using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public interface IPersistance
    {
        public HighScores LoadHighScores();
        public void SaveHighScores(HighScores highScores);

    }
}
