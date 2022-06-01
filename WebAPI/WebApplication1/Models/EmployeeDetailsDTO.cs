using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class EmployeeDetailsDTO
  {
    public Int64 Id { get; set; }
    public string NrLegitimatie { get; set; }
    public string CNP { get; set; }
    public string OraIntrare { get; set; }
    public string OraIesire { get; set; }
    public string CarNumber { get; set; }
    public bool Admin { get; set; }
  }
}
