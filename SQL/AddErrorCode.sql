USE TestTask
GO
CREATE PROCEDURE AddErrorCodes 
	@Code INT, 
	@Text TEXT,
	@outTest TEXT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT * from ErrorCodes WHERE Code = @Code)
		SET @outTest = 'Already exists'
	ELSE
	BEGIN
		INSERT INTO ErrorCodes(Code, Text)
		VALUES(@Code, @Text)
		SET @outTest = 'Added'
	END
END
GO
