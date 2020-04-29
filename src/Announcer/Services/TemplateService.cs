using Announcer.Contracts;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using Announcer.Services.Communication;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Announcer.Services
{
    /// <summary>
    /// Template entity service
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class TemplateService : BaseService<Template>, ITemplateService
    {
        /// <summary>
        /// Template service constructor
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public TemplateService(IUnitOfWork unitOfWork, ILogger<BaseService<Template>> logger)
            : base(unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<ISingleResponse<Template>> GetByIdAsync(int id)
        {
            _logger.LogDebug($"'{nameof(GetByIdAsync)}' has been invoked");

            var response = new SingleResponse<Template>();

            try
            {
                response.Model = await _repository.GetAsync(t => t.Id == id, includeDeleted: true);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(GetByIdAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public override async Task<DTResult<Template>> LoadDatatableAsync(DTParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;
            var isDeleted = dtParameters.Columns[3].Search.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = await _repository.ListAsync(includeString: "Clients", includeDeleted: true);

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.Content != null && r.Content.ToUpper().Contains(searchBy.ToUpper()));
            }

            if (!string.IsNullOrEmpty(isDeleted))
            {
                result = result.Where(r => r.IsDeleted == (isDeleted == "0"));
            }

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _repository.CountAsync();

            return new DTResult<Template>()
            {
                Draw = dtParameters.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            };
        }
    }
}