using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cinamaart.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<MainDBContext>(
              options =>
              {
                  options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
                  options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
              });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITvSerieRepository, TvSerieRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            return services;
        }
    }
}
