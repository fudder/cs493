USE [SimpleStore]
GO
/****** Object:  Table [dbo].[Html]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Html](
	[HtmlId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](512) NOT NULL,
	[Html] [varchar](max) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Html] PRIMARY KEY CLUSTERED 
(
	[HtmlId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Image]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[AltText] [varchar](1024) NOT NULL,
	[ImagePath] [varchar](1024) NOT NULL,
	[Height] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Size] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seller](
	[SellerId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](512) NOT NULL,
	[EbayUser] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[SellerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductStatus]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductStatus](
	[ProductStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductStatus] PRIMARY KEY CLUSTERED 
(
	[ProductStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[ProductStatusId] [int] NOT NULL,
	[Title] [varchar](1024) NOT NULL,
	[ShortDesc] [varchar](max) NOT NULL,
	[FullDescHtmlId] [int] NULL,
	[Popularity] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HtmlImage]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HtmlImage](
	[HtmlId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_HtmlImage] PRIMARY KEY CLUSTERED 
(
	[HtmlId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Page](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[Name] [varchar](512) NOT NULL,
	[Title] [varchar](1024) NOT NULL,
	[HtmlId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewsArticle]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsArticle](
	[NewsArticleId] [int] IDENTITY(1,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[Title] [varchar](1024) NOT NULL,
	[Abstract] [varchar](max) NOT NULL,
	[ArticleHtmlId] [int] NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_NewsArticle] PRIMARY KEY CLUSTERED 
(
	[NewsArticleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SiteNav]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteNav](
	[SiteId] [int] NOT NULL,
	[PageId] [int] NOT NULL,
	[Seq] [int] NOT NULL,
 CONSTRAINT [PK_SiteNav] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC,
	[PageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Name] [varchar](1024) NOT NULL,
	[Seq] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 07/01/2010 20:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Site](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](512) NOT NULL,
	[SellerId] [int] NOT NULL,
	[LogoImageId] [int] NULL,
	[Tagline] [varchar](1024) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Html_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Html] ADD  CONSTRAINT [DF_Html_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Image_AltText]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_AltText]  DEFAULT ('') FOR [AltText]
GO
/****** Object:  Default [DF_ProductImage_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_ProductImage_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Seller_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_ProductStatus_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductStatus] ADD  CONSTRAINT [DF_ProductStatus_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Product_ShortDescription]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ShortDescription]  DEFAULT ('') FOR [ShortDesc]
GO
/****** Object:  Default [DF_Product_Popularity]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Popularity]  DEFAULT ((0)) FOR [Popularity]
GO
/****** Object:  Default [DF_Product_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Page_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Page] ADD  CONSTRAINT [DF_Page_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_NewsArticle_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[NewsArticle] ADD  CONSTRAINT [DF_NewsArticle_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Category_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_ProductImage_IsPrimary]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductImage] ADD  CONSTRAINT [DF_ProductImage_IsPrimary]  DEFAULT ((0)) FOR [IsPrimary]
GO
/****** Object:  Default [DF_Site_Tagline]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Site] ADD  CONSTRAINT [DF_Site_Tagline]  DEFAULT ('') FOR [Tagline]
GO
/****** Object:  Default [DF_Site_Created]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Site] ADD  CONSTRAINT [DF_Site_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  ForeignKey [FK_Product_Html]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Html] FOREIGN KEY([FullDescHtmlId])
REFERENCES [dbo].[Html] ([HtmlId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Html]
GO
/****** Object:  ForeignKey [FK_Product_ProductStatus]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductStatus] FOREIGN KEY([ProductStatusId])
REFERENCES [dbo].[ProductStatus] ([ProductStatusId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductStatus]
GO
/****** Object:  ForeignKey [FK_Product_Site]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Site]
GO
/****** Object:  ForeignKey [FK_HtmlImage_Html]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[HtmlImage]  WITH CHECK ADD  CONSTRAINT [FK_HtmlImage_Html] FOREIGN KEY([HtmlId])
REFERENCES [dbo].[Html] ([HtmlId])
GO
ALTER TABLE [dbo].[HtmlImage] CHECK CONSTRAINT [FK_HtmlImage_Html]
GO
/****** Object:  ForeignKey [FK_HtmlImage_Image]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[HtmlImage]  WITH CHECK ADD  CONSTRAINT [FK_HtmlImage_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[HtmlImage] CHECK CONSTRAINT [FK_HtmlImage_Image]
GO
/****** Object:  ForeignKey [FK_Page_Html]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Page]  WITH CHECK ADD  CONSTRAINT [FK_Page_Html] FOREIGN KEY([HtmlId])
REFERENCES [dbo].[Html] ([HtmlId])
GO
ALTER TABLE [dbo].[Page] CHECK CONSTRAINT [FK_Page_Html]
GO
/****** Object:  ForeignKey [FK_Page_Site]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Page]  WITH CHECK ADD  CONSTRAINT [FK_Page_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[Page] CHECK CONSTRAINT [FK_Page_Site]
GO
/****** Object:  ForeignKey [FK_NewsArticle_Html]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[NewsArticle]  WITH CHECK ADD  CONSTRAINT [FK_NewsArticle_Html] FOREIGN KEY([ArticleHtmlId])
REFERENCES [dbo].[Html] ([HtmlId])
GO
ALTER TABLE [dbo].[NewsArticle] CHECK CONSTRAINT [FK_NewsArticle_Html]
GO
/****** Object:  ForeignKey [FK_NewsArticle_Site]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[NewsArticle]  WITH CHECK ADD  CONSTRAINT [FK_NewsArticle_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[NewsArticle] CHECK CONSTRAINT [FK_NewsArticle_Site]
GO
/****** Object:  ForeignKey [FK_SiteNav_Page]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[SiteNav]  WITH CHECK ADD  CONSTRAINT [FK_SiteNav_Page] FOREIGN KEY([PageId])
REFERENCES [dbo].[Page] ([PageId])
GO
ALTER TABLE [dbo].[SiteNav] CHECK CONSTRAINT [FK_SiteNav_Page]
GO
/****** Object:  ForeignKey [FK_SiteNav_Site]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[SiteNav]  WITH CHECK ADD  CONSTRAINT [FK_SiteNav_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[SiteNav] CHECK CONSTRAINT [FK_SiteNav_Site]
GO
/****** Object:  ForeignKey [FK_Category_Category]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
/****** Object:  ForeignKey [FK_Category_Site]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Site]
GO
/****** Object:  ForeignKey [FK_ProductCategory_Category]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
/****** Object:  ForeignKey [FK_ProductCategory_Product]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
/****** Object:  ForeignKey [FK_ProductImage_Image]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Image]
GO
/****** Object:  ForeignKey [FK_ProductImage_Product]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
/****** Object:  ForeignKey [FK_Site_Image]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_Image] FOREIGN KEY([LogoImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_Image]
GO
/****** Object:  ForeignKey [FK_Site_Seller]    Script Date: 07/01/2010 20:56:53 ******/
ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_Seller] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Seller] ([SellerId])
GO
ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_Seller]
GO
