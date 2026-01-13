using MaratonValto.Models;
using Microsoft.EntityFrameworkCore;

namespace MaratonValto.Services
{
    public class FutoService : IFuto
    {
        private readonly MaratonContext _context;

        public FutoService(MaratonContext context)
        {
            _context = context;
        }

        public async Task<object> GetAllData()
        {
            try
            {
                var futok = await _context.Futoks.ToArrayAsync();
                return futok;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<object> GetOneData(int id)
        {
            try
            {
                var oneFuto = await _context.Futoks.FirstOrDefaultAsync(f => f.Fid == id);
                if (oneFuto != null)
                {
                    return oneFuto;
                }
                return "Nincs ilyen futó";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
