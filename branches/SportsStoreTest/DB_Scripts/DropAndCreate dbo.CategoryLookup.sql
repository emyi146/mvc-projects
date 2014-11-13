USE [SportsStore]
GO

/****** Objeto: Table [dbo].[CategoryLookup] Fecha del script: 12/11/2014 19:12:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[CategoryLookup];


GO
CREATE TABLE [dbo].[CategoryLookup] (
    [CategoryLookup_Id]   INT         IDENTITY (1, 1) NOT NULL,
    [CategoryLookup_Name] NCHAR (100) NOT NULL
);


