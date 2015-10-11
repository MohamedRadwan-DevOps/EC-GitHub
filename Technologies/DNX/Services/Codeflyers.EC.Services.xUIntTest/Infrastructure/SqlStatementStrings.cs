namespace Codeflyers.EC.Services.xUIntTest.Infrastructure
{
    public class SqlStatementStrings
    {
        //public const string IntAuthenticateUserWithValidCredentialsReturnTrue = @"
        //    use [DB_Name]
        //    SET IDENTITY_INSERT[dbo].[Users]
        //    ON
        //    INSERT[dbo].[Users] ([UserId], [Name], [Email], [UserName], [Password],[Phone],[Address]) VALUES(1, N'Mohamed Radwan', N'mradwan@commentor.dk', N'mradwan', N'koko', N'122334444', N'Herlev')
        //    SET IDENTITY_INSERT[dbo].[Users]
        //    OFF";

        public const string IntAuthenticateUserWithValidCredentialsReturnTrue =
            @"INSERT[dbo].[Users] ([Name], [Email], [UserName], [Password],[Phone],[Address]) VALUES( N'Mohamed Radwan', N'mradwan@commentor.dk', N'mradwan', N'koko', N'122334444', N'Herlev')";

    }
}
