USE [TodoExample]

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[dbp_update_todo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[dbp_update_todo]
END

GO

CREATE PROCEDURE dbp_update_todo
	@id		INT,
	@title	NVARCHAR(100),
	@state	NVARCHAR(10),
	@code	NVARCHAR(50)

AS

UPDATE ti
   SET ti.title = @title,
	   ti.state = @state
  FROM dbo.[Todo.Item]		ti
  JOIN dbo.[Todo.Sharing]	s ON ti.codeId = s.id
 WHERE ti.id = @id AND s.code = @code

SELECT	'Todo updated successfully' [message],
		'Success' [status]