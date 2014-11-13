USE [SportsStore]
GO

/****** Objeto: Table [dbo].[Product] Fecha del script: 12/11/2014 19:15:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Product];


GO
CREATE TABLE [dbo].[Product] (
    [Product_Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Product_Name]        NVARCHAR (100)  NOT NULL,
    [Product_Description] NVARCHAR (500)  NOT NULL,
    [Product_Category]    NVARCHAR (50)   NOT NULL,
    [Product_Price]       DECIMAL (16, 2) NOT NULL
);


