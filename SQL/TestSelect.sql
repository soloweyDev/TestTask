USE TestTask;
GO
CREATE PROCEDURE TestSelect AS
BEGIN
    SELECT TOP (1000) Code, TextIn
	FROM ErrorCodes
END;