using Codeflyers.EC.Domain.Concrete;
using Codeflyers.EC.Services.Concrete;
using Codeflyers.EC.Services.MSIntTest.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingConfUtilities;

namespace Codeflyers.EC.Services.MSIntTest.Tests
{
    [TestClass]
    public class UserServicesIntTest
    {
        private static DevUtilities _devUtilities;
        private static string _connectionString ;
       
        [ClassInitialize]
        public static void Initilize(TestContext testContext)
        {
            if (_devUtilities == null)
            {
                _devUtilities = new DevUtilities();

            }
            if (_connectionString == null)
            {
                _connectionString = _devUtilities.GetConnectionStringFromConfig("EfDbContext");
            } 
        }

        [TestMethod]
        public void MS_Int_AuthenticateUser_ValidCredentials_ReturnTrue()
        {

            //Initialize
            _devUtilities.ExecuteSqlScriptFile(_connectionString, TestUtilities.ProjectDirectory() + "\\SQLScripts\\Int_AuthenticateUser_WithValidCredentials_ReturnTrue.sql");


            //Arrange
            var targetObject = new UserServices(new EfUserRepository());
            var userName = "mradwan";
            var password = "koko";

            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.IsTrue(result);

            //Cleaning
            _devUtilities.DeleteTableDataAndRessedId("Users", _connectionString);
        }
        [TestMethod]
        public void MS_Int_AuthenticateUser_ValidUserNameAndInvalidPassword_ReturnFalse()
        {
            //Initialize
            _devUtilities.ExecuteSqlScriptFile(_connectionString, TestUtilities.ProjectDirectory() + "\\SQLScripts\\Int_AuthenticateUser_WithValidCredentials_ReturnTrue.sql");

            //Arrange
            var targetObject = new UserServices(new EfUserRepository());
            var userName = "mradwan";
            var password = "kkkk";

            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.IsFalse(result);

            //Cleaning
            _devUtilities.DeleteTableDataAndRessedId("Users", _connectionString);
        }
    }
}
