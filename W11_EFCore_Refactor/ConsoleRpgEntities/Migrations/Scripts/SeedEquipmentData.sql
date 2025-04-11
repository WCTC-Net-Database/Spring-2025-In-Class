SET IDENTITY_INSERT [dbo].[Equipment] ON
INSERT INTO [dbo].[Equipment] ([Id], [Weapon], [Armor]) VALUES (1, N'Club', N'Shield')
SET IDENTITY_INSERT [dbo].[Equipment] OFF

UPDATE Players SET EquipmentId=1 WHERE Id=1;
