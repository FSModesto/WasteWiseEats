using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WasteWiseEatsAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityProfileRole",
                columns: table => new
                {
                    Role = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityProfileRole", x => new { x.ProfileId, x.Role });
                    table.ForeignKey(
                        name: "FK_SecurityProfileRole_SecurityProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "SecurityProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFirstAccess = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_SecurityProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "SecurityProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationCenters_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationCenterAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCenterAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationCenterAddresses_DonationCenters_DonationCenterId",
                        column: x => x.DonationCenterId,
                        principalTable: "DonationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantAddresses_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasDonated = table.Column<bool>(type: "bit", nullable: false),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteRegisters_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationProposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WasteRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasAccepted = table.Column<bool>(type: "bit", nullable: false),
                    RemovalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationProposals_DonationCenters_DonationCenterId",
                        column: x => x.DonationCenterId,
                        principalTable: "DonationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationProposals_WasteRegisters_WasteRegisterId",
                        column: x => x.WasteRegisterId,
                        principalTable: "WasteRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WasteRegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPerishable = table.Column<bool>(type: "bit", nullable: false),
                    HasPrepared = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_WasteRegisters_WasteRegisterId",
                        column: x => x.WasteRegisterId,
                        principalTable: "WasteRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SecurityProfile",
                columns: new[] { "Id", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), "Gerenciamento de propostas de doação", "Proprietário do centro de doação", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), "Gerenciamento de funcionários e demandas do restaurante.", "Proprietário do restaurante", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), "Acesso irrestrito ao sistema.", "Super Usuário", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), "Gerenciamento de desperdícios e cadastro de doações.", "Atendente do restaurante", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SecurityProfileRole",
                columns: new[] { "ProfileId", "Role" },
                values: new object[,]
                {
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 3 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 4 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 5 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 6 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 7 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 8 },
                    { new Guid("100f0e52-f543-4586-bc1e-f2741f56b535"), 10 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 1 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 2 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 3 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 9 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 11 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 12 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 13 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 14 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 15 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 16 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 17 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 18 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 20 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 1 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 2 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 3 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 4 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 5 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 6 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 7 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 8 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 9 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 10 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 11 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 12 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 13 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 14 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 15 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 16 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 17 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 18 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 19 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 20 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 21 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 22 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 23 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 24 },
                    { new Guid("3f92d673-3abe-4ee5-9e7a-ed927918ed31"), 25 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 2 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 9 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 11 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 21 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 22 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 23 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 24 },
                    { new Guid("cc0be4a1-a29d-43d8-97d9-0151015a4147"), 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationCenterAddresses_DonationCenterId",
                table: "DonationCenterAddresses",
                column: "DonationCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationCenters_UserId",
                table: "DonationCenters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationProposals_DonationCenterId",
                table: "DonationProposals",
                column: "DonationCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationProposals_WasteRegisterId",
                table: "DonationProposals",
                column: "WasteRegisterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_WasteRegisterId",
                table: "Foods",
                column: "WasteRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_UserId",
                table: "Restaurant",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAddresses_RestaurantId",
                table: "RestaurantAddresses",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                table: "User",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteRegisters_RestaurantId",
                table: "WasteRegisters",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationCenterAddresses");

            migrationBuilder.DropTable(
                name: "DonationProposals");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "RestaurantAddresses");

            migrationBuilder.DropTable(
                name: "SecurityProfileRole");

            migrationBuilder.DropTable(
                name: "DonationCenters");

            migrationBuilder.DropTable(
                name: "WasteRegisters");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SecurityProfile");
        }
    }
}
