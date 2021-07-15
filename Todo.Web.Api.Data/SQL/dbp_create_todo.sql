USE [TodoExample]

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[dbp_create_todo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[dbp_create_todo]
END

GO

CREATE PROCEDURE dbp_create_todo
	@code  NVARCHAR(50),
	@title NVARCHAR(100)

AS

DECLARE @code_id INT

SELECT @code_id = s.id
  FROM dbo.[Todo.Sharing] s
 WHERE s.code = @code

INSERT INTO dbo.[Todo.Item] (codeId, title, state)
VALUES (@code_id, @title, 'Todo');

SELECT	'Todo created successfully' [message],
		'Success' [status]