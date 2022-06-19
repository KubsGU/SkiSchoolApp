using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiSchool.Domain.Entities;
public class Report
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public byte[] Data { get; set; }
}
