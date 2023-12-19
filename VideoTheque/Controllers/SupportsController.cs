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

    }
}
