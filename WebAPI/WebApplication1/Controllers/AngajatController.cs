using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Data;
using System.Net.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AngajatController : ApiController
    {
        // GET: Angajat
        public HttpResponseMessage Get()
        {
            string query = @"
                    select CNP, Nume, Prenume, Poza, NR_Legitimatie, Departament,
                    Orar_Start, Orar_End, Cod_Securitate, Numar_Inregistrare, Acces,
                    CNP_Acordare_Drept,Data_Acordare_Drept from
                    dbo.Angajati
                    ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["AngajatAppDB"].ConnectionString))
                using(var cmd= new SqlCommand(query,con))
            using(var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                //da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Angajat dep)
        {
            try
            {
                string query = @"
                        insert into dbo.Angajati values
                        (
                        '" + dep.CNP + @"'
                        '" + dep.Nume+ @"'
                        '" + dep.Prenume + @"'
                        '" + dep.Poza + @"'
                        '" + dep.NR_Legitimatie + @"'
                        '" + dep.Departament + @"'
                        '" + dep.Orar_Start + @"'
                        '" + dep.Orar_End + @"'
                        '" + dep.Cod_Securitate + @"'
                        '" + dep.Numar_Inregistrari + @"'
                        '" + dep.Acces + @"'
                        '" + dep.CNP_Acordare_Drept + @"'
                        '" + dep.Data_Acordare_Drept + @"'
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

        public string Put(Angajat dep)
        {
            try
            {
                string query = @"
                        update dbo.Angajati set Nume=
                        '" + dep.Nume + @"'
                        where CNP="+dep.CNP+@"
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
                        delete dbo.Angajati
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

        [System.Web.Http.Route("api/Angajat/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Poze/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }

    }
}