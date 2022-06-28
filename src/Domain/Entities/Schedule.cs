using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiSchool.Domain.Entities;
public class Schedule
{
    public int Id { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; }
}
