using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest
{
    public class PremiereLeagueTeams
    {
        public string TwentyTwentyFourToTwentyTwentyFiveSeason(int place)
        {
            if (place == 1)
            {
                return "Liverpool";
            }
            else if (place == 2)
            {
                return "Man City";
            }
            else if (place == 3) {
                return "Arsenal";
            }
            else
            {
                return "Aston Villa";
            }
            
        }
    }
}
