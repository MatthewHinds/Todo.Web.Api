USE [TodoExample]

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[dbp_delete_todo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[dbp_delete_todo]
END

GO

CREATE PROCEDURE dbp_delete_todo
	@id		INT,
	@code	NVARCHAR(50)

AS

DELETE ti
  FROM dbo.[Todo.Item]		ti
  JOIN dbo.[Todo.Sharing]	s ON ti.codeId = s.id
 WHERE ti.id = @id AND s.code = @code

SELECT	'Todo deleted successfully' [message],
		'Success' [status]