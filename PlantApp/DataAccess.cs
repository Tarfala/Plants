using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PlantApp.Domain;

namespace PlantApp
{
    class DataAccess
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=Plants";

        public List<Plant> GetAllPlantSorted()
        {
            var sql = @"SELECT PlantId, Name FROM Plant";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                var list = new List<Plant>();
                while (reader.Read())
                {
                    var bp = new Plant
                    {
                        PlantId = reader.GetSqlInt32(0).Value,
                        Name = reader.GetSqlString(1).Value,

                    };
                    list.Add(bp);
                }
                return list;
            }
        }

        internal bool CheckIfUserIsValid(User loggedOnUser)
        {
            bool userExist = false;
            var sql = "SELECT COUNT(*) FROM [User] WHERE UserName = @userName AND PassWord = @passWord";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("userName", loggedOnUser.UserName));
                command.Parameters.Add(new SqlParameter("passWord", loggedOnUser.PassWord));
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int countTag = reader.GetSqlInt32(0).Value;
                    if (countTag == 1)
                        userExist = true;
                }
            }
            return userExist;
        }

        public List<Plant> GetSinglePlant(string command)
        {
            int input = int.Parse(command);
            var sql = @"SELECT * FROM Plant where PlantId=@input";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command2 = new SqlCommand(sql, connection))
            {
                connection.Open();
                command2.Parameters.Add(new SqlParameter("input", input));
                SqlDataReader reader = command2.ExecuteReader();
                var list = new List<Plant>();
                while (reader.Read())
                {
                    var bp = new Plant
                    {
                        Name = reader.GetSqlString(0).Value.ToString(),
                        PlantId = reader.GetSqlInt32(1).Value,
                        LatinName = reader.GetSqlString(2).Value,
                        LocationId = reader.GetSqlInt32(3).Value,
                        WaterFrekuenseInDays = reader.GetSqlInt32(4).Value,
                        PlantTypeId = reader.GetSqlInt32(5).Value,
                        ScentId = reader.GetSqlInt32(6).Value,
                        SoilId = reader.GetSqlInt32(7).Value,
                        NutritionId = reader.GetSqlInt32(8).Value,
                        OriginId = reader.GetSqlInt32(9).Value,
                        PoisonId = reader.GetSqlInt32(10).Value,
                        GeneralInfo = reader.GetSqlString(11).Value
                    };
                    list.Add(bp);
                }
                return list;
            }
        }

        internal void CreateNewAccount(User loggedOnUser)
        {
            var sql = @"INSERT INTO [User] (UserName, PassWord, Email, UserLevelId, ZoneId, UserLocationId) VALUES (@userName, @passWord, @email, 1, 2, 3)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("userName", loggedOnUser.UserName));
                command.Parameters.Add(new SqlParameter("passWord", loggedOnUser.PassWord));
                command.Parameters.Add(new SqlParameter("email", loggedOnUser.Email));
                command.ExecuteNonQuery();   
            }
        }

        internal bool TestOfUserName(User loggedOnUser)
        {
            bool testUser = true;
            var sql = @"SELECT COUNT(*) FROM [User] WHERE UserName = @userName";

            using (SqlConnection connection = new SqlConnection(conString))
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("userName", loggedOnUser.UserName));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int countTag = reader.GetSqlInt32(0).Value;
                    if (countTag == 0)
                        testUser = false;
                }
            }
            return testUser;
        }

        //public Plant GetPlantByCategory(int input)
        //{
        //    var sql = @"SELECT PlantId, Name
        //                FROM Plant 
        //                WHERE PlantTypeId=@input";
        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();

public List<Plant> GetPlantByCategory(int input)
        {
            var sql = @"SELECT PlantId, Name, PlantType.PlantType
                        FROM Plant 
                        inner join PlantType on Plant.PlantTypeId=PlantType.PlantTypeId
                        WHERE plant.PlantTypeId=@InputId";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("InputId", input));
                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Plant>();

                while (reader.Read())
                {
                    var bp = new Plant
                    {
                        PlantId = reader.GetSqlInt32(0).Value,
                        Name = reader.GetSqlString(1).Value,
                    };
                    list.Add(bp);
                }
                return list;
            }
        }

        internal List<PlantType> GetCategort()
        {
            var sql = @"SELECT PlantTypeId, PlantType FROM PlantType";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                var list = new List<PlantType>();
                while (reader.Read())
                {
                    var bp = new PlantType
                    {
                        PlantTypeId = reader.GetSqlInt32(0).Value,
                        PlantTypes = reader.GetSqlString(1).Value,

                    };
                    list.Add(bp);
                }
                return list;
            }
        }
    }
}
