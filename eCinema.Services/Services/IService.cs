using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface IService<T, TSearch> where T : class where TSearch : BaseSearchObject
    {
        Task<IEnumerable<T>> GetAll(TSearch? search);
        Task<T> GetById(Guid id);
    }
}
