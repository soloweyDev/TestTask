USE TestTask;
GO
CREATE PROCEDURE TestSelect AS
BEGIN
    SELECT TOP (1000) [Code],[Text]
	FROM [TestTask].[dbo].[ErrorCodes]
END;