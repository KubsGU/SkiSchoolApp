using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Commands.CreateRentalReport;
public class RentalReportRecord
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ClientFullName { get; set; }
    public string ClientPesel { get; set; }
    public List<Equipment> Equipment { get; set; }
    public bool Status { get; set; }
}
