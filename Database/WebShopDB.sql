USE [WEBSHOPDB]
GO

/****** Object:  Table [dbo].[UserGroup]    Script Date: 1/3/2026 12:38:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserGroup](
	[UserGroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UserAccount]    Script Date: 1/3/2026 12:37:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserAccount](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[Builtin] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_UserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroup] ([UserGroupID])
GO

ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [FK_UserAccount_UserGroup]
GO

/****** Object:  Table [dbo].[StaticPage]    Script Date: 11/17/2012 23:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaticPage](
	[PageID] [int] NOT NULL,
	[PageTitle] [nvarchar](255) NOT NULL,
	[LanguageID] [varchar](5) NOT NULL,
	[PageContent] [ntext] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastUpdatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_StaticPage] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SiteStatistic]    Script Date: 11/17/2012 23:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteStatistic](
	[StatisticId] [int] NOT NULL,
	[VisitCounter] [bigint] NOT NULL,
 CONSTRAINT [PK_SiteStatistic] PRIMARY KEY CLUSTERED 
(
	[StatisticId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ProductCategory]    Script Date: 1/3/2026 12:41:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 1/3/2026 12:40:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductNumber] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ShortDesc] [nvarchar](255) NULL,
	[Description] [ntext] NULL,
	[Unit] [nchar](10) NULL,
	[UnitPrice] [float] NOT NULL,
	[Oldprice] [float] NULL,
	[CategoryId] [int] NOT NULL,
	[IsPromotion] [bit] NOT NULL,
	[IsFeatured] [bit] NOT NULL,
	[SmallImage] [image] NULL,
	[BigImage] [image] NULL,
	[IsInstock] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_isPromotion]  DEFAULT ((0)) FOR [IsPromotion]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_BS_Product_IsFeatured]  DEFAULT ((0)) FOR [IsFeatured]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([ProductCategoryID])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO

/****** Object:  Table [dbo].[SalesOrder]    Script Date: 1/3/2026 12:41:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](30) NULL,
	[Customer] [nvarchar](30) NOT NULL,
	[AddressLine1] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](30) NULL,
	[Email] [nvarchar](50) NULL,
	[DeliveryAddress] [nvarchar](150) NULL,
	[BillingAddress] [nvarchar](150) NULL,
	[Description] [nvarchar](255) NULL,
	[StatusId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderMaster] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/17/2012 23:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderProductId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [tinyint] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OrderProduct]    Script Date: 1/3/2026 12:42:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderProduct](
	[OrderProductId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [tinyint] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_quantity]  DEFAULT ((1)) FOR [Quantity]
GO

ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_total]  DEFAULT ((0)) FOR [Total]
GO

ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_SalesOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[SalesOrder] ([OrderId])
GO

ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_SalesOrder]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 11/17/2012 23:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [varchar](5) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[FAQ]    Script Date: 11/17/2012 23:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[FaqId] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](255) NOT NULL,
	[Answer] [ntext] NOT NULL,
 CONSTRAINT [PK_FaqId] PRIMARY KEY CLUSTERED 
(
	[FaqId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

---Contraints
/****** Object:  Default [DF_OrderDetail_price]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_price]  DEFAULT ((0)) FOR [Price]
GO
/****** Object:  Default [DF_OrderDetail_quantity]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_quantity]  DEFAULT ((1)) FOR [Quantity]
GO
/****** Object:  Default [DF_OrderDetail_amountMoney]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF_OrderDetail_total]  DEFAULT ((0)) FOR [Total]
GO
/****** Object:  Default [DF_Product_isPromote]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_isPromotion]  DEFAULT ((0)) FOR [IsPromotion]
GO
/****** Object:  Default [DF_BS_Product_IsFeatured]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_BS_Product_IsFeatured]  DEFAULT ((0)) FOR [IsFeatured]
GO
/****** Object:  Default [DF_SiteStatistic_visitCounter]    Script Date: 11/17/2012 23:01:22 ******/
ALTER TABLE [dbo].[SiteStatistic] ADD  CONSTRAINT [DF_SiteStatistic_visitCounter]  DEFAULT ((0)) FOR [VisitCounter]
GO
