--Name Proj04
--Author Yamba OUANDAOGO
--Date july 29, 2019


Use TheKitchenRecipesDB
-- Create the table for recipes

IF OBJECT_ID('dbo.Recipes', 'U') IS NOT NULL
DROP TABLE dbo.Recipes
CREATE TABLE dbo.Recipes
(
RecipesID   INT NOT NULL   PRIMARY KEY, -- primary key column
CuisineID VARCHAR(20),
NameofRecipe VARCHAR(50) NOT NULL,
PrepTime TIME (6)  NOT NULL,
CookTime TIME(6) NOT NULL,
ReadyIn TIME (6) NOT NULL,
LevelRecipeID VARCHAR(20)NOT NULL,
RecipeDescription TEXT  NOT NULL,
CaloriePerServing VARCHAR (500) NOT NULL,
);
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(1,'African','Chicken Stew','00:20:00','00:40:00','01:00:00','Easy', 'Heat the oil ','233 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(2,'Asian','Chicken Noodle Soup','00:10:00','00:30:00','00:40:00','Easy', 'Heat a large stock pot over medium heat. Add oil, carrots, onion, and bell pepper.  ','332 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(3,'American','Baked Potato Salad ','00:25:00','01:20:00','01:45:00','Moderate', 'Bake for 1 hour in the preheated oven, until golden brown. ','421 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(4,'Carribean','Caribbean Shrimp','00:10:00','00:40:00','01:10:00','Easy', 'In a large bowl combine oil, ginger, lime juice, garlic, soy sauce, sugar and red peppe ','132 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(5,'Indian','Fish Curry','00:20:00','00:35:00','01:25:00','High', 'Arrange the fish fillets in a baking dish, discarding any extra marinade. ','238 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(6,'Italian',' Lasagna','00:30:00','01:30:00','02:00:00','High', 'Bake at 350 degrees F (175 degrees C) for 1 1/2 hours. ','755 calories');
INSERT dbo.Recipes (RecipesID,CuisineID ,NameofRecipe,PrepTime ,CookTime,ReadyIn,LevelRecipeID,RecipeDescription,CaloriePerServing)
Values(7,'Mexican','Best Beef Enchiladas','00:25:00','00:20:00','00:45:00','Easy', 'Bake in the preheated oven until cheese topping is melted and enchiladas  ','539 calories');



select*from dbo.Recipes

--Create a table for the type of cuisine.

IF OBJECT_ID('dbo.Cuisine', 'U') IS NOT NULL
DROP TABLE dbo.Cuisine
CREATE TABLE dbo.Cuisine
(
CuisineID  VARCHAR(20) NOT NULL PRIMARY KEY, -- primary key column
CuisineType VARCHAR(20) NOT NULL,
);
GO
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES ( 1,'African');
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES (2,'Asian');
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES ( 3,'American')
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES ( 4,'Indian')
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES ( 5,'Italian')
INSERT dbo.Cuisine (CuisineID, CuisineType)
VALUES ( 6,'Mexican');
Select * from dbo.Cuisine

--Create a table for the levels.
IF OBJECT_ID('dbo.Levels', 'U') IS NOT NULL
DROP TABLE dbo.Levels
CREATE TABLE dbo.Levels
(
LevelsID  VARCHAR(20) NOT NULL PRIMARY KEY, -- primary key column
SortByLevel INT 
);
INSERT dbo.levels (LevelsID,SortByLevel)
VALUES ( 'High',3);
INSERT dbo.levels (LevelsID,SortByLevel)
VALUES ( 'Moderate', 2);
INSERT dbo.levels (LevelsID,SortByLevel)
VALUES ('Easy', 1);
Select * from dbo.Levels

--Create a table for the RecipeIngredients.
IF OBJECT_ID('dbo.RecipeIngredients', 'U') IS NOT NULL
DROP TABLE dbo.RecipeIngredients
CREATE TABLE dbo.RecipeIngredients
(
RecipeIngredientID INT NOT NULL PRIMARY KEY, -- primary key column
RecipesID   INT NOT NULL,
Amount VARCHAR (20) NOT NULL,
MeasurementsID VARCHAR (20) Not NULL,
IngredientID INT NOT NULL,
);

--Create a table for Ingredients.
IF OBJECT_ID('dbo.Ingredients', 'U') IS NOT NULL
DROP TABLE dbo.Ingredients
CREATE TABLE dbo.Ingredients
(
IngredientID INT NOT NULL PRIMARY KEY, -- primary key column
IngredientName VARCHAR (20)
);
INSERT dbo.Ingredients (IngredientID,IngredientName)
VALUES (





--Create a table for Measurement.
IF OBJECT_ID('dbo.MeasurementTbl', 'U') IS NOT NULL
DROP TABLE dbo.MeasurementTbl
CREATE TABLE dbo.MeasurementTbl
(
MeasurementsID INT NOT NULL PRIMARY KEY, -- primary key column
Measurement VARCHAR (20) NOT NULL,
Abbreviation VARCHAR (20),
);
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (1,'pack(s)','pk(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (2,'package(s)','pkg(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (3,'cup(s)','l(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (4,'liter(s)','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (5,'teaspoon(s)','tsp(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (6,'tablespoon(s)','tbsp(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (7,'head(s)','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (8,'pound(s)','lb(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (9,'ounce(s)','oz(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (10,'large','lg.');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (11,'jar(s)','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (12,'milliliter','ml(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (13,'sheet(s)','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (14,'medium','med.');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (15,'small','sm.');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (16,'stick(s)','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (17,'piece(s)','pc(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (18,'pint','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (19,'gallon(s)','gal(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (20,'quart(s)','qt(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (21,'loaf','');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (22,'gram(s)','g(s).');
INSERT dbo.MeasurementTbl (MeasurementsID,Measurement,Abbreviation)
VALUES (23,'milligram(s)','mg(s).');
Select * from dbo.MeasurementTbl

--Create a table for NutritionalInfo
IF OBJECT_ID('dbo.NutritionalInfo', 'U') IS NOT NULL
DROP TABLE dbo.NutritionalInfo
CREATE TABLE dbo.NutritionalInfo
(
NutritionalInfoID INT NOT NULL PRIMARY KEY, -- primary key column
Nutrition VARCHAR (20),
MeasurementsID INT 
);

INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (1,'Saturated Fat',22);
INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (2,'Trans Fat',22);
INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (3,'Sodium',23);
INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (4,'Carbohydrate',22);
INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (5,'Protein',22);
INSERT dbo.NutritionalInfo (NutritionalInfoID,Nutrition,MeasurementsID)
VALUES (6,'Cholesterol',23);


--Create a table for RecipeNutritionnalInfo
IF OBJECT_ID('dbo.RecipeNutritionnalInfo', 'U') IS NOT NULL
DROP TABLE dbo.RecipeNutritionnalInfo
CREATE TABLE dbo.RecipeNutritionnalInfo
(
RecipNutrittionnalID   INT PRIMARY KEY, -- primary key column
RecipeID INT NOT NULL,
NutritionalInfoID INT NOT NULL, 
);
INSERT dbo.RecipeNutritionnalInfo (RecipNutrittionnalID,RecipeID,NutritionalInfoID)
VALUES (,'','');