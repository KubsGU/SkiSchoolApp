using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Clients.Queries;

public class ClientDto : IMapFrom<Client>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IDNo { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
}
