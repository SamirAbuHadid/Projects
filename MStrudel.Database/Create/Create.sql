﻿-- Create DB MStrudel
IF NOT EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'MStrudel')
BEGIN
	USE [master]

	CREATE DATABASE [MStrudel]
	 CONTAINMENT = NONE
	 ON  PRIMARY 
	( NAME = N'MStrudel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014EE\MSSQL\DATA\mstrudel.mdf' , SIZE = 46272KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
	 LOG ON 
	( NAME = N'MStrudel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014EE\MSSQL\DATA\mstrudel.ldf' , SIZE = 265344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
	GO

	ALTER DATABASE [MStrudel] SET COMPATIBILITY_LEVEL = 120
	GO

	ALTER DATABASE [MStrudel] SET ANSI_NULL_DEFAULT OFF 
	GO

	ALTER DATABASE [MStrudel] SET ANSI_NULLS OFF 
	GO

	ALTER DATABASE [MStrudel] SET ANSI_PADDING OFF 
	GO

	ALTER DATABASE [MStrudel] SET ANSI_WARNINGS OFF 
	GO

	ALTER DATABASE [MStrudel] SET ARITHABORT OFF 
	GO

	ALTER DATABASE [MStrudel] SET AUTO_CLOSE OFF 
	GO

	ALTER DATABASE [MStrudel] SET AUTO_SHRINK OFF 
	GO

	ALTER DATABASE [MStrudel] SET AUTO_UPDATE_STATISTICS ON 
	GO

	ALTER DATABASE [MStrudel] SET CURSOR_CLOSE_ON_COMMIT OFF 
	GO

	ALTER DATABASE [MStrudel] SET CURSOR_DEFAULT  GLOBAL 
	GO

	ALTER DATABASE [MStrudel] SET CONCAT_NULL_YIELDS_NULL OFF 
	GO

	ALTER DATABASE [MStrudel] SET NUMERIC_ROUNDABORT OFF 
	GO

	ALTER DATABASE [MStrudel] SET QUOTED_IDENTIFIER OFF 
	GO

	ALTER DATABASE [MStrudel] SET RECURSIVE_TRIGGERS OFF 
	GO

	ALTER DATABASE [MStrudel] SET  ENABLE_BROKER 
	GO

	ALTER DATABASE [MStrudel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
	GO

	ALTER DATABASE [MStrudel] SET DATE_CORRELATION_OPTIMIZATION OFF 
	GO

	ALTER DATABASE [MStrudel] SET TRUSTWORTHY OFF 
	GO

	ALTER DATABASE [MStrudel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
	GO

	ALTER DATABASE [MStrudel] SET PARAMETERIZATION SIMPLE 
	GO

	ALTER DATABASE [MStrudel] SET READ_COMMITTED_SNAPSHOT OFF 
	GO

	ALTER DATABASE [MStrudel] SET HONOR_BROKER_PRIORITY OFF 
	GO

	ALTER DATABASE [MStrudel] SET RECOVERY SIMPLE 
	GO

	ALTER DATABASE [MStrudel] SET  MULTI_USER 
	GO

	ALTER DATABASE [MStrudel] SET PAGE_VERIFY CHECKSUM  
	GO

	ALTER DATABASE [MStrudel] SET DB_CHAINING OFF 
	GO

	ALTER DATABASE [MStrudel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
	GO

	ALTER DATABASE [MStrudel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
	GO

	ALTER DATABASE [MStrudel] SET DELAYED_DURABILITY = DISABLED 
	GO

	ALTER DATABASE [MStrudel] SET  READ_WRITE 
	GO
END
GO

USE MStrudel

CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SortId] [int] NOT NULL
 CONSTRAINT [PK_Categories] PRIMARY KEY 
(
	[CategoryID] ASC
))

insert into Categories (Name, SortId)
values ('Солодкі', 5)