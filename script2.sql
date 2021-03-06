USE [Plants]
GO
SET IDENTITY_INSERT [dbo].[Soil] ON 

INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (1, N'Nutrition Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (2, N'Sand Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (3, N'Mud Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (4, N'Flower Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (5, N'Medeterianian Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (6, N'Tomato Soil')
INSERT [dbo].[Soil] ([SoilId], [SoilType]) VALUES (7, N'Geranium Soil')
SET IDENTITY_INSERT [dbo].[Soil] OFF
SET IDENTITY_INSERT [dbo].[Nutrition] ON 

INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (1, N'Flower Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (2, N'Green Plants')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (3, N'Medeterian Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (4, N'Tomato Plant')
INSERT [dbo].[Nutrition] ([NutritionId], [NutritionType]) VALUES (5, N'Orcid Plant')
SET IDENTITY_INSERT [dbo].[Nutrition] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (1, N'North')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (2, N'South')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (3, N'West')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (4, N'East')
INSERT [dbo].[Location] ([LocationId], [Location]) VALUES (5, N'Dark')
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Origin] ON 

INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (1, N'Polar')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (2, N'Boreal')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (3, N'Mountain')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (4, N'Mediterrean')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (5, N'Desert')
INSERT [dbo].[Origin] ([OriginId], [Zone]) VALUES (6, N'Tropical')
SET IDENTITY_INSERT [dbo].[Origin] OFF
SET IDENTITY_INSERT [dbo].[UserLevelId] ON 

INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (1, N'Admin')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (2, N'Beginer')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (3, N'Experienced')
INSERT [dbo].[UserLevelId] ([UserLevelId], [UserLevel]) VALUES (4, N'Advanced')
SET IDENTITY_INSERT [dbo].[UserLevelId] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (1, N'Admin', N'Admin', 1, 4, 1, N'test@test.se')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (3, N'Jonte', N'Tobbe', 2, 3, 2, N'jon.risberg@gmail.com')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (4, N'Tobbe', N'Jonte', 3, 2, 3, N'spara.Energi@gmail.com')
INSERT [dbo].[User] ([UserId], [UserName], [PassWord], [UserLocationId], [ZoneId], [UserLevelId], [Email]) VALUES (5, N'Sara', N'JonTobb', 4, 1, 4, N'test@test.se')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[PlantType] ON 

INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (1, N'FlowerPlant')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (2, N'Cactus')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (3, N'FoodPlant')
INSERT [dbo].[PlantType] ([PlantTypeId], [PlantType]) VALUES (4, N'GreenPlant')
SET IDENTITY_INSERT [dbo].[PlantType] OFF
SET IDENTITY_INSERT [dbo].[Poison] ON 

INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (1, N'None')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (2, N'Low')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (3, N'Medium')
INSERT [dbo].[Poison] ([PoisonId], [PoisonType]) VALUES (4, N'High')
SET IDENTITY_INSERT [dbo].[Poison] OFF
SET IDENTITY_INSERT [dbo].[Scent] ON 

INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (1, N'None')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (2, N'Low')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (3, N'Medium')
INSERT [dbo].[Scent] ([ScentId], [Scent]) VALUES (4, N'High')
SET IDENTITY_INSERT [dbo].[Scent] OFF
SET IDENTITY_INSERT [dbo].[Plant] ON 

INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Hortensia', 1, N'Hydrangea macrophylla', 3, 3, 1, 1, 4, 1, 4, 1, N'Nice Flower ')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Zonalpelargon', 2, N'Pelargonium x hortorum', 3, 7, 1, 2, 7, 1, 4, 1, N'Ugly Flower')
INSERT [dbo].[Plant] ([Name], [PlantId], [LatinName], [LocationId], [WaterFrekuenseInDays], [PlantTypeId], [ScentId], [SoilId], [NutritionId], [OriginId], [PoisonId], [GeneralInfo]) VALUES (N'Zamiakalla', 3, N'Zamioculcas Zamijofolia', 5, 14, 4, 1, 4, 2, 6, 1, N'Never Dies')
SET IDENTITY_INSERT [dbo].[Plant] OFF
SET IDENTITY_INSERT [dbo].[UserPlants] ON 

INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId]) VALUES (2, 2, 1, 30, 1, 1, CAST(N'2019-01-09' AS Date), N'Den är gul', NULL)
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId]) VALUES (3, 3, 2, 14, 1, 3, CAST(N'2018-12-24' AS Date), N'Finaste blomman jag har', NULL)
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId]) VALUES (4, 1, 3, 7, 5, 3, CAST(N'2017-01-01' AS Date), N'Den är mycket vacker', NULL)
INSERT [dbo].[UserPlants] ([UserPlantId], [PlantId], [LocationId], [WaterFrekuenseInDays], [SoildId], [NutritionId], [BoughtDate], [Comment], [UserId]) VALUES (5, 1, 1, 14, 1, 1, CAST(N'1855-01-05' AS Date), N'Arv-Planta', NULL)
SET IDENTITY_INSERT [dbo].[UserPlants] OFF
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (1, 3)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (2, 1)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (2, 2)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (3, 1)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (3, 2)
INSERT [dbo].[PlantToLocation] ([LocationId], [PlantId]) VALUES (5, 3)
