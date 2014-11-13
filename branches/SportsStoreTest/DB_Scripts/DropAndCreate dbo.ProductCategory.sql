USE [SportsStore]
GO

/****** Objeto: Table [dbo].[ProductCategory] Fecha del script: 12/11/2014 19:16:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ProductCategory];


GO
CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategory_Id]             INT      IDENTITY (1, 1) NOT NULL,
    [ProductCategory_ProdId]         INT      NOT NULL,
    [ProductCategory_CatId]          INT      NOT NULL,
    [ProductCategory_DeactivateDate] DATETIME NULL
);


