using AutoMapper;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Extentions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Cinamaart.Application.Features.Movies.Commands.UpdateMovie
{
    internal class UpdateMovieCommandHandler(
            IMapper mapper,
            IMovieRepository movieRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateMovieCommandHandler> logger
        ) : IRequestHandler<UpdateMovieCommand, Result<MovieDTO>>
    {
        public async Task<Result<MovieDTO>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movie = mapper.Map<Movie>(request);
                await movieRepository.UpdateAsync(movie);
                await unitOfWork.SaveAsync(cancellationToken);

                var data = mapper.Map<MovieDTO>(movie);
                return Result<MovieDTO>.Success(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while updating movie, requested data = {request}", request.ToJson());
                return Result<MovieDTO>.Failure("UpdateMovie.Exception", ex.Message);
            }
        }
    }
}
