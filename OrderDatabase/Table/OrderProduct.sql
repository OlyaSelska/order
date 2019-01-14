CREATE TABLE [dbo].[OrderProduct]
(
	[OrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	CONSTRAINT [PK_OrderProduct] PRIMARY KEY([OrderId], [ProductId]),
	CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
	CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
)