using AutoMapper;
using CoreRestApplication.Model;

namespace CoreRestApplication.Data.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AddressDto, AddressModel>();
            CreateMap<CustomerDto, MrGreenCustomerModel>();
            CreateMap<CustomerDto, RedBetCustomerModel>();
        }
    }
}
