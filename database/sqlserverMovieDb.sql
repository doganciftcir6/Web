USE [MovieDb]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Macera')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Romantik')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Bilim Kurgu')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Korku')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([Id], [Name], [Surname]) VALUES (1, N'Yönetmen name 1', N'Yönetmen surname 1')
INSERT [dbo].[Director] ([Id], [Name], [Surname]) VALUES (2, N'Yönetmen name 2', N'Yönetmen surname 2')
SET IDENTITY_INSERT [dbo].[Director] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([Id], [Name], [Description], [Duration], [ImageUrl], [Trailer], [DirectorId]) VALUES (1, N'Film 1', N'Film 1 açıklama', N'120', N'1.jpg', N'1.mp4                                        ', 1)
INSERT [dbo].[Movie] ([Id], [Name], [Description], [Duration], [ImageUrl], [Trailer], [DirectorId]) VALUES (3, N'Film 2', N'Film 2 açıklama', N'90', N'2.jpg', N'2.mp4                                        ', 2)
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
INSERT [dbo].[Movie_Catery] ([MovieId], [CategoryId]) VALUES (1, 1)
INSERT [dbo].[Movie_Catery] ([MovieId], [CategoryId]) VALUES (1, 3)
INSERT [dbo].[Movie_Catery] ([MovieId], [CategoryId]) VALUES (3, 1)
GO
SET IDENTITY_INSERT [dbo].[Star] ON 

INSERT [dbo].[Star] ([Id], [Name], [Surname]) VALUES (1, N'Oyuncu 1', N'oyuncu 1 sıurname')
INSERT [dbo].[Star] ([Id], [Name], [Surname]) VALUES (2, N'Oyuncu 2', N'oyuncu 2 surname')
SET IDENTITY_INSERT [dbo].[Star] OFF
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (1, 1)
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (1, 2)
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (3, 1)
GO
INSERT [dbo].[MovieDetail] ([Id], [Country], [Publish_date]) VALUES (1, N'Türkiye', CAST(N'2022-10-04T12:42:08.320' AS DateTime))
INSERT [dbo].[MovieDetail] ([Id], [Country], [Publish_date]) VALUES (3, N'Türkiye', CAST(N'2022-10-04T12:42:37.740' AS DateTime))
GO
