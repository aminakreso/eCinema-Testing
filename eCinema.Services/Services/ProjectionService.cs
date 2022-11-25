using System.Security.Cryptography.X509Certificates;
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

            if (search.StartTime is not null)
                filteredQuery = filteredQuery.Where(x => x.StartTime!.Value == search.StartTime);

            return filteredQuery;

        }

        public async override Task BeforeInsert(ProjectionUpsertRequest insert, Projection entity)
        {
            var flag =await ProjectionExist(Guid.Empty, insert);
            if (flag)
                throw new Exception("Not allowed!");
        }
        
        public async override Task BeforeUpdate(ProjectionUpsertRequest update, Projection entity)
        {
            var flag =await ProjectionExist(entity.Id, update);
            if (flag)
                throw new InvalidOperationException("Not allowed!");
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

        public async Task<bool> ProjectionExist(Guid? id,ProjectionUpsertRequest projectionUpsertRequest)
        {
            if (id != Guid.Empty && await _cinemaContext.Projections.AnyAsync(x => x.Id == id) == false)
            {
                throw new Exception("Can't update unexisting projection!");
            }
            
            return await _cinemaContext.Projections.Where(x=> x.HallId == projectionUpsertRequest.HallId)
                .AnyAsync(x => ((projectionUpsertRequest.StartTime >= x.StartTime && projectionUpsertRequest.StartTime <= x.EndTime)
                           || (projectionUpsertRequest.EndTime >= x.StartTime && projectionUpsertRequest.EndTime <= x.EndTime)
                           || (projectionUpsertRequest.StartTime <= x.StartTime && projectionUpsertRequest.EndTime >= x.EndTime))
                          && x.Id != id);
        }

        public override async Task<ProjectionDto> Delete(Guid id)
        {
            if (await CanDelete(id) == false)
                throw new Exception("Can't delete started projection!");
            return await base.Delete(id);
        }

        private async Task<bool> CanDelete(Guid id)
        {
            var projection = await GetById(id);

            return !(projection.StartTime <= DateTime.Now) || !(projection.EndTime >= DateTime.Now);
        }
    }
}
