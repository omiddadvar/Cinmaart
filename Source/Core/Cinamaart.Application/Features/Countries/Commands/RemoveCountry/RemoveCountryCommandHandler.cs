using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Commands.RemoveCountry
{
    public class RemoveCountryCommandHandler(
            ICountryRepository countryRepository,
            IUnitOfWork unitOfWork,
            ILogger<RemoveCountryCommandHandler> logger
        ) : IRequestHandler<RemoveCountryCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RemoveCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await countryRepository.DeleteAsync(request.Id);
                await unitOfWork.SaveAsync(cancellationToken);
                return Result<bool>.Success(true);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while removing country, requested data = {request}", request.ToJson());
                return Result<bool>.Failure("RemoveCountry.Exception", ex.Message);
            }
        }
    }
}
