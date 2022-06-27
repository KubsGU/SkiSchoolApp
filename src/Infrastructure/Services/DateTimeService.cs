using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public DateTime Yesterday => DateTime.Today.AddDays(-1);
        public DateTime Today => DateTime.Today;
    }
}