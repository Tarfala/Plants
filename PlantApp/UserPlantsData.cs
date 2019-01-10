using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PlantApp.Domain;


namespace PlantApp
{
    partial class DataAccess
    {
        public List<UserPlant> ShowAllUserPlantsList()
        {
            List<UserPlant> list = new List<UserPlant>();

            var sql = @"
SELECT UserPlantId, Plant.Name, Location.Location, UserPlants.WaterFrekuenseInDays, Soil.SoilType, Nutrition.NutritionType, BoughtDate, Comment, UserPlants.UserId, [User].UserName
FROM UserPlants
INNER JOIN Plant ON UserPlants.PlantId=Plant.PlantId
INNER JOIN Location ON UserPlants.LocationId=Location.LocationId
INNER JOIN Soil ON UserPlants.SoildId=Soil.SoilId
INNER JOIN Nutrition ON UserPlants.NutritionId=Nutrition.NutritionId
INNER JOIN [User] ON UserPlants.UserId=[User].UserId
";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var up = new UserPlant
                    {
                        UserPlantId = reader.GetSqlInt32(0).Value,
                        Name = reader.GetSqlString(1).Value,
                        Location = reader.GetSqlString(2).Value,
                        WaterFrequence = reader.GetSqlInt32(3).Value,
                        Soil = reader.GetSqlString(4).Value,
                        Nutrition = reader.GetSqlString(5).Value,
                        Bought = reader.GetSqlDateTime(6).Value,
                        UserInfo = reader.GetSqlString(7).Value,
                        UserId = reader.GetSqlInt32(8).Value,
                        UserName = reader.GetSqlString(9).Value,
                    };
                    list.Add(up);

                }
                return list;
            }

        }
            public List<UserPlant> ShowAllPlantsOnUser(int userId)
            {
                List<UserPlant> list = new List<UserPlant>();

                var sql = @"
SELECT UserPlantId, Plant.Name, Location.Location, UserPlants.WaterFrekuenseInDays, Soil.SoilType, Nutrition.NutritionType, BoughtDate, Comment, UserPlants.UserId, [User].UserName
FROM UserPlants
INNER JOIN Plant ON UserPlants.PlantId=Plant.PlantId
INNER JOIN Location ON UserPlants.LocationId=Location.LocationId
INNER JOIN Soil ON UserPlants.SoildId=Soil.SoilId
INNER JOIN Nutrition ON UserPlants.NutritionId=Nutrition.NutritionId
INNER JOIN [User] ON UserPlants.UserId=[User].UserId
WHERE UserPlants.UserId=@UserId
";
                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("UserId", userId));

                SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var up = new UserPlant
                        {
                            UserPlantId = reader.GetSqlInt32(0).Value,
                            Name = reader.GetSqlString(1).Value,
                            Location = reader.GetSqlString(2).Value,
                            WaterFrequence = reader.GetSqlInt32(3).Value,
                            Soil = reader.GetSqlString(4).Value,
                            Nutrition = reader.GetSqlString(5).Value,
                            Bought = reader.GetSqlDateTime(6).Value,
                            UserInfo = reader.GetSqlString(7).Value,
                            UserId = reader.GetSqlInt32(8).Value,
                            UserName = reader.GetSqlString(9).Value,
                        };
                        list.Add(up);

                    }
                    return list;
                }
            }
        }
}




