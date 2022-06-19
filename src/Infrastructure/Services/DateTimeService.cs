using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}