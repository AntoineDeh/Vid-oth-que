namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.Supports;
    using VideoTheque.Businesses.Genres;
    using VideoTheque.DTOs;
    using VideoTheque.Repositories.Supports;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("supports")]
    public class SupportsController : ControllerBase
    {
        private readonly ISupportsBusiness _supportBusiness;
        protected readonly ILogger<SupportsController> _logger;

        public SupportsController(ILogger<SupportsController> logger, ISupportsBusiness supportsBusiness)
        {
            _logger = logger;
            _supportBusiness = supportsBusiness;
        }

        [HttpGet]
        public async Task<List<SupportsViewModel>> GetSupports() => (await _supportBusiness.GetSupports()).Adapt<List<SupportsViewModel>>();

        [HttpGet("{id}")]
        public async Task<SupportsViewModel> GetSupport([FromRoute] int id) => _supportBusiness.GetSupport(id).Adapt<SupportsViewModel>();

        [HttpPost]
        public async Task<IResult> InsentSupport([FromBody] SupportsViewModel supportVM)
        {
            var created = _supportBusiness.InsertSupport(supportVM.Adapt<SupportsDto>());
            return Results.Created($"/support/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSupport([FromRoute] int id, [FromBody] SupportsViewModel supportVM)
        {
            _supportBusiness.UpdateSupport(id, supportVM.Adapt<SupportsDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSupport([FromRoute] int id)
        {
            _supportBusiness.DeleteSupport(id);
            return Results.Ok();
        }
    }
}
