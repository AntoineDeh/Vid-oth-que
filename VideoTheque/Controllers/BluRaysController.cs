namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.BluRays;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("films")]
    public class BluRaysController : ControllerBase
    {

        private readonly IBluRaysBusiness _BluRaysBusiness;
        protected readonly ILogger<BluRaysController> _Logger;

        public BluRaysController(IBluRaysBusiness bluRaysBusiness, ILogger<BluRaysController> logger)
        {
            _BluRaysBusiness = bluRaysBusiness;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<List<BluRayViewModel>> GetBluRays() => (await _BluRaysBusiness.GetBluRays()).Adapt<List<BluRayViewModel>>();

        [HttpGet("{id}")]
        public async Task<BluRayViewModel> GetBluRay([FromRoute] int id) => _BluRaysBusiness.GetBluRay(id).Adapt<BluRayViewModel>();

        [HttpPost]
        public async Task<IResult> InsertBluRay([FromBody] BluRayViewModel bluRayVM)
        {
            var created = _BluRaysBusiness.InsertBluRay(bluRayVM.Adapt<BluRayDto>());
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateBluRay([FromRoute] int id, [FromBody] BluRayViewModel bluRayVM)
        {
            _BluRaysBusiness.UpdateBluRay(id, bluRayVM.Adapt<BluRayDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteBluRay([FromRoute] int id)
        {
            _BluRaysBusiness?.DeleteBluRay(id);
            return Results.Ok();
        }
    }
}
