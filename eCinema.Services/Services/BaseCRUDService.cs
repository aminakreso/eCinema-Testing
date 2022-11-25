using AutoMapper;
using eCinema.Model.Helpers;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using InvalidOperationException = System.InvalidOperationException;

namespace eCinema.Services.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch>,
        ICRUDService<T, TSearch, TInsert, TUpdate> where T : class where TDb : class where TSearch : BaseSearchObject
        where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public virtual async Task<T> Insert(TInsert insert)
        {
            var set = _cinemaContext.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(insert);
            await BeforeInsert(insert,entity);

            await set.AddAsync(entity);
            IsActiveHelper<TDb>.SetIsActive(entity, true);
            
            await _cinemaContext.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Update(Guid id, TUpdate update)
        {
            var set = _cinemaContext.Set<TDb>();

            var entity = await set.FindAsync(id);

            if (entity is null)
                throw new InvalidOperationException();

            _mapper.Map(update, entity);

            await BeforeUpdate(update,entity);

            await _cinemaContext.SaveChangesAsync();

            return _mapper.Map<T>(entity);

        }
        
        public virtual async Task<T> Delete(Guid id)
        {
            var set = _cinemaContext.Set<TDb>();

            var entity = await set.FindAsync(id);
            
            if (entity is null)
                throw new InvalidOperationException();

            IsActiveHelper<TDb>.SetIsActive(entity, false);
            
            await _cinemaContext.SaveChangesAsync();

            return await GetById(id);
        }

        public virtual async Task BeforeInsert(TInsert? insert = null, TDb? entity = null)
        {

        }

        public virtual async Task BeforeUpdate(TUpdate? update = null, TDb? entity=null)
        {

        }
    }
}
