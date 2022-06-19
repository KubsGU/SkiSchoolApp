﻿using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Equipments.Queries;
public class EquipmentDto :IMapFrom<Equipment>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }

}
