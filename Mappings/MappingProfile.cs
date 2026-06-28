using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Models;

namespace CarRentalAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<CreateCarDto, Car>();
        CreateMap<UpdateCarDto, Car>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Rental, RentalDto>().ReverseMap();
        CreateMap<CreateRentalDto, Rental>();
        CreateMap<UpdateRentalDto, Rental>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<CreatePaymentDto, Payment>();
    }
}