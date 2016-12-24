using MartenBackend.Repository.Contract;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace MartenBackend.BusinessEngine.Test
{
    public class SampleBusinessEngineUnitTests
    {

        [Fact]
        public void Test1()
        {
            var mock = new Mock<ICustomerRepository>();
            // Arrange - configure the mock
            mock.Setup(x => x.CountAsync())
                .Returns(Task.FromResult<int>(5));
            var sut = new SampleBusinessEngine(mock.Object);

            // Act
            var actual = sut.ADataMiningOperation().Result;

            // Assert - assert on the mock
            mock.Verify(x => x.CountAsync());
            Assert.Equal(5 * Math.PI, actual);
            // }

        }
    }
}
