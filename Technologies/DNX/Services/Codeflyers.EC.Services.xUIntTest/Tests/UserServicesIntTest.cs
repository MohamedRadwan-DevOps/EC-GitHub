using Codeflyers.EC.Domain.Concrete;
using Codeflyers.EC.Services.Concrete;
using Codeflyers.EC.Services.xUIntTest.Infrastructure;
using TestingConfUtilities;
using TestingConfUtilities.Classes;
using Xunit;

namespace Codeflyers.EC.Services.xUIntTest.Tests
{
    public class UserServicesIntTest
    {
        private DevUtilities _devUtilities;
        private string _connectionString ;
        public void Initilize()
        {
            if (_devUtilities == null)
            {
                _devUtilities = new DevUtilities();
                
            }
            if (_connectionString == null)
            {
                _connectionString = Config.ConnectionString;
            }
        }

        [Fact]
        public void xU_Int_AuthenticateUser_ValidCredentials_ReturnTrue()
        {

            //Initialize
            Initilize();
            _devUtilities.ExecuteSqlScriptContent(_connectionString, SqlStatementStrings.IntAuthenticateUserWithValidCredentialsReturnTrue);
            
            //Arrange
            var targetObject = new UserServices(new EfUserRepository());
            var userName = "mradwan";
            var password = "koko";

            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.True(result);

            //Cleaning
            _devUtilities.DeleteTableDataAndRessedId("Users", _connectionString);
        }
        [Fact]
        public void xU_Int_AuthenticateUser_ValidUserNameAndInvalidPassword_ReturnFalse()
        {
            //Initialize
            Initilize();
            _devUtilities.ExecuteSqlScriptContent(_connectionString, SqlStatementStrings.IntAuthenticateUserWithValidCredentialsReturnTrue);

            //Arrange
            var targetObject = new UserServices(new EfUserRepository());
            var userName = "mradwan";
            var password = "kkkk";

            //Act
            var result = targetObject.AuthenticateUser(userName, password);

            //Assert
            Assert.False(result);

            //Cleaning
            _devUtilities.DeleteTableDataAndRessedId("Users", _connectionString);
        }
    }
}
