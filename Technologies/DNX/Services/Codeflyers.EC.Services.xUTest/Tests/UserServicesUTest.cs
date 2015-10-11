using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Services.Concrete;
using Codeflyers.EC.Services.xUTest.Infrastructure;
using Moq;
using Xunit;

namespace Codeflyers.EC.Services.xUTest.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class UserServicesUTest
    {
        [Fact]
        public void xU_U_AuthenticateUser_ValidCredentials_ReturnTrue()
        {
            //Arrange
            var mock = new Mock<IUserRepository>();
            mock.Setup(m => m.GetAll()).Returns(TestPreparation.CreateUsers().AsQueryable());
            var targetObject = new UserServices(mock.Object);
            var userName = "mradwan";
            var password = "koko";


            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void xU_U_AuthenticateUser_InvalidUserName_ReturnFalse()
        {
            //Arrange
            var mock = new Mock<IUserRepository>();
            mock.Setup(m => m.GetAll()).Returns(TestPreparation.CreateUsers().AsQueryable());
            var targetObject = new UserServices(mock.Object);
            var userName = "hello";
            var password = "kkkk";


            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.False(result);
        }
        [Fact]
        public void xU_U_AuthenticateUser_ValidUserNameAndInvalidPassword_ReturnFalse()
        {
            //Arrange
            var mock = new Mock<IUserRepository>();
            mock.Setup(m => m.GetAll()).Returns(TestPreparation.CreateUsers().AsQueryable());
            var targetObject = new UserServices(mock.Object);
            var userName = "mradwan";
            var password = "kkkk";


            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.False(result);
        }
}
}
