IF db_id('TodoExample') IS NOT NULL
	DROP DATABASE [TodoExample]
GO

IF db_id('TodoExample') IS NULL
	CREATE DATABASE [TodoExample]
GO

CREATE TABLE [TodoExample].dbo.[Todo.Sharing] (
	id						INT NOT NULL IDENTITY,
	code					NVARCHAR(50) UNIQUE,

	CONSTRAINT sharing_pk	PRIMARY KEY (id)
);

CREATE TABLE [TodoExample].dbo.[Todo.Item] (
	id						INT NOT NULL IDENTITY,
	codeId					INT NOT NULL,
	title					NVARCHAR(100) NOT NULL,
	state					NVARCHAR(10) NOT NULL,

	CONSTRAINT todo_pk		PRIMARY KEY (id),
	CONSTRAINT code_id_fk	FOREIGN KEY (codeId) REFERENCES [TodoExample].dbo.[Todo.Sharing](id)
);