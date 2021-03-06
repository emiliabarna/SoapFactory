USE [master]
GO
/****** Object:  Database [SoapFactory]    Script Date: 2017. 09. 06. 11:46:02 ******/
CREATE DATABASE [SoapFactory]
 CONTAINMENT = NONE

GO
ALTER DATABASE [SoapFactory] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoapFactory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoapFactory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoapFactory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoapFactory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoapFactory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoapFactory] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoapFactory] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoapFactory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoapFactory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoapFactory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoapFactory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoapFactory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoapFactory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoapFactory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoapFactory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoapFactory] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoapFactory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoapFactory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoapFactory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoapFactory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoapFactory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoapFactory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoapFactory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoapFactory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SoapFactory] SET  MULTI_USER 
GO
ALTER DATABASE [SoapFactory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoapFactory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoapFactory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoapFactory] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoapFactory] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoapFactory] SET QUERY_STORE = OFF
GO
USE [SoapFactory]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SoapFactory]
GO
/****** Object:  Table [dbo].[FinancialTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialTable](
	[IdMovement] [int] IDENTITY(1,1) NOT NULL,
	[IsSelling] [bit] NOT NULL,
	[Amount] [float] NOT NULL,
	[FinancialPosition] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientStockTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientStockTable](
	[TransactionNumber] [int] IDENTITY(1,1) NOT NULL,
	[IdIngredient] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[DateOfBestUse] [date] NOT NULL,
	[Producer] [nvarchar](max) NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NULL,
	[Others] [nvarchar](max) NULL,
 CONSTRAINT [PK_IngredientStockMovemensTable] PRIMARY KEY CLUSTERED 
(
	[TransactionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredientTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientTable](
	[IdIngredient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stock] [float] NULL,
 CONSTRAINT [PK_IngredientTable1] PRIMARY KEY CLUSTERED 
(
	[IdIngredient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeTable](
	[IdRecipe] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
	[IdIngredient] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Others] [nvarchar](max) NULL,
 CONSTRAINT [PK_RecipeTable] PRIMARY KEY CLUSTERED 
(
	[IdRecipe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoapStockTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoapStockTable](
	[TransactionNumber] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[IdSoap] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SellingPrice] [float] NULL,
 CONSTRAINT [PK_SoapStockMovemensTable] PRIMARY KEY CLUSTERED 
(
	[TransactionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoapTable]    Script Date: 2017. 09. 06. 11:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoapTable](
	[IdSoap] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IdRecipe] [int] NOT NULL,
	[TimeOfProduction] [date] NOT NULL,
	[TimeOfReadyToUse] [date] NOT NULL,
	[BestBeforeDate] [date] NOT NULL,
	[InStock] [int] NOT NULL,
	[Others] [nvarchar](max) NULL,
 CONSTRAINT [PK_SoapTable] PRIMARY KEY CLUSTERED 
(
	[IdSoap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[IngredientStockTable] ON 

INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (4, 1, CAST(N'2017-08-09' AS Date), CAST(N'2019-01-20' AS Date), N'Walmark', 1000, 2500, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (5, 2, CAST(N'2016-12-20' AS Date), CAST(N'2018-02-21' AS Date), N'Hals', 3000, 2800, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (6, 3, CAST(N'2016-12-20' AS Date), CAST(N'2019-08-03' AS Date), N'Haribo', 5000, 6000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (7, 4, CAST(N'2016-11-04' AS Date), CAST(N'2017-12-10' AS Date), N'Mars', 3000, 4500, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (8, 5, CAST(N'2017-08-13' AS Date), CAST(N'2019-08-10' AS Date), N'Halasi', 450, 870, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (9, 6, CAST(N'2017-06-10' AS Date), CAST(N'2018-10-12' AS Date), N'Barna&Barna', 3000, 6500, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (10, 7, CAST(N'2017-02-13' AS Date), CAST(N'2018-03-23' AS Date), N'Lenesi', 800, 1400, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (11, 9, CAST(N'2017-08-09' AS Date), CAST(N'2017-08-20' AS Date), N'Saját', 1000, 0, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (12, 10, CAST(N'2017-01-20' AS Date), CAST(N'2019-02-10' AS Date), N'Hódossy', 4500, 8000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (13, 11, CAST(N'2017-05-10' AS Date), CAST(N'2020-10-10' AS Date), N'Accony', 3000, 2000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (14, 12, CAST(N'2017-08-09' AS Date), CAST(N'2017-12-10' AS Date), N'saját', 1000, 0, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (15, 13, CAST(N'2016-11-18' AS Date), CAST(N'2019-08-21' AS Date), N'Conagra', 3000, 2300, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (16, 14, CAST(N'2017-09-11' AS Date), CAST(N'2020-10-10' AS Date), N'C&C', 2000, 2800, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (17, 15, CAST(N'2017-05-10' AS Date), CAST(N'2018-05-20' AS Date), N'Vénusz', 5000, 2800, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (18, 2, CAST(N'2017-10-12' AS Date), CAST(N'2017-11-20' AS Date), N'xyz', 1000, 2000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (19, 11, CAST(N'2017-03-10' AS Date), CAST(N'2018-04-10' AS Date), N'x', 500, 2000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (20, 8, CAST(N'2016-10-10' AS Date), CAST(N'2020-01-01' AS Date), N'x', 1000, 2000, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (21, 9, CAST(N'2017-01-10' AS Date), CAST(N'2018-02-10' AS Date), N'y', 2000, 2300, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (22, 12, CAST(N'2016-12-10' AS Date), CAST(N'2017-12-10' AS Date), N'd', 800, 1200, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (23, 16, CAST(N'2017-08-10' AS Date), CAST(N'2017-08-12' AS Date), N'saját termesztés', 500, 0, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (24, 17, CAST(N'2017-08-10' AS Date), CAST(N'2017-08-10' AS Date), N'saját termesztés', 1000, 0, NULL)
INSERT [dbo].[IngredientStockTable] ([TransactionNumber], [IdIngredient], [Date], [DateOfBestUse], [Producer], [Quantity], [Price], [Others]) VALUES (25, 1, CAST(N'2017-08-10' AS Date), CAST(N'2017-08-10' AS Date), N'xc', 1000, 1200, NULL)
SET IDENTITY_INSERT [dbo].[IngredientStockTable] OFF
SET IDENTITY_INSERT [dbo].[IngredientTable] ON 

INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (1, N'kakaóvaj', 3000)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (2, N'argánolaj', 4000)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (3, N'kókuszzsír', 5000)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (4, N'szőlőmagolaj', 300)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (5, N'ricinusolaj', 500)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (6, N'mandulaolaj', 800)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (7, N'lenmagolaj', 1000)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (8, N'mandulaolaj', 1400)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (9, N'diőfőzet', 2500)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (10, N'sheavaj', 200)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (11, N'repceolaj', 500)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (12, N'babérlevél macerátum', 1200)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (13, N'jojoba olaj', 500)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (14, N'avocado olaj', 800)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (15, N'napraforgóolaj', 900)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (16, N'pitypang', 500)
INSERT [dbo].[IngredientTable] ([IdIngredient], [Name], [Stock]) VALUES (17, N'levendulamacerátum', 1000)
SET IDENTITY_INSERT [dbo].[IngredientTable] OFF
SET IDENTITY_INSERT [dbo].[RecipeTable] ON 

INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (4, N'diószappan', CAST(N'2017-08-09' AS Date), 10, 100, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (5, N'diószappan', CAST(N'2017-08-09' AS Date), 3, 600, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (6, N'diószappan', CAST(N'2017-08-09' AS Date), 4, 150, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (7, N'diószappan', CAST(N'2017-08-09' AS Date), 5, 80, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (8, N'diószappan', CAST(N'2017-08-09' AS Date), 6, 40, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (9, N'diószappan', CAST(N'2017-08-09' AS Date), 7, 20, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (10, N'diószappan', CAST(N'2017-08-09' AS Date), 1, 150, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (11, N'mandulaszappan', CAST(N'2017-08-09' AS Date), 1, 280, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (12, N'mandulaszappan', CAST(N'2017-08-09' AS Date), 13, 500, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (13, N'mandulaszappan', CAST(N'2017-08-09' AS Date), 7, 300, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (14, N'mandulaszappan', CAST(N'2017-08-09' AS Date), 12, 800, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (15, N'mandulaszappan', CAST(N'2017-08-09' AS Date), 15, 400, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (16, N'levendula szappan', CAST(N'2017-05-20' AS Date), 1, 600, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (17, N'levendula szappan', CAST(N'2017-05-20' AS Date), 8, 300, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (18, N'levendula szappan', CAST(N'2017-05-20' AS Date), 3, 320, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (19, N'levendula szappan', CAST(N'2017-05-20' AS Date), 4, 60, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (20, N'levendula szappan', CAST(N'2017-05-20' AS Date), 10, 120, NULL)
INSERT [dbo].[RecipeTable] ([IdRecipe], [Name], [Date], [IdIngredient], [Quantity], [Others]) VALUES (21, N'levendula szappan', CAST(N'2017-05-20' AS Date), 17, 200, NULL)
SET IDENTITY_INSERT [dbo].[RecipeTable] OFF
SET IDENTITY_INSERT [dbo].[SoapStockTable] ON 

INSERT [dbo].[SoapStockTable] ([TransactionNumber], [Date], [IdSoap], [Quantity], [SellingPrice]) VALUES (6, CAST(N'2017-09-06' AS Date), 2, 2, 1000)
SET IDENTITY_INSERT [dbo].[SoapStockTable] OFF
SET IDENTITY_INSERT [dbo].[SoapTable] ON 

INSERT [dbo].[SoapTable] ([IdSoap], [Name], [IdRecipe], [TimeOfProduction], [TimeOfReadyToUse], [BestBeforeDate], [InStock], [Others]) VALUES (2, N'aromás diós', 4, CAST(N'2017-08-10' AS Date), CAST(N'2017-08-10' AS Date), CAST(N'2017-08-10' AS Date), 10, NULL)
INSERT [dbo].[SoapTable] ([IdSoap], [Name], [IdRecipe], [TimeOfProduction], [TimeOfReadyToUse], [BestBeforeDate], [InStock], [Others]) VALUES (3, N'krémes állagú diószappan', 4, CAST(N'2017-09-05' AS Date), CAST(N'2017-09-05' AS Date), CAST(N'2017-09-05' AS Date), 0, NULL)
INSERT [dbo].[SoapTable] ([IdSoap], [Name], [IdRecipe], [TimeOfProduction], [TimeOfReadyToUse], [BestBeforeDate], [InStock], [Others]) VALUES (5, N'levendulaszappa-illatos', 16, CAST(N'2017-09-05' AS Date), CAST(N'2017-09-05' AS Date), CAST(N'2017-09-05' AS Date), 10, NULL)
SET IDENTITY_INSERT [dbo].[SoapTable] OFF
ALTER TABLE [dbo].[IngredientStockTable]  WITH CHECK ADD  CONSTRAINT [FK_IngredientStockTable_IngredientTable1] FOREIGN KEY([IdIngredient])
REFERENCES [dbo].[IngredientTable] ([IdIngredient])
GO
ALTER TABLE [dbo].[IngredientStockTable] CHECK CONSTRAINT [FK_IngredientStockTable_IngredientTable1]
GO
ALTER TABLE [dbo].[RecipeTable]  WITH CHECK ADD  CONSTRAINT [FK_RecipeTable_IngredientTable] FOREIGN KEY([IdIngredient])
REFERENCES [dbo].[IngredientTable] ([IdIngredient])
GO
ALTER TABLE [dbo].[RecipeTable] CHECK CONSTRAINT [FK_RecipeTable_IngredientTable]
GO
ALTER TABLE [dbo].[SoapStockTable]  WITH CHECK ADD  CONSTRAINT [FK_SoapStockTable_SoapTable] FOREIGN KEY([IdSoap])
REFERENCES [dbo].[SoapTable] ([IdSoap])
GO
ALTER TABLE [dbo].[SoapStockTable] CHECK CONSTRAINT [FK_SoapStockTable_SoapTable]
GO
ALTER TABLE [dbo].[SoapTable]  WITH CHECK ADD  CONSTRAINT [FK_SoapTable_RecipeTable] FOREIGN KEY([IdRecipe])
REFERENCES [dbo].[RecipeTable] ([IdRecipe])
GO
ALTER TABLE [dbo].[SoapTable] CHECK CONSTRAINT [FK_SoapTable_RecipeTable]
GO
USE [master]
GO
ALTER DATABASE [SoapFactory] SET  READ_WRITE 
GO
