using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiSchool.Domain.Entities;
public class Timetable
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Trainer Trainer { get; set; }
    public Client Client { get; set; }
    public bool IsCancelled { get; set; }
}
