using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyEntity.Migrations
{
    /// <inheritdoc />
    public partial class addModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Fine = table.Column<float>(type: "real", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "subCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArearOfSquer = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategory", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_subCategory_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_state_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_city_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "areaOfCity",
                columns: table => new
                {
                    AreaOfCityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaOfCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areaOfCity", x => x.AreaOfCityId);
                    table.ForeignKey(
                        name: "FK_areaOfCity_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "house",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AreaOfCityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_house", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_house_areaOfCity_AreaOfCityId",
                        column: x => x.AreaOfCityId,
                        principalTable: "areaOfCity",
                        principalColumn: "AreaOfCityId");
                    table.ForeignKey(
                        name: "FK_house_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_house_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_house_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_house_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_house_subCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "subCategory",
                        principalColumn: "SubCategoryId");
                    table.ForeignKey(
                        name: "FK_house_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_areaOfCity_CityId",
                table: "areaOfCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_city_StateId",
                table: "city",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_house_AreaOfCityId",
                table: "house",
                column: "AreaOfCityId");

            migrationBuilder.CreateIndex(
                name: "IX_house_CategoryId",
                table: "house",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_house_CityId",
                table: "house",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_house_CountryId",
                table: "house",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_house_StateId",
                table: "house",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_house_SubCategoryId",
                table: "house",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_house_UserId",
                table: "house",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_state_CountryId",
                table: "state",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_subCategory_CategoryId",
                table: "subCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "house");

            migrationBuilder.DropTable(
                name: "areaOfCity");

            migrationBuilder.DropTable(
                name: "subCategory");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
