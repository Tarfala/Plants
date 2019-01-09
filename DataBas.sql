USE [master]
GO
/****** Object:  Database [Plants]    Script Date: 2019-01-09 13:48:52 ******/
CREATE DATABASE [Plants]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Plants', FILENAME = N'C:\Users\Risberg\Plants.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Plants_log', FILENAME = N'C:\Users\Risberg\Plants_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Plants] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [Plants] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[Comment]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[CommentType]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Nutrition]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Origin]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Plant]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[PlantToLocation]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[PlantType]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Poison]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Scent]    Script Date: 2019-01-09 13:48:52 ******/
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
/****** Object:  Table [dbo].[Soil]    Script Date: 2019-01-09 13:48:53 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2019-01-09 13:48:53 ******/
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
/****** Object:  Table [dbo].[UserLevelId]    Script Date: 2019-01-09 13:48:53 ******/
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
/****** Object:  Table [dbo].[UserPlants]    Script Date: 2019-01-09 13:48:53 ******/
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
	[BoughtDate] [date] NULL,
	[Comment] [text] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserPlants] PRIMARY KEY CLUSTERED 
(
	[UserPlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
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
