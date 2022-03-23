using AutoMapper;
using DTMoney.Api.DTO;
using DTMoney.Api.Model;

namespace DTMoney.Api.Map
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<FinancialTransactionDTO, FinancialTransaction>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => $"{src.Type.Trim().ToUpperInvariant()}"))
                .ReverseMap();
        }
    }
}
