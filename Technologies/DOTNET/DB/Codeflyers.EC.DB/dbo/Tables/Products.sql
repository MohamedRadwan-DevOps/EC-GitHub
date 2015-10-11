CREATE TABLE [dbo].[Products] (
    [ProductId]      INT             IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (100)  NOT NULL,
    [Title] NVARCHAR (200)  NOT NULL,
    [Description]    NVARCHAR (500)   NOT NULL,
    [Category]       NVARCHAR(50) NOT NULL,
    [Brand]       NVARCHAR(50) NOT NULL,
    [RewardPoints]       INT NOT NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    [ImageData] VARBINARY(MAX) NULL, 
    [ImageMimeType] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

