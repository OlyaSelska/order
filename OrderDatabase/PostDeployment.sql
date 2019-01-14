/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Product]([Name], [Price]) VALUES (N'apple', 2)
INSERT INTO [dbo].[Product]([Name], [Price]) VALUES (N'banana', 2.2)
INSERT INTO [dbo].[Product]([Name], [Price]) VALUES (N'pineapple', 3)
INSERT INTO [dbo].[Product]([Name], [Price]) VALUES (N'orange', 1.5)
INSERT INTO [dbo].[Product]([Name], [Price]) VALUES (N'kokos', 1)
