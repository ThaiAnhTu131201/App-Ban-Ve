USE [master]
GO
/****** Object:  Database [AppBanVePhim3009]    Script Date: 14/10/2021 5:10:45 PM ******/
CREATE DATABASE [AppBanVePhim3009]
 
GO
USE [AppBanVePhim3009]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 14/10/2021 5:10:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaChiTietHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[MaGhe] [int] NOT NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ghe]    Script Date: 14/10/2021 5:10:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ghe](
	[MaGhe] [int] IDENTITY(1,1) NOT NULL,
	[SoGhe] [int] NOT NULL,
	[MaHangGhe] [int] NOT NULL,
 CONSTRAINT [PK_Ghe] PRIMARY KEY CLUSTERED 
(
	[MaGhe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangGhe]    Script Date: 14/10/2021 5:10:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangGhe](
	[MaHangGhe] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nchar](1) NOT NULL,
	[GiaTien] [float] NOT NULL,
 CONSTRAINT [PK_HangGhe] PRIMARY KEY CLUSTERED 
(
	[MaHangGhe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 14/10/2021 5:10:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayMua] [datetime] NOT NULL,
	[TongTien] [float] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ghe] ON 
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (2, 2, 1)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (3, 3, 1)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (4, 4, 1)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (5, 5, 1)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (6, 6, 2)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (7, 7, 2)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (8, 8, 2)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (9, 9, 2)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (10, 10, 2)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (11, 11, 3)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (12, 12, 3)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (13, 13, 3)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (14, 14, 3)
GO
INSERT [dbo].[Ghe] ([MaGhe], [SoGhe], [MaHangGhe]) VALUES (15, 15, 3)
GO
SET IDENTITY_INSERT [dbo].[Ghe] OFF
GO
SET IDENTITY_INSERT [dbo].[HangGhe] ON 
GO
INSERT [dbo].[HangGhe] ([MaHangGhe], [Ten], [GiaTien]) VALUES (1, N'a', 5000)
GO
INSERT [dbo].[HangGhe] ([MaHangGhe], [Ten], [GiaTien]) VALUES (2, N'b', 6500)
GO
INSERT [dbo].[HangGhe] ([MaHangGhe], [Ten], [GiaTien]) VALUES (3, N'c', 8000)
GO
SET IDENTITY_INSERT [dbo].[HangGhe] OFF
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_Ghe] FOREIGN KEY([MaGhe])
REFERENCES [dbo].[Ghe] ([MaGhe])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_Ghe]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_HoaDon]
GO
ALTER TABLE [dbo].[Ghe]  WITH CHECK ADD  CONSTRAINT [FK_Ghe_HangGhe] FOREIGN KEY([MaHangGhe])
REFERENCES [dbo].[HangGhe] ([MaHangGhe])
GO
ALTER TABLE [dbo].[Ghe] CHECK CONSTRAINT [FK_Ghe_HangGhe]
GO
USE [master]
GO
ALTER DATABASE [AppBanVePhim3009] SET  READ_WRITE 
GO
