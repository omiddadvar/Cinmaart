using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Repositories.ConfigEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Contexts
{
    public class MainDBContext : IdentityDbContext<User,Role , long>
    {
        //#region Identity Tables
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        //#endregion
        public MainDBContext(DbContextOptions options) : base(options) { }

        #region Main Tables
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<TvSerie> TvSeries { get; set; }
        #endregion
        #region Type Tables
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }
        #endregion
        #region Pivot Tables
        public DbSet<EpisodeSubtitle> EpisodeSubtitles { get; set; }
        public DbSet<MovieArtist> MovieArtists { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieSubtitle> MovieSubtitles { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SubtitleDocument> SubtitleDocuments { get; set; }
        public DbSet<TvSerieArtist> TvSerieArtists { get; set; }
        public DbSet<TvSerieGenre> TvSerieGenres { get; set; }
        public DbSet<TvSerieTag> TvSerieTags { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations without filteration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDBContext).Assembly);

            // Apply all configurations with filteration capability
            //ConfigureAllEntities.Configure(modelBuilder);   

            base.OnModelCreating(modelBuilder);
        }
    }
}
