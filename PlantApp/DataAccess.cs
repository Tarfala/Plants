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

        internal void CreateNewAccount(User loggedOnUser)
        {
            throw new NotImplementedException();
        }        

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
