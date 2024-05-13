using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Repositories.ConfigEntities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Repositories.ConfigEntities.Pivots;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class ConfigureAllEntities
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //-----Type-Tables------
            new DocumentTypeConfig().Configure(modelBuilder.Entity<DocumentType>());
            new GenderConfig().Configure(modelBuilder.Entity<Gender>());
            new GenreConfig().Configure(modelBuilder.Entity<Genre>());
            new TagConfig().Configure(modelBuilder.Entity<Tag>());

            //-----Main-Tables------
            new ArtistConfig().Configure(modelBuilder.Entity<Artist>());
            new AuthorConfig().Configure(modelBuilder.Entity<Author>());
            new CountryConfig().Configure(modelBuilder.Entity<Country>());
            new DocumenConfig().Configure(modelBuilder.Entity<Document>());
            new EpisodeConfig().Configure(modelBuilder.Entity<Episode>());
            new MovieConfig().Configure(modelBuilder.Entity<Movie>());
            new SeasonConfig().Configure(modelBuilder.Entity<Season>());
            new SubtitleConfig().Configure(modelBuilder.Entity<Subtitle>());
            new TvSerieConfig().Configure(modelBuilder.Entity<TvSerie>());

            //-----Pivot-Tables------
            new EpisodeSubtitleConfig().Configure(modelBuilder.Entity<EpisodeSubtitle>());
            new MovieArtistConfig().Configure(modelBuilder.Entity<MovieArtist>());
            new MovieGenreConfig().Configure(modelBuilder.Entity<MovieGenre>());
            new MovieSubtitleConfig().Configure(modelBuilder.Entity<MovieSubtitle>());
            new MovieTagConfig().Configure(modelBuilder.Entity<MovieTag>());
            new RatingConfig().Configure(modelBuilder.Entity<Rating>());
            new SubtitleDocumentConfig().Configure(modelBuilder.Entity<SubtitleDocument>());
            new TvSerieArtistConfig().Configure(modelBuilder.Entity<TvSerieArtist>());
            new TvSerieGenreConfig().Configure(modelBuilder.Entity<TvSerieGenre>());
            new TvSerieTagConfig().Configure(modelBuilder.Entity<TvSerieTag>());
            new UserDocumentConfig().Configure(modelBuilder.Entity<UserDocument>());
        }
    }
}
