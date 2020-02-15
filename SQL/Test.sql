-- TEST TestSelect
EXEC TestSelect


-- TEST AddErrorCodes
DECLARE @Code INT, @Text1 NVARCHAR(255), @outTest NVARCHAR(20)
SET @Code = -1
SET @Text1 = N'Оператор временно недоступен'
 
EXEC AddErrorCodes @Code, @Text1, @outTest OUTPUT
 
PRINT @outTest

-- TEST AddCategories
DECLARE @Id INT, @Name NVARCHAR(255), @Parent INT, @Image NVARCHAR(255), @outTest NVARCHAR(20)
SET @Id = 100
SET @Name = N'Автоматический выбор оператора'
SET @Parent = 0
SET @Image = 'main_main_ico.gif'

EXEC AddCategories @Id, @Name, @Parent, @Image, @outTest OUTPUT
 
PRINT @outTest