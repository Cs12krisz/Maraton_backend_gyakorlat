namespace MaratonValto.Services
{
    public interface IFuto
    {
        Task<object> GetAllData();
        Task<object> GetOneData(int id);
        Task<object> OutOneData(int id);

    }
}
