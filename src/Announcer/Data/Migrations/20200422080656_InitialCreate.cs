using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Announcer.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    TemplateId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ProfileImage = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => new { x.GroupId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_GroupMembers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    SenderId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SentTime = table.Column<DateTime>(nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    RecipientId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Clients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Clients_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Alerji ve İmmünoloji 1" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 12" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 13" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 14" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 2" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 3" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 4" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 5" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 6" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 7" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 8" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 9" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 1" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 10" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 11" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 2" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 4" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 5" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 6" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 7" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 8" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 9" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nefroloji 1" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nefroloji 2" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nefroloji 3" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 1" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 2" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 3" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 4" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz 3" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 10" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji 1" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 9" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 10" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 11" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 12" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 13" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 14" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 15" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 16" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 17" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 18" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 19" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 2" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 20" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 21" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 22" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 3" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 4" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 5" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 6" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 7" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 8" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 9" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 1" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 2" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 3" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 4" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 5" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 6" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 7" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi 8" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 5" },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 6" },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 7" },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 8" },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 6" },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 7" },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 8" },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 9" },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Romatoloji 1" },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 1" },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 2" },
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 3" },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 4" },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 5" },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 6" },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 7" },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma 8" },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Tıbbi Genetik 1" },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Tıbbi Genetik 2" },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Tıbbi Onkoloji 1" },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Tıbbi Onkoloji 2" },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Tıbbi Onkoloji 3" },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 1" },
                    { 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 10" },
                    { 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 2" },
                    { 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 3" },
                    { 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 4" },
                    { 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 5" },
                    { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 6" },
                    { 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 7" },
                    { 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 8" },
                    { 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji 9" },
                    { 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Yanık Polikliniği 1" },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 5" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum 1" },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 4" },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 2" },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji 9" },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 1" },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 10" },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 11" },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 12" },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 13" },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 14" },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 15" },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 16" },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 17" },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 2" },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 3" },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 4" },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 5" },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 6" },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 7" },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 8" },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi 9" },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Plastik Cerrahi 1" },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 1" },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 2" },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 3" },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 4" },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 5" },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 6" },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 7" },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 8" },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri 9" },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 1" },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi 3" },
                    { 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Yanık Polikliniği 2" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Jinekolojik Onkoloji 1" },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 8" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Çocuk Ürolojisi 1" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 1" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 2" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 3" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 4" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 5" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 6" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 7" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 8" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji 9" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Endokrinoloji 1" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 1" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 2" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 9" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 3" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 5" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 6" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 7" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 8" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 1" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 10" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 11" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 12" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 13" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 14" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 2" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 3" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 4" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon 4" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 8" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 7" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 6" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Alerji ve İmmünoloji 2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 1" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 2" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 3" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 4" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 5" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 6" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 7" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi 8" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Cerrahi Onkoloji 1" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Cerrahi Onkoloji 2" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Çocuk Cerrahisi 1" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Çocuk Gastroenterolojisi 1" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Çocuk Hematolojisi 1" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Çocuk Kardiyolojisi 1" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Çocuk Psiyikatri 1" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Çocuk Romatolojisi 1" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 1" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 10" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 11" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 12" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 13" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 14" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 15" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 16" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 2" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 3" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 4" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları 5" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 5" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 6" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 7" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 8" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 10" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 11" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 12" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 13" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 14" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 15" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 2" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 3" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 4" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 5" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 6" },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 7" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 8" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 9" },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Hematoloji 1" },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 1" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 10" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 11" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 12" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 13" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 14" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 15" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 16" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 2" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 3" },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 4" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 5" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 6" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 7" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları 1" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları 9" },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 9" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 7" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi 9" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 1" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 10" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 11" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 12" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 2" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 3" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 4" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 5" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 6" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 7" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 8" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi 9" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Cerrahisi 1" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Cerrahisi 2" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Cerrahisi 3" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Cerrahisi 4" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 1" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 10" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 11" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 12" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 13" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 14" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 15" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 2" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 3" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 4" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 5" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 6" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları 8" }
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[] { 1, "{ \"header\": { \"columns\": [ \"Birim Adı\", \"Çağırılan Hasta\", \"Sonraki Hasta\" ] } }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Default Template" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name", "TemplateId", "UserId" },
                values: new object[,]
                {
                    { "10.100.1.1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Alerji ve İmmünoloji Bekleme 1", 1, null },
                    { "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kalp ve Damar Cerrahisi Bekleme 1", 1, null },
                    { "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji Bekleme 1", 1, null },
                    { "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Kardiyoloji Bekleme 2", 1, null },
                    { "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz Bekleme 1", 1, null },
                    { "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kulak Burun Boğaz Bekleme 2", 1, null },
                    { "10.100.1.29", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nefroloji Bekleme 1", 1, null },
                    { "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Nöroloji Bekleme 1", 1, null },
                    { "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi Bekleme 1", 1, null },
                    { "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi Bekleme 2", 1, null },
                    { "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Ortopedi Bekleme 3", 1, null },
                    { "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Psikiyatri Bekleme 1", 1, null },
                    { "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Radyasyon Onkolojisi Bekleme 1", 1, null },
                    { "10.100.1.36", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Romatoloji Bekleme 1", 1, null },
                    { "10.100.1.37", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Sigarayı Bıraktırma Bekleme 1", 1, null },
                    { "10.100.1.38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Tıbbi Genetik Bekleme 1", 1, null },
                    { "10.100.1.39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Tıbbi Onkoloji Bekleme 1", 1, null },
                    { "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji Bekleme 1", 1, null },
                    { "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum Bekleme 3", 1, null },
                    { "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum Bekleme 2", 1, null },
                    { "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Kadın Hastalıkları ve Doğum Bekleme 1", 1, null },
                    { "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları Bekleme 2", 1, null },
                    { "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Beyin ve Sinir Cerrahisi Bekleme 1", 1, null },
                    { "10.100.1.3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Cerrahi Onkoloji Bekleme 1", 1, null },
                    { "10.100.1.4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Çocuk Bekleme 1", 1, null },
                    { "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları Bekleme 1", 1, null },
                    { "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "E Blok", false, null, null, "Çocuk Sağlığı ve Hastalıkları Bekleme 2", 1, null },
                    { "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Dermatoloji Bekleme 1", 1, null },
                    { "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Enfeksiyon Bekleme 1", 1, null },
                    { "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi Bekleme 1", 1, null },
                    { "10.100.1.41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Üroloji Bekleme 2", 1, null },
                    { "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FTR", false, null, null, "Fizik Tedavi Bekleme 2", 1, null },
                    { "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi Bekleme 2", 1, null },
                    { "10.100.1.13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Cerrahisi Bekleme 1", 1, null },
                    { "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları Bekleme 1", 1, null },
                    { "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Blok", false, null, null, "Göğüs Hastalıkları Bekleme 2", 1, null },
                    { "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları Bekleme 1", 1, null },
                    { "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "Göz Hastalıkları Bekleme 2", 1, null },
                    { "10.100.1.18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D Blok", false, null, null, "Hematoloji Bekleme 1", 1, null },
                    { "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Blok", false, null, null, "İç Hastalıkları Bekleme 1", 1, null },
                    { "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Genel Cerrahi Bekleme 1", 1, null },
                    { "10.100.1.42", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "B Blok", false, null, null, "Yanık Polikliniği Bekleme 1", 1, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "GroupId", "ClientId", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, "10.100.1.1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 111, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 112, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 202, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 201, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 200, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 100, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 101, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 102, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 103, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 104, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 105, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 113, "10.100.1.17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 212, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 211, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 210, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 209, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 15, "10.100.1.18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 118, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 117, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 116, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 129, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 128, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 127, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 110, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 126, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 124, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 123, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 115, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 199, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 208, "10.100.1.31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 114, "10.100.1.18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 125, "10.100.1.19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 109, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 108, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 107, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 91, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 84, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 203, "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 204, "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 205, "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 206, "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 92, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 207, "10.100.1.33", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 82, "10.100.1.13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 81, "10.100.1.13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 80, "10.100.1.13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 216, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 79, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 78, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 83, "10.100.1.13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 119, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 179, "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 95, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 106, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 99, "10.100.1.16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 213, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 214, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 215, "10.100.1.32", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 98, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 94, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 90, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 88, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 87, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 86, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 85, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 97, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 96, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 89, "10.100.1.15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 77, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 120, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 122, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 185, "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 154, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 155, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 156, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 157, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 158, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 159, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 160, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 161, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 162, "10.100.1.24", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 184, "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 183, "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 178, "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 163, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 169, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 170, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 171, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 180, "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 181, "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 182, "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 176, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 175, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 168, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 186, "10.100.1.28", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 167, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 165, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 164, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 16, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 174, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 173, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 172, "10.100.1.25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 166, "10.100.1.26", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 146, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 145, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 144, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 150, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 149, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 148, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 147, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 143, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 132, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 151, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 192, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 194, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 195, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 196, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 197, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 198, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 130, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 193, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 121, "10.100.1.20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 152, "10.100.1.21", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 190, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 142, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 141, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 140, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 139, "10.100.1.23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 187, "10.100.1.29", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 188, "10.100.1.29", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 191, "10.100.1.30", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 189, "10.100.1.29", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 138, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 137, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 136, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 135, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 134, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 133, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 153, "10.100.1.22", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 71, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 93, "10.100.1.14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 69, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 24, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 25, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 26, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 34, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 248, "10.100.1.39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 247, "10.100.1.39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 246, "10.100.1.39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 131, "10.100.1.39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 36, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 37, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 38, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 39, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 40, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 41, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 23, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 42, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 44, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 245, "10.100.1.38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 244, "10.100.1.38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 46, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 47, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 70, "10.100.1.12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 49, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 50, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 51, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 52, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 53, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 54, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 60, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 61, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 43, "10.100.1.7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 62, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 22, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 20, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 2, "10.100.1.1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 258, "10.100.1.41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 257, "10.100.1.41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 250, "10.100.1.41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 35, "10.100.1.41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 3, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 4, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 5, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 6, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 7, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 8, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 9, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 10, "10.100.1.2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 256, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 21, "10.100.1.6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 255, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 12, "10.100.1.3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 254, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 253, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 252, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 251, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 249, "10.100.1.40", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 19, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 27, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 28, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 29, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 30, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 31, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 32, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 33, "10.100.1.5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 11, "10.100.1.3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 63, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 48, "10.100.1.8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 65, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 58, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 59, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 66, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 67, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 235, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 232, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 231, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 230, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 229, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 228, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 227, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 226, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 64, "10.100.1.9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 13, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 68, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 72, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 73, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 74, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 75, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 76, "10.100.1.11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 225, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 224, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 223, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 222, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 221, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 220, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 219, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 218, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 217, "10.100.1.34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 57, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 56, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 177, "10.100.1.27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 55, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 18, "10.100.1.10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 233, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { 234, "10.100.1.35", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "7cedbfeb-5eff-4790-9d19-dc25670664d2", "{ \"columns\": [ \"Pekcan Aksöz\", \"Saliha Canan Dıvarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 20, 16, 22, 43, 0, DateTimeKind.Unspecified) },
                    { "e11eb266-688c-4bfc-adc9-db05930f6a16", "{ \"columns\": [ \"Sebiha Büyüköztürk\", \"Argün Hilmi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 193, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 10, 25, 56, 0, DateTimeKind.Unspecified) },
                    { "66178fb2-c205-40a3-843d-c2ab1e6f06f5", "{ \"columns\": [ \"Can Güney Bülbül\", \"Perihan Haykır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 188, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 11, 4, 40, 0, DateTimeKind.Unspecified) },
                    { "3500de1a-1f87-44c7-a3fc-64c09a052bb3", "{ \"columns\": [ \"Elife Çerçi\", \"Abdullatif Karacabey\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 239, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 6, 6, 10, 0, DateTimeKind.Unspecified) },
                    { "97df17cd-c67f-487c-8afc-9b7416c7a3d5", "{ \"columns\": [ \"Taylan Remzi Baykuş\", \"Vedia Gülçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 145, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 11, 3, 45, 0, DateTimeKind.Unspecified) },
                    { "1456abe4-8008-4777-9c81-a18afa75be89", "{ \"columns\": [ \"Memet Ali Ardıç\", \"Nadire Erbul\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 18, 41, 29, 0, DateTimeKind.Unspecified) },
                    { "f9c7df3c-db92-46bc-b3be-6ec9e374a0a4", "{ \"columns\": [ \"Lemis Akküt\", \"Mehmet Kemal Dengizek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 20, 51, 9, 0, DateTimeKind.Unspecified) },
                    { "8e448575-74d2-48b7-acfd-b24040bbe4ba", "{ \"columns\": [ \"Hiba Alpuğan\", \"Enver Dur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 47, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 41, 42, 0, DateTimeKind.Unspecified) },
                    { "3ded77e1-caea-499a-b20d-e68970533da0", "{ \"columns\": [ \"Müyesser Akyildirim\", \"Ziya Doğramacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 26, 45, 0, DateTimeKind.Unspecified) },
                    { "c8c77311-2c12-4ae7-b9af-0588919bc53e", "{ \"columns\": [ \"Ahmet Raşit Akoğuz\", \"Tubanur Dereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 14, 11, 0, DateTimeKind.Unspecified) },
                    { "9493fc80-381f-40ea-96a3-31d69d0c678f", "{ \"columns\": [ \"Ayşen Aksoy\", \"Osman Sinan Devrim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 18, 25, 29, 0, DateTimeKind.Unspecified) },
                    { "6f3a1962-07ca-4dd1-98a6-10530ee93242", "{ \"columns\": [ \"Yaşar Utku Anıl Altın\", \"Karanalp Dursun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 51, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 18, 49, 0, DateTimeKind.Unspecified) },
                    { "05f17c2e-bc36-4c8c-a7bc-ea59da4df8c5", "{ \"columns\": [ \"Fethullah Altınöz\", \"Elanaz Dülgerbaki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 53, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 19, 28, 29, 0, DateTimeKind.Unspecified) },
                    { "5f986a9f-8895-43a9-823e-6bad4e534ec4", "{ \"columns\": [ \"Yansı Hilal Çınaroğlu\", \"Seyit Ahmet Karadağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 243, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 57, 51, 0, DateTimeKind.Unspecified) },
                    { "1beae363-4e7e-4ff0-9cea-6d6cb776dbf7", "{ \"columns\": [ \"Aleda Buyuran\", \"Erk Deha Harmankaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 187, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 0, 41, 0, DateTimeKind.Unspecified) },
                    { "4d56da73-dcf9-4808-98d3-af64846c237a", "{ \"columns\": [ \"İbrahim Onat Belge\", \"Sevgi Tutku Güllüce\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 152, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 10, 45, 7, 0, DateTimeKind.Unspecified) },
                    { "a4bd4d52-d7a0-49be-b7e9-b4f004ab2ff1", "{ \"columns\": [ \"Maral Çakıcı\", \"Şaziye Kabukçu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 220, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 20, 21, 1, 0, DateTimeKind.Unspecified) },
                    { "23ffc6b7-0de6-4592-842c-548afdf513aa", "{ \"columns\": [ \"Sena Nur Candan\", \"Selime Hüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 198, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 4, 51, 29, 0, DateTimeKind.Unspecified) },
                    { "647b60f0-f3ef-4c89-804d-2c9dc42aa818", "{ \"columns\": [ \"Nüket Aksan\", \"Bedir Destereci\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 33, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 7, 55, 50, 0, DateTimeKind.Unspecified) },
                    { "d484756e-f717-48e2-926b-302502fb471c", "{ \"columns\": [ \"Semina Aktuna\", \"Haldun Dinçtürk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 5, 6, 0, DateTimeKind.Unspecified) },
                    { "b93b613b-4718-4632-b3ba-03fb7a5c712e", "{ \"columns\": [ \"Atahan Adanır\", \"Ozan Ege Çomu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 16, 35, 59, 0, DateTimeKind.Unspecified) },
                    { "edb1b1ae-c7b5-4ccd-9029-5c29a0f75dec", "{ \"columns\": [ \"Saba Atmaca\", \"Cantekin Erten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 88, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 21, 8, 1, 0, DateTimeKind.Unspecified) },
                    { "99fb8eeb-0c14-451f-a01d-5ee4bf72748a", "{ \"columns\": [ \"İlma Aldağ\", \"Firuze Dönder\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 43, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 48, 44, 0, DateTimeKind.Unspecified) },
                    { "02f36e03-7483-4603-944e-1166db8869ee", "{ \"columns\": [ \"Elif Ege Çağlayan\", \"Ahuşen İşgüzar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 217, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 23, 43, 16, 0, DateTimeKind.Unspecified) },
                    { "ac00e9b9-23c5-47fe-9734-43a6a0491433", "{ \"columns\": [ \"Hüner Berk\", \"Öymen Gümüşsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 156, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 21, 14, 45, 0, DateTimeKind.Unspecified) },
                    { "795786eb-d86f-4d52-a5c5-aa784ba6e69f", "{ \"columns\": [ \"Rubabe Gökçen Atlı\", \"İlkin Ersöz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 87, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 20, 11, 52, 0, DateTimeKind.Unspecified) },
                    { "aa2ae1ce-1aec-438b-9ce4-02e35e9185ee", "{ \"columns\": [ \"Hanife Duygu Ata\", \"Alper Emin Erkuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 83, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 21, 9, 39, 27, 0, DateTimeKind.Unspecified) },
                    { "3055daa5-1113-4f6e-a7d5-6004ab95bea8", "{ \"columns\": [ \"Önel Çapa\", \"Ünzile Kalfaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 224, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 8, 36, 10, 0, DateTimeKind.Unspecified) },
                    { "90ea02b8-a35b-40b7-8c64-8515c7d4efb2", "{ \"columns\": [ \"Şeyda Nur Arikan\", \"Cem Ozan Erim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 74, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 21, 7, 38, 18, 0, DateTimeKind.Unspecified) },
                    { "74c8bf7b-4e2c-47ca-91c8-114529f4c3a0", "{ \"columns\": [ \"Mükerrem Zeynep Ağca\", \"Ayben Çorumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 20, 19, 52, 0, 0, DateTimeKind.Unspecified) },
                    { "3f88e32b-5708-41b5-8a04-116187c5b6e4", "{ \"columns\": [ \"Betül Bozyer\", \"Büşranur Halaçoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 178, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 8, 0, 21, 0, DateTimeKind.Unspecified) },
                    { "5b7f8793-5efb-4776-a030-0f95bed0a940", "{ \"columns\": [ \"Omaç Çıngır\", \"Cevza Karadalan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 244, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 4, 22, 52, 0, DateTimeKind.Unspecified) },
                    { "b754e6d7-72e3-42ae-9447-b95cfeb1c81a", "{ \"columns\": [ \"Abdullah Emirhan Caner\", \"Denizcan Ilık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 199, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 23, 44, 6, 0, DateTimeKind.Unspecified) },
                    { "b2399dc1-7103-4561-9e6b-c408588f7b50", "{ \"columns\": [ \"Almina Avcı Özsoy\", \"Tunca Eryılmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 92, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 14, 28, 53, 0, DateTimeKind.Unspecified) },
                    { "e066126c-f576-4dae-8013-377ed9d33e98", "{ \"columns\": [ \"Bestami Ağırağaç\", \"Abdulbaki Çotur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 0, 30, 39, 0, DateTimeKind.Unspecified) },
                    { "3213013f-d12b-4aab-b170-5cee1ef967ea", "{ \"columns\": [ \"Elif Tuğçe Altaş\", \"Birsen Durmuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 49, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 13, 24, 34, 0, DateTimeKind.Unspecified) },
                    { "01227626-b76e-446c-8cc6-2634e7bad9fb", "{ \"columns\": [ \"Sırma Begüm Altunbaş\", \"Erem Edibali Mp\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 58, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 10, 50, 5, 0, DateTimeKind.Unspecified) },
                    { "810c13f1-af1c-4d9e-938b-433d27a3946e", "{ \"columns\": [ \"Yasin Şükrü Arap\", \"Akife Erbay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 68, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 16, 16, 45, 0, DateTimeKind.Unspecified) },
                    { "46113564-c216-43c7-81d9-376ba601bfeb", "{ \"columns\": [ \"Ayşegül Barutçuoğlu\", \"Busem Gökçeaslan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 129, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 1, 58, 28, 0, DateTimeKind.Unspecified) },
                    { "8576f62b-bb50-46e9-9cc6-2aa660065ec6", "{ \"columns\": [ \"Ilım Aslantürk\", \"Hasan Burak Erkoç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "2077f9d8-71eb-42e1-9e8e-6cce87b4ea60", "{ \"columns\": [ \"Gülser Bal\", \"Kerem Cahit Gençoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 119, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 17, 38, 4, 0, DateTimeKind.Unspecified) },
                    { "127483d9-2c87-4360-9d6c-8d78d5559796", "{ \"columns\": [ \"Atak Batar\", \"Denizhan Gönül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 135, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 10, 10, 33, 0, DateTimeKind.Unspecified) },
                    { "745bb61e-1390-4dfa-a0dc-08917cb1e2e4", "{ \"columns\": [ \"Ömer Buğra Alparslan\", \"Tugce Dudu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 46, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 16, 14, 54, 0, DateTimeKind.Unspecified) },
                    { "d11374d6-a697-4d1f-9dee-4876ca55dc8a", "{ \"columns\": [ \"Nazım Orhun Baturalp\", \"Nazım Berke Göven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 140, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 2, 59, 2, 0, DateTimeKind.Unspecified) },
                    { "b8ace037-483a-487f-b961-0a08665b0c23", "{ \"columns\": [ \"Sarper Akış\", \"Hürel Demiriz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 4, 13, 6, 0, DateTimeKind.Unspecified) },
                    { "338bb552-822d-464d-8d7d-9032e8255b0a", "{ \"columns\": [ \"Sabiha Elvan Atol\", \"İsmail Enes Eruzun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 90, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 19, 58, 20, 0, DateTimeKind.Unspecified) },
                    { "e130b99c-cdf7-4a95-837e-7e8ac0529c45", "{ \"columns\": [ \"Oğuzcan Coşandal\", \"Sidar İnceoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 211, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 6, 14, 55, 0, DateTimeKind.Unspecified) },
                    { "c410f99e-43ef-4e1c-9a6a-1496acd4a65f", "{ \"columns\": [ \"Esim Çaylar\", \"Necip Fazıl Kanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 229, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 11, 38, 41, 0, DateTimeKind.Unspecified) },
                    { "7a1d918e-fbb7-49f6-ab3e-a17287bb20e1", "{ \"columns\": [ \"Mehmet Tarık Çelikkol\", \"Arca Karabulut\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 238, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 10, 7, 29, 0, DateTimeKind.Unspecified) },
                    { "51216571-2558-49c3-bcf9-d69c02419e70", "{ \"columns\": [ \"Zeynep Nihan Aydınlıoğlu\", \"Batıray Eski\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 99, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 23, 50, 9, 0, DateTimeKind.Unspecified) },
                    { "70ede9f1-6ad0-4dd9-a471-baad1c7c2d37", "{ \"columns\": [ \"Erol Özgür Baştuğ\", \"Nilüfer Gönay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 134, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 22, 39, 49, 0, DateTimeKind.Unspecified) },
                    { "66953db4-4de7-41dd-88e9-8389ccdf51c5", "{ \"columns\": [ \"Eda Sena Akyıldız\", \"Goncagül Diri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 10, 11, 27, 0, DateTimeKind.Unspecified) },
                    { "266e9818-1a34-4c21-9e02-23d56daa66b2", "{ \"columns\": [ \"Mahperi Baştopçu\", \"Yeşim Gölmes\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 133, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 26, 28, 0, DateTimeKind.Unspecified) },
                    { "141d0db7-95bf-4b5f-b5fb-cacf238c7d3e", "{ \"columns\": [ \"Doğuşcan Biriz\", \"Ahmet Korhan Güzel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 169, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 5, 25, 15, 0, DateTimeKind.Unspecified) },
                    { "c2b0c74b-2a9d-4c18-b93e-c946959176cd", "{ \"columns\": [ \"Seung Hun Baki\", \"Muazzez Ece Gemalmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 118, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 24, 30, 0, DateTimeKind.Unspecified) },
                    { "f1d908b4-c41a-4e16-b728-ccd9e27715ee", "{ \"columns\": [ \"Büşra Cüce\", \"İhsan Vehbi İpekoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 213, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 8, 28, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "cdc1ecbc-f567-4c42-b51b-3972d1c8603c", "{ \"columns\": [ \"Cansev Arat\", \"Burç Erbil\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 69, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 18, 50, 0, 0, DateTimeKind.Unspecified) },
                    { "84a2406c-2e72-4d18-a4af-d4ca73f54657", "{ \"columns\": [ \"Elif Dilay Altinkaya\", \"Cem Efe Edeş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 57, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 11, 6, 33, 0, DateTimeKind.Unspecified) },
                    { "fa2d1aa6-c0d4-427e-970f-c31b7eb8947e", "{ \"columns\": [ \"Paksoy Ateş\", \"Abdullah Mert Erol\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 85, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 13, 55, 21, 0, DateTimeKind.Unspecified) },
                    { "5c8c60e6-d9b2-405b-8826-d7922946fce4", "{ \"columns\": [ \"Ata Kerem Akman\", \"Zeynep Büşra Derdemez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 0, 27, 12, 0, DateTimeKind.Unspecified) },
                    { "0d048d80-b6a3-4997-8a6e-4004cecf502e", "{ \"columns\": [ \"Lemi Akarçay\", \"Aydonat Dalkılıç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 18, 53, 26, 0, DateTimeKind.Unspecified) },
                    { "d894f6a2-9e67-4a32-aeff-2ec96ae2fbc6", "{ \"columns\": [ \"Çelik Bilgir\", \"Mert Alican Güreş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 165, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 10, 59, 36, 0, DateTimeKind.Unspecified) },
                    { "b6af6470-8b2f-4620-9657-6653961ffc88", "{ \"columns\": [ \"Hayrunnisa Aşveren\", \"Hanife Nur Erkovan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 82, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 7, 4, 7, 0, DateTimeKind.Unspecified) },
                    { "c013a0c2-9fa9-40b7-a320-1dbbb7e0b8ac", "{ \"columns\": [ \"Saime Avıandı\", \"Arslan Erzurumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 93, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 7, 31, 25, 0, DateTimeKind.Unspecified) },
                    { "35699a91-4889-438d-8591-b5a45c260e7c", "{ \"columns\": [ \"İlyas Umut Apul\", \"Mert Cem Eliçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 66, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 13, 19, 43, 0, DateTimeKind.Unspecified) },
                    { "a081ecdf-8aff-44d1-ac67-294ffaf41594", "{ \"columns\": [ \"Özgen Baka\", \"Hayri Anıl Geçkin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 117, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 22, 39, 0, 0, DateTimeKind.Unspecified) },
                    { "176a77cc-0165-48c6-91d7-4f374b3fec9c", "{ \"columns\": [ \"Hayriye Büyükgüngör\", \"Muhammed Sefa Hilal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 192, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 12, 45, 42, 0, DateTimeKind.Unspecified) },
                    { "ca8420f7-f900-49a9-8422-4b2f58cf1135", "{ \"columns\": [ \"Mercan Bağçivan\", \"Nihan Gazitepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 113, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 11, 28, 35, 0, DateTimeKind.Unspecified) },
                    { "604968c2-5225-4835-a7e9-741dc2b9558f", "{ \"columns\": [ \"Ateş Aycı\", \"İslam Eshaqzada\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 98, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 14, 29, 28, 0, DateTimeKind.Unspecified) },
                    { "a305d7c3-aeb7-4e29-9065-0cc6fc660ba9", "{ \"columns\": [ \"Kubilay Barış Begiç\", \"Bektaş Gülenç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 149, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 6, 49, 0, DateTimeKind.Unspecified) },
                    { "4998db3a-edf3-48c7-9859-f4a7959f27dc", "{ \"columns\": [ \"Ferdacan Aruca\", \"Hüseyin Serkan Erkekli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 77, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 11, 5, 27, 0, DateTimeKind.Unspecified) },
                    { "f1e97687-1f6b-42c3-9dcd-f6132425d5a0", "{ \"columns\": [ \"Osman Yasin Aysan\", \"Turan Fahri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 106, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 40, 27, 0, DateTimeKind.Unspecified) },
                    { "0c091629-8238-4b18-ab1e-79be6c272bf0", "{ \"columns\": [ \"Alçiçek Bad\", \"Ertuğ Furuncuoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 111, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 13, 30, 15, 0, DateTimeKind.Unspecified) },
                    { "6705297a-6cc1-4517-bd5c-eb197f068e9b", "{ \"columns\": [ \"Ruhugül Babadostu\", \"İrfan Anıl Fındıkçı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 110, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 18, 42, 0, DateTimeKind.Unspecified) },
                    { "6059920c-a7ec-4f37-9088-2770f99d5a15", "{ \"columns\": [ \"İltem Boztepe\", \"Feray Hakverdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 177, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 1, 38, 54, 0, DateTimeKind.Unspecified) },
                    { "621be0bb-5364-444b-a612-157e8efff241", "{ \"columns\": [ \"Serdar Kaan Barbaros\", \"Kubra Göçmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 127, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 17, 10, 6, 0, DateTimeKind.Unspecified) },
                    { "a50f82f0-977c-484b-98e0-e037fae711d5", "{ \"columns\": [ \"Gönül Çağatay\", \"Zerin İshakoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 215, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 4, 59, 44, 0, DateTimeKind.Unspecified) },
                    { "d43ab835-2431-4b34-bfdb-22b3860db650", "{ \"columns\": [ \"Sena Çekmecelioğlu\", \"Muharrem Kanmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 230, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 21, 2, 33, 17, 0, DateTimeKind.Unspecified) },
                    { "2f2c2293-a36e-4757-99b4-80d4baba228f", "{ \"columns\": [ \"Erhan Çıray\", \"Mustafa Emir Karademir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 245, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 23, 13, 26, 0, DateTimeKind.Unspecified) },
                    { "2f72ff04-91ab-4e28-9c7c-18e9dab873a7", "{ \"columns\": [ \"Ahmet Ruken Altay\", \"Taçmin Durmuşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 1, 18, 6, 0, DateTimeKind.Unspecified) },
                    { "6e24d2cf-399e-4fde-8980-07072c63bc03", "{ \"columns\": [ \"Rima Altıparmak\", \"Mehmet Erman Düzbayır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 56, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 20, 7, 20, 0, DateTimeKind.Unspecified) },
                    { "123099c8-9f67-4f98-97d5-a2dad284f00e", "{ \"columns\": [ \"Jutenya Benan\", \"Denktaş Gülşen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 153, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 21, 14, 22, 0, DateTimeKind.Unspecified) },
                    { "5e919393-0475-4532-8969-044aab604ffe", "{ \"columns\": [ \"Cankız Bulgan\", \"Boran Hamidi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 182, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 4, 19, 58, 0, DateTimeKind.Unspecified) },
                    { "ae7f6e56-5ee9-44dd-8771-c1de66e7936c", "{ \"columns\": [ \"Lal Bilgeç\", \"Yasemin Erva Güntek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 161, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 51, 53, 0, DateTimeKind.Unspecified) },
                    { "d25b56d5-edd6-4a03-8834-0bc129995641", "{ \"columns\": [ \"Balkın Cigerlioğlu\", \"Emine Selcen İmre\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 208, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 20, 26, 52, 0, DateTimeKind.Unspecified) },
                    { "eb005194-4006-4d47-a5ce-5a4196c5ec94", "{ \"columns\": [ \"Mustafa Doğukan Berberoğlu\", \"Hasan Fahri Gültepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 155, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 14, 44, 16, 0, DateTimeKind.Unspecified) },
                    { "2fe5d0de-ff73-4d59-9383-90cd9546967e", "{ \"columns\": [ \"Çağkan Çelenlioğlu\", \"Suna Karaaslanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 233, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 14, 17, 11, 0, DateTimeKind.Unspecified) },
                    { "a41796fe-d855-40f4-946d-6998103aba32", "{ \"columns\": [ \"Halim Aral\", \"Ahmet Sencer Emikoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 67, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 34, 17, 0, DateTimeKind.Unspecified) },
                    { "21ce5003-e4f2-4136-8d8f-ba920f614a6a", "{ \"columns\": [ \"Mehmet Can Akçaözoğlu\", \"Fadik Himoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 194, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 21, 3, 57, 41, 0, DateTimeKind.Unspecified) },
                    { "62452f56-3268-4b9b-aaed-a8488873b06e", "{ \"columns\": [ \"Ayla Baytın\", \"Aybike Güleç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 148, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 28, 27, 0, DateTimeKind.Unspecified) },
                    { "bd7669b5-412e-40ec-b5ce-4b3b939ddd30", "{ \"columns\": [ \"Kerime Aydoğan Yozgat\", \"Süheyl Esvap\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 19, 34, 0, DateTimeKind.Unspecified) },
                    { "26576367-f91b-4dbe-af76-59abbb971386", "{ \"columns\": [ \"Nunazlı Arpacı\", \"Rekin Erkek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 76, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 20, 42, 49, 0, DateTimeKind.Unspecified) },
                    { "0e0d33b0-1b18-407f-bbea-eb302990cf6d", "{ \"columns\": [ \"İlkay Ramazan Ankara\", \"Lale Ekrem\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 64, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 7, 47, 0, DateTimeKind.Unspecified) },
                    { "aa348b9f-d150-416e-a032-03fb884a51ee", "{ \"columns\": [ \"Hikmet Nazlı Alver\", \"Çağın Egin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 62, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "9fafb8ed-1a0c-46ae-a395-2d506cd8a61c", "{ \"columns\": [ \"Büşra Gül Altundal\", \"İbrahim Alp Tekin Ege\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 15, 13, 58, 0, DateTimeKind.Unspecified) },
                    { "f352a124-fe4a-4a0c-8686-54db4094c051", "{ \"columns\": [ \"Ünkan Çini\", \"Seren Karakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 247, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 17, 32, 0, DateTimeKind.Unspecified) },
                    { "34746421-ceec-4c43-b05a-718dab11eca2", "{ \"columns\": [ \"Senay Bilgen\", \"Günan Güral\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 162, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 4, 59, 42, 0, DateTimeKind.Unspecified) },
                    { "c7a22424-362e-448e-af56-efe0a77329a4", "{ \"columns\": [ \"Hatice Gamze Çınar\", \"Haluk Barış Karaçeşme\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 242, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 3, 8, 19, 0, DateTimeKind.Unspecified) },
                    { "b0742ee4-3cbb-4062-81bf-4c284e03543d", "{ \"columns\": [ \"Selma Simge Ceylan\", \"Güçlü İçten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 203, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 9, 30, 8, 0, DateTimeKind.Unspecified) },
                    { "617b9f97-085f-4a2a-8d74-2ee535b0a681", "{ \"columns\": [ \"Yaprak Bural\", \"Berrak Harman\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 186, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 22, 10, 53, 0, DateTimeKind.Unspecified) },
                    { "58f2123b-8a61-4fd1-a434-342098f4ea5c", "{ \"columns\": [ \"Ogün Bölge\", \"Selin Sıla Halıcılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 179, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 18, 21, 57, 0, DateTimeKind.Unspecified) },
                    { "b826ba7c-fa27-42b3-8635-51c4a219113f", "{ \"columns\": [ \"Bensu Batur\", \"Ayşe Elif Görür\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 139, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 15, 40, 0, DateTimeKind.Unspecified) },
                    { "5bf3bda2-5c38-4d3b-bf0c-5dc6c91579e9", "{ \"columns\": [ \"Murat Sinan Ayaz\", \"Rukiye Esgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 97, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 23, 4, 53, 0, DateTimeKind.Unspecified) },
                    { "c6679da9-8372-47b1-9c1e-626feda6aa9a", "{ \"columns\": [ \"Zümra Çelık\", \"Ahmet Can Karabacak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 234, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 18, 20, 41, 0, DateTimeKind.Unspecified) },
                    { "89937a90-1095-41a3-9d4e-79baae1e391e", "{ \"columns\": [ \"Bayülken Çaprak\", \"Sezer Kalsın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 225, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 3, 12, 24, 0, DateTimeKind.Unspecified) },
                    { "a395111e-a27e-4bd2-9ab3-7cba45c6618f", "{ \"columns\": [ \"Hacı Bayram Ufuk Çamaş\", \"Ömer Faruk Kadı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 222, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 12, 13, 48, 0, DateTimeKind.Unspecified) },
                    { "20455710-80bd-4d02-8175-486e16ba5042", "{ \"columns\": [ \"Afra Selcen Çağan\", \"Necati İrsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 214, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 7, 59, 0, DateTimeKind.Unspecified) },
                    { "6c66fc78-d5fd-4aa8-80e6-37e8d1547916", "{ \"columns\": [ \"Ayseren Boyuktaş\", \"Ahmet Furkan Hacılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 173, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 19, 1, 9, 0, DateTimeKind.Unspecified) },
                    { "86d869c9-41f5-4599-8d7e-ef1b056aad53", "{ \"columns\": [ \"Efecan Çetintaş\", \"Tuğra Karacan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 240, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 6, 32, 13, 0, DateTimeKind.Unspecified) },
                    { "7771dc74-032c-488b-bc54-036e646c15d0", "{ \"columns\": [ \"Aykanat Ağıroğlu\", \"Neva Çuhadar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 6, 58, 40, 0, DateTimeKind.Unspecified) },
                    { "28de7457-b228-4c01-9823-a9e7a86768c3", "{ \"columns\": [ \"Gönülgül Çelikağı\", \"Gül Sena Karabıyık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 236, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 1, 17, 39, 0, DateTimeKind.Unspecified) },
                    { "c86078d1-bfd8-42f7-9413-a47ed592240c", "{ \"columns\": [ \"Melike Dilara Büyükfırat\", \"Mustafa Ali Hiçyılmam\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 191, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 20, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { "e96f6586-0d1e-4378-8568-8eeef30b7918", "{ \"columns\": [ \"Asiye Burabak\", \"Aynur Dilan Hancı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 184, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 2, 8, 47, 0, DateTimeKind.Unspecified) },
                    { "c3aa93bc-3ff4-4e98-8ffb-2dc02890509f", "{ \"columns\": [ \"Yüksel Balcı\", \"Sadık Can Gezmiş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 120, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 3, 41, 25, 0, DateTimeKind.Unspecified) },
                    { "03ef9d15-c1d2-46ef-a226-bf612cb0dd71", "{ \"columns\": [ \"Muhammed Üzeyir Çekmeci\", \"Zeynep Figen Kantarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 231, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 0, 56, 0, DateTimeKind.Unspecified) },
                    { "a6950b81-88eb-494b-9061-90218d95abcc", "{ \"columns\": [ \"Elvan Çatal\", \"Şahan Kandaşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 228, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "fd141150-143a-4628-8bca-9c8f2c32f61b", "{ \"columns\": [ \"Dilhan Çakanel\", \"Melis Ezgi Kabayuka\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 219, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 11, 58, 0, DateTimeKind.Unspecified) },
                    { "36017ce0-840f-4065-a795-9a4942eb6d01", "{ \"columns\": [ \"Doktora Canuyar\", \"Mustafa Furkan Işınay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 201, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 11, 16, 38, 0, DateTimeKind.Unspecified) },
                    { "a160ef3b-0a69-4ee8-ada3-5879499bb54d", "{ \"columns\": [ \"Onay Buğdaypınarı\", \"Ramazan Tarık Hamarat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 181, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 13, 37, 52, 0, DateTimeKind.Unspecified) },
                    { "591ce889-4d97-4328-89fe-5ee26a23f53c", "{ \"columns\": [ \"Bengisu Boya\", \"Mustafa Berkay Güzeloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 171, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 14, 13, 55, 0, DateTimeKind.Unspecified) },
                    { "e740fbd6-39c6-437b-a0a1-f7f62836c942", "{ \"columns\": [ \"Altan Boy\", \"Manolya Güzeller\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 170, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 12, 32, 18, 0, DateTimeKind.Unspecified) },
                    { "416635ee-cb76-489e-8c72-62473d9583ce", "{ \"columns\": [ \"Didem Bıçaksız\", \"Argun Güneri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 159, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 59, 8, 0, DateTimeKind.Unspecified) },
                    { "1515cc31-7a9f-44e9-9571-9daa8fb43fb3", "{ \"columns\": [ \"Demircan Baydil\", \"Abdulhalim Guguk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 142, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 16, 0, 53, 0, DateTimeKind.Unspecified) },
                    { "1c519fb3-4535-4bc3-b39c-295c70f68299", "{ \"columns\": [ \"Burak Tatkan Altıntaş\", \"Fidan Dündar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 54, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 7, 32, 0, DateTimeKind.Unspecified) },
                    { "72712d57-3758-4496-aa6b-8de96224ce7e", "{ \"columns\": [ \"Rafi Akaş\", \"Refiye Seda Dalyaprak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 0, 20, 26, 0, DateTimeKind.Unspecified) },
                    { "a0ee994a-fbdc-4ece-8ed3-266d773c3f52", "{ \"columns\": [ \"Arzucan Bulgur\", \"Tazika Hilal Hamzaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 183, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 22, 40, 51, 0, DateTimeKind.Unspecified) },
                    { "64b397e2-aa88-4866-b785-87440e939d14", "{ \"columns\": [ \"Pekin Boz\", \"Fazilet Hacıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 174, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 10, 56, 21, 0, DateTimeKind.Unspecified) },
                    { "f7a64a43-cebe-458b-9c5f-9d123c135155", "{ \"columns\": [ \"Coşkun Baran\", \"Tilbe Göç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 126, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 21, 11, 38, 0, DateTimeKind.Unspecified) },
                    { "2a11de79-d394-4213-970c-b190392c8280", "{ \"columns\": [ \"Sera Cansın Azbay\", \"Latife Fatin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 108, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 16, 54, 51, 0, DateTimeKind.Unspecified) },
                    { "00b4bcc9-494f-4d50-bca8-00cff0a95d35", "{ \"columns\": [ \"Nebahat Ansen\", \"Bağış Can Elbaşı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 12, 57, 54, 0, DateTimeKind.Unspecified) },
                    { "1c55299d-de8c-4485-8e8f-c4e0049cba0a", "{ \"columns\": [ \"Emre Ayberk Akfırat\", \"Doga Elif Delice\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 23, 12, 45, 0, DateTimeKind.Unspecified) },
                    { "c5edc718-655d-46f9-bc23-c3b5df63ad06", "{ \"columns\": [ \"Rıdvan Çıkıkcı\", \"Emir Doğan Karaçay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 241, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 7, 58, 42, 0, DateTimeKind.Unspecified) },
                    { "0acbbd0c-340c-4ca6-b95e-5c294f84602a", "{ \"columns\": [ \"Mahire Çalım\", \"Bergüzar Kaçaranoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 221, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 10, 18, 45, 0, DateTimeKind.Unspecified) },
                    { "33f2696f-356b-4410-bcc0-b05062434592", "{ \"columns\": [ \"Mayıs Cumalı\", \"Nesli İpçizade\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 212, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 16, 19, 36, 0, DateTimeKind.Unspecified) },
                    { "41f60ba2-fd7c-473b-8d04-2d5273eef4b3", "{ \"columns\": [ \"Seyit Ceran\", \"Sude İbrahim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 202, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 17, 47, 59, 0, DateTimeKind.Unspecified) },
                    { "02994ec5-db9b-42a3-842a-99776f98f611", "{ \"columns\": [ \"Edip Attila\", \"Hamıd Eryıldız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 91, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 1, 5, 35, 0, DateTimeKind.Unspecified) },
                    { "d1c37a96-6e4d-4c53-9e23-ea041f6fde6d", "{ \"columns\": [ \"Şerife Asil\", \"İbrahim Candaş Erki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 78, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 14, 44, 48, 0, DateTimeKind.Unspecified) },
                    { "d88b99b4-b82d-4a51-b1b8-8df2eb65358c", "{ \"columns\": [ \"İlkim Ateşcan\", \"Çisel Ersin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 86, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 15, 18, 22, 0, DateTimeKind.Unspecified) },
                    { "fb836b31-d8ac-4568-93e4-d09871cc201f", "{ \"columns\": [ \"Kurtbey Canbağı\", \"Mustafa Sefa Hopacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 196, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 10, 35, 32, 0, DateTimeKind.Unspecified) },
                    { "f1232ab0-14d1-4726-a3d4-aba9298c3789", "{ \"columns\": [ \"Ezel Bargan\", \"Kubilay Gödek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 128, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 49, 28, 0, DateTimeKind.Unspecified) },
                    { "95ff9f1b-bc8a-4f14-a2d3-de4f23b21997", "{ \"columns\": [ \"Abdullah Atakan Baluken\", \"Abdullah Halit Golba\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 125, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 2, 58, 0, DateTimeKind.Unspecified) },
                    { "612a6893-9c31-4411-838c-9543ef9832bc", "{ \"columns\": [ \"Hami Aydoğdu\", \"Yargı Yekta Eşe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 101, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 14, 36, 11, 0, DateTimeKind.Unspecified) },
                    { "9e2e0a0d-5454-4e71-98c2-89da9da7315b", "{ \"columns\": [ \"Nefse Altunbulak\", \"Volkan Eyüp Efşin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 59, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 19, 53, 36, 0, DateTimeKind.Unspecified) },
                    { "bb9ca76e-a3a3-44ef-bffb-549c4774bd93", "{ \"columns\": [ \"Bahar Özlem Albaş\", \"Seli M Sharef Dökülmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 58, 37, 0, DateTimeKind.Unspecified) },
                    { "299e3160-1289-4b81-8671-f1ec4d9dbfdb", "{ \"columns\": [ \"Özde Acarkan\", \"Zülal Çolak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 22, 15, 31, 0, DateTimeKind.Unspecified) },
                    { "3172c635-127b-4ff0-8fb1-f9fcb83645ca", "{ \"columns\": [ \"Yücel Civan\", \"Tevfik İnal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 209, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 4, 2, 0, DateTimeKind.Unspecified) },
                    { "5b0691d3-e68f-45b7-a49e-f6d4a6ca8100", "{ \"columns\": [ \"Pırıltı Bahçeli\", \"Şeniz Geboloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 115, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 13, 24, 53, 0, DateTimeKind.Unspecified) },
                    { "393a4d89-9521-49d3-8679-4c8aab4fc028", "{ \"columns\": [ \"Mehmetcan Akay\", \"Esat Erdem Daniş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 59, 39, 0, DateTimeKind.Unspecified) },
                    { "6d53efcf-6490-4501-a4e2-bafe8383f02a", "{ \"columns\": [ \"Emine Münevver Akca\", \"Fetullah Davutoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 52, 5, 0, DateTimeKind.Unspecified) },
                    { "791a2780-7240-452d-b03d-2e3092292f62", "{ \"columns\": [ \"Uğur Ali Aysal\", \"Faik Ezber\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 105, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 10, 41, 0, DateTimeKind.Unspecified) },
                    { "c319887f-1767-49ed-b292-222580761718", "{ \"columns\": [ \"Bedirhan Lütfü Akşamoğlu\", \"Samet Emre Dikbaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 20, 9, 4, 0, DateTimeKind.Unspecified) },
                    { "4a0745b0-a186-401d-93c1-8e1ccb7e73f4", "{ \"columns\": [ \"Şennur Ağnar\", \"Öznur Çulhaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 15, 19, 12, 0, DateTimeKind.Unspecified) },
                    { "8650a59c-94fc-46ff-8de4-49c2efa17ff1", "{ \"columns\": [ \"Oltun Çanga\", \"Dağhan Kadoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 223, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 19, 24, 58, 0, DateTimeKind.Unspecified) },
                    { "691d49dd-ceaf-4042-bf29-c11537833ec4", "{ \"columns\": [ \"Tuğce Cibooğlu\", \"Nihal İlısu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 206, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 57, 28, 0, DateTimeKind.Unspecified) },
                    { "e1bbda8b-3d86-45cf-bebb-707b339b93db", "{ \"columns\": [ \"Gökay Bağış\", \"Menekşe Geben\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 114, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 21, 17, 54, 0, DateTimeKind.Unspecified) },
                    { "32f59ca2-3a80-4f5b-85e3-157e8dc4a1b0", "{ \"columns\": [ \"Deniz Dilay Arıcan\", \"Hüseyin Zeyd Ercoşkun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 71, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 18, 31, 11, 0, DateTimeKind.Unspecified) },
                    { "6bc9bd0d-46d2-46a0-9ba2-7ba3e9727e50", "{ \"columns\": [ \"Ahmet Polat Aklar Çörekçi\", \"Alya Denizgünü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 3, 37, 0, DateTimeKind.Unspecified) },
                    { "055713d0-7d25-464e-90c5-87e1f3aefb2e", "{ \"columns\": [ \"Ahmet Yasin Burak\", \"Ayman Hangül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 185, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 21, 2, 50, 44, 0, DateTimeKind.Unspecified) },
                    { "60d460bc-5167-4322-8e7e-7cc249839133", "{ \"columns\": [ \"Kübra Tansu Bilgit\", \"Zeynep Doğa Gürses\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 166, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 17, 51, 8, 0, DateTimeKind.Unspecified) },
                    { "22e026a7-d9fb-4b2c-b722-343e8479a027", "{ \"columns\": [ \"Aygün Bayram\", \"Ömer Okan Gülebakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 147, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 13, 16, 12, 0, DateTimeKind.Unspecified) },
                    { "3f7ce268-ad5a-4f4c-b603-568f0548109c", "{ \"columns\": [ \"Burçin Kübra Baykal\", \"Gülten Güdücü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 143, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 12, 19, 44, 0, DateTimeKind.Unspecified) },
                    { "4bddbfee-58d9-4fa2-85bc-0e0194c7637f", "{ \"columns\": [ \"Sevtap Atan\", \"Elif Kevser Eroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 84, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 16, 27, 28, 0, DateTimeKind.Unspecified) },
                    { "d98acbb2-c2f6-4539-88d2-c2e8b15dec79", "{ \"columns\": [ \"Bayar Çelik\", \"Asya Sema Karabağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 235, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 3, 54, 2, 0, DateTimeKind.Unspecified) },
                    { "32b9f4f5-ad4a-448e-9255-eaa435fd5a45", "{ \"columns\": [ \"Buse Gizem Berker\", \"Eylem Gündüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 157, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 18, 10, 0, DateTimeKind.Unspecified) },
                    { "8a326b9a-9682-451f-8cfd-c8ecf1ba2f43", "{ \"columns\": [ \"Sevginur Aşcı\", \"Selman Erkoşan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 81, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 10, 44, 52, 0, DateTimeKind.Unspecified) },
                    { "c2309d9c-3374-4c1c-88db-3919b0954301", "{ \"columns\": [ \"Mazlum Altan\", \"Sanber Durak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 48, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 22, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "269f8817-7f89-4c21-8a97-d837a8762036", "{ \"columns\": [ \"Servet Akçagunay\", \"Mert Görkem Dayıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 6, 22, 0, DateTimeKind.Unspecified) },
                    { "59c4e042-e5b3-4909-9e45-55c1cbb585a6", "{ \"columns\": [ \"Doğangün Çağlar\", \"Dursun Korel İşgören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 216, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 14, 6, 11, 0, DateTimeKind.Unspecified) },
                    { "de811cd6-12ac-48b3-bc9a-3f73fbaba7c7", "{ \"columns\": [ \"Çilem Akçay\", \"Ergün Değirmendereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "1cba1c87-af1a-429e-9c26-21f271da7abe", "{ \"columns\": [ \"Nehar Avşar\", \"Neslihan Buşra Esat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 94, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 14, 25, 47, 0, DateTimeKind.Unspecified) },
                    { "364cb342-41ad-4cd8-82ee-ea21ec47b944", "{ \"columns\": [ \"Halime Beydağ\", \"Melek Diler Günel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 158, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 7, 27, 34, 0, DateTimeKind.Unspecified) },
                    { "60e6d7d1-c535-4bb2-95c8-628df407b3e8", "{ \"columns\": [ \"Safa Ahmet Baydar\", \"Meltem Göymen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 141, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 37, 28, 0, DateTimeKind.Unspecified) },
                    { "e2887ede-f6f1-4086-87d8-f68eb4d1b479", "{ \"columns\": [ \"Fazıl Erem Batuk\", \"Şahabettin Görgüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 138, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 22, 50, 59, 0, DateTimeKind.Unspecified) },
                    { "b54af2a2-cae0-4373-98dc-5eed1d92af0f", "{ \"columns\": [ \"Özgün Bahtıyar\", \"Zeynep Senahan Geçioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 116, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 13, 8, 53, 0, DateTimeKind.Unspecified) },
                    { "ac7ecfe3-d78c-4f55-9566-3e6dd380d95d", "{ \"columns\": [ \"Ali İsmail Babacan\", \"Eyüp Orhun Fındık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 109, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 48, 48, 0, DateTimeKind.Unspecified) },
                    { "d7a8d8ed-dc95-4e0a-9351-9452c2c7e679", "{ \"columns\": [ \"Rana Altınoklu\", \"Öktem Duymuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 52, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 8, 31, 0, DateTimeKind.Unspecified) },
                    { "0be97bfc-abd6-4a4f-b883-3790b4887ee1", "{ \"columns\": [ \"Ecem Hatice Akova\", \"Dalay Derya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 32, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 21, 54, 30, 0, DateTimeKind.Unspecified) },
                    { "3a7431aa-cae2-483a-ad44-f36329ad8136", "{ \"columns\": [ \"Arkan Bozdemir\", \"Çisil Hazal Hafız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 176, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 19, 31, 34, 0, DateTimeKind.Unspecified) },
                    { "ba05b3a0-f2a7-4e59-b336-27363e11542e", "{ \"columns\": [ \"İclal Akkoyun\", \"Aysel Aysu Demirsatan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 1, 58, 53, 0, DateTimeKind.Unspecified) },
                    { "73e0b817-1894-4cf9-a76a-283d704b285b", "{ \"columns\": [ \"Özer Seçkin Ciddi\", \"Elif Nisan İmamoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 207, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 16, 36, 14, 0, DateTimeKind.Unspecified) },
                    { "6fe45d0a-dd9a-4ffd-bfcb-15e2213c2244", "{ \"columns\": [ \"Remzi Bilgi\", \"Osman Cihan Gürdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 163, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 20, 19, 59, 0, DateTimeKind.Unspecified) },
                    { "db59bbe5-fab2-4797-80f1-139bd0b5d8a1", "{ \"columns\": [ \"Thomas Aygen\", \"Elzem Evrenos\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 102, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 3, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "b01b0cd5-5f59-4def-a110-5a4391b89103", "{ \"columns\": [ \"Zeki Yiğithan Armutcu\", \"Bahar Cemre Erin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 2, 23, 47, 0, DateTimeKind.Unspecified) },
                    { "c13e2d93-0c2e-42c5-a4f4-4d4fcb502ea3", "{ \"columns\": [ \"Hulki Bent\", \"Köksal Gültaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 154, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 35, 26, 0, DateTimeKind.Unspecified) },
                    { "b3e77416-0f41-428d-8b8c-83bd57c099f3", "{ \"columns\": [ \"Derviş Haluk Baykan\", \"Işınbıke Gülcan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 144, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 19, 0, 58, 0, DateTimeKind.Unspecified) },
                    { "8b1c295c-25fc-4800-a0c8-b5204b5012ad", "{ \"columns\": [ \"Çisem Atok\", \"Onur Kerem Ertepınar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 89, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 18, 8, 13, 0, DateTimeKind.Unspecified) },
                    { "3bdbdd71-a644-4c08-99f3-b96d02f74bb1", "{ \"columns\": [ \"Ece Pınar Çeliker\", \"Fatma Büşra Karabıyıklı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 237, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 6, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "02ae076a-c879-4175-b60d-940564628146", "{ \"columns\": [ \"Öget Arif\", \"Samed Erek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 73, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 14, 42, 43, 0, DateTimeKind.Unspecified) },
                    { "f84e3fad-4b1b-49f5-a027-54c3f10eb5c1", "{ \"columns\": [ \"Seher İrem Çitfçi\", \"Naci Karakaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 249, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 2, 32, 0, DateTimeKind.Unspecified) },
                    { "6d94f615-738b-488f-8d27-e99c7e3e7bdb", "{ \"columns\": [ \"Kayıhan Nedim Akarcalı\", \"Hüsne Aysun Dal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 7, 40, 22, 0, DateTimeKind.Unspecified) },
                    { "4b725cbc-d939-45a2-8292-5d0211cc0d96", "{ \"columns\": [ \"Murat Kaan Ayanoglu\", \"Belin Esendemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 96, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 22, 22, 54, 0, DateTimeKind.Unspecified) },
                    { "f45ac260-b8d0-491a-920b-b32d22d5ad49", "{ \"columns\": [ \"Kutlu Alibeyoğlu\", \"Doruk Deniz Döner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 15, 40, 2, 0, DateTimeKind.Unspecified) },
                    { "c5bd7e99-f608-468a-bf2b-d2c80228cad5", "{ \"columns\": [ \"Mehmet Buğrahan Birgili\", \"Birgen Güvener\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 168, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 16, 22, 55, 0, DateTimeKind.Unspecified) },
                    { "c28f7f50-c93d-4d3f-a50f-cc913dfb7478", "{ \"columns\": [ \"Safa Batga\", \"Şueda Göreke\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 136, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 21, 5, 6, 53, 0, DateTimeKind.Unspecified) },
                    { "07fb140e-f967-47bf-b21e-39ff34b7d979", "{ \"columns\": [ \"Merve Ece Altıok\", \"Barın Düşenkalkar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 55, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 20, 58, 35, 0, DateTimeKind.Unspecified) },
                    { "b7391ce3-41d7-484a-aae7-7a945f817c42", "{ \"columns\": [ \"Ercüment Akıncılar\", \"Miraç Demırören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 21, 16, 0, DateTimeKind.Unspecified) },
                    { "15ebc701-ba7d-4b6d-baa0-d9b1b84e4f3a", "{ \"columns\": [ \"Nuhaydar Akbilmez\", \"Ayşe Neslihan Daşdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 6, 32, 0, DateTimeKind.Unspecified) },
                    { "37d8c78f-808a-4cd3-9dfa-1bccd8b8f143", "{ \"columns\": [ \"Mügenur Ahmet\", \"Çağrı Atahan Dağar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 9, 12, 7, 0, DateTimeKind.Unspecified) },
                    { "6cdd3b3b-b2b0-432c-b89b-cf3f7c819a8b", "{ \"columns\": [ \"Şansal Coşan\", \"İbrahim Kağan İncekara\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 210, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 19, 51, 38, 0, DateTimeKind.Unspecified) },
                    { "e03b6846-c43a-4d77-98bb-45f5fbf4f530", "{ \"columns\": [ \"Gökmen Battal\", \"Ersin Görgülü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 137, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 18, 7, 24, 0, DateTimeKind.Unspecified) },
                    { "7067df04-3f5c-469f-8327-6854303ca868", "{ \"columns\": [ \"İzlem Arınç\", \"Aynur Gül Ercüment\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 72, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 7, 54, 1, 0, DateTimeKind.Unspecified) },
                    { "355f468d-235b-412d-8633-b5523d1f7737", "{ \"columns\": [ \"Erna Aluç\", \"Güngör Erkin Egeli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 61, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 15, 53, 4, 0, DateTimeKind.Unspecified) },
                    { "6df69880-23f1-4413-b50e-05652f8a5aa0", "{ \"columns\": [ \"Aksu Bozdağ\", \"Kıvılcım Hadi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 175, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 12, 4, 49, 0, DateTimeKind.Unspecified) },
                    { "6e24e514-8ad0-4e7d-ae73-8892b07d43f0", "{ \"columns\": [ \"Muhammet Raşit Balı\", \"Nergiz Gilim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 122, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 17, 3, 38, 0, DateTimeKind.Unspecified) },
                    { "dea65be2-ccbe-4f2b-8d2f-338e816e2388", "{ \"columns\": [ \"Memet Bağcı\", \"Berhudan Garip\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 112, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 18, 14, 59, 0, DateTimeKind.Unspecified) },
                    { "f03126ea-577a-44d6-ac6a-0d1fcbdf1da4", "{ \"columns\": [ \"Fatma Özlem Acar\", \"Gürbüz Çivici\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 8, 37, 49, 0, DateTimeKind.Unspecified) },
                    { "b78650fd-103a-44fd-b3ea-2a2b503f9739", "{ \"columns\": [ \"İbrahim Hakkı Bugey\", \"Yeter Hamamcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 3, 42, 1, 0, DateTimeKind.Unspecified) },
                    { "5174bbc9-aeab-44d5-b4c5-2b2af97b352f", "{ \"columns\": [ \"Uluç Emre Binbay\", \"Tarık Güven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 167, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 15, 15, 26, 0, DateTimeKind.Unspecified) },
                    { "79bb4fb2-70d5-4584-bd1e-d5b3a053a569", "{ \"columns\": [ \"Nesibe Nurefşan Alkan\", \"Çisil Zeynep Dönmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 22, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "b0d1843c-f3da-4f99-a085-4741e6ae516e", "{ \"columns\": [ \"Kerime Hacer Akıllı\", \"Muhammed Bazit Deliloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 7, 7, 46, 0, DateTimeKind.Unspecified) },
                    { "f6af2042-2470-4cb3-9e92-0ec5e5bd2fab", "{ \"columns\": [ \"Hacı Mehmet Adıgüzel\", \"Hilal Ebru Çonay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 10, 8, 37, 0, DateTimeKind.Unspecified) },
                    { "01f1780e-db05-499c-a6cc-0af9626ead0d", "{ \"columns\": [ \"Saliha Zeynep Bülent\", \"Furkan Hızarcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 190, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 7, 58, 41, 0, DateTimeKind.Unspecified) },
                    { "f0f16eab-8e06-4847-b9c2-97266c312f72", "{ \"columns\": [ \"Mahmut Bilal Bülend\", \"Turhan Onur Hırlak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 189, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 8, 28, 45, 0, DateTimeKind.Unspecified) },
                    { "ac480e7b-a75c-4e17-bdd8-f81c01b33438", "{ \"columns\": [ \"Sakıp Balıoğlu\", \"Mehmet Gökalp Ginoviç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 123, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 9, 42, 35, 0, DateTimeKind.Unspecified) },
                    { "c0ca54f6-d165-48bd-8ba8-242d1379f0a7", "{ \"columns\": [ \"İsmail Umut Anık\", \"Alphan Ekercan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 63, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 1, 18, 30, 0, DateTimeKind.Unspecified) },
                    { "96d3d5b2-1766-4fb0-80eb-67c9d825bb15", "{ \"columns\": [ \"Senem Aksevim\", \"Rümeysa İrem Devecel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 6, 21, 36, 0, DateTimeKind.Unspecified) },
                    { "b8daf7c3-41a5-4664-bb62-22b90d75624e", "{ \"columns\": [ \"Berker Akkiray\", \"Sömer Demiroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 20, 15, 59, 13, 0, DateTimeKind.Unspecified) },
                    { "1b560dc4-2d79-426b-ae62-1a01d2ec0486", "{ \"columns\": [ \"Cihan Akarpınar\", \"Ezgin Dallı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 23, 23, 27, 0, DateTimeKind.Unspecified) },
                    { "3400c96c-41c4-4b60-abc8-141c7733e37c", "{ \"columns\": [ \"Mustafa Kerem Cansu\", \"Ayşe Zeyneb Irıcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 34, 2, 0, DateTimeKind.Unspecified) },
                    { "34882be6-51c3-4f18-88ce-4062f87819ca", "{ \"columns\": [ \"Sefa Kadir Başar\", \"Banuhan Gökçek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 130, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 6, 15, 21, 0, DateTimeKind.Unspecified) },
                    { "f48bcdd5-9382-4396-a816-baa198d2c971", "{ \"columns\": [ \"Kazım Balta\", \"Mehmetali Girgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 124, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 21, 17, 0, DateTimeKind.Unspecified) },
                    { "a75f3a6c-7a10-436f-acba-d62c55bd6284", "{ \"columns\": [ \"Kaan Muharrem Ay\", \"Lütfiye Sena Esen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 95, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 16, 42, 17, 0, DateTimeKind.Unspecified) },
                    { "437dd426-0e9e-41ce-8964-f909a9d815b9", "{ \"columns\": [ \"Tutkum Ahmadı Asl\", \"Olgun Dadalıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "768b9f36-7716-48db-a542-393115bda3cf", "{ \"columns\": [ \"Ahmet Gazi Çintan\", \"Büşra Hazal Karakaplan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 248, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 29, 21, 0, DateTimeKind.Unspecified) },
                    { "003b471e-15e6-4348-93f8-4867ccfc99d9", "{ \"columns\": [ \"Mihrinaz Bilal\", \"Mehmet Yekta Güneyi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 160, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 10, 9, 50, 0, DateTimeKind.Unspecified) },
                    { "5553474f-a1b0-49c4-9227-5932421d53b5", "{ \"columns\": [ \"Güneş Aykan\", \"Ilgaz Eyipişiren\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 103, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 22, 51, 0, DateTimeKind.Unspecified) },
                    { "55d65346-2528-4c2f-99af-6246ea29df61", "{ \"columns\": [ \"Onur Taylan Boylu\", \"Mehmet Anıl Hacıalioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 172, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 3, 34, 43, 0, DateTimeKind.Unspecified) },
                    { "bda2b9ef-2bf2-4820-986d-27fec6f47aaa", "{ \"columns\": [ \"Mustafa Burhan Askın\", \"Beniz Erkmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 79, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 3, 6, 59, 0, DateTimeKind.Unspecified) },
                    { "9ba7a2c0-e1e7-4fc2-92a1-96951474018f", "{ \"columns\": [ \"Berfin Dilay Bekaroğlu\", \"Merter Gülkan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 151, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 14, 53, 12, 0, DateTimeKind.Unspecified) },
                    { "128adc08-e696-4062-b27f-654b69c36862", "{ \"columns\": [ \"Armağan Bilgiç\", \"Okyanus Gürel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 164, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 5, 27, 45, 0, DateTimeKind.Unspecified) },
                    { "c67b542e-0b78-495f-a993-f3f8fde32345", "{ \"columns\": [ \"Sevinç Ak\", \"Özalp Dağbağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 10, 36, 1, 0, DateTimeKind.Unspecified) },
                    { "df400796-b07e-47f3-91dc-f6e34b5ac994", "{ \"columns\": [ \"Özen Çakan\", \"Uzel Kabataş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 218, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 11, 53, 6, 0, DateTimeKind.Unspecified) },
                    { "428d2db0-75de-43a1-b343-f53221a1c523", "{ \"columns\": [ \"Mustafa Samed Beğenilmiş\", \"Emircan Güleryüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 20, 37, 0, DateTimeKind.Unspecified) },
                    { "92410500-aabc-4586-9060-c95e6b0c41a0", "{ \"columns\": [ \"Ecren Baldo\", \"Resmiye Elif Gırgın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 121, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 32, 20, 0, DateTimeKind.Unspecified) },
                    { "5dba48be-4e68-45d7-b1d3-3031049116c6", "{ \"columns\": [ \"Şüheda Çiçekli\", \"Ilgar Pamir Karaismail\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 246, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 1, 10, 50, 0, DateTimeKind.Unspecified) },
                    { "61a18ff3-26b4-4372-8eaa-1fed79d095cd", "{ \"columns\": [ \"Aydın Mert Çelebican\", \"Çilay Kapsız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 232, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 10, 8, 25, 0, DateTimeKind.Unspecified) },
                    { "0c3f6059-5dc8-4027-b3e7-6f75a114faec", "{ \"columns\": [ \"Dilseren Çarıcı\", \"Şensoy Kalyoncu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 226, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 14, 32, 23, 0, DateTimeKind.Unspecified) },
                    { "84d52a74-97f2-42f4-9066-70ae47f222da", "{ \"columns\": [ \"Özgür Choi\", \"Halid İlhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 205, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 16, 3, 4, 0, DateTimeKind.Unspecified) },
                    { "a790c29a-7a3e-46a9-9bcc-874929b08b87", "{ \"columns\": [ \"Abdulvahap Bayrakoğlu\", \"Fatma Sena Güldoğuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 146, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 8, 34, 23, 0, DateTimeKind.Unspecified) },
                    { "0187cc41-da6d-461b-8ae3-099dd3670014", "{ \"columns\": [ \"Elif Etga Başeğmez\", \"Örgün Gökhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 131, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 2, 3, 20, 0, DateTimeKind.Unspecified) },
                    { "d6235fd3-0e31-4fb0-837c-d7c6f9fbad9f", "{ \"columns\": [ \"Aşkım Chiklyaukova\", \"Katya İlgezdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 204, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 4, 49, 51, 0, DateTimeKind.Unspecified) },
                    { "07e8b291-aa7d-448f-b3b2-51a4ae543a2c", "{ \"columns\": [ \"Balın Baştepe\", \"Melike Göksoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 132, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 42, 8, 0, DateTimeKind.Unspecified) },
                    { "291de695-1c94-4ebf-8787-c8ac6b20c550", "{ \"columns\": [ \"Adem Ayvacık\", \"Okbay Fatih\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 107, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 33, 16, 0, DateTimeKind.Unspecified) },
                    { "6e5f7bec-0874-42a3-a46b-2f4175814a62", "{ \"columns\": [ \"Elif Feyza Ayrım\", \"Ongar Eyyupoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 104, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 15, 3, 26, 0, DateTimeKind.Unspecified) },
                    { "38af3e7b-e617-4436-a6d5-1059d9d88ffa", "{ \"columns\": [ \"Selinti Al\", \"Zehra Pelin Döger\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 9, 3, 34, 0, DateTimeKind.Unspecified) },
                    { "7432a61a-0d01-4860-9e15-dc912483a697", "{ \"columns\": [ \"Elif Beyza Çark\", \"Necatı Kamışlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 227, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 11, 44, 37, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "d92a70bc-d011-4caf-bdf9-9da0311055e5", "{ \"columns\": [ \"Mehmet Enes Canan\", \"Ahmet Hakkı Hirik\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 195, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 9, 8, 41, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "c6be7c5d-0730-4372-bbc0-8de6c8b20501", "{ \"columns\": [ \"Recep Ali Samet Akdoğan\", \"Hülya Delı Chasan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 1, 28, 20, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "cb005657-6369-42ef-81ad-de73bdbb688b", "{ \"columns\": [ \"Mustafa Taha Canbek\", \"Toykan Horata\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 197, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 14, 38, 48, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TemplateId",
                table: "Clients",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_ClientId",
                table: "GroupMembers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_GroupId",
                table: "Notifications",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecipientId",
                table: "Notifications",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
