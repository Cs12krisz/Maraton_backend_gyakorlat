using MaratonValto.Models;
using MaratonValto.Models.Dtos;
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
                var futok = await _context.Futoks.Include(f => f.Eredmenyeks).ToArrayAsync();
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
                var oneFuto = await _context.Futoks.Include(f => f.Eredmenyeks).FirstOrDefaultAsync(e => e.Fid == id);
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

        public async Task<object> PutOneData(PutEredmenyDto putEredmenyDto)
        {
            try
            {
                if (putEredmenyDto != null)
                {
                    var futo = await _context.Futoks.Include(f => f.Eredmenyeks).FirstOrDefaultAsync(f => f.Fid == putEredmenyDto.Fid);
                    if (futo != null)
                    {
                        foreach (var item in futo.Eredmenyeks)
                        {
                            item.Ido = putEredmenyDto.Ido;
                        }
                        _context.Update(futo);
                        await _context.SaveChangesAsync();
                        return new { value = futo, message = "Sikeres módosítás" };
                    }

                }

                return "Sikertelen módosítás";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
