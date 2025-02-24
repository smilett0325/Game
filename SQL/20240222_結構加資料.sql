USE [Rizz]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2024/2/22 上午 10:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Identity] [int] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BanGames]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanGames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Content] [nvarchar](200) NOT NULL,
	[Date] [datetime] NOT NULL,
	[AdminId] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_BanGames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BanMembers]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Member1Id] [int] NOT NULL,
	[Member2Id] [int] NOT NULL,
	[Content] [nvarchar](200) NOT NULL,
	[Date] [date] NOT NULL,
	[AdminId] [int] NULL,
	[StatusTime] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_BanMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetails]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[FinalPayment] [decimal](18, 2) NOT NULL,
	[BounsPoint] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[DiscountId] [int] NULL,
 CONSTRAINT [PK_BillDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillDetailId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_BillItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boards]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Boards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BonusItems]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BonusProducts]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[URL] [nvarchar](3000) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BonusProductTypes]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collections]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collections](
	[Id] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[MemberTagId] [int] NULL,
	[BillDetailId] [int] NOT NULL,
 CONSTRAINT [PK_Collections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Comment] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Developers]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[EncryptedPassword] [nvarchar](1000) NOT NULL,
	[EMail] [nvarchar](256) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[BanTime] [datetime] NULL,
	[IsConfirmed] [bit] NOT NULL,
	[ConfirmCode] [nvarchar](256) NULL,
 CONSTRAINT [PK_Developers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountItem]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiscountId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
 CONSTRAINT [PK_DiscountItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Percent] [int] NOT NULL,
	[DiscountType] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[Desciption] [nvarchar](500) NULL,
	[DeveloperId] [int] NULL,
 CONSTRAINT [PK_CustomerDiscounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DLCs]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DLCs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[AttachedGameId] [int] NOT NULL,
 CONSTRAINT [PK_DLCs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friends]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friends](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Member1Id] [int] NOT NULL,
	[Member2Id] [int] NOT NULL,
	[Relationship] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Friends] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Introduction] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[Price] [int] NOT NULL,
	[Cover] [nvarchar](200) NOT NULL,
	[DeveloperId] [int] NOT NULL,
	[MaxPercent] [int] NULL,
	[Video] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameTags]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_GameTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[DisplayImage] [nvarchar](3000) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[AvatarURL] [nvarchar](200) NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[BanTime] [datetime] NULL,
	[Bonus] [int] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[Birthday] [datetime] NULL,
	[NickName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberTags]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberTags](
	[Id] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MemberTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BoardId] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](200) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BoardId] [int] NOT NULL,
	[MessageId] [int] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishListes]    Script Date: 2024/2/22 上午 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishListes](
	[Id] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
 CONSTRAINT [PK_WishListes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [Account], [Password], [Identity]) VALUES (1, N'123456', N'123456', 1)
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[BillDetails] ON 

INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (2, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-01-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (9, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-03-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (11, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2024-03-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (12, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2024-01-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (13, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2024-02-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (16, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2022-04-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (17, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-06-07T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[BillDetails] ([Id], [MemberId], [FinalPayment], [BounsPoint], [TransactionDate], [DiscountId]) VALUES (18, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-05-07T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BillDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[BillItems] ON 

INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (1, 2, 11, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (2, 2, 12, CAST(39.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (4, 11, 38, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (5, 11, 39, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (6, 17, 35, CAST(46.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (7, 18, 11, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (8, 16, 35, CAST(105.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (9, 13, 40, CAST(49.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (10, 16, 44, CAST(67.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (11, 11, 50, CAST(76.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (12, 18, 53, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (13, 17, 44, CAST(63.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (14, 16, 50, CAST(43.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (15, 16, 39, CAST(79.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (16, 12, 52, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (18, 17, 41, CAST(45.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (19, 2, 8, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (20, 2, 50, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (21, 11, 50, CAST(89.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (22, 13, 43, CAST(58.00 AS Decimal(18, 2)))
INSERT [dbo].[BillItems] ([Id], [BillDetailId], [GameId], [Price]) VALUES (23, 11, 8, CAST(67.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[BillItems] OFF
GO
SET IDENTITY_INSERT [dbo].[BonusProducts] ON 

INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (13, 2, 100, N'CatImage.gif', N'CatImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (14, 2, 100, N'CoinImage.gif', N'CoinImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (15, 2, 150, N'DiceImage.gif', N'DiceImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (16, 2, 150, N'VRImage.gif', N'VRImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (17, 2, 200, N'PortalgunImage.gif', N'PortalgunImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (18, 2, 200, N'DrakSoulsImage.gif', N'DrakSoulsImage')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (19, 4, 300, N'ApexFrame.png', N'ApexFrame')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (20, 4, 300, N'CatFrame1.png', N'CatFrame1')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (21, 4, 300, N'CatFrame2.png', N'CatFrame2')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (22, 4, 250, N'SpeedLineFrame.png', N'SpeedLineFrame')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (23, 4, 250, N'CatFrame2.png', N'WhiteFrame')
INSERT [dbo].[BonusProducts] ([Id], [ProductTypeId], [Price], [URL], [Name]) VALUES (24, 4, 300, N'TVFrame.png', N'TVFrame')
SET IDENTITY_INSERT [dbo].[BonusProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[BonusProductTypes] ON 

INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (1, 1, N'靜態頭像')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (2, 2, N'動態頭像')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (3, 3, N'靜態外框')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (4, 4, N'動態外框')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (5, 5, N'靜態貼圖')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (6, 6, N'動態貼圖')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (7, 7, N'靜態主題')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (8, 8, N'動態主題')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (9, 1, N'靜態頭像')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (10, 2, N'動態頭像')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (11, 3, N'靜態外框')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (12, 4, N'動態外框')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (13, 5, N'靜態貼圖')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (14, 6, N'動態貼圖')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (15, 7, N'靜態主題')
INSERT [dbo].[BonusProductTypes] ([Id], [Type], [Name]) VALUES (16, 8, N'動態主題')
SET IDENTITY_INSERT [dbo].[BonusProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Developers] ON 

INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (6, N'John Doe', N'john_doe_dev', N'hashed_password_1', N'john.doe@email.com', N'1234567890', CAST(N'2024-02-06T00:46:29.420' AS DateTime), 1, N'confirm_code_1')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (7, N'Alice Smith', N'alice_smith_dev', N'hashed_password_2', N'alice.smith@email.com', N'9876543210', NULL, 1, N'confirm_code_2')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (8, N'Bob Johnson', N'bob_johnson_dev', N'hashed_password_3', N'bob.johnson@email.com', N'5556667777', NULL, 1, N'confirm_code_3')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (9, N'Eva White', N'eva_white_dev', N'hashed_password_4', N'eva.white@email.com', N'1112223333', NULL, 1, N'confirm_code_4')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (10, N'Michael Brown', N'michael_brown_dev', N'hashed_password_5', N'michael.brown@email.com', N'9990001111', NULL, 1, N'confirm_code_5')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (11, N'Sophia Taylor', N'sophia_taylor_dev', N'hashed_password_6', N'sophia.taylor@email.com', N'2223334444', NULL, 1, N'confirm_code_6')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (12, N'William Miller', N'william_miller_dev', N'hashed_password_7', N'william.miller@email.com', N'7778889999', NULL, 1, N'confirm_code_7')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (13, N'Olivia Davis', N'123456', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'olivia.davis@email.com', N'4445556666', NULL, 1, N'confirm_code_8')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (14, N'James Wilson', N'james_wilson_dev', N'hashed_password_9', N'james.wilson@email.com', N'1112223333', NULL, 1, N'confirm_code_9')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (15, N'Emma Moore', N'emma_moore_dev', N'hashed_password_10', N'emma.moore@email.com', N'8889990000', NULL, 1, N'confirm_code_10')
INSERT [dbo].[Developers] ([Id], [Name], [Account], [EncryptedPassword], [EMail], [PhoneNumber], [BanTime], [IsConfirmed], [ConfirmCode]) VALUES (16, N'Jojo1', N'jjjjjj', N'4CC8F4D609B717356701C57A03E737E5AC8FE885DA8C7163D3DE47E01849C635', N'cwpeng.irene@gmail.com', N'0912345678', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Developers] OFF
GO
SET IDENTITY_INSERT [dbo].[DiscountItem] ON 

INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (10, 3, 36)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (11, 3, 37)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (12, 3, 38)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (13, 3, 39)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (14, 3, 40)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (15, 3, 41)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (16, 4, 3)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (17, 4, 4)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (18, 2, 37)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (19, 2, 38)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (20, 2, 39)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (21, 2, 40)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (22, 2, 41)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (23, 2, 42)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (24, 2, 43)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (25, 2, 44)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (26, 12, 3)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (27, 12, 4)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (28, 12, 5)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (29, 12, 6)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (30, 12, 7)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (31, 12, 8)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (32, 12, 9)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (33, 12, 10)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (34, 12, 11)
INSERT [dbo].[DiscountItem] ([Id], [DiscountId], [GameId]) VALUES (35, 12, 12)
SET IDENTITY_INSERT [dbo].[DiscountItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Discounts] ON 

INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (2, CAST(N'2024-02-21' AS Date), CAST(N'2024-02-29' AS Date), 20, N'Seasonal', N'冬日優惠', N'background10.jpg', N'冬季來臨，享受20%折扣！歡迎體驗我們精選的遊戲，讓冷冷的冬天熱鬧起來。趕快入手，不容錯過！在這個季節，遊戲將為您帶來溫暖和歡樂。', 11)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (3, CAST(N'2024-03-10' AS Date), CAST(N'2024-03-20' AS Date), 15, N'Holiday', N'春節特惠', N'background9.jpg', N'慶祝春節！享受15%折扣，一同在遊戲世界中迎接新的一年。春節期間特有的激動時刻，千萬別錯過！一場充滿節慶氛圍的遊戲饗宴等著您。', 6)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (4, CAST(N'2024-04-05' AS Date), CAST(N'2024-04-15' AS Date), 25, N'Sale', N'四月狂歡', N'background8.jpg', N'四月特賣狂歡，所有遊戲優惠25%！錯過就要等下一次了。豐富的遊戲等您來體驗，現在就開始您的遊戲之旅吧！四月陽光明媚，一同享受遊戲樂趣。', 7)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (5, CAST(N'2024-05-15' AS Date), CAST(N'2024-05-25' AS Date), 30, N'Flash', N'閃電特價', N'background7.jpg', N'限時閃電特價！全站30%折扣，快來搶購您喜愛的遊戲。優惠僅此一次，別錯過這個難得的機會！在這段時間內，您將享受到更多驚喜和樂趣。', 8)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (6, CAST(N'2024-06-01' AS Date), CAST(N'2024-06-10' AS Date), 10, N'Daily', N'每日驚喜', N'background6.jpg', N'每日一個驚喜！我們將提供各式各樣的優惠，每天都有不同的驚喜等著您。每日都有新遊戲優惠，絕對讓您欲罷不能！遊戲世界的每一天都充滿驚奇，不容錯過。', 9)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (7, CAST(N'2024-07-08' AS Date), CAST(N'2024-07-18' AS Date), 18, N'Summer', N'夏日特賣', N'background5.jpg', N'夏日來臨，涼爽優惠！所有遊戲18%折扣，讓您的夏天更加精彩。炎炎夏日，盡情享受遊戲的樂趣吧！夏日特賣期間，各種令人興奮的遊戲等您體驗。', 13)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (8, CAST(N'2024-08-15' AS Date), CAST(N'2024-08-25' AS Date), 12, N'BackToSchool', N'返校優惠', N'background4.jpg', N'迎接新學期！返校特惠12%折扣，一同度過充實的學習時光。開學季優惠，快點選購您需要的遊戲吧！在這個學期，遊戲將伴您度過豐富的學習時光。', NULL)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (9, CAST(N'2024-09-05' AS Date), CAST(N'2024-09-15' AS Date), 22, N'LaborDay', N'勞動節大酬賓', N'background3.jpg', N'勞動節大酬賓，享受22%折扣，感謝您的辛勞和支持。勞動節限定，優惠期間不容錯過！在這個節日，我們感激每一位辛勤工作的您，讓遊戲帶給您歡樂和輕鬆。', NULL)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (10, CAST(N'2024-10-10' AS Date), CAST(N'2024-10-20' AS Date), 17, N'Autumn', N'秋季限定優惠', N'background2.jpg', N'秋季限定優惠！所有遊戲17%折扣，感受秋風的清新。秋天是遊戲的好時光，立即享受遊戲樂趣吧！在這個季節，我們為您精心挑選了一系列的遊戲，讓您感受秋天的美好。', NULL)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (11, CAST(N'2024-11-01' AS Date), CAST(N'2024-11-10' AS Date), 28, N'Halloween', N'萬聖節特賣', N'background1.jpg', N'萬聖節特賣！嚇人的優惠，所有遊戲28%折扣，讓您的萬聖夜更加刺激。萬聖節限定，給您帶來驚喜與刺激！在這個恐怖的節日，您將體驗到極致的遊戲樂趣。', NULL)
INSERT [dbo].[Discounts] ([Id], [StartDate], [EndDate], [Percent], [DiscountType], [Name], [Image], [Desciption], [DeveloperId]) VALUES (12, CAST(N'0001-01-01' AS Date), CAST(N'0001-01-01' AS Date), 5, N'季度特價', N'寶可夢好玩~\', N'images.jpg', N'皮卡', NULL)
SET IDENTITY_INSERT [dbo].[Discounts] OFF
GO
SET IDENTITY_INSERT [dbo].[DLCs] ON 

INSERT [dbo].[DLCs] ([Id], [GameId], [AttachedGameId]) VALUES (1, 4, 57)
INSERT [dbo].[DLCs] ([Id], [GameId], [AttachedGameId]) VALUES (2, 4, 58)
SET IDENTITY_INSERT [dbo].[DLCs] OFF
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (3, N'刺激戰場', N'極致射擊體驗，多人連線競技', N'《刺激戰場》是一款引領極致射擊體驗風潮的多人連線競技遊戲。玩家可在開放世界中展開激烈對戰，搭載豐富武器系統及多樣載具，讓每場戰鬥都充滿挑戰與策略。', CAST(N'2023-03-02' AS Date), 0, N'1234.jpg', 6, 95, N'www.saveyt.cc_360p_Noita - Noita''d 27.mp4')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (4, N'文明帝國', N'建設文明，戰略征戰', N'《文明帝國》是一款建設文明、發展科技、進行戰略征戰的遊戲。玩家將領導一個文明的發展，建立城市、培養軍隊，並與其他文明展開激烈的外交與戰爭。', CAST(N'2023-06-25' AS Date), 49, N'ss_ffa38dcd56c15a949178cf7074c9b044ade9c3a4.600x338.jpg', 8, 90, N'movie480_vp9 (4).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (5, N'奇幻冒險', N'開啟冒險之旅，探索奇幻世界', N'《奇幻冒險》是一款打造龐大開放世界的角色扮演遊戲。玩家可在奇幻的世界中進行冒險，探索神秘洞穴、與魔法生物對抗，並參與豐富的劇情故事。', CAST(N'2023-09-12' AS Date), 69, N'ss_d1c0a418890d7dce6fc1ef88e0ab038c12ca69d7.600x338.jpg', 9, 92, N'movie480_vp9 (8).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (6, N'極速飆風', N'極速競速，感受風的挑戰', N'《極速飆風》將玩家帶入極速競技的世界，提供緊張刺激的多人對戰體驗。各式賽道、豐富車輛選擇，帶來極速飆風的快感，挑戰玩家的極限操作技巧。', CAST(N'2023-12-01' AS Date), 39, N'ss_b32f81356aefb70ef08a41ab1a194fdf3c35a785.1920x1080.jpg', 7, 88, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (7, N'恐懼之夜', N'生存恐怖，挑戰心靈極限', N'《恐懼之夜》營造了一個令人毛骨悚然的恐怖世界，玩家必須在黑暗中生存，逃避各種恐怖生物的追捕。遊戲中的驚悚場景將挑戰玩家的心靈極限。', CAST(N'2023-02-20' AS Date), 29, N'ss_264faf6cbb2d4466c2a10f9e03fe1487e0615379.600x338.jpg', 11, 85, N'movie480_vp9 (5).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (8, N'未來之戰', N'極致射擊體驗，多人連線競技', N'《未來之戰》是一款引領極致射擊體驗風潮的多人連線競技遊戲。玩家可在開放世界中展開激烈對戰，搭載豐富武器系統及多樣載具，讓每場戰鬥都充滿挑戰與策略。', CAST(N'2023-03-10' AS Date), 59, N'ss_168528c86261f98aeb64192dc34025a4b361ff4a.1920x1080.jpg', 13, 95, N'movie480_vp9 (6).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (9, N'文化帝國', N'建設文明，戰略征戰', N'《文化帝國》是一款建設文明、發展科技、進行戰略征戰的遊戲。玩家將領導一個文明的發展，建立城市、培養軍隊，並與其他文明展開激烈的外交與戰爭。', CAST(N'2023-06-25' AS Date), 49, N'ss_a7fc1cb93030e790706ac85645034c844fd04c05.1920x1080.jpg', 12, 90, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (10, N'神秘大地', N'開啟冒險之旅，探索奇幻世界', N'《神秘大地》是一款打造龐大開放世界的角色扮演遊戲。玩家可在神秘的世界中進行冒險，探索神秘洞穴、與魔法生物對抗，並參與豐富的劇情故事。', CAST(N'2023-09-12' AS Date), 69, N'ss_ffd046bcf93e80e4f506a6235bae69670b7eec79.600x338.jpg', 11, 92, N'movie480 (1).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (11, N'極速飆風2', N'極速競速，感受風的挑戰', N'《極速飆風2》將玩家帶入極速競技的世界，提供緊張刺激的多人對戰體驗。各式賽道、豐富車輛選擇，帶來極速飆風的快感，挑戰玩家的極限操作技巧。', CAST(N'2023-12-01' AS Date), 39, N'ss_7c86a17d545b6260ecdcfdd62622e49dcc9011bd.600x338.jpg', 8, 88, N'movie480_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (12, N'夢魘之夜', N'生存恐怖，挑戰心靈極限', N'《夢魘之夜》營造了一個令人毛骨悚然的恐怖世界，玩家必須在黑暗中生存，逃避各種恐怖生物的追捕。遊戲中的驚悚場景將挑戰玩家的心靈極限。', CAST(N'2023-02-20' AS Date), 29, N'Pickatchu.jpg', 7, 85, N'movie480_vp9 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (35, N'刺客教條：維京紀元', N'探索北歐史詩，成為維京戰士，體驗極致沉浸的冒險', N'《刺客教條：維京紀元》將玩家帶入9世紀的北歐，扮演一位維京戰士，探索開放世界並參與史詩級的冒險。遊戲融合了精湛的劇情、出色的遊戲機制，以及令人難以置信的視覺效果，為玩家帶來前所未有的沉浸體驗，難以置信的視覺效果。', CAST(N'2022-11-10' AS Date), 59, N'ss_a2c61b591e9670d8d2cc84a935278280684dc81a.1920x1080.jpg', 7, 90, N'movie480_vp9 (5).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (36, N'未來之戰', N'探索科技戰爭，展開激烈戰鬥，挑戰未來的極限', N'《未來之戰》將玩家投入科技戰爭的戰場，面對激烈的戰鬥與挑戰未來的極限。遊戲呈現出磅礡的戰爭場面、精心設計的科技裝備，以及引人入勝的劇情，讓玩家沉浸在未來世界的極致體驗中。', CAST(N'2023-08-15' AS Date), 49, N'ss_92a713e2f0ce374a446367c57f962ef942b2c173.600x338.jpg', 6, 85, N'movie480_vp9 (7).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (37, N'夢幻之旅', N'冒險探索，解謎與魔法的奇幻之旅', N'《夢幻之旅》邀您進入奇幻的冒險世界，充滿解謎與魔法。遊戲結合精美的畫面、豐富的冒險敘事，帶領玩家展開一場令人難以忘懷的夢幻之旅。', CAST(N'2023-02-28' AS Date), 39, N'ss_df93b5e8a183f7232d68be94ae78920a90de1443.600x338.jpg', 10, 80, N'movie480_vp9 (5).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (38, N'極速飆車', N'挑戰極速，競技飆車的刺激快感', N'《極速飆車》將您引入極速競技的世界，感受刺激快感。遊戲展現真實的賽車體驗、多樣化的賽道，以及緊張刺激的競賽。準備好迎接速度的挑戰了嗎？', CAST(N'2023-05-20' AS Date), 29, N'ss_391a1c5adf618fbcd1bec89e25e0ac54bb4d915f.600x338.jpg', 9, 88, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (39, N'星際探險家', N'穿越宇宙，探索星系，成為宇宙探險家', N'《星際探險家》將您帶入宇宙的無垠星系，成為一位探險家。遊戲呈現宏偉的宇宙景觀、多樣的行星生態，以及探索未知的刺激。準備啟程展開您的星際冒險嗎？', CAST(N'2023-10-08' AS Date), 69, N'ss_3b08a991443164a65f84f1bd9f1363e6c2ec4581.600x338.jpg', 7, 92, N'movie4802_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (40, N'時光漩渦', N'解開時空之謎，冒險穿越不同時代', N'《時光漩渦》邀您解開時空之謎，穿越不同時代的奇妙冒險。遊戲結合引人入勝的敘事、精心設計的時代場景，帶領玩家探索時間的奧秘。準備開啟您的時空之旅了嗎？', CAST(N'2023-11-30' AS Date), 59, N'ss_dad710e3c4e6b818fa0a935b25a1fc31e73188a5.600x338.jpg', 11, 85, N'movie4801_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (41, N'夢幻建築師', N'打造夢幻城市，建築藝術的奇妙體驗', N'《夢幻建築師》讓您成為城市的設計者，打造屬於自己的夢幻城市。遊戲融合建築藝術、城市規劃，讓您感受創造力的極致樂趣。準備展開建築的奇妙旅程了嗎？', CAST(N'2024-03-15' AS Date), 49, N'ss_822fac38a830a3b585fa8bdd0f2450507cb13b06.600x338.jpg', 12, 78, N'movie480_vp9 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (42, N'神秘迷宮', N'挑戰迷宮，探索神秘秘境的謎題', N'《神秘迷宮》將您引入神秘的迷宮之中，挑戰各種謎題。遊戲呈現出多變的迷宮結構、驚險的探險體驗，讓您沉浸在神秘秘境的冒險之旅。準備面對迷宮的挑戰了嗎？', CAST(N'2024-06-25' AS Date), 39, N'ss_d4930d675af053dc1e61a876a34fc003e85e261f.600x338.jpg', 15, 88, N'movie480 (1).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (43, N'極地探險', N'挑戰極寒，冒險極地的極限之旅', N'《極地探險》帶您挑戰極寒環境，展開極地的極限之旅。遊戲展現出冰雪世界的壯闊景觀、生存挑戰，以及極地冒險的刺激。準備迎接極地的挑戰了嗎？', CAST(N'2024-09-12' AS Date), 69, N'ss_0d6e1ca2ecb03008b22588ece2389523a2298889.1920x1080.jpg', 13, 90, N'movie480_vp9 (3).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (44, N'幻想之森', N'探索奇幻之森，邂逅神秘生物的奇幻之旅', N'《幻想之森》邀您探索奇幻之森，邂逅神秘生物的奇幻之旅。遊戲結合豐富的生態系統、精緻的畫面，帶領玩家沉浸在奇幻的森林冒險中。', CAST(N'2024-12-01' AS Date), 59, N'ss_574ea9c6460c58e665bff993e8394362c1fb10e7.1920x1080.jpg', 7, 85, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (46, N'星際征服者', N'成為宇宙之王，征服星際文明', N'《星際征服者》邀您成為宇宙之王，征服星際文明。遊戲融合了策略戰爭、外交政治，讓您體驗星際征服的震撼旅程。', CAST(N'2025-10-10' AS Date), 59, N'ss_0c79f56fc7be1bd0102f2ca1c92c8f0900daf4fb.600x338.jpg', 10, 92, N'movie480_vp9 (10).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (47, N'時空漫遊者', N'穿越時空，探索歷史的奧秘', N'《時空漫遊者》帶您穿越時空，探索歷史的奧秘。遊戲結合了時空冒險、考古發現，讓您沉浸在時光之中，揭開歷史的面紗。', CAST(N'2026-02-18' AS Date), 49, N'ss_6eac5a3b59e181d1ffa26757b041be521bfe1779.600x338.jpg', 6, 85, N'movie4801_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (48, N'夢幻飛艇隊', N'組建屬於您的夢幻飛艇隊，冒險起飛', N'《夢幻飛艇隊》邀您組建屬於自己的夢幻飛艇隊，冒險起飛。遊戲呈現出繽紛的飛行冒險、多元的飛艇裝備，讓您體驗夢幻的飛行之旅。', CAST(N'2026-05-25' AS Date), 39, N'ss_168528c86261f98aeb64192dc34025a4b361ff4a.1920x1080.jpg', 9, 90, N'movie480_vp9 (7).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (49, N'巨石之戰', N'在巨石世界展開史詩戰爭', N'《巨石之戰》將您引入充滿巨石的史詩世界，展開一場史詩戰爭。遊戲融合了巨石文明、戰略戰爭，讓您體驗史詩巨石之戰。', CAST(N'2026-08-12' AS Date), 69, N'ss_df93b5e8a183f7232d68be94ae78920a90de1443.600x338.jpg', 8, 88, N'movie4803_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (50, N'蒸汽之都', N'建造屬於您的蒸汽都市，引領科技革命', N'《蒸汽之都》邀您建造屬於自己的蒸汽都市，引領科技革命。遊戲結合蒸汽科技、城市建設，讓您體驗蒸汽時代的奇妙之旅。', CAST(N'2026-11-05' AS Date), 29, N'ss_495cead0fc7f9fe07026bb7d018a005c810bd2c9.1920x1080.jpg', 13, 85, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (51, N'冰雪競技', N'加入冰雪競技，挑戰極限運動', N'《冰雪競技》讓您加入冰雪競技，挑戰極限運動的精彩。遊戲呈現出真實的冰雪場景、多種極限運動，讓您感受冰雪競技的激情刺激。', CAST(N'2027-02-20' AS Date), 39, N'ss_b5d5ea3ed8622e2a12ea6e30b512c0b358f92f01.1920x1080.jpg', 15, 78, N'movie4802_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (52, N'神聖之劍', N'尋找神聖之劍，對抗黑暗勢力', N'《神聖之劍》邀您尋找神聖之劍，對抗黑暗勢力。遊戲結合冒險探索、魔法戰鬥，讓您踏上一場充滿神秘的冒險之旅。', CAST(N'2027-05-15' AS Date), 49, N'ss_dad710e3c4e6b818fa0a935b25a1fc31e73188a5.600x338.jpg', 10, 90, N'movie480_vp9 (3).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (53, N'星際商人', N'成為星際商人，掌握貿易王國', N'《星際商人》邀您成為星際商人，掌握貿易王國的權力。遊戲融合了經濟策略、星際貿易，讓您體驗星際商業的繁榮與挑戰。', CAST(N'2027-08-08' AS Date), 29, N'ss_6eac5a3b59e181d1ffa26757b041be521bfe1779.600x338.jpg', 15, 88, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (54, N'狂野賽車', N'參加狂野賽車，挑戰極速競速', N'《狂野賽車》讓您參加狂野賽車，挑戰極速競速的極限。遊戲呈現出真實的賽車場景、多樣的賽道挑戰，讓您感受狂野賽車的刺激。', CAST(N'2027-11-25' AS Date), 59, N'ss_ffa38dcd56c15a949178cf7074c9b044ade9c3a4.600x338.jpg', 14, 92, N'movie4803_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (55, N'幻想之門', N'打開幻想之門，進入奇幻異世界', N'《幻想之門》帶您打開幻想之門，進入奇幻異世界。遊戲結合奇幻冒險、異世文明，讓您沉浸在幻想之門的奇妙冒險。', CAST(N'2028-02-10' AS Date), 39, N'ss_7c86a17d545b6260ecdcfdd62622e49dcc9011bd.600x338.jpg', 12, 85, N'movie480_vp9 (9).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (56, N'test', N'testtest', N'testtesttest', CAST(N'2024-02-13' AS Date), 1, N'下載.jpg', 8, 1, N'www.saveyt.cc_360p_Noita - Noita''d 27.mp4')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (57, N'test', N'testtest', N'testtesttest', CAST(N'2024-02-13' AS Date), 1, N'下載.jpg', 8, 1, N'www.saveyt.cc_360p_Noita - Noita''d 27.mp4')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (58, N'123', N'123', N'1231231', CAST(N'2024-02-02' AS Date), 1, N'babymiloarchive on ig.jpg', 8, 1, N'www.saveyt.cc_360p_Noita - Noita''d 27.mp4')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (59, N'寶可夢朱', N'一款很像帕魯的遊戲', N'可以用很多寶可夢求抓到很多帕魯', CAST(N'2024-02-01' AS Date), 5, N'images.jpg', 8, NULL, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (60, N'寶可夢朱', N'一款很像帕魯的遊戲', N'可以用很多寶可夢求抓到很多帕魯', CAST(N'2024-02-01' AS Date), 5, N'images.jpg', 8, 2, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (61, N'寶可夢朱', N'一款很像帕魯的遊戲', N'可以用很多寶可夢求抓到很多帕魯', CAST(N'2024-02-01' AS Date), 5, N'images.jpg', 8, 2, N'movie480 (2).webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (62, N'寶可夢紫', N'帕魯', N'皮卡丘', CAST(N'2024-02-15' AS Date), 1000, N'babymiloarchive on ig.jpg', 13, 80, N'movie4803_vp9.webm')
INSERT [dbo].[Games] ([Id], [Name], [Introduction], [Description], [ReleaseDate], [Price], [Cover], [DeveloperId], [MaxPercent], [Video]) VALUES (63, N'寶可夢劍', N'一款抓帕魯的遊戲', N'遊戲中你可以使用大師求去抓你的塔主', CAST(N'2024-02-09' AS Date), 1000, N'images.jpg', 13, NULL, N'movie480_vp9 (5).webm')
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[GameTags] ON 

INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (7, 4, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (8, 4, 4)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (9, 4, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (10, 5, 89)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (11, 5, 8)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (12, 5, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (18, 4, 86)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (19, 4, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (20, 4, 76)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (21, 4, 32)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (22, 4, 42)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (23, 5, 4)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (24, 5, 46)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (25, 5, 47)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (26, 5, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (27, 5, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (28, 6, 91)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (29, 6, 17)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (30, 6, 27)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (31, 6, 40)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (32, 6, 68)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (33, 7, 92)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (34, 7, 58)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (35, 7, 27)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (36, 7, 83)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (37, 7, 46)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (38, 8, 69)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (39, 8, 78)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (40, 8, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (41, 8, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (42, 8, 75)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (43, 9, 22)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (44, 9, 36)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (45, 9, 21)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (46, 9, 29)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (47, 9, 11)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (48, 10, 4)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (49, 10, 58)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (50, 10, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (51, 10, 18)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (52, 10, 82)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (53, 11, 35)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (54, 11, 25)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (55, 11, 24)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (56, 11, 79)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (57, 11, 54)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (58, 12, 35)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (59, 12, 34)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (60, 12, 79)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (61, 12, 45)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (62, 12, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (63, 35, 94)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (64, 35, 40)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (65, 35, 68)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (66, 35, 30)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (67, 35, 34)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (68, 36, 12)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (69, 36, 60)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (70, 36, 16)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (71, 36, 36)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (72, 36, 48)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (73, 37, 20)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (74, 37, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (75, 37, 45)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (76, 37, 2)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (77, 37, 38)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (78, 38, 55)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (79, 38, 80)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (80, 38, 26)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (81, 38, 14)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (82, 38, 43)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (83, 39, 5)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (84, 39, 69)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (85, 39, 25)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (86, 39, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (87, 39, 38)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (88, 40, 43)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (89, 40, 63)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (90, 40, 47)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (91, 40, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (92, 40, 17)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (93, 41, 80)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (94, 41, 50)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (95, 41, 52)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (96, 41, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (97, 41, 79)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (98, 42, 24)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (99, 42, 56)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (100, 42, 65)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (101, 42, 25)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (102, 42, 14)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (103, 43, 23)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (104, 43, 46)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (105, 43, 40)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (106, 43, 28)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (107, 43, 39)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (108, 44, 83)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (109, 44, 90)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (110, 44, 91)
GO
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (111, 44, 31)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (112, 44, 43)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (118, 4, 51)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (119, 4, 26)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (120, 4, 4)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (121, 4, 94)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (122, 4, 93)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (123, 5, 57)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (124, 5, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (125, 5, 94)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (126, 5, 18)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (127, 5, 65)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (128, 6, 28)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (129, 6, 68)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (130, 6, 17)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (131, 6, 36)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (132, 6, 57)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (133, 7, 20)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (134, 7, 64)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (135, 7, 12)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (136, 7, 50)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (137, 7, 51)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (138, 8, 86)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (139, 8, 17)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (140, 8, 47)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (141, 8, 71)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (142, 8, 81)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (143, 9, 22)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (144, 9, 77)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (145, 9, 29)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (146, 9, 26)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (147, 9, 64)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (148, 10, 38)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (149, 10, 71)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (150, 10, 49)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (151, 10, 45)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (152, 10, 33)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (153, 11, 77)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (154, 11, 88)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (155, 11, 58)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (156, 11, 44)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (157, 11, 87)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (158, 12, 85)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (159, 12, 75)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (160, 12, 35)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (161, 12, 68)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (162, 12, 67)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (163, 35, 73)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (164, 35, 91)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (165, 35, 18)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (166, 35, 11)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (167, 35, 70)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (168, 36, 94)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (169, 36, 6)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (170, 36, 91)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (171, 36, 77)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (172, 36, 35)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (173, 37, 88)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (174, 37, 80)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (175, 37, 69)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (176, 37, 90)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (177, 37, 66)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (178, 38, 77)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (179, 38, 69)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (180, 38, 38)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (181, 38, 31)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (182, 38, 11)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (183, 39, 15)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (184, 39, 23)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (185, 39, 48)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (186, 39, 14)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (187, 39, 62)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (188, 40, 17)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (189, 40, 51)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (190, 40, 43)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (191, 40, 94)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (192, 40, 24)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (193, 41, 35)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (194, 41, 45)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (195, 41, 46)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (196, 41, 80)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (197, 41, 67)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (198, 42, 92)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (199, 42, 69)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (200, 42, 4)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (201, 42, 47)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (202, 42, 59)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (203, 43, 64)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (204, 43, 56)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (205, 43, 72)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (206, 43, 53)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (207, 43, 26)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (208, 44, 81)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (209, 44, 73)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (210, 44, 34)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (211, 44, 7)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (212, 44, 55)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (219, 3, 28)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (220, 3, 12)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (221, 3, 21)
GO
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (223, 57, 90)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (224, 57, 53)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (225, 57, 86)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (226, 58, 21)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (227, 58, 11)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (228, 3, 29)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (229, 3, 46)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (230, 3, 52)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (231, 3, 5)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (232, 3, 22)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (233, 3, 30)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (234, 59, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (235, 59, 2)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (236, 59, 3)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (237, 59, 5)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (238, 59, 7)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (239, 60, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (240, 60, 2)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (241, 60, 3)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (242, 60, 5)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (243, 60, 7)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (244, 61, 1)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (245, 61, 2)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (246, 61, 3)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (247, 61, 5)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (248, 61, 7)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (249, 62, 21)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (250, 62, 22)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (255, 63, 2)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (256, 63, 30)
INSERT [dbo].[GameTags] ([Id], [GameId], [TagId]) VALUES (257, 63, 22)
SET IDENTITY_INSERT [dbo].[GameTags] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (1, 3, N'ss_391a1c5adf618fbcd1bec89e25e0ac54bb4d915f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (4, 3, N'ss_168528c86261f98aeb64192dc34025a4b361ff4a.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (5, 36, N'ss_b32f81356aefb70ef08a41ab1a194fdf3c35a785.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (6, 36, N'ss_d148f56dfbda96b7312be5521af4a7740216fddd.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (7, 36, N'ss_df93b5e8a183f7232d68be94ae78920a90de1443.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (8, 40, N'ss_3a459e9ea8b54c3864379fcad38bff3ae7fe4e8c.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (9, 40, N'ss_6ac16a708699a9d3d90359da2450cbc6b20e4e4c.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (10, 40, N'ss_9f8cb11c51ef285b43f0eb908c586d81fe57573a.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (11, 47, N'ss_ed67ab6ee30d3dc40135d4474dae7baa0f3a9bb1.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (12, 47, N'ss_ffa38dcd56c15a949178cf7074c9b044ade9c3a4.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (13, 6, N'ss_1e6f7cf3c58086df2a3e9b13a988c2681d372b2d.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (14, 6, N'ss_1ee4e56933a1e9984db0be274e2d884313056932.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (15, 6, N'ss_5f6c9a2d36035f57008b60683f42a7634e02f1ed.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (16, 6, N'ss_8b87c40eec29f82e91b90db47662edf8702aedab.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (17, 12, N'ss_1e6f7cf3c58086df2a3e9b13a988c2681d372b2d.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (18, 12, N'ss_1ee4e56933a1e9984db0be274e2d884313056932.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (22, 12, N'ss_5f6c9a2d36035f57008b60683f42a7634e02f1ed.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (23, 12, N'ss_8b87c40eec29f82e91b90db47662edf8702aedab.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (24, 12, N'ss_a2c61b591e9670d8d2cc84a935278280684dc81a.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (25, 35, N'ss_1b3b5fd437939a7ed00a2155269e78994cb998d3.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (26, 35, N'ss_4c403dcd22f20a11524269c71f9feec96085a762.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (27, 35, N'ss_5f6217d8357904f376e171a1ac46db4fd9f8000c.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (28, 35, N'ss_39fc644a464b4df4348ddba1e78274513a152e86.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (29, 39, N'ss_c512fb42986a5438ea5ef3c5fda901428b2717d0.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (30, 39, N'ss_df93b5e8a183f7232d68be94ae78920a90de1443.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (31, 39, N'ss_e7141be8f5c212a989cf43aa0c55ab3f576aa2fd.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (32, 39, N'ss_fb8e5e2ae29ce64e2898315c66b5db08989e8f91.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (33, 44, N'ss_cb77efbe47788bd02be46ec93cc5609b2b9f8540.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (34, 44, N'ss_d4930d675af053dc1e61a876a34fc003e85e261f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (35, 44, N'ss_fe70d46859593aef623a0614f4686e2814405035.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (36, 44, N'ss_ffa38dcd56c15a949178cf7074c9b044ade9c3a4.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (37, 4, N'ss_5c674ff5ae1969b21a1b4903dfd964298fad3017.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (38, 4, N'ss_13bb35638c0267759276f511ee97064773b37a51.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (39, 4, N'ss_160b081796d18008d568495c6fdee74b6607bd24.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (40, 4, N'ss_3654155c149e7afed026e2fafc4af5059a80eb6e.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (41, 11, N'ss_83afcc8fbdd3eaa9f9d165f2748438c837697cf8.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (42, 11, N'ss_b32f81356aefb70ef08a41ab1a194fdf3c35a785.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (43, 11, N'ss_edaf6a07a66115b0eaa06b4a90d9b16dbdc5ed3f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (44, 49, N'ss_7ca28c9b8ddd25305ab7e37ad0a59e243e1c1e8f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (45, 49, N'ss_83afcc8fbdd3eaa9f9d165f2748438c837697cf8.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (46, 49, N'ss_8949ed7dd24a02d5ea13b08fc5c04fab400dc4bd.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (47, 49, N'ss_eb977f87934660f2489b7c7254d0597f7295dda6.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (48, 49, N'ss_f9aad46ea4a4168b3ce4cb75a1019eaf201cc376.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (49, 5, N'ss_160b081796d18008d568495c6fdee74b6607bd24.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (50, 5, N'ss_2254a50f27951fb9028bc00b93a7f2ed7aac1e13.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (51, 5, N'ss_dad710e3c4e6b818fa0a935b25a1fc31e73188a5.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (52, 38, N'ss_2254a50f27951fb9028bc00b93a7f2ed7aac1e13.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (53, 38, N'ss_a7fc1cb93030e790706ac85645034c844fd04c05.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (54, 38, N'ss_b04bd26db728825191ff94f57539276865be4c8c.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (55, 38, N'ss_b8bfcb1b39644ca7aba0f830ef4675829ca23b56.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (56, 38, N'ss_dad710e3c4e6b818fa0a935b25a1fc31e73188a5.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (57, 48, N'ss_92a713e2f0ce374a446367c57f962ef942b2c173.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (59, 48, N'ss_3654155c149e7afed026e2fafc4af5059a80eb6e.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (60, 48, N'ss_edaf6a07a66115b0eaa06b4a90d9b16dbdc5ed3f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (61, 48, N'ss_ffd046bcf93e80e4f506a6235bae69670b7eec79.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (62, 10, N'ss_0ef5e9c846ad1cdd7357a7ca6b122e2643d74b9c.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (63, 10, N'ss_5f6217d8357904f376e171a1ac46db4fd9f8000c.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (64, 10, N'ss_13bb35638c0267759276f511ee97064773b37a51.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (65, 10, N'ss_27258f5e9161bbffe37393e3b6752ad3bc1233c1.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (66, 37, N'ss_0c8cbc20442b948c91b02d9e1b41bf0638a07c08.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (67, 37, N'ss_1b3b5fd437939a7ed00a2155269e78994cb998d3.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (68, 37, N'ss_6eac5a3b59e181d1ffa26757b041be521bfe1779.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (69, 37, N'ss_8e08976236d29b1897769257ac3c64e9264792a5.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (70, 37, N'ss_038ffb556dbe87524ce7b320b294aec3494008e1.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (71, 46, N'ss_5c674ff5ae1969b21a1b4903dfd964298fad3017.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (72, 46, N'ss_038ffb556dbe87524ce7b320b294aec3494008e1.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (73, 46, N'ss_54b9c26b028c84d5f8a5316f31ae6203953ed84d.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (74, 46, N'ss_83afcc8fbdd3eaa9f9d165f2748438c837697cf8.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (75, 46, N'ss_f81b7c4f20be3b99f76a1415c4cdb9b444c99b97.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (77, 52, N'ss_18979ca60376090aa14e22e8e4ecbff0ed997a21.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (78, 52, N'ss_a7fc1cb93030e790706ac85645034c844fd04c05.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (79, 52, N'ss_ef98db5d5a4d877531a5567df082b0fb62d75c80.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (80, 7, N'ss_0ef21692dacced263c19c4b90ea032f2e4dd798f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (81, 7, N'ss_7c86a17d545b6260ecdcfdd62622e49dcc9011bd.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (82, 7, N'ss_168528c86261f98aeb64192dc34025a4b361ff4a.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (83, 9, N'ss_0ef21692dacced263c19c4b90ea032f2e4dd798f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (84, 9, N'ss_5f6c9a2d36035f57008b60683f42a7634e02f1ed.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (85, 9, N'ss_574ea9c6460c58e665bff993e8394362c1fb10e7.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (86, 9, N'ss_edaf6a07a66115b0eaa06b4a90d9b16dbdc5ed3f.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (87, 41, N'ss_52b5730f94d6a6cfab5491faa125497f4e63209e.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (88, 41, N'ss_2254a50f27951fb9028bc00b93a7f2ed7aac1e13.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (89, 41, N'ss_a9fa84f0c21bc536f00925ab4586e8c4f587c2b7.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (90, 41, N'ss_ef82850f036dac5772cb07dbc2d1116ea13eb163.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (91, 55, N'ss_0c8cbc20442b948c91b02d9e1b41bf0638a07c08.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (92, 55, N'ss_7009fb22be187c090877765bca59322b39541809.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (93, 55, N'ss_27258f5e9161bbffe37393e3b6752ad3bc1233c1.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (94, 55, N'ss_a7fc1cb93030e790706ac85645034c844fd04c05.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (95, 8, N'ss_028210b79cb58d9e294f70c575ecc60f9fa8a644.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (96, 8, N'ss_b8bfcb1b39644ca7aba0f830ef4675829ca23b56.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (97, 8, N'ss_d148f56dfbda96b7312be5521af4a7740216fddd.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (98, 43, N'ss_0c8cbc20442b948c91b02d9e1b41bf0638a07c08.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (99, 43, N'ss_1e47bb8bbfaaaf3282bfb5d253378832b55c4e56.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (100, 43, N'ss_06e27c15c7b4b10233c937b887cf6a6925c83009.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (101, 43, N'ss_8b87c40eec29f82e91b90db47662edf8702aedab.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (102, 50, N'ss_d830cfd0550fbb64d80e803e93c929c3abb02056.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (104, 50, N'ss_f9aad46ea4a4168b3ce4cb75a1019eaf201cc376.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (105, 50, N'ss_fb8e5e2ae29ce64e2898315c66b5db08989e8f91.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (106, 50, N'ss_ffd046bcf93e80e4f506a6235bae69670b7eec79.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (107, 54, N'ss_1e6f7cf3c58086df2a3e9b13a988c2681d372b2d.600x338.jpg')
GO
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (108, 54, N'ss_d830cfd0550fbb64d80e803e93c929c3abb02056.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (109, 54, N'ss_f9aad46ea4a4168b3ce4cb75a1019eaf201cc376.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (110, 54, N'ss_fb8e5e2ae29ce64e2898315c66b5db08989e8f91.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (111, 54, N'ss_ffd046bcf93e80e4f506a6235bae69670b7eec79.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (112, 42, N'ss_9f8cb11c51ef285b43f0eb908c586d81fe57573a.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (113, 42, N'ss_a7fc1cb93030e790706ac85645034c844fd04c05.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (114, 42, N'ss_b5d5ea3ed8622e2a12ea6e30b512c0b358f92f01.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (115, 51, N'ss_8949ed7dd24a02d5ea13b08fc5c04fab400dc4bd.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (116, 51, N'ss_d1c0a418890d7dce6fc1ef88e0ab038c12ca69d7.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (117, 51, N'ss_ffd046bcf93e80e4f506a6235bae69670b7eec79.600x338.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (122, 56, N'babymiloarchive on ig.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (123, 56, N'Deadpool.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (124, 56, N'HD Game Wallpapers 1080p - Wallpaper Cave.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (125, 57, N'babymiloarchive on ig.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (126, 57, N'Deadpool.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (127, 57, N'HD Game Wallpapers 1080p - Wallpaper Cave.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (128, 58, N'下載.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (129, 59, N'1694966373704.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (130, 59, N'ss_1e47bb8bbfaaaf3282bfb5d253378832b55c4e56.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (131, 60, N'1694966373704.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (132, 60, N'ss_1e47bb8bbfaaaf3282bfb5d253378832b55c4e56.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (133, 61, N'1694966373704.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (134, 61, N'ss_1e47bb8bbfaaaf3282bfb5d253378832b55c4e56.1920x1080.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (135, 62, N'images.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (137, 63, N'1234.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (138, 63, N'1694966373704.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (139, 63, N'babymiloarchive on ig.jpg')
INSERT [dbo].[Images] ([Id], [GameId], [DisplayImage]) VALUES (140, 63, N'background3.jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (1, N'john_doe', N'securePass123', N'john.doe@email.com', N'avatar_john.jpg', CAST(N'2023-01-15T08:30:00.000' AS DateTime), NULL, 150, CAST(N'2023-02-10T18:45:00.000' AS DateTime), CAST(N'1985-08-15T00:00:00.000' AS DateTime), N'JohnDoe')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (2, N'bob_jackson', N'bobPass789', N'bob.jackson@email.com', N'avatar_bob.jpg', CAST(N'2023-03-10T14:20:00.000' AS DateTime), NULL, 90, CAST(N'2023-04-08T21:30:00.000' AS DateTime), CAST(N'1988-11-18T00:00:00.000' AS DateTime), N'BobTheExplorer')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (3, N'linda_carter', N'lindaPass123', N'linda.carter@email.com', N'avatar_linda.jpg', CAST(N'2023-04-22T17:10:00.000' AS DateTime), NULL, 110, CAST(N'2023-05-12T08:40:00.000' AS DateTime), CAST(N'1995-09-30T00:00:00.000' AS DateTime), N'LindaAdventure')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (4, N'david_williams', N'securePass789', N'david.williams@email.com', N'avatar_david.jpg', CAST(N'2023-05-05T09:00:00.000' AS DateTime), NULL, 80, CAST(N'2023-06-02T16:15:00.000' AS DateTime), CAST(N'1982-07-25T00:00:00.000' AS DateTime), N'DavidMastermind')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (5, N'emily_harris', N'emilyPass456', N'emily.harris@email.com', N'avatar_emily.jpg', CAST(N'2023-06-18T13:45:00.000' AS DateTime), NULL, 130, CAST(N'2023-07-08T12:20:00.000' AS DateTime), CAST(N'1998-01-12T00:00:00.000' AS DateTime), N'EmilyEnchant')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (6, N'michael_lee', N'michaelPass123', N'michael.lee@email.com', N'avatar_michael.jpg', CAST(N'2023-07-01T10:30:00.000' AS DateTime), NULL, 95, CAST(N'2023-08-02T09:05:00.000' AS DateTime), CAST(N'1987-03-22T00:00:00.000' AS DateTime), N'MichaelMaestro')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (7, N'susan_clark', N'susanPass789', N'susan.clark@email.com', N'avatar_susan.jpg', CAST(N'2023-08-14T19:20:00.000' AS DateTime), NULL, 105, CAST(N'2023-09-10T14:45:00.000' AS DateTime), CAST(N'1993-12-05T00:00:00.000' AS DateTime), N'SusanStar')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (8, N'richard_turner', N'richardPass456', N'richard.turner@email.com', N'avatar_richard.jpg', CAST(N'2023-09-27T15:55:00.000' AS DateTime), NULL, 75, CAST(N'2023-10-20T17:30:00.000' AS DateTime), CAST(N'1980-06-08T00:00:00.000' AS DateTime), N'RichardRider')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (9, N'olivia_nguyen', N'oliviaPass123', N'olivia.nguyen@email.com', N'avatar_olivia.jpg', CAST(N'2023-10-10T12:40:00.000' AS DateTime), NULL, 140, CAST(N'2023-11-02T08:10:00.000' AS DateTime), CAST(N'1996-02-28T00:00:00.000' AS DateTime), N'OliviaOracle')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (10, N'steven_kim', N'stevenPass789', N'steven.kim@email.com', N'avatar_steven.jpg', CAST(N'2023-11-23T08:25:00.000' AS DateTime), NULL, 100, CAST(N'2023-12-15T11:50:00.000' AS DateTime), CAST(N'1984-09-15T00:00:00.000' AS DateTime), N'StevenStrategist')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (11, N'jessica_ng', N'jessicaPass456', N'jessica.ng@email.com', N'avatar_jessica.jpg', CAST(N'2023-12-06T11:15:00.000' AS DateTime), NULL, 115, CAST(N'2024-01-05T18:20:00.000' AS DateTime), CAST(N'1991-11-10T00:00:00.000' AS DateTime), N'JessicaJourney')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (12, N'ryan_kelly', N'ryanPass123', N'ryan.kelly@email.com', N'avatar_ryan.jpg', CAST(N'2024-01-19T14:35:00.000' AS DateTime), NULL, 85, CAST(N'2024-02-10T09:55:00.000' AS DateTime), CAST(N'1989-04-17T00:00:00.000' AS DateTime), N'RyanRover')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (13, N'grace_harrison', N'gracePass789', N'grace.harrison@email.com', N'avatar_grace.jpg', CAST(N'2024-02-01T18:50:00.000' AS DateTime), NULL, 125, CAST(N'2024-03-08T16:15:00.000' AS DateTime), CAST(N'1994-07-08T00:00:00.000' AS DateTime), N'GraceGazer')
INSERT [dbo].[Members] ([Id], [Account], [Password], [Mail], [AvatarURL], [RegistrationDate], [BanTime], [Bonus], [LastLoginDate], [Birthday], [NickName]) VALUES (14, N'peter_wood', N'peterPass456', N'peter.wood@email.com', N'avatar_peter.jpg', CAST(N'2024-03-15T21:05:00.000' AS DateTime), NULL, 70, CAST(N'2024-04-05T12:40:00.000' AS DateTime), CAST(N'1983-12-20T00:00:00.000' AS DateTime), N'PeterPioneer')
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Name]) VALUES (1, N'動作')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (2, N'冒險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (3, N'角色扮演')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (4, N'第一人稱射擊')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (5, N'模擬')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (6, N'策略')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (7, N'益智')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (8, N'恐怖')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (9, N'沙盒')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (10, N'多人遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (11, N'存活')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (12, N'開放世界')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (13, N'競速')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (14, N'競速')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (15, N'體育')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (16, N'獨立遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (17, N'科幻')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (18, N'奇幻')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (19, N'歷史')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (20, N'潛行')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (21, N'多人線上戰鬥競技場 (MOBA)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (22, N'大型多人線上角色扮演遊戲 (MMORPG)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (23, N'打鬥')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (24, N'休閒')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (25, N'探險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (26, N'戰術')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (27, N'教育')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (28, N'音樂')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (29, N'益智平台動作')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (30, N'視覺小說')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (31, N'節奏')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (32, N'復古')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (33, N'虛擬實境 (VR)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (34, N'擴增實境 (AR)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (35, N'合作')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (36, N'線上')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (37, N'魯蛇模式')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (38, N'戰爭')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (39, N'?博朋克')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (40, N'推理')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (41, N'喜劇')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (42, N'黑色電影')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (43, N'模擬賽車')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (44, N'歷史小說')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (45, N'塔防')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (46, N'實時戰略 (RTS)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (47, N'回合制策略 (TBS)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (48, N'城市建設')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (49, N'管理')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (50, N'探險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (51, N'動畫風')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (52, N'卡通風')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (53, N'4X (探索、擴張、利用、消滅)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (54, N'平台動作')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (55, N'製作')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (56, N'家庭友好')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (57, N'神話')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (58, N'海戰')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (59, N'政治')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (60, N'益智冒險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (61, N'模擬體育')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (62, N'戰術角色扮演遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (63, N'時間管理')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (64, N'西部風')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (65, N'曆史改編')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (66, N'大炮')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (67, N'生存遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (68, N'犯罪')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (69, N'黑暗奇幻')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (70, N'地城探險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (71, N'經濟')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (72, N'間諜')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (73, N'駭客')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (74, N'神秘地城')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (75, N'浪漫')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (76, N'諷刺')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (77, N'沙盒角色扮演遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (78, N'太空探險')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (79, N'蒸汽龐克')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (80, N'超級英雄')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (81, N'戰術射擊')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (82, N'卡牌遊戲 (TCG)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (83, N'虛擬寵物')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (84, N'荒野生存')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (85, N'替代現實遊戲 (ARG)')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (86, N'喜劇角色扮演遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (87, N'陰謀')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (88, N'實驗性')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (89, N'英雄射擊')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (90, N'生活模擬')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (91, N'足球')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (92, N'宇宙')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (93, N'時間旅行')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (94, N'2D格鬥遊戲')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (95, N'模擬')
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
ALTER TABLE [dbo].[BanGames]  WITH CHECK ADD  CONSTRAINT [FK_BanGames_Admins] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
GO
ALTER TABLE [dbo].[BanGames] CHECK CONSTRAINT [FK_BanGames_Admins]
GO
ALTER TABLE [dbo].[BanGames]  WITH CHECK ADD  CONSTRAINT [FK_BanGames_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[BanGames] CHECK CONSTRAINT [FK_BanGames_Games]
GO
ALTER TABLE [dbo].[BanGames]  WITH CHECK ADD  CONSTRAINT [FK_BanGames_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[BanGames] CHECK CONSTRAINT [FK_BanGames_Members]
GO
ALTER TABLE [dbo].[BanMembers]  WITH CHECK ADD  CONSTRAINT [FK_BanMembers_Admins] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
GO
ALTER TABLE [dbo].[BanMembers] CHECK CONSTRAINT [FK_BanMembers_Admins]
GO
ALTER TABLE [dbo].[BanMembers]  WITH CHECK ADD  CONSTRAINT [FK_BanMembers_Members] FOREIGN KEY([Member1Id])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[BanMembers] CHECK CONSTRAINT [FK_BanMembers_Members]
GO
ALTER TABLE [dbo].[BanMembers]  WITH CHECK ADD  CONSTRAINT [FK_BanMembers_Members1] FOREIGN KEY([Member2Id])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[BanMembers] CHECK CONSTRAINT [FK_BanMembers_Members1]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_Discounts] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_Discounts]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_Members]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK_BillItems_BillDetails] FOREIGN KEY([BillDetailId])
REFERENCES [dbo].[BillDetails] ([Id])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK_BillItems_BillDetails]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK_BillItems_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK_BillItems_Games]
GO
ALTER TABLE [dbo].[Boards]  WITH CHECK ADD  CONSTRAINT [FK_Boards_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Boards] CHECK CONSTRAINT [FK_Boards_Members]
GO
ALTER TABLE [dbo].[BonusItems]  WITH CHECK ADD  CONSTRAINT [FK_BonusItems_BonusProducts] FOREIGN KEY([ProductId])
REFERENCES [dbo].[BonusProducts] ([Id])
GO
ALTER TABLE [dbo].[BonusItems] CHECK CONSTRAINT [FK_BonusItems_BonusProducts]
GO
ALTER TABLE [dbo].[BonusItems]  WITH CHECK ADD  CONSTRAINT [FK_Items_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[BonusItems] CHECK CONSTRAINT [FK_Items_Members]
GO
ALTER TABLE [dbo].[BonusProducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[BonusProductTypes] ([Id])
GO
ALTER TABLE [dbo].[BonusProducts] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Games]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Members]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_BillDetails] FOREIGN KEY([BillDetailId])
REFERENCES [dbo].[BillDetails] ([Id])
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_BillDetails]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_Games]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_Members]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_MemberTags] FOREIGN KEY([MemberTagId])
REFERENCES [dbo].[MemberTags] ([Id])
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_MemberTags]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Games]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Members]
GO
ALTER TABLE [dbo].[DiscountItem]  WITH CHECK ADD  CONSTRAINT [FK_DiscountItem_Discounts] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
GO
ALTER TABLE [dbo].[DiscountItem] CHECK CONSTRAINT [FK_DiscountItem_Discounts]
GO
ALTER TABLE [dbo].[DiscountItem]  WITH CHECK ADD  CONSTRAINT [FK_DiscountItem_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[DiscountItem] CHECK CONSTRAINT [FK_DiscountItem_Games]
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Discounts_Developers] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[Developers] ([Id])
GO
ALTER TABLE [dbo].[Discounts] CHECK CONSTRAINT [FK_Discounts_Developers]
GO
ALTER TABLE [dbo].[DLCs]  WITH CHECK ADD  CONSTRAINT [FK_DLCs_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[DLCs] CHECK CONSTRAINT [FK_DLCs_Games]
GO
ALTER TABLE [dbo].[DLCs]  WITH CHECK ADD  CONSTRAINT [FK_DLCs_Games1] FOREIGN KEY([AttachedGameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[DLCs] CHECK CONSTRAINT [FK_DLCs_Games1]
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD  CONSTRAINT [FK_Friends_Members] FOREIGN KEY([Member1Id])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Friends] CHECK CONSTRAINT [FK_Friends_Members]
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD  CONSTRAINT [FK_Friends_Members1] FOREIGN KEY([Member2Id])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Friends] CHECK CONSTRAINT [FK_Friends_Members1]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Developers] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[Developers] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Developers]
GO
ALTER TABLE [dbo].[GameTags]  WITH CHECK ADD  CONSTRAINT [FK_GameTags_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[GameTags] CHECK CONSTRAINT [FK_GameTags_Games]
GO
ALTER TABLE [dbo].[GameTags]  WITH CHECK ADD  CONSTRAINT [FK_GameTags_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[GameTags] CHECK CONSTRAINT [FK_GameTags_Tags]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Games]
GO
ALTER TABLE [dbo].[MemberTags]  WITH CHECK ADD  CONSTRAINT [FK_MemberTags_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[MemberTags] CHECK CONSTRAINT [FK_MemberTags_Games]
GO
ALTER TABLE [dbo].[MemberTags]  WITH CHECK ADD  CONSTRAINT [FK_MemberTags_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[MemberTags] CHECK CONSTRAINT [FK_MemberTags_Members]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Boards] FOREIGN KEY([BoardId])
REFERENCES [dbo].[Boards] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Boards]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Members]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Boards] FOREIGN KEY([BoardId])
REFERENCES [dbo].[Boards] ([Id])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Boards]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Members]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Messages] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Messages] ([Id])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Messages]
GO
ALTER TABLE [dbo].[WishListes]  WITH CHECK ADD  CONSTRAINT [FK_WishListes_Discounts] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discounts] ([Id])
GO
ALTER TABLE [dbo].[WishListes] CHECK CONSTRAINT [FK_WishListes_Discounts]
GO
ALTER TABLE [dbo].[WishListes]  WITH CHECK ADD  CONSTRAINT [FK_WishListes_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[WishListes] CHECK CONSTRAINT [FK_WishListes_Games]
GO
ALTER TABLE [dbo].[WishListes]  WITH CHECK ADD  CONSTRAINT [FK_WishListes_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[WishListes] CHECK CONSTRAINT [FK_WishListes_Members]
GO
