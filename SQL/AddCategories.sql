USE TestTask;
GO
CREATE PROCEDURE AddCategories 
	@Id INT, 
	@Name NVARCHAR(255),
	@Parent INT,
	@Image NVARCHAR(255)
AS
BEGIN
	IF NOT EXISTS (SELECT * from Categories WHERE Id = @Id)
	BEGIN
		INSERT INTO Categories(Id, Name, Parent, Image)
		VALUES(@Id, @Name, @Parent, @Image)
	END;
END;
GO
