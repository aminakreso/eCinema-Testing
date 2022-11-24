using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface IProjectionService : ICRUDService<ProjectionDto, ProjectionSearchObject,
        ProjectionUpsertRequest, ProjectionUpsertRequest>
    { }
}
