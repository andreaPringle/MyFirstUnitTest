using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;
namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;  IDNS _dNS;
        
        public NetworkServiceTests()
        {
            _dNS = A.Fake<IDNS>();
            //
            _pingService = new NetworkService(_dNS);
        }
        [Fact]
        public void NetworkService_SendPing_ReturnSTring()
        {
            //Arrange - variables, classes, mocks
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
            //Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
        [Theory]
        [InlineData(1.1, 2.2, 3.3)]
        [InlineData(2, 4, 6)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange 
            var pingService = new NetworkService(_dNS);

            //Act
           var result = _pingService.PingTimeout(a, b);
            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-100, 0);
        }

         [Fact]
         public void NetworkService_LastPingDate_ReturnDate()
         {
             var result = _pingService.LastPingDate();

             result.Should().BeAfter(2.August(2015));
             result.Should().BeBefore(2.August(2030));  
         }


        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
           
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 3
            };

            var result = _pingService.GetPingOptions();
           
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(3);
        }

        [Fact]
        public void NetworkService_MostRecentsPings_ReturnObject()
        {

            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 3
            };

            var result = _pingService.MostRecentPings();

            result.Should().BeOfType<PingOptions[]>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }

}


