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
            try
            {
                if (putEredmenyDto != null)
                {
                    Eredmenyek newEredmenyek = new Eredmenyek()
                    {
                        Kor = putEredmenyDto.Kor,
                        Ido = putEredmenyDto.Ido
                    };

                    var futo = _context.Eredmenyeks.FirstOrDefault(e => e.FutoNavigation.Fid == putEredmenyDto.Fid);
                    if (futo != null)
                    {
                        futo.Ido = putEredmenyDto.Ido;
                        futo.Kor = putEredmenyDto.Kor;
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
