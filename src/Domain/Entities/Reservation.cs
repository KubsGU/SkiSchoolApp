using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiSchool.Domain.Entities;
public class Reservation
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
}
