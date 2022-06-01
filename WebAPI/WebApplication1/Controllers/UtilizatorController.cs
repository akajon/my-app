using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class UtilizatorController : ApiController
    {

    [Route("api/Utilizator/login")]
    [AcceptVerbs("GET")]
    public bool Login(string user, string parola) {
          string query = @"
                        select * from      
                        dbo.users
                        where username='" + user + "' and passwd ='" + parola + "'";
          DataTable table = new DataTable();
          using (var con = new SqlConnection(ConfigurationManager.
              ConnectionStrings["AngajatAppDB"].ConnectionString))
          using (var cmd = new SqlCommand(query, con))
          using (var da = new SqlDataAdapter(cmd))
          {
            cmd.CommandType = CommandType.Text;
            da.Fill(table);
          }
      if (table.Rows.Count > 0)
      {
        return true;
      }
      return false;

    }

        public HttpResponseMessage Get()
        {
            string query = @"
                    select id, coordinator_name, username, passwd from      
                    dbo.users
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AngajatAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Utilizator dep)
        {
            try
            {
                string query = @"
                        insert into dbo.users values
                        (
                        '" + dep.id + @"'
                        '" + dep.coordinator_name + @"'
                        '" + dep.username + @"'
                        '" + dep.passwd + @"'
                        )
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngajatAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    //da.Fill(table);

                }
                return "Added Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Utilizator dep)
        {
            try
            {
                string query = @"
                        update dbo.users set User=
                        '" + dep.username + @"'
                        where Id=" + dep.id + @"
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngajatAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    //da.Fill(table);

                }
                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                        delete dbo.users 
                        where Id =" + id + @"
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngajatAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    //da.Fill(table);

                }
                return "Deleted Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Delete!!";
            }
        }
    }
}
