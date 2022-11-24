using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class ProjectionService : BaseCRUDService<ProjectionDto, Projection, ProjectionSearchObject, ProjectionUpsertRequest, ProjectionUpsertRequest>,
        IProjectionService
    {
        public ProjectionService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

        public override IQueryable<Projection> AddFilter(IQueryable<Projection> query, ProjectionSearchObject search)
        {
            var filteredQuery = query;

            if (!string.IsNullOrWhiteSpace(search.Name))
                filteredQuery = filteredQuery.Include(x => x.Movie).Where(x => x.Movie.Name.ToLower().Contains(search.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(search.Status) && search.Status != "Svi")
                filteredQuery = filteredQuery.Where(x => x.Status!.ToLower().Contains(search.Status.ToLower()));

            if (search.HallId != Guid.Empty && search.HallId is not null)
                filteredQuery = filteredQuery.Where(x => x.HallId! == search.HallId);

            if (search.DateTime is not null)
                filteredQuery = filteredQuery.Where(x => x.DateTime.Value == search.DateTime);


            return filteredQuery;

        }

        public override IQueryable<Projection> AddInclude(IQueryable<Projection> query, ProjectionSearchObject search)
        {
            
            if(search?.IncludeMovies is true)
            {
                query = query.Include(x => x.Movie);
            }

            if (search?.IncludeHalls is true)
            {
                query = query.Include(x => x.Hall);
            }

            if (search?.IncludePrices is true)
            {
                query = query.Include(x => x.Price);
            }

            return query;
        }
    }
}
