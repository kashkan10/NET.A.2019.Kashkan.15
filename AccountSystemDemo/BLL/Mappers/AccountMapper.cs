using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Collections.Generic;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountDTO, Account>().ForMember("Owner", opt => opt.MapFrom(src => src.Name + " " + src.LastName));
            cfg.CreateMap<Account, AccountDTO>().ForMember("Name", opt => opt.MapFrom(src => src.Owner.Split()[0])).ForMember("LastName", opt => opt.MapFrom(src => src.Owner.Split()[1]));
            cfg.CreateMap<IEnumerable<Account>, IEnumerable<AccountDTO>>();
        }).CreateMapper();
    }
}
