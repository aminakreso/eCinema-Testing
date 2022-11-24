using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class ProjectionController : BaseCRUDController<ProjectionDto, ProjectionSearchObject, ProjectionUpsertRequest, ProjectionUpsertRequest>
    {
        private readonly IProjectionService _projectionService;
        public ProjectionController(IProjectionService projectionService)
            : base(projectionService)
        {
            _projectionService = projectionService;
        }
    }
}
