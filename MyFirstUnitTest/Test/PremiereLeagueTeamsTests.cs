using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest.Test
{
    public static class PremiereLeagueTeamsTests
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void PremiereLeagueTeams_ReturnTopThreePremiereleaguePlaces_ReturnString()
        {
            try
            {
                //Arrange - Get your variables, classes, functions, etc
                int place = 2;
                PremiereLeagueTeams premiereLeagueTeams = new PremiereLeagueTeams();

                //Act - Execute the function
                string result = premiereLeagueTeams.TwentyTwentyFourToTwentyTwentyFiveSeason(place);

                //Assert - Whatever is returned is it what you want
                if (result == "Liverpool" || result == "Man City" || result == "Aresenal")
                {
                    Console.WriteLine("PASSED: PremiereLeagueTeams.ReturnTopThreePremiereleaguePlaces.ReturnString");
                }
                else {
                    Console.WriteLine("FAILED: PremiereLeagueTeams.ReturnTopThreePremiereleaguePlaces.ReturnString");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
