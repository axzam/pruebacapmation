



DROP TABLE IF EXISTS Cliente
GO

CREATE TABLE Cliente (Id int identity(1,1) primary key, [Name] varchar(250), [LastName] varchar(250), [Age] int, [Nationality] varchar(250), [Estatus] bit)
GO

DROP PROCEDURE IF EXISTS usp_insert_cliente
GO

CREATE PROCEDURE usp_insert_cliente(@Name varchar(250), @LastName varchar(250), @Age int, @Nationality varchar(250))
AS
INSERT INTO Cliente( Name, LastName, Age, Nationality, Estatus) VALUES ( @Name, @LastName, @Age, @Nationality, 1)
GO



DROP PROCEDURE IF EXISTS usp_get_cliente_by_id
GO

CREATE PROCEDURE usp_get_cliente_by_id(@Id int)
AS
SELECT * FROM Cliente WHERE Id = @Id and Estatus = 1
GO




DROP PROCEDURE IF EXISTS usp_get_list_cliente
GO

CREATE PROCEDURE usp_get_list_cliente
AS
SELECT * FROM Cliente WHERE Estatus = 1 
GO



DROP PROCEDURE IF EXISTS usp_delete_cliente
GO
CREATE PROCEDURE usp_delete_cliente(@Id int)
AS
UPDATE Cliente SET Estatus = 0 WHERE Id = @Id
GO



DROP PROCEDURE IF EXISTS usp_update_cliente
GO
CREATE PROCEDURE usp_update_cliente(@Id int, @Name varchar(250), @LastName varchar(250), @Age int, @Nationality varchar(250) )
AS
UPDATE Cliente SET Name = @Name, LastName = @LastName, Age = @Age, Nationality = @Nationality WHERE Id = @id
GO