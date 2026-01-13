using MaratonValto.Models.Dtos;

namespace MaratonValto.Services
{
    public interface IEredmeny
    {
        Task<object> PutOneData(PutEredmenyDto putEredmenyDto);
    }
}
