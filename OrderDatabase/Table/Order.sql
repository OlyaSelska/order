CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Email] NVARCHAR(50),
	[DeliveryAddress] NVARCHAR(50),
	CONSTRAINT [PK_Order] PRIMARY KEY ([Id])
)