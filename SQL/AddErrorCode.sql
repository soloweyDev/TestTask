USE TestTask;
GO
CREATE PROCEDURE AddErrorCodes 
	@Code INT, 
	@TextIn NVARCHAR(255)
AS
BEGIN
	IF NOT EXISTS (SELECT * from ErrorCodes WHERE Code = @Code)
	BEGIN
		INSERT INTO ErrorCodes(Code, TextIn)
		VALUES(@Code, @TextIn)
	END;
END;
GO
