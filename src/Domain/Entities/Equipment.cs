namespace SkiSchool.Domain.Entities;
public class Equipment
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
