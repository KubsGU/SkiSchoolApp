namespace SkiSchool.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Yesterday { get; }
        DateTime Today { get; }
    }
}