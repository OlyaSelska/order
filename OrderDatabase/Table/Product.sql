CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(50),
	[Price] FLOAT NOT NULL,
	[Unit] INT,
	CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
)