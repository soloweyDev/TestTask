USE TestTask;
GO
CREATE PROCEDURE AddCategories 
	@Id INT, 
	@Name NVARCHAR(255),
	@Parent INT,
	@Image NVARCHAR(255),
	@outTest NVARCHAR(20) OUTPUT
AS
BEGIN
	IF EXISTS (SELECT * from Categories WHERE Id = @Id)
		SET @outTest = 'Already exists'
	ELSE
	BEGIN
		INSERT INTO Categories(Id, Name, Parent, Image)
		VALUES(@Id, @Name, @Parent, @Image)
		SET @outTest = 'Added'
	END
END
GO
