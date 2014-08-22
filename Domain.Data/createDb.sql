create database ContactApp
GO

CREATE LOGIN [ContactAppUser] WITH PASSWORD='p@55word', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
/****** Object:  User [ContactAppUser]    Script Date: 7/21/2014 1:54:34 PM ******/
CREATE USER [ContactAppUser] FOR LOGIN [ContactAppUser] WITH DEFAULT_SCHEMA=[dbo]
GO
EXEC sp_addrolemember 'db_datareader', 'ContactAppUser'
EXEC sp_addrolemember 'db_datawriter', 'ContactAppUser'
EXEC sp_addrolemember 'db_owner', 'ContactAppUser'
GO

USE [ContactApp]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 22/08/2014 17:47:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT dbo.Contact (Id, Name) VALUES (NEWID(), 'Bill')
INSERT dbo.Contact (Id, Name) VALUES (NEWID(), 'Ben')
INSERT dbo.Contact (Id, Name) VALUES (NEWID(), 'Sally')
GO



