USE [SportsStore]
GO
/****** Object:  StoredProcedure [dbo].[ListProductsByCategory]    Script Date: 13/11/2014 20:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[ListProductsByCategory]
	@CategoryId		INT				= NULL,
	@Page			INT				= 1,
	@PageSize		INT				= 200000,
	@SortParam		NVARCHAR(50)	= NULL,
	@TotalRows		INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @MinRow INT
	DECLARE @MaxRow INT

	SET @MinRow = (@Page-1)*@PageSize + 1
	SET @MaxRow = @MinRow + @PageSize - 1 
	
	;WITH CTE_Result AS
	(
		SELECT COUNT(*) AS TotalCount
		FROM Product
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
	)
	SELECT @TotalRows = TotalCount FROM CTE_Result

	;WITH CTE_Result AS
	(
		SELECT ROW_NUMBER() OVER 
		(
			ORDER BY
			CASE WHEN @SortParam = 'Product_ID ASC' THEN Product_ID END ,
			CASE WHEN @SortParam = 'Product_ID DESC' THEN Product_ID END DESC,
			CASE WHEN @SortParam = 'Product_Name ASC' THEN Product_Name END ,
			CASE WHEN @SortParam = 'Product_Name DESC' THEN Product_Name END DESC,
			CASE WHEN @SortParam = 'Product_Description ASC' THEN Product_Description END ,
			CASE WHEN @SortParam = 'Product_Description DESC' THEN Product_Description END DESC,
			CASE WHEN @SortParam = 'Product_Price ASC' THEN Product_Price END ,
			CASE WHEN @SortParam = 'Product_Price DESC' THEN Product_Price END DESC,
			CASE WHEN @SortParam = 'CategoryLookup_Name ASC' THEN CategoryLookup_Name END ,
			CASE WHEN @SortParam = 'CategoryLookup_Name DESC' THEN CategoryLookup_Name END DESC,
			CASE WHEN @SortParam IS NULL THEN Product_Id END 
		) AS ROW, 
		Product_Id, Product_Name, Product_Description, Product_Price, CategoryLookup_Name 
		FROM Product
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
	)

	SELECT Product_Id, Product_Name, Product_Description, Product_Price, CategoryLookup_Name 
	FROM CTE_Result
	WHERE ROW BETWEEN @MinRow AND @MaxRow
		 
	
END
