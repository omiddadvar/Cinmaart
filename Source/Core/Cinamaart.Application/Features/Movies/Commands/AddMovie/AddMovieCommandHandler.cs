using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Cinamaart.Application.Features.Movies.Commands.AddMovie
{
    internal class AddMovieCommandHandler(
            IMapper mapper,
            IMovieRepository movieRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddMovieCommandHandler> logger
        ) : IRequestHandler<AddMovieCommand, Result<MovieDTO>>
    {
        public async Task<Result<MovieDTO>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movie = mapper.Map<Movie>(request);
                movie = await movieRepository.AddAsync(movie);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<MovieDTO>(movie);
                return Result<MovieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding movie, requested data = {request}", request.ToJson());
                return Result<MovieDTO>.Failure("AddMovie.Exception", ex.Message);
            }
        }
    }
}
