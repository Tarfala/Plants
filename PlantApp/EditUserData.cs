using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PlantApp.Domain;

namespace PlantApp
{
    partial class DataAccess
    {

        public void EditUser(User x)
        {
            User userEdit = x;

            var sql = @"UPDATE User 
                    SET PassWord=@PassWord, Email=@Email, LastWater=@LastWater 
                    WHERE userEdit=@userEdit";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("PassWord", userEdit.PassWord));
                command.Parameters.Add(new SqlParameter("Email", userEdit.Email));
                command.Parameters.Add(new SqlParameter("userId", userEdit.UserId));

                command.ExecuteNonQuery();

            }

        }

    }
}
