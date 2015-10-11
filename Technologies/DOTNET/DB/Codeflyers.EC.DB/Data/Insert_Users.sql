USE [Codeflyers.EC.DB]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserId], [Name], [Email], [Phone], [Address], [PostCode], [Country], [State], [UserName], [Password]) VALUES (1, N'Mohamed', N'mradwan@codeflyers.com', N'12345678', N'Herlev', N'2731', N'Denmark', N'Herlev', N'mra', N'koko')
GO
INSERT [dbo].[Users] ([UserId], [Name], [Email], [Phone], [Address], [PostCode], [Country], [State], [UserName], [Password]) VALUES (2, N'Rania', N'Rania@codeflyers.com', N'33445533', N'Herlev', N'2731', N'Denmark', N'Herlev', N'rania', N'koko')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO