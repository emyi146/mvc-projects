USE [SportsStore]
GO

/****** Object:  StoredProcedure [dbo].[ListProductsByCategory]    Script Date: 13/11/2014 1:50:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[ListProductsByCategory]
	@CategoryId INT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Product_Id, Product_Name, Product_Description, Product_Price, CategoryLookup_Name FROM Product
	LEFT JOIN 
	ProductCategory
	ON Product_Id = ProductCategory_ProdId
	LEFT JOIN
	CategoryLookup
	ON CategoryLookup_Id = ProductCategory_CatId
	WHERE 
		@CategoryId IS NULL
		OR
		@CategoryId = CategoryLookup_Id
END



GO


