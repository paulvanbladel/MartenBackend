using Autofac;
using Autofac.Extras.Moq;
using MartenBackend.Bootstrapping;
using MartenBackend.Repository.Contract;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MartenBackend.BusinessEngine.Test
{
    public class SampleBusinessEngineUnitTests
    {

        [Fact]
        public void Test1()
        {

            IContainer container = Bootstrap.GetContainerForBusinessEngineUnitTest();

            using (var scope = container.BeginLifetimeScope())
            {
                using (var mock = AutoMock.GetLoose())
                {
                    // Arrange - configure the mock
                    mock.Mock<ICustomerRepository>().Setup(x => x.CountAsync())
                        .Returns(Task.FromResult<int>(5));
                    var sut = mock.Create<SampleBusinessEngine>();

                    // Act
                    var actual = sut.ADataMiningOperation().Result;

                    // Assert - assert on the mock
                    mock.Mock<ICustomerRepository>().Verify(x => x.CountAsync());
                    Assert.Equal(5 * Math.PI, actual);
                }

            }
        }
    }
}
