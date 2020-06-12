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
    /// Setting Api Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class SettingsController : BaseApiController
    {
        private readonly ISettingService _settingService;

        /// <summary>
        /// Setting Api Controller constructor
        /// </summary>
        /// <param name="settingService"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public SettingsController(ISettingService settingService, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<SettingsController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _settingService = settingService ?? throw new ArgumentNullException(nameof(settingService));
        }

        /// <summary>
        /// Creates a Setting.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Settings
        ///     {
        ///         "key": "Organization",
        ///         "value": "xxx Şehir Hastanesi"
        ///     }
        /// </remarks>
        /// <param name="settingDTO">Setting to be created</param>
        /// <returns>A newly created Setting</returns>
        /// <response code="201">Returns the newly created setting</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(SettingDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SettingDTO>> CreateSettingAsync([FromBody] SaveSettingDTO settingDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateSettingAsync));

            if (settingDTO == null) return BadRequest("Setting info is null");

            // Check if setting exists
            if (await _settingService.ExistsAsync(s => s.Key == settingDTO.Key))
                return BadRequest($"A setting with key {settingDTO.Key} exists");

            // Create a new setting
            var addResult = await _settingService.AddAsync(_mapper.Map<Setting>(settingDTO));
            if (!addResult.IsSuccessful)
                return BadRequest(addResult.Message);

            _logger.LogDebug($"Setting '{addResult.Model.Key}' with id '{addResult.Model.Id}' created.");

            return CreatedAtRoute("GetSetting", new { id = addResult.Model.Key },
                _mapper.Map<SettingDTO>(addResult.Model));
        }

        /// <summary>
        /// Deletes a Setting.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE api/Settings/1
        /// </remarks>
        /// <param name="id">Setting id to be deleted</param>
        /// <returns>Deleted Setting</returns>
        /// <response code="200">Returns deleted setting</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the setting is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSettingAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteSettingAsync));

            // Check if setting exists
            var getResult = await _settingService.GetByIdAsync(id);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Setting with key {id} not found.");

            // Delete setting
            var deleteResult = await _settingService.DeleteAsync(getResult.Model);

            if (deleteResult.IsSuccessful)
                _logger.LogDebug($"Setting with key {id} deleted.");

            return deleteResult.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Settings with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Settings?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Settings with paging support</returns>
        /// <response code="200">Returns all Settings in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSettingsAsync([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllSettingsAsync));

            var includeString = "";

            var response = await _settingService.ListAsync(includeString: includeString,
                page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} settings. Listing page {queryParams.Page} of {response.TotalPages}");

            var result = new PagedResponse<SettingDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                TotalItems = response.TotalItems,
                PageSize = queryParams.PageSize ?? 0,
                CurrentPage = queryParams.Page ?? 0,
                Model = _mapper.Map<IEnumerable<SettingDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Setting with specified key.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Settings/organization
        /// </remarks>
        /// <param name="id">Setting key</param>
        /// <returns>Setting with specified key</returns>
        /// <response code="200">Returns Setting with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}", Name = "GetSetting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSettingByKeyAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetSettingByKeyAsync));

            var response = await _settingService.GetAsync(g => g.Key.ToUpperInvariant() == id.ToUpperInvariant());

            _logger.LogDebug($"Found setting with {id}");

            var result = new SingleResponse<SettingDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<SettingDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Setting with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Settings/1
        /// </remarks>
        /// <param name="id">Setting id</param>
        /// <returns>Setting with specified key</returns>
        /// <response code="200">Returns Setting with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSettingByIdAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetSettingByKeyAsync));

            var response = await _settingService.GetAsync(g => g.Id == id, "", true);

            _logger.LogDebug($"Found setting with key {id}");

            var result = new SingleResponse<SettingDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<SettingDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all settings matching parameters</returns>
        /// <response code="200">Returns all settings matching parameters</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("LoadTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadTableAsync([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTableAsync));

            try
            {
                var dtResult = await _settingService.LoadDatatableAsync(dtParameters);

                return Ok(new
                {
                    draw = dtResult.Draw,
                    recordsTotal = dtResult.RecordsTotal,
                    recordsFiltered = dtResult.RecordsFiltered,
                    data = _mapper.Map<IEnumerable<SettingDTO>>(dtResult.Data)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates Setting with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Settings/1
        ///     {
        ///         "key": "Organization",
        ///         "value": "yyy Şehir Hastanesi"
        ///     }
        /// </remarks>
        /// <param name="id">Setting id</param>
        /// <param name="settingDTO">Setting to be updated</param>
        /// <returns>Setting with specified id</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSettingAsync(int id, [FromBody] SaveSettingDTO settingDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateSettingAsync));

            // Check if setting exists
            var getResult = await _settingService.GetByIdAsync(id);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Setting with id {id} not found.");

            // Update setting
            var oldSetting = getResult.Model;
            _mapper.Map(settingDTO, oldSetting);

            var response = await _settingService.UpdateAsync(oldSetting);

            _logger.LogDebug($"Setting with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}