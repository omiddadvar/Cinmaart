using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Application.Features.Countries.Commands.AddCountry
{
    public class AddCountryCommandHandler(
            IMapper mapper,
            ICountryRepository countryRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddCountryCommandHandler> logger
        ) : IRequestHandler<AddCountryCommand, Result<CountryDTO>>
    {
        public async Task<Result<CountryDTO>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var country = mapper.Map<Country>(request);
                country = await countryRepository.AddAsync(country);
                await unitOfWork.SaveAsync(cancellationToken);
                
                var countryDTO = mapper.Map<CountryDTO>(country);
                return Result<CountryDTO>.Success(countryDTO);
            }
            catch( Exception ex )
            {
                logger.LogError(ex, "Error while adding country, requested data = {request}", request.ToJson());
                return Result<CountryDTO>.Failure("AddCountry.Exception", ex.Message);
            }
        }
    }
}
