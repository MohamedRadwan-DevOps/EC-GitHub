CREATE TABLE [dbo].[Users] (
    [UserId]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Email] NVARCHAR (100)  NOT NULL,
    [Phone]    NVARCHAR (15)   NOT NULL,
    [Address]       NVARCHAR(50) NOT NULL,
    [PostCode] NVARCHAR(50) NULL, 
    [Country] NVARCHAR(50) NULL, 
    [State] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(15) NULL, 
    [Password] NVARCHAR(15) NULL, 
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

