/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [JobFair]    Script Date: 12/13/2017 11:21:14 AM ******/
/*CREATE DATABASE [JobFair]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobFair', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\JobFair.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobFair_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\JobFair_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
*/
ALTER DATABASE [JobFair] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobFair].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobFair] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobFair] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobFair] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobFair] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobFair] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobFair] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JobFair] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobFair] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobFair] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobFair] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobFair] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobFair] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobFair] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobFair] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobFair] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JobFair] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobFair] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobFair] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobFair] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobFair] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobFair] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JobFair] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobFair] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JobFair] SET  MULTI_USER 
GO
ALTER DATABASE [JobFair] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobFair] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobFair] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobFair] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobFair] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobFair] SET QUERY_STORE = OFF
GO
USE [JobFair]
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
USE [JobFair]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Candidates_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Description] [text] NULL,
	[Email] [varchar](25) NULL,
	[Phone] [varchar](13) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyInterviewers]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInterviewers](
	[CompanyID] [int] NOT NULL,
	[InterviewerID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interviewers]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviewers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_Interviewers_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterviewInterviewers]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterviewInterviewers](
	[InterviewerID] [int] NOT NULL,
	[InterviewID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interviews]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobFairID] [int] NOT NULL,
	[CandidateID] [int] NOT NULL,
	[TimeSlotID] [int] NOT NULL,
	[TableID] [int] NOT NULL,
 CONSTRAINT [PK_Interviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First] [varchar](15) NOT NULL,
	[MI] [char](1) NULL,
	[Last] [varchar](20) NOT NULL,
	[Title] [varchar](10) NULL,
	[Address1] [varchar](25) NULL,
	[Address2] [varchar](25) NULL,
	[City] [varchar](20) NULL,
	[State] [varchar](2) NULL,
	[Zip] [varchar](10) NULL,
	[EMail] [varchar](35) NULL,
	[Phone] [varchar](13) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlots]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlots](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobFairID] [int] NOT NULL,
	[DayID] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeSlots_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InterviewInfo_1]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InterviewInfo_1]
AS
SELECT        dbo.Interviews.ID, CandidateNames.First, CandidateNames.MI, CandidateNames.Last, InterviewCompanyNames.Name, dbo.Interviews.TableID, TimeSlots_1.StartTime
FROM            dbo.Interviews INNER JOIN
                             (SELECT        dbo.Candidates.ID, dbo.People.First, dbo.People.MI, dbo.People.Last
                               FROM            dbo.Candidates INNER JOIN
                                                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID) AS CandidateNames ON dbo.Interviews.CandidateID = CandidateNames.ID INNER JOIN
                             (SELECT        dbo.InterviewInterviewers.InterviewID, dbo.Companies.Name
                               FROM            dbo.InterviewInterviewers INNER JOIN
                                                         dbo.Interviewers ON dbo.InterviewInterviewers.InterviewerID = dbo.Interviewers.ID INNER JOIN
                                                         dbo.CompanyInterviewers ON dbo.Interviewers.ID = dbo.CompanyInterviewers.InterviewerID INNER JOIN
                                                         dbo.Companies ON dbo.CompanyInterviewers.CompanyID = dbo.Companies.ID) AS InterviewCompanyNames ON dbo.Interviews.ID = InterviewCompanyNames.InterviewID INNER JOIN
                         dbo.TimeSlots AS TimeSlots_1 ON dbo.Interviews.TimeSlotID = TimeSlots_1.ID
GO
/****** Object:  Table [dbo].[JobFairs]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobFairs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Website] [varchar](75) NULL,
	[Phone] [varchar](13) NULL,
	[ContactPersonID] [int] NULL,
 CONSTRAINT [PK_JobFairs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[testView]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[testView]
AS
SELECT        dbo.People.First, dbo.People.MI, dbo.People.Last, dbo.JobFairs.Title, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime
FROM            dbo.Interviews INNER JOIN
                         dbo.People ON dbo.Interviews.ID = dbo.People.ID INNER JOIN
                         dbo.Interviewers ON dbo.People.ID = dbo.Interviewers.PersonID INNER JOIN
                         dbo.Candidates ON dbo.Interviews.CandidateID = dbo.Candidates.ID AND dbo.People.ID = dbo.Candidates.PersonID INNER JOIN
                         dbo.JobFairs ON dbo.Interviews.ID = dbo.JobFairs.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID AND dbo.JobFairs.ID = dbo.TimeSlots.JobFairID
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobFairID] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
	[Accessible] [bit] NULL,
	[HasPower] [bit] NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[test2]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[test2]
AS
SELECT        dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.TimeSlots.DayID, dbo.Tables.ID, dbo.People.First, dbo.People.Last, dbo.Companies.Name, dbo.JobFairs.Title
FROM            dbo.Candidates INNER JOIN
                         dbo.Companies ON dbo.Candidates.ID = dbo.Companies.ID INNER JOIN
                         dbo.Interviewers ON dbo.Candidates.ID = dbo.Interviewers.ID INNER JOIN
                         dbo.Interviews ON dbo.Candidates.ID = dbo.Interviews.CandidateID INNER JOIN
                         dbo.JobFairs ON dbo.Candidates.ID = dbo.JobFairs.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID AND dbo.Interviewers.PersonID = dbo.People.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID AND dbo.JobFairs.ID = dbo.TimeSlots.JobFairID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID
GO
/****** Object:  Table [dbo].[JobFairDays]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobFairDays](
	[ID] [int] NOT NULL,
	[JobFairID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[test3BecauseIKeepFuckingUp]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[test3BecauseIKeepFuckingUp]
AS
SELECT        dbo.Companies.Name, dbo.People.First, dbo.People.Last, dbo.JobFairs.Title, dbo.TimeSlots.DayID, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.JobFairDays.ID AS Expr2, dbo.Tables.ID AS Expr1
FROM            dbo.Interviews INNER JOIN
                         dbo.Companies ON dbo.Interviews.ID = dbo.Companies.ID INNER JOIN
                         dbo.Candidates ON dbo.Interviews.CandidateID = dbo.Candidates.ID INNER JOIN
                         dbo.JobFairDays ON dbo.Interviews.ID = dbo.JobFairDays.ID INNER JOIN
                         dbo.JobFairs ON dbo.JobFairDays.JobFairID = dbo.JobFairs.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID AND dbo.JobFairs.ID = dbo.TimeSlots.JobFairID
GO
/****** Object:  View [dbo].[testNumberFucking5lmao]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[testNumberFucking5lmao]
AS
SELECT        dbo.JobFairs.Title, dbo.Companies.Name, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime
FROM            dbo.JobFairs INNER JOIN
                         dbo.Companies ON dbo.JobFairs.ID = dbo.Companies.ID INNER JOIN
                         dbo.Candidates ON dbo.JobFairs.ID = dbo.Candidates.ID INNER JOIN
                         dbo.Interviews ON dbo.Candidates.ID = dbo.Interviews.CandidateID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID INNER JOIN
                         dbo.TimeSlots ON dbo.JobFairs.ID = dbo.TimeSlots.JobFairID AND dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID
GO
/****** Object:  View [dbo].[iWantToDie]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[iWantToDie]
AS
SELECT        dbo.Companies.Name
FROM            dbo.Companies INNER JOIN
                         dbo.Interviews ON dbo.Companies.ID = dbo.Interviews.ID
GO
/****** Object:  View [dbo].[iAmSoConfused]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[iAmSoConfused]
AS
SELECT        dbo.Companies.Name
FROM            dbo.Interviews INNER JOIN
                         dbo.Companies ON dbo.Interviews.ID = dbo.Companies.ID
GO
/****** Object:  View [dbo].[ISwearToGod]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ISwearToGod]
AS
SELECT        dbo.People.First, dbo.Tables.ID, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.TimeSlots.DayID, dbo.JobFairs.Title, dbo.Companies.Name
FROM            dbo.People INNER JOIN
                         dbo.Tables ON dbo.People.ID = dbo.Tables.ID INNER JOIN
                         dbo.TimeSlots ON dbo.People.ID = dbo.TimeSlots.ID INNER JOIN
                         dbo.JobFairs ON dbo.TimeSlots.JobFairID = dbo.JobFairs.ID INNER JOIN
                         dbo.JobFairDays ON dbo.JobFairs.ID = dbo.JobFairDays.JobFairID INNER JOIN
                         dbo.Companies ON dbo.People.ID = dbo.Companies.ID INNER JOIN
                         dbo.Interviews ON dbo.Tables.ID = dbo.Interviews.TableID AND dbo.TimeSlots.ID = dbo.Interviews.TimeSlotID INNER JOIN
                         dbo.Candidates ON dbo.People.ID = dbo.Candidates.PersonID AND dbo.Interviews.CandidateID = dbo.Candidates.ID
GO
/****** Object:  View [dbo].[iDontEvenKnow]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[iDontEvenKnow]
AS
SELECT        dbo.People.First, dbo.People.Last, dbo.JobFairs.Title, dbo.Companies.Name, dbo.TimeSlots.DayID, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime
FROM            dbo.Candidates INNER JOIN
                         dbo.Companies ON dbo.Candidates.ID = dbo.Companies.ID INNER JOIN
                         dbo.Interviews ON dbo.Candidates.ID = dbo.Interviews.CandidateID INNER JOIN
                         dbo.JobFairs ON dbo.Candidates.ID = dbo.JobFairs.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID AND dbo.JobFairs.ID = dbo.TimeSlots.JobFairID
GO
/****** Object:  View [dbo].[WhatTheFUck]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[WhatTheFUck]
AS
SELECT        dbo.People.First, dbo.People.Last, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.Companies.Name
FROM            dbo.Interviews INNER JOIN
                         dbo.Candidates ON dbo.Interviews.CandidateID = dbo.Candidates.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID INNER JOIN
                         dbo.Companies ON dbo.Interviews.ID = dbo.Companies.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID
GO
/****** Object:  View [dbo].[okay]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[okay]
AS
SELECT        dbo.People.First, dbo.People.Last, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.Tables.ID, dbo.JobFairs.Title
FROM            dbo.Interviews INNER JOIN
                         dbo.Candidates ON dbo.Interviews.CandidateID = dbo.Candidates.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID INNER JOIN
                         dbo.JobFairs ON dbo.TimeSlots.JobFairID = dbo.JobFairs.ID
GO
/****** Object:  Table [dbo].[JobFairVenues]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobFairVenues](
	[JobFairID] [int] NOT NULL,
	[VenueID] [int] NOT NULL,
 CONSTRAINT [PK_JobFairVenues] PRIMARY KEY CLUSTERED 
(
	[JobFairID] ASC,
	[VenueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VenueID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venues]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Short Description] [varchar](255) NULL,
	[Long Description] [varchar](max) NULL,
 CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[TEST]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TEST]
AS
SELECT        dbo.People.First, dbo.People.Last, dbo.TimeSlots.StartTime, dbo.TimeSlots.EndTime, dbo.JobFairs.Title
FROM            dbo.JobFairVenues INNER JOIN
                         dbo.Interviews INNER JOIN
                         dbo.Candidates ON dbo.Interviews.CandidateID = dbo.Candidates.ID INNER JOIN
                         dbo.People ON dbo.Candidates.PersonID = dbo.People.ID INNER JOIN
                         dbo.TimeSlots ON dbo.Interviews.TimeSlotID = dbo.TimeSlots.ID INNER JOIN
                         dbo.JobFairs ON dbo.TimeSlots.JobFairID = dbo.JobFairs.ID ON dbo.JobFairVenues.JobFairID = dbo.JobFairs.ID INNER JOIN
                         dbo.Venues INNER JOIN
                         dbo.Locations ON dbo.Venues.ID = dbo.Locations.VenueID ON dbo.JobFairVenues.VenueID = dbo.Venues.ID INNER JOIN
                         dbo.Locations AS Locations_1 ON dbo.Venues.ID = Locations_1.VenueID INNER JOIN
                         dbo.Tables ON dbo.Interviews.TableID = dbo.Tables.ID AND dbo.Locations.ID = dbo.Tables.LocationID AND Locations_1.ID = dbo.Tables.LocationID INNER JOIN
                         dbo.Interviewers ON dbo.People.ID = dbo.Interviewers.PersonID INNER JOIN
                         dbo.InterviewInterviewers ON dbo.Interviews.ID = dbo.InterviewInterviewers.InterviewID AND dbo.Interviewers.ID = dbo.InterviewInterviewers.InterviewerID INNER JOIN
                         dbo.JobFairVenues AS JobFairVenues_1 ON dbo.JobFairs.ID = JobFairVenues_1.JobFairID AND dbo.Venues.ID = JobFairVenues_1.VenueID
GO
/****** Object:  Table [dbo].[CompanyInterests]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInterests](
	[CompanyID] [int] NOT NULL,
	[InterestID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 12/13/2017 11:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NULL,
 CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [FK_Candidates_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [FK_Candidates_People]
GO
ALTER TABLE [dbo].[CompanyInterests]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInterests_Companies] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[CompanyInterests] CHECK CONSTRAINT [FK_CompanyInterests_Companies]
GO
ALTER TABLE [dbo].[CompanyInterests]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInterests_Specialties] FOREIGN KEY([InterestID])
REFERENCES [dbo].[Specialties] ([ID])
GO
ALTER TABLE [dbo].[CompanyInterests] CHECK CONSTRAINT [FK_CompanyInterests_Specialties]
GO
ALTER TABLE [dbo].[CompanyInterviewers]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInterviewers_Companies] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([ID])
GO
ALTER TABLE [dbo].[CompanyInterviewers] CHECK CONSTRAINT [FK_CompanyInterviewers_Companies]
GO
ALTER TABLE [dbo].[CompanyInterviewers]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyInterviewers_Interviewers] FOREIGN KEY([InterviewerID])
REFERENCES [dbo].[Interviewers] ([ID])
GO
ALTER TABLE [dbo].[CompanyInterviewers] NOCHECK CONSTRAINT [FK_CompanyInterviewers_Interviewers]
GO
ALTER TABLE [dbo].[Interviewers]  WITH NOCHECK ADD  CONSTRAINT [FK_Interviewers_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([ID])
GO
ALTER TABLE [dbo].[Interviewers] NOCHECK CONSTRAINT [FK_Interviewers_People]
GO
ALTER TABLE [dbo].[InterviewInterviewers]  WITH CHECK ADD  CONSTRAINT [FK_InterviewInterviewers_Interviews] FOREIGN KEY([InterviewID])
REFERENCES [dbo].[Interviews] ([ID])
GO
ALTER TABLE [dbo].[InterviewInterviewers] CHECK CONSTRAINT [FK_InterviewInterviewers_Interviews]
GO
ALTER TABLE [dbo].[JobFairDays]  WITH NOCHECK ADD  CONSTRAINT [FK_JobFairDays_JobFairs] FOREIGN KEY([JobFairID])
REFERENCES [dbo].[JobFairs] ([ID])
GO
ALTER TABLE [dbo].[JobFairDays] NOCHECK CONSTRAINT [FK_JobFairDays_JobFairs]
GO
ALTER TABLE [dbo].[JobFairVenues]  WITH NOCHECK ADD  CONSTRAINT [FK_JobFairVenues_JobFairs] FOREIGN KEY([JobFairID])
REFERENCES [dbo].[JobFairs] ([ID])
GO
ALTER TABLE [dbo].[JobFairVenues] NOCHECK CONSTRAINT [FK_JobFairVenues_JobFairs]
GO
ALTER TABLE [dbo].[JobFairVenues]  WITH CHECK ADD  CONSTRAINT [FK_JobFairVenues_Venues] FOREIGN KEY([VenueID])
REFERENCES [dbo].[Venues] ([ID])
GO
ALTER TABLE [dbo].[JobFairVenues] CHECK CONSTRAINT [FK_JobFairVenues_Venues]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Venues] FOREIGN KEY([VenueID])
REFERENCES [dbo].[Venues] ([ID])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Venues]
GO
ALTER TABLE [dbo].[Tables]  WITH NOCHECK ADD  CONSTRAINT [FK_Tables_Locations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locations] ([ID])
GO
ALTER TABLE [dbo].[Tables] NOCHECK CONSTRAINT [FK_Tables_Locations]
GO
ALTER TABLE [dbo].[TimeSlots]  WITH NOCHECK ADD  CONSTRAINT [FK_TimeSlots_JobFairs] FOREIGN KEY([JobFairID])
REFERENCES [dbo].[JobFairs] ([ID])
GO
ALTER TABLE [dbo].[TimeSlots] NOCHECK CONSTRAINT [FK_TimeSlots_JobFairs]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iAmSoConfused'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iAmSoConfused'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 840
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 6
               Left = 878
               Bottom = 136
               Right = 1048
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 157
               Left = 457
               Bottom = 287
               Right = 627
            End
            DisplayFlags =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iDontEvenKnow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iDontEvenKnow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iDontEvenKnow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[5] 2[36] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TimeSlots_1"
            Begin Extent = 
               Top = 138
               Left = 438
               Bottom = 268
               Right = 608
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "InterviewCompanyNames"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CandidateNames"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InterviewInfo_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InterviewInfo_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "People"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 840
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairDays"
            Begin Extent = 
               Top = 6
               Left = 878
               Bottom = 102
               Right = 1048
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 102
               Left = 878
               Bottom = 232
               Right = 1048
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 83
               Left = 110
               Bottom = 213
               Right = 280
            End
            DisplayFlags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ISwearToGod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 94
               Left = 443
               Bottom = 190
               Right = 613
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ISwearToGod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ISwearToGod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iWantToDie'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'iWantToDie'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -32
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 10
               Left = 238
               Bottom = 106
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 6
               Left = 431
               Bottom = 136
               Right = 601
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 145
               Left = 416
               Bottom = 275
               Right = 586
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 180
               Left = 209
               Bottom = 310
               Right = 379
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 116
               Left = 614
               Bottom = 246
               Right = 792
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'okay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'okay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'okay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[87] 4[4] 2[4] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 166
               Left = 876
               Bottom = 296
               Right = 1046
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 0
               Left = 390
               Bottom = 96
               Right = 560
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 57
               Left = 195
               Bottom = 187
               Right = 365
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Locations"
            Begin Extent = 
               Top = 21
               Left = 876
               Bottom = 151
               Right = 1046
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 413
               Left = 970
               Bottom = 543
               Right = 1140
            End
            DisplayFlags = 344
            TopColumn = 1
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 257
               Left = 287
               Bottom = 387
               Right = 465
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Venues"
            Begin Extent = 
               Top = 32
               Left = 642
               Bottom = 162
               Right = 822
            End
            DisplayF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TEST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'lags = 344
            TopColumn = 0
         End
         Begin Table = "JobFairVenues"
            Begin Extent = 
               Top = 343
               Left = 238
               Bottom = 439
               Right = 408
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Locations_1"
            Begin Extent = 
               Top = 94
               Left = 638
               Bottom = 224
               Right = 808
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 340
               Left = 529
               Bottom = 470
               Right = 699
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "Interviewers"
            Begin Extent = 
               Top = 103
               Left = 394
               Bottom = 199
               Right = 564
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "InterviewInterviewers"
            Begin Extent = 
               Top = 208
               Left = 196
               Bottom = 304
               Right = 366
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "JobFairVenues_1"
            Begin Extent = 
               Top = 453
               Left = 515
               Bottom = 549
               Right = 685
            End
            DisplayFlags = 344
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TEST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TEST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviewers"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 136
               Right = 1048
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 102
               Left = 454
               Bottom = 232
               Right = 624
            End
            DisplayF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'lags = 280
            TopColumn = 1
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 96
               Left = 240
               Bottom = 226
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[70] 4[5] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 435
               Left = 475
               Bottom = 565
               Right = 645
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 336
               Left = 89
               Bottom = 466
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 252
               Left = 519
               Bottom = 348
               Right = 689
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairDays"
            Begin Extent = 
               Top = 193
               Left = 891
               Bottom = 289
               Right = 1061
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 102
               Left = 454
               Bottom = 232
               Right = 632
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 19
               Left = 855
               Bottom = 149
               Right = 1025
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 312
               Left = 894
               Bottom = 442
               Right = 1064
            End
            D' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test3BecauseIKeepFuckingUp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'isplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 111
               Left = 71
               Bottom = 241
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test3BecauseIKeepFuckingUp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'test3BecauseIKeepFuckingUp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 136
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 6
               Left = 462
               Bottom = 102
               Right = 632
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 670
               Bottom = 136
               Right = 840
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tables"
            Begin Extent = 
               Top = 182
               Left = 513
               Bottom = 312
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 162
               Left = 245
               Bottom = 292
               Right = 415
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testNumberFucking5lmao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testNumberFucking5lmao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testNumberFucking5lmao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Interviewers"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 102
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobFairs"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 136
               Right = 1048
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 102
               Left = 454
               Bottom = 232
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'testView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Interviews"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Candidates"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "People"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Companies"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TimeSlots"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 136
               Right = 1040
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WhatTheFUck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WhatTheFUck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'WhatTheFUck'
GO
USE [master]
GO
ALTER DATABASE [JobFair] SET  READ_WRITE 
GO
