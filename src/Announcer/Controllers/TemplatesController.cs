using Announcer.Contracts;
using Announcer.Dtos.Requests;
using Announcer.Dtos.Responses;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using Announcer.Services.Communication;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcer.Controllers
{
    /// <summary>
    /// Template Api Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class TemplatesController : BaseApiController
    {
        private readonly ITemplateService _templateService;
        private readonly IClientService _clientService;

        /// <summary>
        /// Template Api Controller constructor
        /// </summary>
        /// <param name="templateService"></param>
        /// <param name="clientService"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public TemplatesController(ITemplateService templateService, IClientService clientService, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, ILogger<TemplatesController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _templateService = templateService ?? throw new ArgumentNullException(nameof(templateService));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        /// <summary>
        /// Creates a Template.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Templates
        ///     {
        ///         "name": "Sample Template",
        ///         "content": "{ \"header\": { \"columns\": [ \"Header 1\", \"Header 2\", \"Header 3\" ] } }"
        ///     }
        /// </remarks>
        /// <param name="templateDTO">Template to be created</param>
        /// <returns>A newly created Template</returns>
        /// <response code="201">Returns the newly created template</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(TemplateDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TemplateDTO>> CreateTemplateAsync([FromBody] SaveTemplateDTO templateDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateTemplateAsync));

            if (templateDTO == null) return BadRequest("Template info is null");

            // Check if template exists
            if (await _templateService.ExistsAsync(t => t.Name == templateDTO.Name))
                return BadRequest($"A template with name {templateDTO.Name} exists");

            // Create a new template
            var addResult = await _templateService.AddAsync(_mapper.Map<Template>(templateDTO));
            if (!addResult.IsSuccessful)
                return BadRequest(addResult.Message);

            _logger.LogDebug($"Template '{addResult.Model.Name}' with id '{addResult.Model.Id}' created.");

            return CreatedAtRoute("GetTemplate", new { id = addResult.Model.Id },
                _mapper.Map<TemplateDTO>(addResult.Model));
        }

        /// <summary>
        /// Deletes a Template.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE api/Templates/1
        /// </remarks>
        /// <param name="id">Template Id to be deleted</param>
        /// <returns>Deleted Template</returns>
        /// <response code="200">Returns deleted template</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the template is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTemplateAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteTemplateAsync));

            // Check if template exists
            var getResult = await _templateService.GetByIdAsync(id);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Template with id {id} not found.");

            // Delete template
            var deleteResult = await _templateService.DeleteAsync(getResult.Model);

            if (deleteResult.IsSuccessful)
                _logger.LogDebug($"Template with id {id} deleted.");

            return deleteResult.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Templates with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Templates?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Templates with paging support</returns>
        /// <response code="200">Returns all Templates in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTemplatesAsync([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllTemplatesAsync));

            var includeString = queryParams.IsDetailRequired ? "Clients" : "";

            var response = await _templateService.ListAsync(includeString: includeString,
                page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} templates. Listing page {queryParams.Page} of {response.TotalPages}");

            var result = new PagedResponse<TemplateDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                TotalItems = response.TotalItems,
                PageSize = queryParams.PageSize ?? 0,
                CurrentPage = queryParams.Page ?? 0,
                Model = _mapper.Map<IEnumerable<TemplateDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets clients of a Template with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Templates/1/Clients
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Templates of Client with specified id</returns>
        /// <response code="200">Returns templates of Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id:int}/Clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientsByTemplateAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetClientsByTemplateAsync));

            var response = await _clientService.ListClientsByTemplateAsync(id);

            var result = new ListResponse<ClientDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<IEnumerable<ClientDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Template with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Templates/1
        /// </remarks>
        /// <param name="id">Template id</param>
        /// <returns>Template with specified id</returns>
        /// <response code="200">Returns Template with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id:int}", Name = "GetTemplate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTemplateByIdAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetTemplateByIdAsync));

            var response = await _templateService.GetAsync(g => g.Id == id, "Clients", true);

            _logger.LogDebug($"Found template with id {id}");

            var result = new SingleResponse<TemplateDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<TemplateDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all templates matching parameters</returns>
        /// <response code="200">Returns all templates matching parameters</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("LoadTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadTableAsync([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTableAsync));

            try
            {
                var dtResult = await _templateService.LoadDatatableAsync(dtParameters);

                return Ok(new
                {
                    draw = dtResult.Draw,
                    recordsTotal = dtResult.RecordsTotal,
                    recordsFiltered = dtResult.RecordsFiltered,
                    data = _mapper.Map<IEnumerable<TemplateDTO>>(dtResult.Data)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates Template with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Templates/1
        ///     {
        ///         "name": "Sample Template",
        ///         "content": "{ \"header\": { \"columns\": [ \"Header 1\", \"Header 2\", \"Header 3\" ] } }"
        ///     }
        /// </remarks>
        /// <param name="id">Template id</param>
        /// <param name="templateDTO">Template to be updated</param>
        /// <returns>Template with specified id</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTemplateAsync(int id, [FromBody] SaveTemplateDTO templateDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateTemplateAsync));

            // Check if template exists
            var getResult = await _templateService.GetByIdAsync(id);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Template with id {id} not found.");

            // Update template
            var oldTemplate = getResult.Model; 
            _mapper.Map(templateDTO, oldTemplate);

            var response = await _templateService.UpdateAsync(oldTemplate);

            _logger.LogDebug($"Template with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}