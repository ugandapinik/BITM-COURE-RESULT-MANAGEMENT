using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityMS.DAL {
    public class ScheduleGateway {


        public string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;


        public bool IsDepartmentNameExist(string DeptName) {
            bool isDeptNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT DeptName FROM Departments WHERE DeptName= @DeptName ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("DeptName", SqlDbType.NVarChar);
            command.Parameters["DeptName"].Value = DeptName;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) {
                isDeptNameExists = true;
            }
            connection.Close();

            return isDeptNameExists;
        }

    }
}