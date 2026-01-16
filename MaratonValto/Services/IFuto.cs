using MaratonValto.Models.Dtos;

namespace MaratonValto.Services
{
    public interface IFuto
    {
        Task<object> GetAllData();
        Task<object> GetOneData(int id);
        Task<object> PutOneData(PutEredmenyDto putEredmenyDto);

    }
}
