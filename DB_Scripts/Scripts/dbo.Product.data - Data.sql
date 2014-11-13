DELETE FROM [dbo].[Product]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (1, N'Kayak', N'A boat for one person', CAST(275.50 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (2, N'Lifejacket', N'Protective and fashionable', CAST(48.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (3, N'Soccer Ball', N'FIFA-approved size and weight',  CAST(19.50 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (4, N'Corner Flags', N'Give your playing field a professional touch', CAST(34.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (5, N'Stadium', N'Flat-packed 35,000-seat stadium', CAST(79500.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (6, N'Thinking Cap', N'Improve your brain efficiency by 75%', CAST(16.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (7, N'Unsteady Chair', N'Secretly give your opponent a disadvantage',  CAST(29.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (8, N'Human Chess Board', N'A fun game for the family', CAST(75.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (9, N'Bling-Bling King', N'Gold-plated, diamond-studded King', CAST(1200.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (10, N'T-Shirt', N'Confortable and good quality', CAST(79500.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (11, N'Pitch 3G', N'Perfect for rainy days', CAST(16.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (12, N'Bicycle', N'Fastest than a motorbike', CAST(29.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (13, N'Trainers', N'Run like Usain Bolt', CAST(75.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (14, N'Boat', N'You will be the king of the sea', CAST(1200.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (15, N'Fence 110m', N'Resistent to crashes', CAST(79500.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (16, N'Rugby Jumper', N'Not enough for an impact, but looks nice', CAST(16.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Product] ([Product_Id], [Product_Name], [Product_Description], [Product_Price]) VALUES (17, N'Boxing protector', N'Level 3, you can fight agains anyone', CAST(29.95 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
