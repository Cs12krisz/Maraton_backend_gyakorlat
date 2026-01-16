using MaratonValto.Models;
using MaratonValto.Models.Dtos;

namespace MaratonValto.Services
{
    public class EredmyenyService : IEredmeny
    {
        private readonly MaratonContext _context;

        public EredmyenyService(MaratonContext context)
        {
            _context = context;
        }

        public async Task<object> PutOneData(PutEredmenyDto putEredmenyDto)
        {
            throw new NotImplementedException();
        }
    }
}
