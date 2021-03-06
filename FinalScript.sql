USE [master]
GO
/****** Object:  Database [Plants]    Script Date: 2019-01-11 14:22:44 ******/
CREATE DATABASE [Plants]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Plants', FILENAME = N'C:\Users\Administrator\Plants.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Plants_log', FILENAME = N'C:\Users\Administrator\Plants_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Plants] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Plants].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Plants] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Plants] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Plants] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Plants] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Plants] SET ARITHABORT OFF 
GO
ALTER DATABASE [Plants] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Plants] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Plants] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Plants] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Plants] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Plants] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Plants] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Plants] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Plants] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Plants] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Plants] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Plants] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Plants] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Plants] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Plants] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Plants] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Plants] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Plants] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Plants] SET  MULTI_USER 
GO
ALTER DATABASE [Plants] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Plants] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Plants] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Plants] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Plants] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Plants] SET QUERY_STORE = OFF
GO
USE [Plants]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Plants]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] NOT NULL,
	[Comment] [text] NULL,
	[UserID] [int] NULL,
	[Time] [date] NULL,
	[Likes] [int] NULL,
	[CommentTypeId] [int] NULL,
	[PlantId] [int] NULL,
	[UserPlantId] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentType]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentType](
	[CommentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_CommentType] PRIMARY KEY CLUSTERED 
(
	[CommentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nutrition]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nutrition](
	[NutritionId] [int] IDENTITY(1,1) NOT NULL,
	[NutritionType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nutrition] PRIMARY KEY CLUSTERED 
(
	[NutritionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Origin]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Origin](
	[OriginId] [int] IDENTITY(1,1) NOT NULL,
	[Zone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Origin] PRIMARY KEY CLUSTERED 
(
	[OriginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plant]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plant](
	[Name] [nvarchar](50) NULL,
	[PlantId] [int] IDENTITY(1,1) NOT NULL,
	[LatinName] [nvarchar](150) NOT NULL,
	[LocationId] [int] NULL,
	[WaterFrekuenseInDays] [int] NULL,
	[PlantTypeId] [int] NULL,
	[ScentId] [int] NULL,
	[SoilId] [int] NULL,
	[NutritionId] [int] NULL,
	[OriginId] [int] NULL,
	[PoisonId] [int] NULL,
	[GeneralInfo] [text] NULL,
 CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED 
(
	[PlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlantToLocation]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantToLocation](
	[LocationId] [int] NOT NULL,
	[PlantId] [int] NOT NULL,
 CONSTRAINT [PK_PlantToLocation] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC,
	[PlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlantType]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantType](
	[PlantTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PlantType] [nvarchar](50) NULL,
 CONSTRAINT [PK_PlantType] PRIMARY KEY CLUSTERED 
(
	[PlantTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poison]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poison](
	[PoisonId] [int] IDENTITY(1,1) NOT NULL,
	[PoisonType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Poison] PRIMARY KEY CLUSTERED 
(
	[PoisonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scent]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scent](
	[ScentId] [int] IDENTITY(1,1) NOT NULL,
	[Scent] [nvarchar](50) NULL,
 CONSTRAINT [PK_Scent] PRIMARY KEY CLUSTERED 
(
	[ScentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soil]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soil](
	[SoilId] [int] IDENTITY(1,1) NOT NULL,
	[SoilType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Soil] PRIMARY KEY CLUSTERED 
(
	[SoilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
	[UserLocationId] [int] NULL,
	[ZoneId] [int] NULL,
	[UserLevelId] [int] NULL,
	[Email] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLevelId]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLevelId](
	[UserLevelId] [int] IDENTITY(1,1) NOT NULL,
	[UserLevel] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserLevelId] PRIMARY KEY CLUSTERED 
(
	[UserLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPlants]    Script Date: 2019-01-11 14:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPlants](
	[UserPlantId] [int] IDENTITY(1,1) NOT NULL,
	[PlantId] [int] NULL,
	[LocationId] [int] NULL,
	[WaterFrekuenseInDays] [int] NULL,
	[SoildId] [int] NULL,
	[NutritionId] [int] NULL,
	[BoughtDate] [datetime] NULL,
	[Comment] [text] NULL,
	[UserId] [int] NULL,
	[LastWater] [datetime] NULL,
 CONSTRAINT [PK_UserPlants] PRIMARY KEY CLUSTERED 
(
	[UserPlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (1, N'Norr')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (2, N'Söder')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (3, N'Västligt')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (4, N'Östligt')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (5, N'Utan solljus')
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Nutrition] ON 

INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (1, N'Flower Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (2, N'Green Plants')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (3, N'Medeterian Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (4, N'Tomato Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (5, N'Orcid Plant')
SET IDENTITY_INSERT [dbo].[Nutrition] OFF
SET IDENTITY_INSERT [dbo].[Origin] ON 

INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (1, N'Polar')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (2, N'Tempererat')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (3, N'Bergsmiljö')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (4, N'Medelhavet')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (5, N'Öken')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (6, N'Tropiskt')
SET IDENTITY_INSERT [dbo].[Origin] OFF
SET IDENTITY_INSERT [dbo].[Plant] ON 

INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Hortensia', 1, N'Hydrangea macrophylla', 3, 3, 1, 1, 4, 1, 4, 1, N'Nice Flower ')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Zonalpelargon', 2, N'Pelargonium x hortorum', 3, 7, 1, 2, 7, 1, 4, 1, N'Ugly Flower')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Zamiakalla', 3, N'Zamioculcas Zamijofolia', 5, 14, 4, 1, 4, 2, 6, 1, N'Never Dies')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Kalle', 4, N'Bengt', 1, 5, 1, 1, 1, 1, 1, 1, N'Hejhej')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Kanariepalm', 5, N'Phoenix canariensis', 2, 5, 4, 1, 3, 3, 4, 1, N'Kan växa sig stor och fin.')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Rosenkalla', 6, N'Anthurium Andraeanum', 3, 7, 1, 2, 5, 3, 4, 2, N'Elegant växt med luftrenande egenskaper.')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Narrfikus', 7, N'Clusia rosea ''Princess''', 4, 14, 4, 1, 2, 2, 5, 1, N'Fin och lättskött växt med stora, blanka blad.')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Monstera', 10, N'Monstera deliciosa', 4, 7, 4, 1, 2, 4, 4, 1, N'Mycket lättskött växt med stora, vackra blad.')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Brudorkidé', 11, N'Phalaenopsis cvs.', 3, 14, 1, 3, 4, 3, 6, 2, N'Underbart vacker och dessutom lättskött!')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Svärmors kudde', 12, N'Echinocactus grusonii', 2, 30, 2, 1, 1, 1, 5, 1, N'Rund kaktus med hårda ljusa taggar.')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Körsbärstomat', 14, N'Solanum lycopersicum var. cerasiforme', 2, 5, 3, 2, 4, 4, 2, 1, N'Ger rikligt med små, goda frukter tidigt på säsongen. ')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Spansk peppar', 15, N'Capsicum annuum', 2, 7, 3, 1, 6, 3, 4, 1, N'Den hetaste grönsaken! Passar bra att odla i kruka.')
SET IDENTITY_INSERT [dbo].[Plant] OFF
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (1, 3)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (2, 1)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (2, 2)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (3, 1)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (3, 2)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (5, 3)
SET IDENTITY_INSERT [dbo].[PlantType] ON 

INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (1, N'Blommande')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (2, N'Kaktus')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (3, N'Matplanta')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (4, N'Grön planta')
SET IDENTITY_INSERT [dbo].[PlantType] OFF
SET IDENTITY_INSERT [dbo].[Poison] ON 

INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (1, N'None')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (2, N'Low')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (3, N'Medium')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (4, N'High')
SET IDENTITY_INSERT [dbo].[Poison] OFF
SET IDENTITY_INSERT [dbo].[Scent] ON 

INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (1, N'None')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (2, N'Low')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (3, N'Medium')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (4, N'High')
SET IDENTITY_INSERT [dbo].[Scent] OFF
SET IDENTITY_INSERT [dbo].[Soil] ON 

INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (1, N'Nutrition Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (2, N'Sand Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (3, N'Mud Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (4, N'Flower Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (5, N'Medeterianian Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (6, N'Tomato Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (7, N'Geranium Soil')
SET IDENTITY_INSERT [dbo].[Soil] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (1, N'Admin', N'Admin', 1, 4, 1, N'test@test.se')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (3, N'Jonte', N'Tobbe', 2, 3, 2, N'jon.risberg@gmail.com')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (4, N'Tobbe', N'Jonte', 3, 2, 3, N'spara.Energi@gmail.com')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (5, N'Sara', N'sara', 4, 1, 4, N'sara@sara.se')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserLevelId] ON 

INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (1, N'Admin')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (2, N'Beginer')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (3, N'Experienced')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (4, N'Advanced')
SET IDENTITY_INSERT [dbo].[UserLevelId] OFF
SET IDENTITY_INSERT [dbo].[UserPlants] ON 

INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (2, 2, 1, 30, 1, 1, CAST(N'2019-01-09T00:00:00.000' AS DateTime), N'Den är gul', 4, CAST(N'2019-01-09T00:00:00.000' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (3, 3, 2, 14, 1, 3, CAST(N'2018-12-24T00:00:00.000' AS DateTime), N'Finaste blomman jag har', 3, CAST(N'2018-12-24T00:00:00.000' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (4, 1, 3, 7, 5, 3, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Den är mycket vacker', 5, CAST(N'2019-01-10T22:04:30.793' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (5, 1, 1, 3, 1, 1, CAST(N'1855-01-05T00:00:00.000' AS DateTime), N'Arv-Planta', 5, CAST(N'2019-01-11T10:45:06.073' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (6, 4, 1, 10, 1, 1, CAST(N'1989-07-07T00:00:00.000' AS DateTime), N'Bästa plantAN', 5, CAST(N'2019-01-11T14:16:01.387' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (7, 15, 2, 7, 6, 3, CAST(N'2018-08-23T00:00:00.000' AS DateTime), N'Får snart blommor', 4, CAST(N'2019-01-11T14:11:32.410' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (8, 10, 4, 7, 2, 4, CAST(N'2019-01-02T00:00:00.000' AS DateTime), N'Väldigt vacker', 4, CAST(N'2019-01-11T14:11:58.380' AS DateTime))
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId], [LastWater]) VALUES (9, 5, 2, 5, 3, 3, CAST(N'2009-07-07T00:00:00.000' AS DateTime), N'Riktigt stor nu', 4, CAST(N'2019-01-11T14:12:46.987' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserPlants] OFF
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([CommentId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Comment]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_CommentType] FOREIGN KEY([CommentTypeId])
REFERENCES [dbo].[CommentType] ([CommentTypeId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_CommentType]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Plant] FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([PlantId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Plant]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_UserPlants] FOREIGN KEY([UserPlantId])
REFERENCES [dbo].[UserPlants] ([UserPlantId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_UserPlants]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_Nutrition] FOREIGN KEY([NutritionId])
REFERENCES [dbo].[Nutrition] ([NutritionId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_Nutrition]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_Origin] FOREIGN KEY([OriginId])
REFERENCES [dbo].[Origin] ([OriginId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_Origin]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_PlantType] FOREIGN KEY([PlantTypeId])
REFERENCES [dbo].[PlantType] ([PlantTypeId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_PlantType]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_Poison] FOREIGN KEY([PoisonId])
REFERENCES [dbo].[Poison] ([PoisonId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_Poison]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_Scent] FOREIGN KEY([ScentId])
REFERENCES [dbo].[Scent] ([ScentId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_Scent]
GO
ALTER TABLE [dbo].[Plant]  WITH CHECK ADD  CONSTRAINT [FK_Plant_Soil] FOREIGN KEY([SoilId])
REFERENCES [dbo].[Soil] ([SoilId])
GO
ALTER TABLE [dbo].[Plant] CHECK CONSTRAINT [FK_Plant_Soil]
GO
ALTER TABLE [dbo].[PlantToLocation]  WITH CHECK ADD  CONSTRAINT [FK_PlantToLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[PlantToLocation] CHECK CONSTRAINT [FK_PlantToLocation_Location]
GO
ALTER TABLE [dbo].[PlantToLocation]  WITH CHECK ADD  CONSTRAINT [FK_PlantToLocation_Plant] FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([PlantId])
GO
ALTER TABLE [dbo].[PlantToLocation] CHECK CONSTRAINT [FK_PlantToLocation_Plant]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Origin] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Origin] ([OriginId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Origin]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserLevelId] FOREIGN KEY([UserLevelId])
REFERENCES [dbo].[UserLevelId] ([UserLevelId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserLevelId]
GO
ALTER TABLE [dbo].[UserPlants]  WITH CHECK ADD  CONSTRAINT [FK_UserPlants_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[UserPlants] CHECK CONSTRAINT [FK_UserPlants_Location]
GO
ALTER TABLE [dbo].[UserPlants]  WITH CHECK ADD  CONSTRAINT [FK_UserPlants_Nutrition] FOREIGN KEY([NutritionId])
REFERENCES [dbo].[Nutrition] ([NutritionId])
GO
ALTER TABLE [dbo].[UserPlants] CHECK CONSTRAINT [FK_UserPlants_Nutrition]
GO
ALTER TABLE [dbo].[UserPlants]  WITH CHECK ADD  CONSTRAINT [FK_UserPlants_Plant1] FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([PlantId])
GO
ALTER TABLE [dbo].[UserPlants] CHECK CONSTRAINT [FK_UserPlants_Plant1]
GO
ALTER TABLE [dbo].[UserPlants]  WITH CHECK ADD  CONSTRAINT [FK_UserPlants_Soil] FOREIGN KEY([SoildId])
REFERENCES [dbo].[Soil] ([SoilId])
GO
ALTER TABLE [dbo].[UserPlants] CHECK CONSTRAINT [FK_UserPlants_Soil]
GO
ALTER TABLE [dbo].[UserPlants]  WITH CHECK ADD  CONSTRAINT [FK_UserPlants_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserPlants] CHECK CONSTRAINT [FK_UserPlants_User]
GO
USE [master]
GO
ALTER DATABASE [Plants] SET  READ_WRITE 
GO
