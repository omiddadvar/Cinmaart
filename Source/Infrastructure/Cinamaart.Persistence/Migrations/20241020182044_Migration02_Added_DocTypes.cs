using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinamaart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration02_Added_DocTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDocumentTypeId",
                table: "UserDocument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubtitleDocumentTypeId",
                table: "SubtitleDocument",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubtitleDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeriesDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeriesDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    MovieDocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    CraetedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDocument_MovieDocumentType_MovieDocumentTypeId",
                        column: x => x.MovieDocumentTypeId,
                        principalTable: "MovieDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MovieDocument_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvSerieDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TvSerieId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    TvSeriesDocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    CraetedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSerieDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvSerieDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSerieDocument_TvSerie_TvSerieId",
                        column: x => x.TvSerieId,
                        principalTable: "TvSerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSerieDocument_TvSeriesDocumentType_TvSeriesDocumentTypeId",
                        column: x => x.TvSeriesDocumentTypeId,
                        principalTable: "TvSeriesDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_UserDocumentTypeId",
                table: "UserDocument",
                column: "UserDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleDocument_SubtitleDocumentTypeId",
                table: "SubtitleDocument",
                column: "SubtitleDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDocument_DocumentId",
                table: "MovieDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDocument_MovieDocumentTypeId",
                table: "MovieDocument",
                column: "MovieDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDocument_MovieId",
                table: "MovieDocument",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSerieDocument_DocumentId",
                table: "TvSerieDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSerieDocument_TvSerieId",
                table: "TvSerieDocument",
                column: "TvSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSerieDocument_TvSeriesDocumentTypeId",
                table: "TvSerieDocument",
                column: "TvSeriesDocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubtitleDocument_SubtitleDocumentType_SubtitleDocumentTypeId",
                table: "SubtitleDocument",
                column: "SubtitleDocumentTypeId",
                principalTable: "SubtitleDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocument_UserDocumentType_UserDocumentTypeId",
                table: "UserDocument",
                column: "UserDocumentTypeId",
                principalTable: "UserDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubtitleDocument_SubtitleDocumentType_SubtitleDocumentTypeId",
                table: "SubtitleDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocument_UserDocumentType_UserDocumentTypeId",
                table: "UserDocument");

            migrationBuilder.DropTable(
                name: "MovieDocument");

            migrationBuilder.DropTable(
                name: "SubtitleDocumentType");

            migrationBuilder.DropTable(
                name: "TvSerieDocument");

            migrationBuilder.DropTable(
                name: "UserDocumentType");

            migrationBuilder.DropTable(
                name: "MovieDocumentType");

            migrationBuilder.DropTable(
                name: "TvSeriesDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_UserDocument_UserDocumentTypeId",
                table: "UserDocument");

            migrationBuilder.DropIndex(
                name: "IX_SubtitleDocument_SubtitleDocumentTypeId",
                table: "SubtitleDocument");

            migrationBuilder.DropColumn(
                name: "UserDocumentTypeId",
                table: "UserDocument");

            migrationBuilder.DropColumn(
                name: "SubtitleDocumentTypeId",
                table: "SubtitleDocument");
        }
    }
}
