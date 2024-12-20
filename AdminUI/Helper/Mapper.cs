﻿using AdminUI.Objects;
using AutoMapper;

namespace AdminUI.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<EmployeeForm, EmployeeModel>()
             .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.HasValue ? DateOnly.FromDateTime(src.BirthDate.Value) : default))
             .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.HasValue ? DateOnly.FromDateTime(src.StartDate.Value) : (DateOnly?)null));

            // Map từ EmployeeModel sang EmployeeForm
            CreateMap<EmployeeModel, EmployeeForm>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null));

            CreateMap<ProductModel, SelectImportItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SelectImportItem, ImportItem>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ImportPrice))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ImportQty));

            CreateMap<ProductModel, SelectExportItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<SelectExportItem, ExportItem>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ExportPrice))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ExportQty));
        }
    }
}
