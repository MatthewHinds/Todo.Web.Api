USE [TodoExample]

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[dbp_create_sharing_code]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE [dbo].[dbp_create_sharing_code]
END

GO

CREATE PROCEDURE dbp_create_sharing_code

AS

DECLARE @unique_code NVARCHAR(50)

SELECT @unique_code = SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 7)

INSERT INTO dbo.[Todo.Sharing] (code)
VALUES (@unique_code);

SELECT @unique_code [code]

SELECT	'Sharing code created successfully' [message],
		'Success' [status]