using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AngajatController : ApiController
    {
        public HttpResponseMessage GetAngajatWithFilter(string SearchArea)
        {
            string query = @"select cnp, first_name, last_name, pic, legitimation_number, department_id, schedule_start, schedule_end, security_code, registration_number, access, cnp_access_granted, date_access_granted from dbo.employees where first_name like '%" + SearchArea + "%' OR last_name like '%" + SearchArea + "'";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AngajatAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            List<EmployeeDTO> studentList = new List<EmployeeDTO>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                EmployeeDTO student = new EmployeeDTO();
                student.Id = Convert.ToInt64(table.Rows[i]["cnp"]);
                student.Nume = table.Rows[i]["first_name"].ToString();
                student.Prenume = table.Rows[i]["last_name"].ToString();
                studentList.Add(student);
            }
            return Request.CreateResponse(HttpStatusCode.OK, studentList);
        }

    [Route("api/Angajat/entry/details")]
    [AcceptVerbs("GET")]
    public HttpResponseMessage GetEntryDetails(Int64 idAngajat) {
        string query = @"select cnp, entry_date, exit_date from dbo.entries_exits where cnp like '%" + idAngajat + "%'";
        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["AngajatAppDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);

        }
        List<EntryDetailsDTO> studentList = new List<EntryDetailsDTO>();
        for (int i = 0; i < table.Rows.Count; i++)
        {
        DateTime ziIntrare;
        DateTime ziIesire;
        EntryDetailsDTO student = new EntryDetailsDTO();
          ziIntrare = (DateTime)table.Rows[i]["entry_date"];
          ziIesire = (DateTime)table.Rows[i]["exit_date"];
          student.zi = ziIntrare.Day.ToString();
          student.luna = ziIesire.Month.ToString();
          student.oraIesire = ziIesire.Hour.ToString()+":"+ziIesire.Minute.ToString()+":"+ziIesire.Second.ToString();
          student.oraIntrare = ziIntrare.Hour.ToString()+":"+ziIntrare.Minute.ToString()+":"+ziIntrare.Second.ToString();
          studentList.Add(student);
        }
        return Request.CreateResponse(HttpStatusCode.OK, studentList);
    }


    [Route("api/Angajat/details")]
    [AcceptVerbs("GET")]
    public HttpResponseMessage GetDetailsForAngajat(Int64 idAngajat) {
        string query = @"select cnp, legitimation_number, schedule_start, schedule_end, registration_number, cnp_access_granted from dbo.employees where cnp like '%" + idAngajat + "%'";
        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["AngajatAppDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);

        }
        EmployeeDetailsDTO employee = new EmployeeDetailsDTO();
        if(table.Rows.Count > 0)
        {
        employee.Id = Convert.ToInt64(table.Rows[0]["cnp"]);
        employee.OraIntrare = table.Rows[0]["schedule_start"].ToString();
        employee.OraIesire = table.Rows[0]["schedule_end"].ToString();
        employee.CarNumber = table.Rows[0]["registration_number"].ToString();
        employee.Admin = (table.Rows[0]["cnp_access_granted"] != null && (table.Rows[0]["cnp_access_granted"].ToString() != String.Empty));
        employee.CNP = table.Rows[0]["cnp"].ToString();
        employee.NrLegitimatie = table.Rows[0]["legitimation_number"].ToString();
        }
        return Request.CreateResponse(HttpStatusCode.OK, employee);
    }
        // GET: Angajat
        public HttpResponseMessage Get()
        {
            string query = @"
                    select cnp, first_name, last_name, pic, legitimation_number, department_id,
                    schedule_start, schedule_end, security_code, registration_number, access,
                    cnp_access_granted, date_access_granted from
                    dbo.employees
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
        public string Post(Angajat dep)
        {
            try
            {
                string query = @"
                        insert into dbo.employees values
                        (
                        '" + dep.cnp + @"'
                        '" + dep.first_name + @"'
                        '" + dep.last_name + @"'
                        '" + dep.pic + @"'
                        '" + dep.legetimation_number + @"'
                        '" + dep.department + @"'
                        '" + dep.schedule_start + @"'
                        '" + dep.schedule_end + @"'
                        '" + dep.security_code + @"'
                        '" + dep.registration_number + @"'
                        '" + dep.access + @"'
                        '" + dep.cnp_access_granted + @"'
                        '" + dep.data_access_granted + @"'
                        )
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
                        update dbo.employees set Name=
                        '" + dep.first_name + @"'
                        where CNP=" + dep.cnp + @"
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
                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }
        [Route("api/Angajat/delete")]
        public string DeleteEmployee(string IdCNP)
        {
            try
            {
                string query = @"
                        delete dbo.employees
                        where CNP like '%" + IdCNP + "%'";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngajatAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

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
