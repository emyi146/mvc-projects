CREATE TABLE [dbo].[ProductCategory] (
    [ProductCategory_Id]             INT      IDENTITY (1, 1) NOT NULL,
    [ProductCategory_ProdId]         INT      NOT NULL,
    [ProductCategory_CatId]          INT      NOT NULL,
    [ProductCategory_DeactivateDate] DATETIME NULL
);