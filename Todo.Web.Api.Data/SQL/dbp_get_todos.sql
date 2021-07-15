USE [TodoExample]

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[dbp_get_todos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[dbp_get_todos]
END

GO

CREATE PROCEDURE dbp_get_todos
	@code		NVARCHAR(50)

AS

SELECT ti.id,
	   ti.title,
	   ti.state,
	   s.code
  FROM dbo.[Todo.Item]		ti
  JOIN dbo.[Todo.Sharing]	s	ON ti.codeId = s.id
 WHERE s.code = @code

SELECT	'Todos returned successfully' [message],
		'Success' [status]