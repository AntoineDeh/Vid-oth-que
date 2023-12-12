﻿namespace VideoTheque.Controllers
{
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using VideoTheque.Businesses.Personnes;
    using VideoTheque.DTOs;
    using VideoTheque.ViewModels;

    [ApiController]
    [Route("personnes")]
    public class PersonnesController : ControllerBase
    {

        private readonly IPersonnesBusiness _personnesBusiness;
        protected readonly ILogger<PersonnesController>_logger;

        public PersonnesController(IPersonnesBusiness personnesBusiness, ILogger<PersonnesController> logger)
        {
            _personnesBusiness = personnesBusiness;
            _logger = logger;
        }


        [HttpGet]
        public async Task<List<PersonneViewModel>> GetPersonnes() => (await _personnesBusiness.GetPersonnes()).Adapt<List<PersonneViewModel>>();

        [HttpGet("{id}")]
        public async Task<PersonneViewModel> GetPersonne([FromRoute] int id) => _personnesBusiness.GetPersonne(id).Adapt<PersonneViewModel>();

        [HttpPost]
        public async Task<IResult> InsertPersonne([FromBody] PersonneViewModel personneVM)
        {
            var created = _personnesBusiness.InsertPersonne(personneVM.Adapt<PersonneDto>());
            return Results.Created($"/personnes/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdatePersonne([FromRoute] int id, [FromBody] PersonneViewModel personneVM)
        {
            _personnesBusiness.UpdatePersonne(id, personneVM.Adapt<PersonneDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeletePersonne([FromRoute] int id)
        {
            _personnesBusiness.DeletePersonne(id);
            return Results.Ok();
        }
    }
}
