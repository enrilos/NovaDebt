using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.DTOs;

namespace NovaDebt
{
    public class NovaDebtProfile : Profile
    {
        public NovaDebtProfile()
        {
            this.CreateMap<TransactorDTO, Transactor>();
        }
    }
}
