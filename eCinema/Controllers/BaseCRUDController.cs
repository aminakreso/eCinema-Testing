using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
        where T : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _baseCRUDService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _baseCRUDService = service;
        }

        [HttpPost]
        public virtual async Task<T> Insert(TInsert insert)
        {
            return await _baseCRUDService.Insert(insert);
        }

        [HttpPut("{id}")]
        public virtual async Task<T> Update(Guid id, TUpdate update)
        {
            return await _baseCRUDService.Update(id, update);
        }
        
        [HttpPut("{id}/Delete")]
        public virtual async Task<T> Delete(Guid id)
        {
            return await _baseCRUDService.Delete(id);
        }

    }
}
