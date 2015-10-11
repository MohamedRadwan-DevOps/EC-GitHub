CREATE LOGIN [ECLogin] WITH PASSWORD = '123456', DEFAULT_DATABASE=[Codeflyers.EC.DB], DEFAULT_LANGUAGE=us_english, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO




--exec sp_change_user_login '[RadwanLogin]', 'user', 'login'


--No need to be DB Creator since this account will be used for the web application but not the build
--EXEC sp_addsrvrolemember 'RadwanLogin', 'dbcreator';
--GO

--If we need to delete Login we need to make sure it is not has opened session or we need to kill it
--SELECT * FROM sys.dm_exec_sessions WHERE login_name='ALMLogin'
--Kill 52

--Assign sysadmin to our Login
--EXEC sys.sp_addsrvrolemember @loginame = N'ALMLogin', @rolename = N'sysadmin'
--GO
