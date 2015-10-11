using System.Linq;
using Codeflyers.EC.Domain.Abstract;
using Codeflyers.EC.Services.Concrete;
using Codeflyers.EC.Services.MSUTest.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Codeflyers.EC.Services.MSUTest.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    [TestClass]
    public class UserServicesUTest
    {
        [TestMethod]
        public void MS_U_AuthenticateUser_ValidCredentials_ReturnTrue()
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
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MS_U_AuthenticateUser_InvalidUserName_ReturnFalse()
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
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MS_U_AuthenticateUser_ValidUserNameAndInvalidPassword_ReturnFalse()
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
            Assert.IsFalse(result);
        }
}
}
