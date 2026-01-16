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

        public async Task<object> PostOneData(PostEredmenyDto postEredmenyDto)
        {
            try
            {
                if (postEredmenyDto != null)
                {

                    var newEredmeny = new Eredmenyek() 
                    { 
                        Futo = postEredmenyDto.Futo,
                        Kor = postEredmenyDto.Kor,
                        Ido = postEredmenyDto.Ido,
                    };
                    await _context.Eredmenyeks.AddAsync(newEredmeny);
                    await _context.SaveChangesAsync();
                    return new { value = newEredmeny, message = "Sikeres hozzáadás" };
                }

                return "Sikertelen hozzáadás";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
