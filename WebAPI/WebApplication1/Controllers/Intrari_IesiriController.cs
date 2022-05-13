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

namespace WebApplication1.Controllers
{
    public class Intrari_IesiriController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select CNP, Data_Intrare, Data_Iesire from
                    dbo.Intrari_Iesiri
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
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Intrari_Iesiri dep)
        {
            try
            {
                string query = @"
                        insert into dbo.Intrari_Iesiri values
                        (
                        '" + dep.CNP + @"'
                        '" + dep.Data_Intrare + @"'
                        '" + dep.Data_Iesire + @"'
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

        public string Put(Intrari_Iesiri dep)
        {
            try
            {
                string query = @"
                        update dbo.Intrari_Iesiri set 
                        Data_Intrare= '" + dep.Data_Intrare + @"'
                        ,Data_Iesire='" + dep.Data_Iesire + @"'
                        where CNP=" + dep.CNP + @"
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

        public string Delete(int cnp)
        {
            try
            {
                string query = @"
                        delete dbo.Intrari_Iesiri 
                        where CNP=" + cnp + @"
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
