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

        internal bool CheckIfUserIsValid(User loggedOnUser)
        {
            bool userExist = false;
            var sql = "SELECT COUNT(*) FROM User WHERE UserName = @userName AND PassWord = @passWord";

            using (SqlConnection connection = new SqlConnection(conString))
            using(SqlCommand command = new SqlCommand(sql, connection))
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

        //public List<Blogg> GetAllBlogPostsBrief()
        //{
        //    var sql = @"SELECT [Id], [Author], [Title], [Created], [Description], [Updated]
        //                FROM Blogg";

        //    using (SqlConnection connection = new SqlConnection(conString))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        var list = new List<Blogg>();

        //        while (reader.Read())
        //        {
        //            var bp = new Blogg
        //            {
        //                ID = reader.GetSqlInt32(0).Value,
        //                Author = reader.GetSqlString(1).Value,
        //                Title = reader.GetSqlString(2).Value,
        //                Created = reader.GetSqlDateTime(3).Value,
        //                Description = reader.GetSqlString(4).Value,
        //                Updated = reader.GetSqlDateTime(5).Value

        //            };
        //            list.Add(bp);
        //        }

        //        return list;

        //  }
        // }
    }
}
