USE TestTask;
GO
CREATE PROCEDURE AddErrorCodes 
	@Code INT, 
	@TextIn NVARCHAR(255),
	@outTest NVARCHAR(20) OUTPUT
AS
BEGIN
	IF EXISTS (SELECT * from ErrorCodes WHERE Code = @Code)
		SET @outTest = 'Already exists'
	ELSE
	BEGIN
		INSERT INTO ErrorCodes(Code, TextIn)
		VALUES(@Code, @TextIn)
		SET @outTest = 'Added'
	END;
END;
GO
