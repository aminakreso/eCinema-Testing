using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Model.Constants;
using eCinema.Services.Database;
using eCinema.Services.ProjectionStateMachine;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Services
{
    public class ProjectionService : BaseCRUDService<ProjectionDto, Projection, ProjectionSearchObject, ProjectionUpsertRequest, ProjectionUpsertRequest>,
        IProjectionService
    {
        private readonly BaseProjectionState _baseState;
        public ProjectionService(CinemaContext cinemaContext, IMapper mapper, BaseProjectionState baseState) : base(cinemaContext, mapper)
        {
            _baseState = baseState;
        }

        public override async Task<ProjectionDto> Insert(ProjectionUpsertRequest insert)
        {
            var state = _baseState.CreateState(StateMachineConstants.InitialState);
           
            return await state.Insert(insert);
        }
        
        public override async Task<ProjectionDto> Update(Guid id, ProjectionUpsertRequest update)
        {
            var projection = await _cinemaContext.Projections.FindAsync(id);

            var state = _baseState.CreateState(projection?.StateMachine ?? throw new InvalidOperationException());
            state.CurrentEntity = projection;

            await state.Update(update);

            return await GetById(id);
        }

        public override async Task<ProjectionDto> Delete(Guid id)
        {
            var projection = await _cinemaContext.Projections.FindAsync(id);

            var state = _baseState.CreateState(projection?.StateMachine ?? throw new InvalidOperationException());
            state.CurrentEntity = projection;

            await state.Delete();

            return await GetById(id);
        }

        public async Task<ProjectionDto> Activate(Guid id)
        {
            var projection = await _cinemaContext.Projections.FindAsync(id);

            var state = _baseState.CreateState(projection?.StateMachine ?? throw new InvalidOperationException());
            state.CurrentEntity = projection;

            await state.Activate();

            return await GetById(id);
        }
        
        public async Task<ProjectionDto> Hide(Guid id)
        {
            var projection = await _cinemaContext.Projections.FindAsync(id);

            var state = _baseState.CreateState(projection?.StateMachine ?? throw new InvalidOperationException());
            state.CurrentEntity = projection;

            await state.Hide();

            return await GetById(id);
        }

        
        public async Task<List<string>> AllowedActions(Guid id)
        {
            var projection = await GetById(id);
            var state = _baseState.CreateState(projection.StateMachine ?? throw new InvalidOperationException());

            return state.AllowedActions();
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
                filteredQuery = filteredQuery.Where(x => x.DateTime.Value.Date == search.DateTime);


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
