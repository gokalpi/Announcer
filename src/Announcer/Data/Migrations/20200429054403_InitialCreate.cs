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
                    { "27948960-9471-4d46-b372-555cb76f78d5", "{ \"columns\": [ \"Pekcan Aksöz\", \"Saliha Canan Dıvarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 20, 16, 22, 43, 0, DateTimeKind.Unspecified) },
                    { "2da358e6-4743-4513-8935-45f63b32aa2c", "{ \"columns\": [ \"Sebiha Büyüköztürk\", \"Argün Hilmi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 193, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 10, 25, 56, 0, DateTimeKind.Unspecified) },
                    { "8e1846eb-0861-4507-a00e-15e071854475", "{ \"columns\": [ \"Can Güney Bülbül\", \"Perihan Haykır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 188, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 11, 4, 40, 0, DateTimeKind.Unspecified) },
                    { "09bb695f-e2c7-4a7c-8f9a-030e02e98d92", "{ \"columns\": [ \"Elife Çerçi\", \"Abdullatif Karacabey\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 239, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 6, 6, 10, 0, DateTimeKind.Unspecified) },
                    { "c86f848e-49a5-485a-92c3-1137b385609f", "{ \"columns\": [ \"Taylan Remzi Baykuş\", \"Vedia Gülçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 145, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 21, 11, 3, 45, 0, DateTimeKind.Unspecified) },
                    { "1f49f33b-65c4-4736-ab80-5eadb032857b", "{ \"columns\": [ \"Memet Ali Ardıç\", \"Nadire Erbul\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 18, 41, 29, 0, DateTimeKind.Unspecified) },
                    { "94855de7-23e0-4a52-bfbc-c462730752b2", "{ \"columns\": [ \"Lemis Akküt\", \"Mehmet Kemal Dengizek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 20, 51, 9, 0, DateTimeKind.Unspecified) },
                    { "75b1dfb2-c1ac-41ba-a3c3-4b8aa4e835ec", "{ \"columns\": [ \"Hiba Alpuğan\", \"Enver Dur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 47, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 41, 42, 0, DateTimeKind.Unspecified) },
                    { "c585bb56-00ab-4d7c-8bb7-bd9b519270e3", "{ \"columns\": [ \"Müyesser Akyildirim\", \"Ziya Doğramacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 26, 45, 0, DateTimeKind.Unspecified) },
                    { "7d5fcbf2-29ef-4004-8f08-773bfe1d36de", "{ \"columns\": [ \"Ahmet Raşit Akoğuz\", \"Tubanur Dereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 14, 11, 0, DateTimeKind.Unspecified) },
                    { "1de60d9a-f2e3-444c-94f8-fa62cc76d43e", "{ \"columns\": [ \"Ayşen Aksoy\", \"Osman Sinan Devrim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 18, 25, 29, 0, DateTimeKind.Unspecified) },
                    { "65d2a850-a4d2-4104-afdc-fa23deb56f50", "{ \"columns\": [ \"Yaşar Utku Anıl Altın\", \"Karanalp Dursun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 51, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 0, 18, 49, 0, DateTimeKind.Unspecified) },
                    { "638be3c4-50dd-428f-92de-25d01507e32b", "{ \"columns\": [ \"Fethullah Altınöz\", \"Elanaz Dülgerbaki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 53, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 19, 28, 29, 0, DateTimeKind.Unspecified) },
                    { "19d01966-e529-47a6-82eb-7b8ea99f55eb", "{ \"columns\": [ \"Yansı Hilal Çınaroğlu\", \"Seyit Ahmet Karadağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 243, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 57, 51, 0, DateTimeKind.Unspecified) },
                    { "70c6ff30-3be5-4d1c-b110-2de9f6a85d71", "{ \"columns\": [ \"Aleda Buyuran\", \"Erk Deha Harmankaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 187, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 9, 0, 41, 0, DateTimeKind.Unspecified) },
                    { "8434d385-5675-4298-a58e-d2f6f22af565", "{ \"columns\": [ \"İbrahim Onat Belge\", \"Sevgi Tutku Güllüce\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 152, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 10, 45, 7, 0, DateTimeKind.Unspecified) },
                    { "b74f72da-1135-4b5f-afcb-50f3cb0a00c6", "{ \"columns\": [ \"Maral Çakıcı\", \"Şaziye Kabukçu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 220, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 20, 21, 1, 0, DateTimeKind.Unspecified) },
                    { "3a64a8c7-6a0e-4bfa-8e81-08b6aa39abc1", "{ \"columns\": [ \"Sena Nur Candan\", \"Selime Hüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 198, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 4, 51, 29, 0, DateTimeKind.Unspecified) },
                    { "5101d069-27cf-4053-9ed7-263d3c8a2078", "{ \"columns\": [ \"Nüket Aksan\", \"Bedir Destereci\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 33, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 7, 55, 50, 0, DateTimeKind.Unspecified) },
                    { "4277e912-ae92-434f-b3e6-af4257cc23e8", "{ \"columns\": [ \"Semina Aktuna\", \"Haldun Dinçtürk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 5, 6, 0, DateTimeKind.Unspecified) },
                    { "11401b06-7923-4433-953e-63a9f1a38296", "{ \"columns\": [ \"Atahan Adanır\", \"Ozan Ege Çomu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 20, 16, 35, 59, 0, DateTimeKind.Unspecified) },
                    { "f242500c-f11c-4132-b7ea-2431bf46fcc0", "{ \"columns\": [ \"Saba Atmaca\", \"Cantekin Erten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 88, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 21, 8, 1, 0, DateTimeKind.Unspecified) },
                    { "f6f46799-6871-4180-bad2-428be035a6ef", "{ \"columns\": [ \"İlma Aldağ\", \"Firuze Dönder\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 43, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 48, 44, 0, DateTimeKind.Unspecified) },
                    { "3c4cb24f-d207-43ab-9d93-5a958c1c5010", "{ \"columns\": [ \"Elif Ege Çağlayan\", \"Ahuşen İşgüzar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 217, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 23, 43, 16, 0, DateTimeKind.Unspecified) },
                    { "c4abc638-a769-4eeb-abd8-b47aa02bcdd2", "{ \"columns\": [ \"Hüner Berk\", \"Öymen Gümüşsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 156, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 21, 14, 45, 0, DateTimeKind.Unspecified) },
                    { "4a33f7ab-4a40-48ea-a167-ad15fe95a804", "{ \"columns\": [ \"Rubabe Gökçen Atlı\", \"İlkin Ersöz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 87, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 20, 11, 52, 0, DateTimeKind.Unspecified) },
                    { "03b9bf4c-5272-41c9-a20f-c6838f370e2f", "{ \"columns\": [ \"Hanife Duygu Ata\", \"Alper Emin Erkuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 83, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 21, 9, 39, 27, 0, DateTimeKind.Unspecified) },
                    { "b21179fe-cc52-4c7a-8dee-5f75e08778a1", "{ \"columns\": [ \"Önel Çapa\", \"Ünzile Kalfaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 224, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 8, 36, 10, 0, DateTimeKind.Unspecified) },
                    { "e235d8c7-85ba-4c59-99c6-b3ac4f603c48", "{ \"columns\": [ \"Şeyda Nur Arikan\", \"Cem Ozan Erim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 74, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 21, 7, 38, 18, 0, DateTimeKind.Unspecified) },
                    { "81cb417f-dacb-4cea-ab74-09699fa249ef", "{ \"columns\": [ \"Mükerrem Zeynep Ağca\", \"Ayben Çorumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 20, 19, 52, 0, 0, DateTimeKind.Unspecified) },
                    { "7ad2ae92-ae08-416d-8937-a8156759a2ea", "{ \"columns\": [ \"Betül Bozyer\", \"Büşranur Halaçoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 178, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 8, 0, 21, 0, DateTimeKind.Unspecified) },
                    { "2bfd4856-ee79-485b-862b-40e7dcf6276a", "{ \"columns\": [ \"Omaç Çıngır\", \"Cevza Karadalan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 244, false, null, null, null, "10.100.1.36", new DateTime(2020, 4, 21, 4, 22, 52, 0, DateTimeKind.Unspecified) },
                    { "a6f5d085-3ef6-4105-abc6-b79c8fe16027", "{ \"columns\": [ \"Abdullah Emirhan Caner\", \"Denizcan Ilık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 199, false, null, null, null, "10.100.1.40", new DateTime(2020, 4, 20, 23, 44, 6, 0, DateTimeKind.Unspecified) },
                    { "6d1e2d7d-eeaa-4698-bc85-e52baf20c7ce", "{ \"columns\": [ \"Almina Avcı Özsoy\", \"Tunca Eryılmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 92, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 14, 28, 53, 0, DateTimeKind.Unspecified) },
                    { "35f2d9e1-bdfc-4140-bc0a-69918ffcd687", "{ \"columns\": [ \"Bestami Ağırağaç\", \"Abdulbaki Çotur\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 0, 30, 39, 0, DateTimeKind.Unspecified) },
                    { "94349c2d-d36d-47cc-acaa-933d8b8a0b97", "{ \"columns\": [ \"Elif Tuğçe Altaş\", \"Birsen Durmuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 49, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 13, 24, 34, 0, DateTimeKind.Unspecified) },
                    { "ceb1a48d-41b7-4d51-830d-31c1b5e4f311", "{ \"columns\": [ \"Sırma Begüm Altunbaş\", \"Erem Edibali Mp\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 58, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 10, 50, 5, 0, DateTimeKind.Unspecified) },
                    { "e4ac1756-c6da-4548-a5b3-6113097b105e", "{ \"columns\": [ \"Yasin Şükrü Arap\", \"Akife Erbay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 68, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 20, 16, 16, 45, 0, DateTimeKind.Unspecified) },
                    { "3fb8e271-6158-4467-954e-37734eee679a", "{ \"columns\": [ \"Ayşegül Barutçuoğlu\", \"Busem Gökçeaslan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 129, false, null, null, null, "10.100.1.27", new DateTime(2020, 4, 21, 1, 58, 28, 0, DateTimeKind.Unspecified) },
                    { "f6561c50-f80a-4bc2-8679-579c43b92b0c", "{ \"columns\": [ \"Ilım Aslantürk\", \"Hasan Burak Erkoç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 20, 15, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "9d38dffa-0788-4944-a07d-e86adc5b2a82", "{ \"columns\": [ \"Gülser Bal\", \"Kerem Cahit Gençoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 119, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 17, 38, 4, 0, DateTimeKind.Unspecified) },
                    { "4a0cb3eb-3ffb-4f96-b163-7707d4782dc4", "{ \"columns\": [ \"Atak Batar\", \"Denizhan Gönül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 135, false, null, null, null, "10.100.1.33", new DateTime(2020, 4, 21, 10, 10, 33, 0, DateTimeKind.Unspecified) },
                    { "768eea0a-68a2-453e-925c-fc8cb243765c", "{ \"columns\": [ \"Ömer Buğra Alparslan\", \"Tugce Dudu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 46, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 16, 14, 54, 0, DateTimeKind.Unspecified) },
                    { "0e982d6e-d818-4392-81a8-63bb20bf6175", "{ \"columns\": [ \"Nazım Orhun Baturalp\", \"Nazım Berke Göven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 140, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 21, 2, 59, 2, 0, DateTimeKind.Unspecified) },
                    { "7690b27b-5f68-4d11-9a96-641bf3df2d7c", "{ \"columns\": [ \"Sarper Akış\", \"Hürel Demiriz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 4, 13, 6, 0, DateTimeKind.Unspecified) },
                    { "de458374-937e-4ca7-a512-2377b097edde", "{ \"columns\": [ \"Sabiha Elvan Atol\", \"İsmail Enes Eruzun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 90, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 19, 58, 20, 0, DateTimeKind.Unspecified) },
                    { "5523313e-8084-4574-bdd9-cc3b9cf14d4b", "{ \"columns\": [ \"Oğuzcan Coşandal\", \"Sidar İnceoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 211, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 6, 14, 55, 0, DateTimeKind.Unspecified) },
                    { "977e9cdc-41e2-4281-9c8f-56ffb61d3ccf", "{ \"columns\": [ \"Esim Çaylar\", \"Necip Fazıl Kanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 229, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 11, 38, 41, 0, DateTimeKind.Unspecified) },
                    { "b6d0fd63-f176-455f-84c8-452736008b16", "{ \"columns\": [ \"Mehmet Tarık Çelikkol\", \"Arca Karabulut\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 238, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 10, 7, 29, 0, DateTimeKind.Unspecified) },
                    { "fb171198-a5b2-43a8-bff0-832c17e1840c", "{ \"columns\": [ \"Zeynep Nihan Aydınlıoğlu\", \"Batıray Eski\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 99, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 23, 50, 9, 0, DateTimeKind.Unspecified) },
                    { "665725dc-f0af-4c89-8ab1-0151106d759a", "{ \"columns\": [ \"Erol Özgür Baştuğ\", \"Nilüfer Gönay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 134, false, null, null, null, "10.100.1.31", new DateTime(2020, 4, 20, 22, 39, 49, 0, DateTimeKind.Unspecified) },
                    { "dee2067b-3652-4b31-a6c0-3609bc8b8ddc", "{ \"columns\": [ \"Eda Sena Akyıldız\", \"Goncagül Diri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 10, 11, 27, 0, DateTimeKind.Unspecified) },
                    { "42be7a76-e28a-4820-a9da-32e118c2dadb", "{ \"columns\": [ \"Mahperi Baştopçu\", \"Yeşim Gölmes\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 133, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 26, 28, 0, DateTimeKind.Unspecified) },
                    { "a1521f14-885b-411c-9dd2-4b76181a1e5d", "{ \"columns\": [ \"Doğuşcan Biriz\", \"Ahmet Korhan Güzel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 169, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 5, 25, 15, 0, DateTimeKind.Unspecified) },
                    { "d087cc86-5187-4a1c-8fa7-155b30dbfb47", "{ \"columns\": [ \"Seung Hun Baki\", \"Muazzez Ece Gemalmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 118, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 24, 30, 0, DateTimeKind.Unspecified) },
                    { "3dcfa55f-d2bf-4988-964e-63c294a999f0", "{ \"columns\": [ \"Büşra Cüce\", \"İhsan Vehbi İpekoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 213, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 8, 28, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { "15d468c4-c9bb-431c-abbe-df406757d8b5", "{ \"columns\": [ \"Cansev Arat\", \"Burç Erbil\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 69, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 18, 50, 0, 0, DateTimeKind.Unspecified) },
                    { "26c6ffbf-4e47-4d51-8c40-d01c70f556c0", "{ \"columns\": [ \"Elif Dilay Altinkaya\", \"Cem Efe Edeş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 57, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 11, 6, 33, 0, DateTimeKind.Unspecified) },
                    { "51cdee72-aebd-4c6e-bce5-88bf985a46ff", "{ \"columns\": [ \"Paksoy Ateş\", \"Abdullah Mert Erol\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 85, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 13, 55, 21, 0, DateTimeKind.Unspecified) },
                    { "cd21a7c6-acd4-4b23-bc6d-911c9816840f", "{ \"columns\": [ \"Ata Kerem Akman\", \"Zeynep Büşra Derdemez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 21, 0, 27, 12, 0, DateTimeKind.Unspecified) },
                    { "1a77d974-22e7-45d1-8715-37a5a77a3878", "{ \"columns\": [ \"Lemi Akarçay\", \"Aydonat Dalkılıç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, false, null, null, null, "10.100.1.35", new DateTime(2020, 4, 20, 18, 53, 26, 0, DateTimeKind.Unspecified) },
                    { "36e86512-aaf5-4c8a-8db6-93865cb97d7f", "{ \"columns\": [ \"Çelik Bilgir\", \"Mert Alican Güreş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 165, false, null, null, null, "10.100.1.38", new DateTime(2020, 4, 21, 10, 59, 36, 0, DateTimeKind.Unspecified) },
                    { "16f9bbb3-e297-4f02-9da2-68f21f5e7b96", "{ \"columns\": [ \"Hayrunnisa Aşveren\", \"Hanife Nur Erkovan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 82, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 21, 7, 4, 7, 0, DateTimeKind.Unspecified) },
                    { "d03b6682-5793-4001-b64a-75bd1988a94e", "{ \"columns\": [ \"Saime Avıandı\", \"Arslan Erzurumlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 93, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 21, 7, 31, 25, 0, DateTimeKind.Unspecified) },
                    { "c44a094c-7efa-4474-bf5c-d5c506938059", "{ \"columns\": [ \"İlyas Umut Apul\", \"Mert Cem Eliçin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 66, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 20, 13, 19, 43, 0, DateTimeKind.Unspecified) },
                    { "0be3c9ad-13af-4e7c-a618-301c68b1da5c", "{ \"columns\": [ \"Özgen Baka\", \"Hayri Anıl Geçkin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 117, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 22, 39, 0, 0, DateTimeKind.Unspecified) },
                    { "1270edde-8ee7-489c-b548-bf24c95a6d4e", "{ \"columns\": [ \"Hayriye Büyükgüngör\", \"Muhammed Sefa Hilal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 192, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 12, 45, 42, 0, DateTimeKind.Unspecified) },
                    { "ce08599a-7d8b-4cce-8731-559b0ffed8ed", "{ \"columns\": [ \"Mercan Bağçivan\", \"Nihan Gazitepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 113, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 11, 28, 35, 0, DateTimeKind.Unspecified) },
                    { "eed7db76-4f29-40df-be94-41c55d27e044", "{ \"columns\": [ \"Ateş Aycı\", \"İslam Eshaqzada\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 98, false, null, null, null, "10.100.1.39", new DateTime(2020, 4, 20, 14, 29, 28, 0, DateTimeKind.Unspecified) },
                    { "79409a5f-0fb5-4054-b23d-34186c922b06", "{ \"columns\": [ \"Kubilay Barış Begiç\", \"Bektaş Gülenç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 149, false, null, null, null, "10.100.1.30", new DateTime(2020, 4, 20, 19, 6, 49, 0, DateTimeKind.Unspecified) },
                    { "85031977-a228-4e08-a937-34f6fa51b8e0", "{ \"columns\": [ \"Ferdacan Aruca\", \"Hüseyin Serkan Erkekli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 77, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 11, 5, 27, 0, DateTimeKind.Unspecified) },
                    { "23aa5d00-4665-4e21-bca9-97e581c0d6da", "{ \"columns\": [ \"Osman Yasin Aysan\", \"Turan Fahri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 106, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 8, 40, 27, 0, DateTimeKind.Unspecified) },
                    { "8ca0dd3c-e377-4ed1-a2d6-c4246743fd1c", "{ \"columns\": [ \"Alçiçek Bad\", \"Ertuğ Furuncuoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 111, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 13, 30, 15, 0, DateTimeKind.Unspecified) },
                    { "7f7c3bab-1263-4fb0-a869-397af7e6531a", "{ \"columns\": [ \"Ruhugül Babadostu\", \"İrfan Anıl Fındıkçı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 110, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 9, 18, 42, 0, DateTimeKind.Unspecified) },
                    { "91dc0a33-a1fa-4fc4-8ab8-900f2f8340a3", "{ \"columns\": [ \"İltem Boztepe\", \"Feray Hakverdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 177, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 1, 38, 54, 0, DateTimeKind.Unspecified) },
                    { "9240ec53-a893-4f5a-8dad-e592e9b549a5", "{ \"columns\": [ \"Serdar Kaan Barbaros\", \"Kubra Göçmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 127, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 17, 10, 6, 0, DateTimeKind.Unspecified) },
                    { "77fd4cf9-3171-4045-ab3e-4c47a571043f", "{ \"columns\": [ \"Gönül Çağatay\", \"Zerin İshakoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 215, false, null, null, null, "10.100.1.28", new DateTime(2020, 4, 21, 4, 59, 44, 0, DateTimeKind.Unspecified) },
                    { "5d67322c-c8b0-4c04-8bd4-74410e89bf97", "{ \"columns\": [ \"Sena Çekmecelioğlu\", \"Muharrem Kanmaz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 230, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 21, 2, 33, 17, 0, DateTimeKind.Unspecified) },
                    { "6cf45b1a-95e1-4d74-a2ac-9b65d7119f42", "{ \"columns\": [ \"Erhan Çıray\", \"Mustafa Emir Karademir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 245, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 23, 13, 26, 0, DateTimeKind.Unspecified) },
                    { "aca86584-ef99-4e16-829a-e31702f6a403", "{ \"columns\": [ \"Ahmet Ruken Altay\", \"Taçmin Durmuşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 1, 18, 6, 0, DateTimeKind.Unspecified) },
                    { "6fc3cd4c-025c-4771-8d6b-7adb88eb4dda", "{ \"columns\": [ \"Rima Altıparmak\", \"Mehmet Erman Düzbayır\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 56, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 20, 7, 20, 0, DateTimeKind.Unspecified) },
                    { "f5f8fcb8-7fe7-4c17-b783-0d834c789b9b", "{ \"columns\": [ \"Jutenya Benan\", \"Denktaş Gülşen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 153, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 20, 21, 14, 22, 0, DateTimeKind.Unspecified) },
                    { "c34c1e3a-dd75-403b-8883-1462fec47e83", "{ \"columns\": [ \"Cankız Bulgan\", \"Boran Hamidi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 182, false, null, null, null, "10.100.1.29", new DateTime(2020, 4, 21, 4, 19, 58, 0, DateTimeKind.Unspecified) },
                    { "058d3322-808c-4280-a658-74f34ff3039b", "{ \"columns\": [ \"Lal Bilgeç\", \"Yasemin Erva Güntek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 161, false, null, null, null, "10.100.1.37", new DateTime(2020, 4, 21, 10, 51, 53, 0, DateTimeKind.Unspecified) },
                    { "61f73123-8d5d-4b61-82af-1e2956c46454", "{ \"columns\": [ \"Balkın Cigerlioğlu\", \"Emine Selcen İmre\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 208, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 20, 26, 52, 0, DateTimeKind.Unspecified) },
                    { "c59f8c08-7088-4cef-9ada-c0d63dfaa2a0", "{ \"columns\": [ \"Mustafa Doğukan Berberoğlu\", \"Hasan Fahri Gültepe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 155, false, null, null, null, "10.100.1.34", new DateTime(2020, 4, 20, 14, 44, 16, 0, DateTimeKind.Unspecified) },
                    { "64a88f0e-4da8-4a4b-93a4-c4ddfa435d1a", "{ \"columns\": [ \"Çağkan Çelenlioğlu\", \"Suna Karaaslanlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 233, false, null, null, null, "10.100.1.32", new DateTime(2020, 4, 20, 14, 17, 11, 0, DateTimeKind.Unspecified) },
                    { "cb3b8d9e-6e5d-4677-bace-6c06144425a5", "{ \"columns\": [ \"Halim Aral\", \"Ahmet Sencer Emikoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 67, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 34, 17, 0, DateTimeKind.Unspecified) },
                    { "8ad82ffb-23a1-4c3e-89a6-cdd81b181f69", "{ \"columns\": [ \"Mehmet Can Akçaözoğlu\", \"Fadik Himoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 194, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 21, 3, 57, 41, 0, DateTimeKind.Unspecified) },
                    { "49fd8f39-a8a3-4971-adf1-43dc833929e4", "{ \"columns\": [ \"Ayla Baytın\", \"Aybike Güleç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 148, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 28, 27, 0, DateTimeKind.Unspecified) },
                    { "b5a77283-5fce-4d25-9ad0-234926187a4a", "{ \"columns\": [ \"Kerime Aydoğan Yozgat\", \"Süheyl Esvap\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 19, 34, 0, DateTimeKind.Unspecified) },
                    { "4710e608-f142-4245-baaa-f555a8011264", "{ \"columns\": [ \"Nunazlı Arpacı\", \"Rekin Erkek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 76, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 20, 42, 49, 0, DateTimeKind.Unspecified) },
                    { "91b1a9d3-70dc-45f7-8278-78f86d67ed79", "{ \"columns\": [ \"İlkay Ramazan Ankara\", \"Lale Ekrem\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 64, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 7, 47, 0, DateTimeKind.Unspecified) },
                    { "9b045d0b-97c3-4cb0-9efa-f37f4be61825", "{ \"columns\": [ \"Hikmet Nazlı Alver\", \"Çağın Egin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 62, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 14, 6, 2, 0, DateTimeKind.Unspecified) },
                    { "8c6ce462-7c20-485e-b678-a72492e73561", "{ \"columns\": [ \"Büşra Gül Altundal\", \"İbrahim Alp Tekin Ege\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 15, 13, 58, 0, DateTimeKind.Unspecified) },
                    { "2d2add62-50fa-401c-9a61-b053532757f9", "{ \"columns\": [ \"Ünkan Çini\", \"Seren Karakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 247, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 17, 32, 0, DateTimeKind.Unspecified) },
                    { "1979cded-6a48-4426-a17c-52a4cd0d4256", "{ \"columns\": [ \"Senay Bilgen\", \"Günan Güral\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 162, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 4, 59, 42, 0, DateTimeKind.Unspecified) },
                    { "455dde3c-6d01-477c-aae6-21259eb134a2", "{ \"columns\": [ \"Hatice Gamze Çınar\", \"Haluk Barış Karaçeşme\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 242, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 3, 8, 19, 0, DateTimeKind.Unspecified) },
                    { "7edfcaee-54b7-457b-8a16-e79c4eb7fe5d", "{ \"columns\": [ \"Selma Simge Ceylan\", \"Güçlü İçten\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 203, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 9, 30, 8, 0, DateTimeKind.Unspecified) },
                    { "a235266e-cda9-4ee9-9f2a-1ee2edb8b27b", "{ \"columns\": [ \"Yaprak Bural\", \"Berrak Harman\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 186, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 22, 10, 53, 0, DateTimeKind.Unspecified) },
                    { "129d029c-8269-4afb-a4fa-90017aa6a45c", "{ \"columns\": [ \"Ogün Bölge\", \"Selin Sıla Halıcılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 179, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 18, 21, 57, 0, DateTimeKind.Unspecified) },
                    { "452df428-8378-45d8-bcf1-ba7260a33998", "{ \"columns\": [ \"Bensu Batur\", \"Ayşe Elif Görür\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 139, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 21, 8, 15, 40, 0, DateTimeKind.Unspecified) },
                    { "828ee511-c996-46e1-86cc-b95135a994ef", "{ \"columns\": [ \"Murat Sinan Ayaz\", \"Rukiye Esgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 97, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 23, 4, 53, 0, DateTimeKind.Unspecified) },
                    { "777b0aad-9203-4afe-a764-ac42bd5dbf86", "{ \"columns\": [ \"Zümra Çelık\", \"Ahmet Can Karabacak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 234, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 18, 20, 41, 0, DateTimeKind.Unspecified) },
                    { "4a3be722-f359-43c1-9eca-126a18f90f2b", "{ \"columns\": [ \"Bayülken Çaprak\", \"Sezer Kalsın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 225, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 3, 12, 24, 0, DateTimeKind.Unspecified) },
                    { "b6fcca91-ee74-49fb-b095-3ab3ea3e1230", "{ \"columns\": [ \"Hacı Bayram Ufuk Çamaş\", \"Ömer Faruk Kadı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 222, false, null, null, null, "10.100.1.9", new DateTime(2020, 4, 20, 12, 13, 48, 0, DateTimeKind.Unspecified) },
                    { "ea0dadfa-e724-4b53-bfb3-63c5e7333276", "{ \"columns\": [ \"Afra Selcen Çağan\", \"Necati İrsoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 214, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 7, 59, 0, DateTimeKind.Unspecified) },
                    { "2c164b1e-d5d7-4a0c-b645-cbc1b4a83c3b", "{ \"columns\": [ \"Ayseren Boyuktaş\", \"Ahmet Furkan Hacılar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 173, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 20, 19, 1, 9, 0, DateTimeKind.Unspecified) },
                    { "5b31e033-3463-45cd-9a5a-100bf416f623", "{ \"columns\": [ \"Efecan Çetintaş\", \"Tuğra Karacan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 240, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 6, 32, 13, 0, DateTimeKind.Unspecified) },
                    { "d749f01b-1ff8-4c65-99f8-b035c8fc36e0", "{ \"columns\": [ \"Aykanat Ağıroğlu\", \"Neva Çuhadar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 6, 58, 40, 0, DateTimeKind.Unspecified) },
                    { "a92397c4-190a-4602-aa58-5c6c91d5e042", "{ \"columns\": [ \"Gönülgül Çelikağı\", \"Gül Sena Karabıyık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 236, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 1, 17, 39, 0, DateTimeKind.Unspecified) },
                    { "c9935ec4-48cf-4fa2-874b-c9e612c8647f", "{ \"columns\": [ \"Melike Dilara Büyükfırat\", \"Mustafa Ali Hiçyılmam\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 191, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 20, 18, 15, 0, 0, DateTimeKind.Unspecified) },
                    { "75ad128e-0b15-4ced-a13d-c9311f56952d", "{ \"columns\": [ \"Asiye Burabak\", \"Aynur Dilan Hancı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 184, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 2, 8, 47, 0, DateTimeKind.Unspecified) },
                    { "b9ca7fb2-0a80-4ee9-aa28-540dee7ffbd1", "{ \"columns\": [ \"Yüksel Balcı\", \"Sadık Can Gezmiş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 120, false, null, null, null, "10.100.1.12", new DateTime(2020, 4, 21, 3, 41, 25, 0, DateTimeKind.Unspecified) },
                    { "9e12eaa9-bc19-42ec-ab90-0cd80b0cb433", "{ \"columns\": [ \"Muhammed Üzeyir Çekmeci\", \"Zeynep Figen Kantarcı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 231, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 0, 56, 0, DateTimeKind.Unspecified) },
                    { "6a0c8966-dcdc-4420-a53c-ab64f876aa30", "{ \"columns\": [ \"Elvan Çatal\", \"Şahan Kandaşoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 228, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "df1836f2-8528-424d-ab5b-423bf7d8f8d3", "{ \"columns\": [ \"Dilhan Çakanel\", \"Melis Ezgi Kabayuka\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 219, false, null, null, null, "10.100.1.10", new DateTime(2020, 4, 21, 1, 11, 58, 0, DateTimeKind.Unspecified) },
                    { "93651743-325a-4b49-95c7-020d2ff6166f", "{ \"columns\": [ \"Doktora Canuyar\", \"Mustafa Furkan Işınay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 201, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 11, 16, 38, 0, DateTimeKind.Unspecified) },
                    { "553b967c-0936-4a71-a3e0-1d6760b76113", "{ \"columns\": [ \"Onay Buğdaypınarı\", \"Ramazan Tarık Hamarat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 181, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 13, 37, 52, 0, DateTimeKind.Unspecified) },
                    { "31b46b3e-ac5e-4061-83be-1b206b706d3c", "{ \"columns\": [ \"Bengisu Boya\", \"Mustafa Berkay Güzeloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 171, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 14, 13, 55, 0, DateTimeKind.Unspecified) },
                    { "5a0682ea-1fed-4105-a473-a9ea74a0aac3", "{ \"columns\": [ \"Altan Boy\", \"Manolya Güzeller\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 170, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 12, 32, 18, 0, DateTimeKind.Unspecified) },
                    { "fa26aa91-3f96-472f-8ef1-6dc2780c7af6", "{ \"columns\": [ \"Didem Bıçaksız\", \"Argun Güneri\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 159, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 17, 59, 8, 0, DateTimeKind.Unspecified) },
                    { "735ced16-ec50-48c9-b416-7ba192db3dd6", "{ \"columns\": [ \"Demircan Baydil\", \"Abdulhalim Guguk\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 142, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 16, 0, 53, 0, DateTimeKind.Unspecified) },
                    { "b30920d5-2d79-4edd-9c69-4e56a8c39ad2", "{ \"columns\": [ \"Burak Tatkan Altıntaş\", \"Fidan Dündar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 54, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 6, 7, 32, 0, DateTimeKind.Unspecified) },
                    { "8ed215aa-a064-4106-b0a7-878306ab5846", "{ \"columns\": [ \"Rafi Akaş\", \"Refiye Seda Dalyaprak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 21, 0, 20, 26, 0, DateTimeKind.Unspecified) },
                    { "9dcf5c98-053d-4227-9fcd-b8bee0cd031d", "{ \"columns\": [ \"Arzucan Bulgur\", \"Tazika Hilal Hamzaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 183, false, null, null, null, "10.100.1.11", new DateTime(2020, 4, 20, 22, 40, 51, 0, DateTimeKind.Unspecified) },
                    { "82d1d814-2245-4187-b1e0-9fbda8080c72", "{ \"columns\": [ \"Pekin Boz\", \"Fazilet Hacıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 174, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 10, 56, 21, 0, DateTimeKind.Unspecified) },
                    { "af68a5f2-fbd8-4e61-80a3-6e0f45d01638", "{ \"columns\": [ \"Coşkun Baran\", \"Tilbe Göç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 126, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 21, 11, 38, 0, DateTimeKind.Unspecified) },
                    { "e2d297f4-d087-4cb5-b114-efbeb9d40d6b", "{ \"columns\": [ \"Sera Cansın Azbay\", \"Latife Fatin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 108, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 16, 54, 51, 0, DateTimeKind.Unspecified) },
                    { "4e54de84-5066-4e2e-bac7-e0c916cc2f2b", "{ \"columns\": [ \"Nebahat Ansen\", \"Bağış Can Elbaşı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 12, 57, 54, 0, DateTimeKind.Unspecified) },
                    { "244108e0-49cc-48a9-890a-eac948b12910", "{ \"columns\": [ \"Emre Ayberk Akfırat\", \"Doga Elif Delice\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 23, 12, 45, 0, DateTimeKind.Unspecified) },
                    { "0d5e9632-ea3d-4966-9aad-5172c6949627", "{ \"columns\": [ \"Rıdvan Çıkıkcı\", \"Emir Doğan Karaçay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 241, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 7, 58, 42, 0, DateTimeKind.Unspecified) },
                    { "ebcdcc8f-ef3a-48fb-8fb3-07260a76e2c8", "{ \"columns\": [ \"Mahire Çalım\", \"Bergüzar Kaçaranoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 221, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 10, 18, 45, 0, DateTimeKind.Unspecified) },
                    { "b15f5602-bdbe-48af-8477-0499566f0533", "{ \"columns\": [ \"Mayıs Cumalı\", \"Nesli İpçizade\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 212, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 16, 19, 36, 0, DateTimeKind.Unspecified) },
                    { "5188eb34-b870-4a48-bf27-4192479d7e48", "{ \"columns\": [ \"Seyit Ceran\", \"Sude İbrahim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 202, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 17, 47, 59, 0, DateTimeKind.Unspecified) },
                    { "731351f6-f2d8-42d8-a3ee-df468c9505f2", "{ \"columns\": [ \"Edip Attila\", \"Hamıd Eryıldız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 91, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 21, 1, 5, 35, 0, DateTimeKind.Unspecified) },
                    { "66bf6c51-9830-48bf-9b11-b75af1bbba56", "{ \"columns\": [ \"Şerife Asil\", \"İbrahim Candaş Erki\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 78, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 14, 44, 48, 0, DateTimeKind.Unspecified) },
                    { "95fa3bf9-e9d9-4861-b2f4-201a3f2eadbb", "{ \"columns\": [ \"İlkim Ateşcan\", \"Çisel Ersin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 86, false, null, null, null, "10.100.1.2", new DateTime(2020, 4, 20, 15, 18, 22, 0, DateTimeKind.Unspecified) },
                    { "7441f3de-e12a-4e92-b057-16eef38ecf96", "{ \"columns\": [ \"Kurtbey Canbağı\", \"Mustafa Sefa Hopacı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 196, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 10, 35, 32, 0, DateTimeKind.Unspecified) },
                    { "8485692e-838d-4449-96f4-bb78ddf3277b", "{ \"columns\": [ \"Ezel Bargan\", \"Kubilay Gödek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 128, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 49, 28, 0, DateTimeKind.Unspecified) },
                    { "b849f03f-f8e8-4e16-8cc9-e236a7f7a53a", "{ \"columns\": [ \"Abdullah Atakan Baluken\", \"Abdullah Halit Golba\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 125, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 2, 58, 0, DateTimeKind.Unspecified) },
                    { "b8ff4e55-c34b-4877-9cb1-7f9e265fef5b", "{ \"columns\": [ \"Hami Aydoğdu\", \"Yargı Yekta Eşe\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 101, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 14, 36, 11, 0, DateTimeKind.Unspecified) },
                    { "6e8a667a-8dcd-4e94-922d-ea3053256613", "{ \"columns\": [ \"Nefse Altunbulak\", \"Volkan Eyüp Efşin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 59, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 19, 53, 36, 0, DateTimeKind.Unspecified) },
                    { "68e61071-bdb5-4669-85c3-08aec2875848", "{ \"columns\": [ \"Bahar Özlem Albaş\", \"Seli M Sharef Dökülmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 6, 58, 37, 0, DateTimeKind.Unspecified) },
                    { "361e2122-b073-425f-b95d-b71163bb5b7f", "{ \"columns\": [ \"Özde Acarkan\", \"Zülal Çolak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 20, 22, 15, 31, 0, DateTimeKind.Unspecified) },
                    { "25cdb078-3552-4b56-b9d1-a0e7b57a00d0", "{ \"columns\": [ \"Yücel Civan\", \"Tevfik İnal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 209, false, null, null, null, "10.100.1.1", new DateTime(2020, 4, 21, 11, 4, 2, 0, DateTimeKind.Unspecified) },
                    { "94db4173-86d9-49dd-a562-e793d2632f84", "{ \"columns\": [ \"Pırıltı Bahçeli\", \"Şeniz Geboloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 115, false, null, null, null, "10.100.1.3", new DateTime(2020, 4, 20, 13, 24, 53, 0, DateTimeKind.Unspecified) },
                    { "e53ee136-39da-4707-8fdd-7318581aff62", "{ \"columns\": [ \"Mehmetcan Akay\", \"Esat Erdem Daniş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 59, 39, 0, DateTimeKind.Unspecified) },
                    { "a42057e4-4d44-4b0c-b7fc-1feb5efc3d4c", "{ \"columns\": [ \"Emine Münevver Akca\", \"Fetullah Davutoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 52, 5, 0, DateTimeKind.Unspecified) },
                    { "71652cbe-c3d0-4e13-a941-4faef4348c9f", "{ \"columns\": [ \"Uğur Ali Aysal\", \"Faik Ezber\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 105, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 21, 7, 10, 41, 0, DateTimeKind.Unspecified) },
                    { "82c8c0b6-4cce-42ba-9bf9-a5cfb527c6cf", "{ \"columns\": [ \"Bedirhan Lütfü Akşamoğlu\", \"Samet Emre Dikbaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 20, 9, 4, 0, DateTimeKind.Unspecified) },
                    { "56e96e39-93b7-4c37-ae79-9bde4446ea8e", "{ \"columns\": [ \"Şennur Ağnar\", \"Öznur Çulhaoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, null, null, null, "10.100.1.8", new DateTime(2020, 4, 20, 15, 19, 12, 0, DateTimeKind.Unspecified) },
                    { "9f83c5d0-dcc5-4c88-813f-f253d6e10887", "{ \"columns\": [ \"Oltun Çanga\", \"Dağhan Kadoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 223, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 19, 24, 58, 0, DateTimeKind.Unspecified) },
                    { "f3c8ebf2-8eb4-471e-bd82-4ecb4b431fb6", "{ \"columns\": [ \"Tuğce Cibooğlu\", \"Nihal İlısu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 206, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 57, 28, 0, DateTimeKind.Unspecified) },
                    { "328b0a0d-4f91-4f26-8101-2eec39a39292", "{ \"columns\": [ \"Gökay Bağış\", \"Menekşe Geben\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 114, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 21, 17, 54, 0, DateTimeKind.Unspecified) },
                    { "caa05b3b-ba26-494c-a76c-696c3ff0f63c", "{ \"columns\": [ \"Deniz Dilay Arıcan\", \"Hüseyin Zeyd Ercoşkun\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 71, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 20, 18, 31, 11, 0, DateTimeKind.Unspecified) },
                    { "256602db-b8d2-4839-a792-15f3779d1315", "{ \"columns\": [ \"Ahmet Polat Aklar Çörekçi\", \"Alya Denizgünü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, false, null, null, null, "10.100.1.7", new DateTime(2020, 4, 21, 9, 3, 37, 0, DateTimeKind.Unspecified) },
                    { "3d57dfb8-2b27-4d9a-bc7e-62d905aaaf82", "{ \"columns\": [ \"Ahmet Yasin Burak\", \"Ayman Hangül\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 185, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 21, 2, 50, 44, 0, DateTimeKind.Unspecified) },
                    { "01fd1956-c063-4907-93d0-a1eb760e06fc", "{ \"columns\": [ \"Kübra Tansu Bilgit\", \"Zeynep Doğa Gürses\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 166, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 17, 51, 8, 0, DateTimeKind.Unspecified) },
                    { "f8756186-3e0f-42f2-895e-9a24bcbd3f6d", "{ \"columns\": [ \"Aygün Bayram\", \"Ömer Okan Gülebakan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 147, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 13, 16, 12, 0, DateTimeKind.Unspecified) },
                    { "bc4b3e3d-5ce2-43f9-bb63-dd0258386bf7", "{ \"columns\": [ \"Burçin Kübra Baykal\", \"Gülten Güdücü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 143, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 12, 19, 44, 0, DateTimeKind.Unspecified) },
                    { "787ab936-5b35-4985-8857-8665e1b527b9", "{ \"columns\": [ \"Sevtap Atan\", \"Elif Kevser Eroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 84, false, null, null, null, "10.100.1.6", new DateTime(2020, 4, 20, 16, 27, 28, 0, DateTimeKind.Unspecified) },
                    { "1ee4be33-2385-4568-b801-c36672ee389c", "{ \"columns\": [ \"Bayar Çelik\", \"Asya Sema Karabağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 235, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 3, 54, 2, 0, DateTimeKind.Unspecified) },
                    { "edf86aca-0448-4937-ba3f-be07a9e103ae", "{ \"columns\": [ \"Buse Gizem Berker\", \"Eylem Gündüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 157, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 19, 18, 10, 0, DateTimeKind.Unspecified) },
                    { "13527ff1-9a52-481f-82f7-122885cf6905", "{ \"columns\": [ \"Sevginur Aşcı\", \"Selman Erkoşan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 81, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 21, 10, 44, 52, 0, DateTimeKind.Unspecified) },
                    { "8fd8d658-8ad1-44d8-9a58-5a547703ed13", "{ \"columns\": [ \"Mazlum Altan\", \"Sanber Durak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 48, false, null, null, null, "10.100.1.4", new DateTime(2020, 4, 20, 22, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "c08cf2b8-bec4-46d1-b321-cbf76e23ca96", "{ \"columns\": [ \"Servet Akçagunay\", \"Mert Görkem Dayıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 6, 22, 0, DateTimeKind.Unspecified) },
                    { "eb83e1bc-af8d-41f6-9230-9aacee3a94aa", "{ \"columns\": [ \"Doğangün Çağlar\", \"Dursun Korel İşgören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 216, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 14, 6, 11, 0, DateTimeKind.Unspecified) },
                    { "27749623-42a7-4e33-936b-5b88899b0748", "{ \"columns\": [ \"Çilem Akçay\", \"Ergün Değirmendereli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 13, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "3f4c6a77-22ee-494e-ad5c-ae403bc36d11", "{ \"columns\": [ \"Nehar Avşar\", \"Neslihan Buşra Esat\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 94, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 14, 25, 47, 0, DateTimeKind.Unspecified) },
                    { "28e139a4-5074-4d22-9e3b-d4c4be982ef7", "{ \"columns\": [ \"Halime Beydağ\", \"Melek Diler Günel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 158, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 7, 27, 34, 0, DateTimeKind.Unspecified) },
                    { "74c765d4-adc2-4380-84fd-281b20daaaf2", "{ \"columns\": [ \"Safa Ahmet Baydar\", \"Meltem Göymen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 141, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 37, 28, 0, DateTimeKind.Unspecified) },
                    { "22c915ae-e325-4173-8a09-129f21beaed1", "{ \"columns\": [ \"Fazıl Erem Batuk\", \"Şahabettin Görgüner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 138, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 22, 50, 59, 0, DateTimeKind.Unspecified) },
                    { "853c0be1-c916-4c3b-ab5f-02b7faf823cc", "{ \"columns\": [ \"Özgün Bahtıyar\", \"Zeynep Senahan Geçioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 116, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 13, 8, 53, 0, DateTimeKind.Unspecified) },
                    { "0f51943c-be33-41e8-ace7-42dfad894b1a", "{ \"columns\": [ \"Ali İsmail Babacan\", \"Eyüp Orhun Fındık\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 109, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 48, 48, 0, DateTimeKind.Unspecified) },
                    { "feec8bf0-5f9e-43c6-a5f3-2660b3fbe469", "{ \"columns\": [ \"Rana Altınoklu\", \"Öktem Duymuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 52, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 23, 8, 31, 0, DateTimeKind.Unspecified) },
                    { "e4a59dd1-acf8-4ae4-827a-8b62548abf8f", "{ \"columns\": [ \"Ecem Hatice Akova\", \"Dalay Derya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 32, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 21, 54, 30, 0, DateTimeKind.Unspecified) },
                    { "bce15038-889f-428a-b7fb-9297acdd077a", "{ \"columns\": [ \"Arkan Bozdemir\", \"Çisil Hazal Hafız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 176, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 20, 19, 31, 34, 0, DateTimeKind.Unspecified) },
                    { "4dd630f5-9015-4187-9757-86880333ebe1", "{ \"columns\": [ \"İclal Akkoyun\", \"Aysel Aysu Demirsatan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 1, 58, 53, 0, DateTimeKind.Unspecified) },
                    { "38cd2e51-ce58-4ea4-84dd-0b67a2c5ef06", "{ \"columns\": [ \"Özer Seçkin Ciddi\", \"Elif Nisan İmamoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 207, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 16, 36, 14, 0, DateTimeKind.Unspecified) },
                    { "0b17e5fd-9eba-4e55-8b02-bcb7d81614ab", "{ \"columns\": [ \"Remzi Bilgi\", \"Osman Cihan Gürdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 163, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 20, 20, 19, 59, 0, DateTimeKind.Unspecified) },
                    { "4fbae03f-4a0c-4c89-9779-3ef451b485b2", "{ \"columns\": [ \"Thomas Aygen\", \"Elzem Evrenos\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 102, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 3, 7, 17, 0, DateTimeKind.Unspecified) },
                    { "b18b7763-fbc5-48d1-b360-b83a9ab0c2f0", "{ \"columns\": [ \"Zeki Yiğithan Armutcu\", \"Bahar Cemre Erin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 2, 23, 47, 0, DateTimeKind.Unspecified) },
                    { "b3d4ce70-5c8e-4d1d-b183-204828e522f7", "{ \"columns\": [ \"Hulki Bent\", \"Köksal Gültaş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 154, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 8, 35, 26, 0, DateTimeKind.Unspecified) },
                    { "c4556243-4df0-418e-b54f-f7eeaf5552c7", "{ \"columns\": [ \"Derviş Haluk Baykan\", \"Işınbıke Gülcan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 144, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 19, 0, 58, 0, DateTimeKind.Unspecified) },
                    { "7d84c9a4-c0d9-40a7-9f79-0cc5162ee911", "{ \"columns\": [ \"Çisem Atok\", \"Onur Kerem Ertepınar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 89, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 18, 8, 13, 0, DateTimeKind.Unspecified) },
                    { "24d1af25-bba4-4456-aa9b-df7f70621f76", "{ \"columns\": [ \"Ece Pınar Çeliker\", \"Fatma Büşra Karabıyıklı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 237, false, null, null, null, "10.100.1.21", new DateTime(2020, 4, 21, 6, 26, 51, 0, DateTimeKind.Unspecified) },
                    { "4138e8da-54ef-4920-9b52-9bbf22095013", "{ \"columns\": [ \"Öget Arif\", \"Samed Erek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 73, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 14, 42, 43, 0, DateTimeKind.Unspecified) },
                    { "a678cc59-2fc0-437a-abdf-f30c91222be5", "{ \"columns\": [ \"Seher İrem Çitfçi\", \"Naci Karakaya\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 249, false, null, null, null, "10.100.1.22", new DateTime(2020, 4, 21, 4, 2, 32, 0, DateTimeKind.Unspecified) },
                    { "616716c2-a7ec-4fe9-89f0-7ee6a7720386", "{ \"columns\": [ \"Kayıhan Nedim Akarcalı\", \"Hüsne Aysun Dal\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 7, 40, 22, 0, DateTimeKind.Unspecified) },
                    { "ecaf0c85-deb1-4020-b383-f67de9b06945", "{ \"columns\": [ \"Murat Kaan Ayanoglu\", \"Belin Esendemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 96, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 22, 22, 54, 0, DateTimeKind.Unspecified) },
                    { "0ba1216d-817f-4bc6-9dc0-c92820e42586", "{ \"columns\": [ \"Kutlu Alibeyoğlu\", \"Doruk Deniz Döner\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, false, null, null, null, "10.100.1.26", new DateTime(2020, 4, 20, 15, 40, 2, 0, DateTimeKind.Unspecified) },
                    { "7dd25f07-bbe7-4f1d-b3f4-fbf6c28ad7ab", "{ \"columns\": [ \"Mehmet Buğrahan Birgili\", \"Birgen Güvener\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 168, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 16, 22, 55, 0, DateTimeKind.Unspecified) },
                    { "7758e1e9-4806-45b5-8156-a2ef0d9ab286", "{ \"columns\": [ \"Safa Batga\", \"Şueda Göreke\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 136, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 21, 5, 6, 53, 0, DateTimeKind.Unspecified) },
                    { "66c7069b-9f51-4bb4-9543-1102c5006736", "{ \"columns\": [ \"Merve Ece Altıok\", \"Barın Düşenkalkar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 55, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 20, 58, 35, 0, DateTimeKind.Unspecified) },
                    { "25b50715-637b-4513-b891-a63fcc1f978b", "{ \"columns\": [ \"Ercüment Akıncılar\", \"Miraç Demırören\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 21, 16, 0, DateTimeKind.Unspecified) },
                    { "9a95787d-14eb-4d4a-9aa5-3c6e85e4ab45", "{ \"columns\": [ \"Nuhaydar Akbilmez\", \"Ayşe Neslihan Daşdemir\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, false, null, null, null, "10.100.1.25", new DateTime(2020, 4, 20, 19, 6, 32, 0, DateTimeKind.Unspecified) },
                    { "cc5e6ab1-75cb-4deb-90e9-9cc69d1e2023", "{ \"columns\": [ \"Mügenur Ahmet\", \"Çağrı Atahan Dağar\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 9, 12, 7, 0, DateTimeKind.Unspecified) },
                    { "0dd0a156-aa12-46a3-9560-3fa8381fa6b3", "{ \"columns\": [ \"Şansal Coşan\", \"İbrahim Kağan İncekara\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 210, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 19, 51, 38, 0, DateTimeKind.Unspecified) },
                    { "c8707880-51b3-44e8-86ff-9c5f4f9b2172", "{ \"columns\": [ \"Gökmen Battal\", \"Ersin Görgülü\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 137, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 18, 7, 24, 0, DateTimeKind.Unspecified) },
                    { "0b6fc40a-7ae4-436d-b732-f7c9677bec73", "{ \"columns\": [ \"İzlem Arınç\", \"Aynur Gül Ercüment\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 72, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 7, 54, 1, 0, DateTimeKind.Unspecified) },
                    { "7d690e9f-9b5f-424f-a01b-66230007a5a7", "{ \"columns\": [ \"Erna Aluç\", \"Güngör Erkin Egeli\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 61, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 20, 15, 53, 4, 0, DateTimeKind.Unspecified) },
                    { "40041b3b-896a-4915-8254-c8bb1adf38a7", "{ \"columns\": [ \"Aksu Bozdağ\", \"Kıvılcım Hadi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 175, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 12, 4, 49, 0, DateTimeKind.Unspecified) },
                    { "37faf35a-bd09-41ba-a698-46b1fb818cf4", "{ \"columns\": [ \"Muhammet Raşit Balı\", \"Nergiz Gilim\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 122, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 17, 3, 38, 0, DateTimeKind.Unspecified) },
                    { "9b668bf7-c542-42e0-adfe-95724ed407f1", "{ \"columns\": [ \"Memet Bağcı\", \"Berhudan Garip\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 112, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 20, 18, 14, 59, 0, DateTimeKind.Unspecified) },
                    { "005bc9c0-1cc5-4175-ba2d-d21c4be40d38", "{ \"columns\": [ \"Fatma Özlem Acar\", \"Gürbüz Çivici\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, null, null, "10.100.1.23", new DateTime(2020, 4, 21, 8, 37, 49, 0, DateTimeKind.Unspecified) },
                    { "6c362027-f3a2-4090-b9fd-3208ea6d53ee", "{ \"columns\": [ \"İbrahim Hakkı Bugey\", \"Yeter Hamamcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180, false, null, null, null, "10.100.1.24", new DateTime(2020, 4, 21, 3, 42, 1, 0, DateTimeKind.Unspecified) },
                    { "d1664729-4b14-4230-aff4-faf7d95ac39e", "{ \"columns\": [ \"Uluç Emre Binbay\", \"Tarık Güven\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 167, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 15, 15, 26, 0, DateTimeKind.Unspecified) },
                    { "0f496e40-2a9f-42eb-9d14-3f8a480fd0d3", "{ \"columns\": [ \"Nesibe Nurefşan Alkan\", \"Çisil Zeynep Dönmez\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 20, 22, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "af57675c-e2f0-4771-9517-13523c8554c4", "{ \"columns\": [ \"Kerime Hacer Akıllı\", \"Muhammed Bazit Deliloğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 7, 7, 46, 0, DateTimeKind.Unspecified) },
                    { "47feb731-168c-4347-b092-73991920a3d1", "{ \"columns\": [ \"Hacı Mehmet Adıgüzel\", \"Hilal Ebru Çonay\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 10, 8, 37, 0, DateTimeKind.Unspecified) },
                    { "2154cdac-2d76-4b43-a8f8-00a75e098ce8", "{ \"columns\": [ \"Saliha Zeynep Bülent\", \"Furkan Hızarcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 190, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 7, 58, 41, 0, DateTimeKind.Unspecified) },
                    { "ec35c15e-94aa-44c9-b404-bfb462bb37e9", "{ \"columns\": [ \"Mahmut Bilal Bülend\", \"Turhan Onur Hırlak\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 189, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 8, 28, 45, 0, DateTimeKind.Unspecified) },
                    { "6198d826-736c-477c-965e-72b81b073f54", "{ \"columns\": [ \"Sakıp Balıoğlu\", \"Mehmet Gökalp Ginoviç\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 123, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 9, 42, 35, 0, DateTimeKind.Unspecified) },
                    { "f966b6a2-4361-4249-8456-1c4dd2c4dbb2", "{ \"columns\": [ \"İsmail Umut Anık\", \"Alphan Ekercan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 63, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 1, 18, 30, 0, DateTimeKind.Unspecified) },
                    { "146b7c38-8be8-466d-b394-53a6ec9311c8", "{ \"columns\": [ \"Senem Aksevim\", \"Rümeysa İrem Devecel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 21, 6, 21, 36, 0, DateTimeKind.Unspecified) },
                    { "ec42184b-cf6d-4a06-8079-6ca896531d28", "{ \"columns\": [ \"Berker Akkiray\", \"Sömer Demiroğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, false, null, null, null, "10.100.1.15", new DateTime(2020, 4, 20, 15, 59, 13, 0, DateTimeKind.Unspecified) },
                    { "f9aca97d-9dcd-463a-84f3-c51214f2bca0", "{ \"columns\": [ \"Cihan Akarpınar\", \"Ezgin Dallı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 23, 23, 27, 0, DateTimeKind.Unspecified) },
                    { "9acda455-a0ea-422b-b8f3-644781c34268", "{ \"columns\": [ \"Mustafa Kerem Cansu\", \"Ayşe Zeyneb Irıcıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 34, 2, 0, DateTimeKind.Unspecified) },
                    { "828d17c4-63ed-46fc-a798-b8c38f069296", "{ \"columns\": [ \"Sefa Kadir Başar\", \"Banuhan Gökçek\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 130, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 6, 15, 21, 0, DateTimeKind.Unspecified) },
                    { "29c2ea36-9981-4100-926b-2a6adf12238e", "{ \"columns\": [ \"Kazım Balta\", \"Mehmetali Girgin\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 124, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 13, 21, 17, 0, DateTimeKind.Unspecified) },
                    { "7716621e-1eb6-46de-9af7-49bbbb7c5195", "{ \"columns\": [ \"Kaan Muharrem Ay\", \"Lütfiye Sena Esen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 95, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 16, 42, 17, 0, DateTimeKind.Unspecified) },
                    { "7f6165b9-d6dc-4757-87ca-d98ca84ed955", "{ \"columns\": [ \"Tutkum Ahmadı Asl\", \"Olgun Dadalıoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 20, 17, 47, 12, 0, DateTimeKind.Unspecified) },
                    { "00f397ff-3cf8-4b57-8d56-003dfb9de30f", "{ \"columns\": [ \"Ahmet Gazi Çintan\", \"Büşra Hazal Karakaplan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 248, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 29, 21, 0, DateTimeKind.Unspecified) },
                    { "d8fe4914-20ed-478c-97f9-9eba54fe0802", "{ \"columns\": [ \"Mihrinaz Bilal\", \"Mehmet Yekta Güneyi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 160, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 10, 9, 50, 0, DateTimeKind.Unspecified) },
                    { "8304e70d-2257-4ef3-aa03-0ff30743bb06", "{ \"columns\": [ \"Güneş Aykan\", \"Ilgaz Eyipişiren\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 103, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 20, 21, 22, 51, 0, DateTimeKind.Unspecified) },
                    { "522f5445-16ab-431f-8634-159d4790d084", "{ \"columns\": [ \"Onur Taylan Boylu\", \"Mehmet Anıl Hacıalioğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 172, false, null, null, null, "10.100.1.14", new DateTime(2020, 4, 21, 3, 34, 43, 0, DateTimeKind.Unspecified) },
                    { "39812959-7fc4-4950-928e-5ed3ad054dc3", "{ \"columns\": [ \"Mustafa Burhan Askın\", \"Beniz Erkmen\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 79, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 3, 6, 59, 0, DateTimeKind.Unspecified) },
                    { "9abd638f-8c7f-4de3-80df-962adcec71be", "{ \"columns\": [ \"Berfin Dilay Bekaroğlu\", \"Merter Gülkan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 151, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 14, 53, 12, 0, DateTimeKind.Unspecified) },
                    { "e22ba746-37c1-4225-b09c-277c905ef0a0", "{ \"columns\": [ \"Armağan Bilgiç\", \"Okyanus Gürel\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 164, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 5, 27, 45, 0, DateTimeKind.Unspecified) },
                    { "e2992aa0-a3d9-44ce-b031-efb09499191a", "{ \"columns\": [ \"Sevinç Ak\", \"Özalp Dağbağ\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, false, null, null, null, "10.100.1.20", new DateTime(2020, 4, 21, 10, 36, 1, 0, DateTimeKind.Unspecified) },
                    { "a849e32f-3de6-4c9a-b1b5-c01e8836636c", "{ \"columns\": [ \"Özen Çakan\", \"Uzel Kabataş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 218, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 11, 53, 6, 0, DateTimeKind.Unspecified) },
                    { "7ed7c423-e5cf-4d7f-9959-733b3f6d56a6", "{ \"columns\": [ \"Mustafa Samed Beğenilmiş\", \"Emircan Güleryüz\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 20, 37, 0, DateTimeKind.Unspecified) },
                    { "09ee41d5-382c-47e7-9dfe-4c4657c4be7e", "{ \"columns\": [ \"Ecren Baldo\", \"Resmiye Elif Gırgın\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 121, false, null, null, null, "10.100.1.19", new DateTime(2020, 4, 20, 17, 32, 20, 0, DateTimeKind.Unspecified) },
                    { "53e0af48-8056-424a-9200-f67d672f2cb4", "{ \"columns\": [ \"Şüheda Çiçekli\", \"Ilgar Pamir Karaismail\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 246, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 1, 10, 50, 0, DateTimeKind.Unspecified) },
                    { "2bd10a7a-399f-4e27-94b7-ff8aa09f6531", "{ \"columns\": [ \"Aydın Mert Çelebican\", \"Çilay Kapsız\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 232, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 10, 8, 25, 0, DateTimeKind.Unspecified) },
                    { "ecdd7619-b074-467d-a005-392241a9352b", "{ \"columns\": [ \"Dilseren Çarıcı\", \"Şensoy Kalyoncu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 226, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 14, 32, 23, 0, DateTimeKind.Unspecified) },
                    { "6eb07a6b-0ad6-4b1f-9d70-f7248a78a10a", "{ \"columns\": [ \"Özgür Choi\", \"Halid İlhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 205, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 20, 16, 3, 4, 0, DateTimeKind.Unspecified) },
                    { "54901765-a9c4-4ffe-9353-9b2c09624851", "{ \"columns\": [ \"Abdulvahap Bayrakoğlu\", \"Fatma Sena Güldoğuş\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 146, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 8, 34, 23, 0, DateTimeKind.Unspecified) },
                    { "c37f5aef-7c59-4cda-ba06-3ddfb2b659a1", "{ \"columns\": [ \"Elif Etga Başeğmez\", \"Örgün Gökhan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 131, false, null, null, null, "10.100.1.18", new DateTime(2020, 4, 21, 2, 3, 20, 0, DateTimeKind.Unspecified) },
                    { "85ca6dd2-0033-4278-aea8-3d081e6f8a1f", "{ \"columns\": [ \"Aşkım Chiklyaukova\", \"Katya İlgezdi\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 204, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 4, 49, 51, 0, DateTimeKind.Unspecified) },
                    { "4058f611-7c3e-4c7d-a822-3df265d87688", "{ \"columns\": [ \"Balın Baştepe\", \"Melike Göksoy\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 132, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 42, 8, 0, DateTimeKind.Unspecified) },
                    { "eb8bc3bb-9dee-4406-a283-36a189847ca2", "{ \"columns\": [ \"Adem Ayvacık\", \"Okbay Fatih\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 107, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 23, 33, 16, 0, DateTimeKind.Unspecified) },
                    { "ac6f0591-9863-4f39-aaf1-6407d530d0fe", "{ \"columns\": [ \"Elif Feyza Ayrım\", \"Ongar Eyyupoğlu\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 104, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 20, 15, 3, 26, 0, DateTimeKind.Unspecified) },
                    { "84a2718d-d4c8-4021-9f05-715d71ae4150", "{ \"columns\": [ \"Selinti Al\", \"Zehra Pelin Döger\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, false, null, null, null, "10.100.1.17", new DateTime(2020, 4, 21, 9, 3, 34, 0, DateTimeKind.Unspecified) },
                    { "64260f06-a9b5-48cd-99ff-08a0877c950b", "{ \"columns\": [ \"Elif Beyza Çark\", \"Necatı Kamışlı\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 227, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 20, 11, 44, 37, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "405f2346-0dbb-4dea-b2f8-21d9e3330c9e", "{ \"columns\": [ \"Mehmet Enes Canan\", \"Ahmet Hakkı Hirik\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 195, false, null, null, null, "10.100.1.16", new DateTime(2020, 4, 21, 9, 8, 41, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "6bcc5df9-5734-4ebc-89f0-f7b71db88b49", "{ \"columns\": [ \"Recep Ali Samet Akdoğan\", \"Hülya Delı Chasan\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, false, null, null, null, "10.100.1.13", new DateTime(2020, 4, 21, 1, 28, 20, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "GroupId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "RecipientId", "SenderId", "SentTime" },
                values: new object[] { "3246d833-a440-4aa5-9794-b1e0def0f92e", "{ \"columns\": [ \"Mustafa Taha Canbek\", \"Toykan Horata\" ] }", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 197, false, null, null, null, "10.100.1.41", new DateTime(2020, 4, 20, 14, 38, 48, 0, DateTimeKind.Unspecified) });

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
