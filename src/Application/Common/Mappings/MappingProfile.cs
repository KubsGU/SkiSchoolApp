﻿using AutoMapper;
using SkiSchool.Application.Reports.Commands.CreateReport;
using SkiSchool.Domain.Entities;
using System.Reflection;

namespace SkiSchool.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

            CreateMap<Payment, TimetableReportRecord>()
                .ForMember(dest => dest.ClientPesel, opt => opt.MapFrom(src => src.Rental.Client.Pesel))
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => src.Timetable.Client.Name + " " + src.Timetable.Client.Surname))
                .ForMember(dest => dest.TrainerFullName, opt => opt.MapFrom(src => src.Timetable.Trainer.Name + " " + src.Timetable.Trainer.Surname))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Timetable.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Timetable.EndDate))
                .ForMember(dest => dest.TypeOfService, opt => opt.MapFrom(src => src.Timetable.Trainer.TypeOfService));

        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}