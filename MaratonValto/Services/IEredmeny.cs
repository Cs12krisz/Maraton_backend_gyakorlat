using MaratonValto.Models.Dtos;

namespace MaratonValto.Services
{
    public interface IEredmeny
    {
        Task<object> PostOneData(PostEredmenyDto postEredmenyDto);
    }
}
