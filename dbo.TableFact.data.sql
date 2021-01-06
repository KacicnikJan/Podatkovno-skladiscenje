SET IDENTITY_INSERT [dbo].[TableFact] ON
INSERT INTO [dbo].[TableFact] ([Id], [idTable1], [idTable2], [Name], [Time_recorded], [Total_km], [Total_time], [Total_calories]) VALUES (1, 1, 1, NULL, NULL, N'55607282.89                                       ', N'14735568.294                                      ', N'1406047                                           ')
SET IDENTITY_INSERT [dbo].[TableFact] OFF
INSERT INTO TableFact(Total_km, Total_time, Total_calories,idTable1, idTable2 )
VALUES (33523348.8 , 4769260, 845353, 1, 1);
