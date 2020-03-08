USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPagedOR]    Script Date: 9/13/2019 8:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllPagedOR]
@PageIndex int,
@PageSize int , 
@OrderBy nvarchar(50),
@SearchText nvarchar(250)

AS
BEGIN
	Declare @sql nvarchar(4000)
	Declare @paramList nvarchar(MAX) 
	
	SET NOCOUNT ON;
	SET @sql = 'select * from Product where Name = @SearchText or Description = @SearchText 
	or ImageURL = @SearchText or Category = @SearchText 
	Order by '+@OrderBy+' asc OFFSET @PageSize * (@PageIndex - 1) 
	ROWS FETCH NEXT @PageSize ROWS ONLY' 
	
	SELECT @paramlist = '@SearchText nvarchar(250),
	@PageIndex int,
	@PageSize int' 

	exec sp_executesql @sql , @paramlist ,
		@SearchText , 
		@PageIndex,
		@PageSize
	
END
