using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler(
            IMapper mapper,
            ICountryRepository countryRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateCountryCommandHandler> logger
        ) : IRequestHandler<UpdateCountryCommand, Result<CountryDTO>>
    {
        public async Task<Result<CountryDTO>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var country = mapper.Map<Country>(request);
                await countryRepository.UpdateAsync(country);
                await unitOfWork.SaveAsync(cancellationToken);

                var countryDTO = mapper.Map<CountryDTO>(country);
                return Result<CountryDTO>.Success(countryDTO);
            }
            catch( Exception ex )
            {
                logger.LogError(ex, "Error while updating country, requested data = {request}", request.ToJson());
                return Result<CountryDTO>.Failure("UpdateCountry.Exception", ex.Message);
            }
        }
    }
}
