using MaratonValto.Models;

namespace MaratonValto.Services
{
    public class EredmyenyService : IEredmeny
    {
        private readonly MaratonContext _context;

        public EredmyenyService(MaratonContext context)
        {
            _context = context;
        }


    }
}
