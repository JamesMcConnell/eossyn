USE [master]
GO
/****** Object:  Database [Eossyn]    Script Date: 3/6/2013 1:39:02 PM ******/
CREATE DATABASE [Eossyn] ON  PRIMARY 
( NAME = N'Eossyn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Eossyn.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Eossyn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Eossyn_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Eossyn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Eossyn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Eossyn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Eossyn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Eossyn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Eossyn] SET ARITHABORT OFF 
GO
ALTER DATABASE [Eossyn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Eossyn] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Eossyn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Eossyn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Eossyn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Eossyn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Eossyn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Eossyn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Eossyn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Eossyn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Eossyn] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Eossyn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Eossyn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Eossyn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Eossyn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Eossyn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Eossyn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Eossyn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Eossyn] SET RECOVERY FULL 
GO
ALTER DATABASE [Eossyn] SET  MULTI_USER 
GO
ALTER DATABASE [Eossyn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Eossyn] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Eossyn', N'ON'
GO
USE [Eossyn]
GO
/****** Object:  Table [dbo].[CharacterClass]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterClass](
	[CharacterClassId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CharacterClass] PRIMARY KEY CLUSTERED 
(
	[CharacterClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CharacterFaction]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterFaction](
	[CharacterFactionId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CharacterFaction] PRIMARY KEY CLUSTERED 
(
	[CharacterFactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CharacterRace]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterRace](
	[CharacterRaceId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[CharacterFactionId] [int] NOT NULL,
 CONSTRAINT [PK_CharacterRace] PRIMARY KEY CLUSTERED 
(
	[CharacterRaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [ntext] NOT NULL,
	[Salt] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](128) NOT NULL,
	[LastLoginDate] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserCharacter]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCharacter](
	[UserCharacterId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CharacterName] [nvarchar](128) NOT NULL,
	[CharacterRaceId] [int] NOT NULL,
	[WorldId] [uniqueidentifier] NOT NULL,
	[CharacterClassId] [int] NOT NULL,
	[CurrentLevel] [int] NOT NULL,
 CONSTRAINT [PK_UserCharacter] PRIMARY KEY CLUSTERED 
(
	[UserCharacterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSession]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[UserSessionId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CurrentUserCharacterId] [uniqueidentifier] NOT NULL,
	[CurrentWorldId] [uniqueidentifier] NOT NULL,
	[CreatedTime] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[UserSessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSetting]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserId] [uniqueidentifier] NOT NULL,
	[LastUsedCharacterId] [uniqueidentifier] NOT NULL,
	[LastUsedWorldId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[World]    Script Date: 3/6/2013 1:39:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[World](
	[WorldId] [uniqueidentifier] NOT NULL,
	[WorldName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_World] PRIMARY KEY CLUSTERED 
(
	[WorldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CharacterClass] ON 

INSERT [dbo].[CharacterClass] ([CharacterClassId], [Description]) VALUES (1, N'Warrior')
INSERT [dbo].[CharacterClass] ([CharacterClassId], [Description]) VALUES (2, N'Mage')
INSERT [dbo].[CharacterClass] ([CharacterClassId], [Description]) VALUES (3, N'Rogue')
SET IDENTITY_INSERT [dbo].[CharacterClass] OFF
SET IDENTITY_INSERT [dbo].[CharacterFaction] ON 

INSERT [dbo].[CharacterFaction] ([CharacterFactionId], [Description]) VALUES (1, N'Good')
INSERT [dbo].[CharacterFaction] ([CharacterFactionId], [Description]) VALUES (2, N'Bad')
INSERT [dbo].[CharacterFaction] ([CharacterFactionId], [Description]) VALUES (3, N'Ugly')
SET IDENTITY_INSERT [dbo].[CharacterFaction] OFF
SET IDENTITY_INSERT [dbo].[CharacterRace] ON 

INSERT [dbo].[CharacterRace] ([CharacterRaceId], [Description], [CharacterFactionId]) VALUES (1, N'Human', 1)
INSERT [dbo].[CharacterRace] ([CharacterRaceId], [Description], [CharacterFactionId]) VALUES (2, N'Orc', 2)
INSERT [dbo].[CharacterRace] ([CharacterRaceId], [Description], [CharacterFactionId]) VALUES (3, N'Ogre', 3)
SET IDENTITY_INSERT [dbo].[CharacterRace] OFF
INSERT [dbo].[User] ([UserId], [UserName], [Password], [Salt], [EmailAddress], [LastLoginDate], [CreatedDate], [IsEnabled]) VALUES (N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'interneth3ro', N'145cb67b-cead-4f94-b135-0aef2704d1f7ef7abe6409a3ab3d3b89601d6f798e56bdf948aee1d7dc2af26cf0030f1b88f0', N'145cb67b-cead-4f94-b135-0aef2704d1f7', N'james.p.mcconnell@gmail.com', CAST(0x0726E311964F8F360B AS DateTime2), CAST(0x070000000000000000 AS DateTime2), 1)
INSERT [dbo].[UserCharacter] ([UserCharacterId], [UserId], [CharacterName], [CharacterRaceId], [WorldId], [CharacterClassId], [CurrentLevel]) VALUES (N'e11010d1-033f-44ce-9983-c44227440527', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'Vaes', 1, N'b8ee0530-744b-463e-9428-23178f6c7bff', 3, 1)
INSERT [dbo].[UserCharacter] ([UserCharacterId], [UserId], [CharacterName], [CharacterRaceId], [WorldId], [CharacterClassId], [CurrentLevel]) VALUES (N'df97d7f8-46a6-4bc8-b57f-e5d8e0762c55', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'Azash', 2, N'b8ee0530-744b-463e-9428-23178f6c7bff', 1, 1)
INSERT [dbo].[UserCharacter] ([UserCharacterId], [UserId], [CharacterName], [CharacterRaceId], [WorldId], [CharacterClassId], [CurrentLevel]) VALUES (N'f7b3398e-6b2a-4a20-b7c8-fae703f87d82', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'Anele', 3, N'81211982-5613-4f9c-b704-7b6fa35faf84', 2, 1)
INSERT [dbo].[UserSession] ([UserSessionId], [UserId], [CurrentUserCharacterId], [CurrentWorldId], [CreatedTime], [LastUpdated], [IsActive]) VALUES (N'b0962173-0e7c-418e-86da-24b5f565d020', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(0x0780DA2FA871D4360B AS DateTime2), CAST(0x07900130A871D4360B AS DateTime2), 1)
INSERT [dbo].[UserSession] ([UserSessionId], [UserId], [CurrentUserCharacterId], [CurrentWorldId], [CreatedTime], [LastUpdated], [IsActive]) VALUES (N'5718e11c-507b-4b59-b555-4644bb05b492', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(0x0760E1489D66C1360B AS DateTime2), CAST(0x0760E1489D66C1360B AS DateTime2), 0)
INSERT [dbo].[UserSession] ([UserSessionId], [UserId], [CurrentUserCharacterId], [CurrentWorldId], [CreatedTime], [LastUpdated], [IsActive]) VALUES (N'7da2fc69-211f-4cf3-a1cb-511e6841acd4', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(0x07016C106E66C1360B AS DateTime2), CAST(0x07016C106E66C1360B AS DateTime2), 0)
INSERT [dbo].[UserSession] ([UserSessionId], [UserId], [CurrentUserCharacterId], [CurrentWorldId], [CreatedTime], [LastUpdated], [IsActive]) VALUES (N'af91767c-20cb-4184-bbdf-5ca91ba2b524', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(0x07185820E763C1360B AS DateTime2), CAST(0x07185820E763C1360B AS DateTime2), 0)
INSERT [dbo].[UserSession] ([UserSessionId], [UserId], [CurrentUserCharacterId], [CurrentWorldId], [CreatedTime], [LastUpdated], [IsActive]) VALUES (N'0e4edb0f-cf33-4575-a0ca-727a5d82b4ee', N'b3e46507-eb88-4e6d-8b9a-454e4c3e6688', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', CAST(0x07CD442B0563CB360B AS DateTime2), CAST(0x07CD442B0563CB360B AS DateTime2), 0)
INSERT [dbo].[World] ([WorldId], [WorldName]) VALUES (N'b8ee0530-744b-463e-9428-23178f6c7bff', N'World 1')
INSERT [dbo].[World] ([WorldId], [WorldName]) VALUES (N'81211982-5613-4f9c-b704-7b6fa35faf84', N'World 2')
INSERT [dbo].[World] ([WorldId], [WorldName]) VALUES (N'df41208e-e8d2-46c9-8299-8f37632a51f8', N'World 3')
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CharacterRace]  WITH CHECK ADD  CONSTRAINT [FK_CharacterRace_CharacterFaction] FOREIGN KEY([CharacterFactionId])
REFERENCES [dbo].[CharacterFaction] ([CharacterFactionId])
GO
ALTER TABLE [dbo].[CharacterRace] CHECK CONSTRAINT [FK_CharacterRace_CharacterFaction]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_CharacterClass] FOREIGN KEY([CharacterClassId])
REFERENCES [dbo].[CharacterClass] ([CharacterClassId])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_CharacterClass]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_CharacterRace] FOREIGN KEY([CharacterRaceId])
REFERENCES [dbo].[CharacterRace] ([CharacterRaceId])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_CharacterRace]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_User]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_World] FOREIGN KEY([WorldId])
REFERENCES [dbo].[World] ([WorldId])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_World]
GO
ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserDefaults_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserDefaults_User]
GO
ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserDefaults_UserCharacter] FOREIGN KEY([LastUsedCharacterId])
REFERENCES [dbo].[UserCharacter] ([UserCharacterId])
GO
ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserDefaults_UserCharacter]
GO
ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserDefaults_World] FOREIGN KEY([LastUsedWorldId])
REFERENCES [dbo].[World] ([WorldId])
GO
ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserDefaults_World]
GO
USE [master]
GO
ALTER DATABASE [Eossyn] SET  READ_WRITE 
GO
