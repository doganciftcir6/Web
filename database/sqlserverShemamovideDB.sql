USE [MovieDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4.10.2022 12:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Duration] [nvarchar](10) NULL,
	[ImageUrl] [nvarchar](45) NULL,
	[Trailer] [nchar](45) NULL,
	[DirectorId] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Catery]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Catery](
	[MovieId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Movie_Catery] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Star]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Star](
	[MovieId] [int] NOT NULL,
	[StarId] [int] NOT NULL,
 CONSTRAINT [PK_Movie_Star] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[StarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieDetail]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieDetail](
	[Id] [int] NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Publish_date] [datetime] NOT NULL,
 CONSTRAINT [PK_MovieDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Star]    Script Date: 4.10.2022 12:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Star](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Star] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (1, 1)
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (1, 2)
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (3, 1)
GO
INSERT [dbo].[MovieDetail] ([Id], [Country], [Publish_date]) VALUES (1, N'Türkiye', CAST(N'2022-10-04T12:42:08.320' AS DateTime))
INSERT [dbo].[MovieDetail] ([Id], [Country], [Publish_date]) VALUES (3, N'Türkiye', CAST(N'2022-10-04T12:42:37.740' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Star] ON 

INSERT [dbo].[Star] ([Id], [Name], [Surname]) VALUES (1, N'Oyuncu 1', N'oyuncu 1 sıurname')
INSERT [dbo].[Star] ([Id], [Name], [Surname]) VALUES (2, N'Oyuncu 2', N'oyuncu 2 surname')
SET IDENTITY_INSERT [dbo].[Star] OFF
GO
ALTER TABLE [dbo].[MovieDetail] ADD  CONSTRAINT [DF_MovieDetail_Publish_date]  DEFAULT (getdate()) FOR [Publish_date]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Director] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Director] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Director]
GO
ALTER TABLE [dbo].[Movie_Catery]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Catery_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Movie_Catery] CHECK CONSTRAINT [FK_Movie_Catery_Categories]
GO
ALTER TABLE [dbo].[Movie_Catery]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Catery_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Movie_Catery] CHECK CONSTRAINT [FK_Movie_Catery_Movie]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Star_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK_Movie_Star_Movie]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Star_Star] FOREIGN KEY([StarId])
REFERENCES [dbo].[Star] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK_Movie_Star_Star]
GO
ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_Movie] FOREIGN KEY([Id])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_Movie]
GO
