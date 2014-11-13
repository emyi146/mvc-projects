CREATE TABLE [dbo].[Product] (
    [Product_Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Product_Name]        NVARCHAR (100)  NOT NULL,
    [Product_Description] NVARCHAR (500)  NOT NULL,
    [Product_Price]       DECIMAL (16, 2) NOT NULL
);