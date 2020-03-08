USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPagedAND]    Script Date: 9/13/2019 8:42:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllPagedAND]
@PageIndex int,
@PageSize int, 
@OrderBy nvarchar(50),
@Id int = NULL,
@Name nvarchar(100) = NULL,
@Price decimal(18,2) = NULL,
@Description nvarchar(MAX) = NULL,
@ImageURL nvarchar(100) = NULL,
@Category nvarchar(100) = NULL,
@Rating decimal(18,2)= NULL,
@Weight decimal(18,2)= NULL,
@IsActive bit= NULL,
@Width int = NULL,
@Height int = NULL


AS
BEGIN

DECLARE @sql nvarchar(MAX),
@paramlist nvarchar(MAX),
@NameSearch nvarchar(4000)	

	SET NOCOUNT ON;
	SET @sql =' select * from Product '

	IF @Id IS NOT NULL OR
	   @Name IS NOT NULL OR
	   @Price IS NOT NULL OR
	   @Description IS NOT NULL OR
	   @ImageURL IS NOT NULL OR
	   @Category IS NOT NULL OR
	   @Rating IS NOT NULL OR
	   @Weight IS NOT NULL OR
	   @IsActive IS NOT NULL OR
	   @Width IS NOT NULL OR
	   @Height IS NOT NULL 
				SET @sql += 'WHERE 1=1'
	 
	set @NameSearch = '%'+@Name+'%'

	IF @Id IS NOT NULL 
		SET @sql += ' AND Id = @Id'
	IF @Name IS NOT NULL
		SET @sql += ' AND Name LIKE @NameSearch'
	IF @price IS NOT NULL
		SET @sql += ' AND Price = @Price'
	IF @Description IS NOT NULL
		SET @sql += ' AND Description = @Description'
	IF @ImageURL IS NOT NULL
		SET @sql += ' AND ImageURL = @ImageURL'
	IF @Category IS NOT NULL
		SET @sql += ' AND Category = @Category'
	IF @Rating IS NOT NULL
		SET @sql += ' AND Rating = @Rating'
	IF @Weight IS NOT NULL
		SET @sql += ' AND Weight = @Weight'
	IF @IsActive IS NOT NULL
		SET @sql += ' AND IsActive = @IsActive'
	IF @Width IS NOT NULL
		SET @sql += ' AND Width = @Width'
	IF @Height IS NOT NULL
		SET @sql += ' AND Height = @Height'


	SET @sql += ' Order by '+QUOTENAME(@OrderBy)+' asc OFFSET @PageSize * (@PageIndex - 1) 
	ROWS FETCH NEXT @PageSize ROWS ONLY'

	SELECT @paramlist = '@Id [int],
	@NameSearch varchar(4000),
	@Price [decimal](18,2),
	@Description [nvarchar](MAX),
	@ImageURL [nvarchar](100),
	@Category [nvarchar](100),
	@Rating [decimal](18,2),
	@Weight [decimal](18,2),
	@IsActive [bit],
	@Width [int],
	@Height [int],
	@PageIndex [int],
	@PageSize [int]' 
	
	exec sp_executesql @sql , @paramlist , @Id ,
		@NameSearch , 
		@Price ,
		@Description , 
		@ImageURL , 
		@Category,
		@Rating ,
		@Weight,
		@IsActive,
		@Width,
		@Height,
		@PageIndex,
		@PageSize
	
	
END

print @sql		