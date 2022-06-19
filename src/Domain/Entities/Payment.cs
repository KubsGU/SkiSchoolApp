using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiSchool.Domain.Entities;
public class Payment
{
    public int Id { get; set; }
    public decimal Price { get;set; }
    public DateTime Date { get; set; }
    public Equipment Equipment { get; set; }
    public Timetable Timetable { get; set; } 
    public bool Status { get; set; }
}
