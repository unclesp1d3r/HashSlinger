using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Permissions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrackerBinaryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsChunkingAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrackerBinaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsSalted = table.Column<bool>(type: "boolean", nullable: false),
                    IsSlowHash = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Voucher = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supertask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supertask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegisteredSince = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    IsSecret = table.Column<bool>(type: "boolean", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    LineCount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrackerBinary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DownloadUrl = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    BinaryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrackerBinary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrackerBinary_CrackerBinaryType_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pretask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AttackCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ChunkTime = table.Column<int>(type: "integer", nullable: false),
                    StatusTimer = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsSmall = table.Column<bool>(type: "boolean", nullable: false),
                    IsCpuTask = table.Column<bool>(type: "boolean", nullable: false),
                    UseNewBench = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    MaxAgents = table.Column<int>(type: "integer", nullable: false),
                    IsMaskImport = table.Column<bool>(type: "boolean", nullable: false),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pretask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pretask_CrackerBinaryType_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hashlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    HashTypeId = table.Column<int>(type: "integer", nullable: false),
                    HashCount = table.Column<int>(type: "integer", nullable: false),
                    SaltSeparator = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    IsSecret = table.Column<bool>(type: "boolean", nullable: false),
                    HexSalt = table.Column<bool>(type: "boolean", nullable: false),
                    IsSalted = table.Column<bool>(type: "boolean", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    BrainId = table.Column<int>(type: "integer", nullable: false),
                    BrainFeatures = table.Column<short>(type: "smallint", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hashlist_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hashlist_HashType_HashTypeId",
                        column: x => x.HashTypeId,
                        principalTable: "HashType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OperatingSystem = table.Column<int>(type: "integer", nullable: false),
                    Devices = table.Column<string>(type: "text", nullable: false),
                    CommandParameters = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IgnoreErrors = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsTrusted = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastAction = table.Column<int>(type: "integer", nullable: false),
                    LastTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CpuOnly = table.Column<bool>(type: "boolean", nullable: false),
                    ClientSignature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApiKey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartValid = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndValid = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccessKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    AccessCount = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ApiGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiKey_ApiGroup_ApiGroupId",
                        column: x => x.ApiGroupId,
                        principalTable: "ApiGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApiKey_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ObjectId = table.Column<int>(type: "integer", nullable: true),
                    Notification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Receiver = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSetting_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SessionStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    SessionLifetime = table.Column<int>(type: "integer", nullable: false),
                    SessionKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileDownload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDownload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDownload_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CheckType = table.Column<int>(type: "integer", nullable: false),
                    HashtypeId = table.Column<int>(type: "integer", nullable: false),
                    CrackerBinaryId = table.Column<int>(type: "integer", nullable: false),
                    ExpectedCracks = table.Column<int>(type: "integer", nullable: false),
                    AttackCmd = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheck_CrackerBinary_CrackerBinaryId",
                        column: x => x.CrackerBinaryId,
                        principalTable: "CrackerBinary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilePretask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    PretaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePretask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilePretask_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilePretask_Pretask_PretaskId",
                        column: x => x.PretaskId,
                        principalTable: "Pretask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupertaskPretask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupertaskId = table.Column<int>(type: "integer", nullable: false),
                    PretaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupertaskPretask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupertaskPretask_Pretask_PretaskId",
                        column: x => x.PretaskId,
                        principalTable: "Pretask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupertaskPretask_Supertask_SupertaskId",
                        column: x => x.SupertaskId,
                        principalTable: "Supertask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HashlistHashlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentHashlistId = table.Column<int>(type: "integer", nullable: false),
                    HashlistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashlistHashlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashlistHashlist_Hashlist_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HashlistHashlist_Hashlist_ParentHashlistId",
                        column: x => x.ParentHashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskWrapper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    TaskType = table.Column<int>(type: "integer", nullable: false),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskWrapper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskWrapper_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskWrapper_Hashlist_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupAgent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupAgent_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessGroupAgent_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgentStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    StatType = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentStat_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    SolveTime = table.Column<long>(type: "bigint", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: true),
                    HashlistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zap_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zap_Hashlist_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckAgent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HealthCheckId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    NumGpus = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Errors = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckAgent_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HealthCheckAgent_HealthCheck_HealthCheckId",
                        column: x => x.HealthCheckId,
                        principalTable: "HealthCheck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    AttackCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ChunkTime = table.Column<int>(type: "integer", nullable: false),
                    StatusTimer = table.Column<int>(type: "integer", nullable: false),
                    Keyspace = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    KeyspaceProgress = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    MaxAgents = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsSmall = table.Column<bool>(type: "boolean", nullable: false),
                    IsCpuTask = table.Column<bool>(type: "boolean", nullable: false),
                    UseNewBenchmark = table.Column<bool>(type: "boolean", nullable: false),
                    SkipKeyspace = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    CrackerBinaryId = table.Column<int>(type: "integer", nullable: true),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: true),
                    TaskWrapperId = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    StaticChunks = table.Column<int>(type: "integer", nullable: false),
                    ChunkSize = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ForcePipe = table.Column<bool>(type: "boolean", nullable: false),
                    UsePreprocessor = table.Column<bool>(type: "boolean", nullable: false),
                    PreprocessorCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_CrackerBinaryType_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Task_CrackerBinary_CrackerBinaryId",
                        column: x => x.CrackerBinaryId,
                        principalTable: "CrackerBinary",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Task_TaskWrapper_TaskWrapperId",
                        column: x => x.TaskWrapperId,
                        principalTable: "TaskWrapper",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgentZap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    LastZapId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentZap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentZap_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentZap_Zap_LastZapId",
                        column: x => x.LastZapId,
                        principalTable: "Zap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgentError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Error = table.Column<string>(type: "text", nullable: false),
                    ChunkId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentError_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentError_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    Benchmark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignment_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chunk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    Skip = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Length = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: true),
                    DispatchTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SolveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Checkpoint = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Progress = table.Column<int>(type: "integer", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    Speed = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chunk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chunk_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chunk_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileTask_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileTask_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Speed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    SpeedValue = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speed_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Speed_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskDebugOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    Output = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDebugOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDebugOutput_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    HashValue = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Plaintext = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TimeCracked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChunkId = table.Column<int>(type: "integer", nullable: true),
                    IsCracked = table.Column<bool>(type: "boolean", nullable: false),
                    CrackPos = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hash_Chunk_ChunkId",
                        column: x => x.ChunkId,
                        principalTable: "Chunk",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hash_Hashlist_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HashBinary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    Essid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    Plaintext = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    TimeCracked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ChunkId = table.Column<int>(type: "integer", nullable: true),
                    IsCracked = table.Column<bool>(type: "boolean", nullable: false),
                    CrackPos = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashBinary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashBinary_Chunk_ChunkId",
                        column: x => x.ChunkId,
                        principalTable: "Chunk",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HashBinary_Hashlist_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlist",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "RegistrationVouchers",
                columns: new[] { "Id", "Expiration", "Voucher" },
                values: new object[] { 1, new DateTime(2024, 5, 31, 20, 20, 26, 373, DateTimeKind.Utc).AddTicks(5183), "test123456" });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAgent_AccessGroupId",
                table: "AccessGroupAgent",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAgent_AgentId",
                table: "AccessGroupAgent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupUser_AccessGroupId",
                table: "AccessGroupUser",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupUser_UserId",
                table: "AccessGroupUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentError_AgentId",
                table: "AgentError",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentError_TaskId",
                table: "AgentError",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentStat_AgentId",
                table: "AgentStat",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentZap_AgentId",
                table: "AgentZap",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentZap_LastZapId",
                table: "AgentZap",
                column: "LastZapId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKey_ApiGroupId",
                table: "ApiKey",
                column: "ApiGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKey_UserId",
                table: "ApiKey",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AgentId",
                table: "Assignment",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TaskId",
                table: "Assignment",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Chunk_AgentId",
                table: "Chunk",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chunk_TaskId",
                table: "Chunk",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CrackerBinary_CrackerBinaryTypeId",
                table: "CrackerBinary",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File_AccessGroupId",
                table: "File",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDownload_FileId",
                table: "FileDownload",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePretask_FileId",
                table: "FilePretask",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePretask_PretaskId",
                table: "FilePretask",
                column: "PretaskId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTask_FileId",
                table: "FileTask",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTask_TaskId",
                table: "FileTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Hash_ChunkId",
                table: "Hash",
                column: "ChunkId");

            migrationBuilder.CreateIndex(
                name: "IX_Hash_HashlistId",
                table: "Hash",
                column: "HashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_HashBinary_ChunkId",
                table: "HashBinary",
                column: "ChunkId");

            migrationBuilder.CreateIndex(
                name: "IX_HashBinary_HashlistId",
                table: "HashBinary",
                column: "HashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hashlist_AccessGroupId",
                table: "Hashlist",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Hashlist_HashTypeId",
                table: "Hashlist",
                column: "HashTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HashlistHashlist_HashlistId",
                table: "HashlistHashlist",
                column: "HashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_HashlistHashlist_ParentHashlistId",
                table: "HashlistHashlist",
                column: "ParentHashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheck_CrackerBinaryId",
                table: "HealthCheck",
                column: "CrackerBinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckAgent_AgentId",
                table: "HealthCheckAgent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckAgent_HealthCheckId",
                table: "HealthCheckAgent",
                column: "HealthCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSetting_UserId",
                table: "NotificationSetting",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pretask_CrackerBinaryTypeId",
                table: "Pretask",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_UserId",
                table: "Session",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Speed_AgentId",
                table: "Speed",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Speed_TaskId",
                table: "Speed",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SupertaskPretask_PretaskId",
                table: "SupertaskPretask",
                column: "PretaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SupertaskPretask_SupertaskId",
                table: "SupertaskPretask",
                column: "SupertaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CrackerBinaryId",
                table: "Task",
                column: "CrackerBinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CrackerBinaryTypeId",
                table: "Task",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskWrapperId",
                table: "Task",
                column: "TaskWrapperId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDebugOutput_TaskId",
                table: "TaskDebugOutput",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskWrapper_AccessGroupId",
                table: "TaskWrapper",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskWrapper_HashlistId",
                table: "TaskWrapper",
                column: "HashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Zap_AgentId",
                table: "Zap",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zap_HashlistId",
                table: "Zap",
                column: "HashlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessGroupAgent");

            migrationBuilder.DropTable(
                name: "AccessGroupUser");

            migrationBuilder.DropTable(
                name: "AgentError");

            migrationBuilder.DropTable(
                name: "AgentStat");

            migrationBuilder.DropTable(
                name: "AgentZap");

            migrationBuilder.DropTable(
                name: "ApiKey");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "FileDownload");

            migrationBuilder.DropTable(
                name: "FilePretask");

            migrationBuilder.DropTable(
                name: "FileTask");

            migrationBuilder.DropTable(
                name: "Hash");

            migrationBuilder.DropTable(
                name: "HashBinary");

            migrationBuilder.DropTable(
                name: "HashlistHashlist");

            migrationBuilder.DropTable(
                name: "HealthCheckAgent");

            migrationBuilder.DropTable(
                name: "NotificationSetting");

            migrationBuilder.DropTable(
                name: "RegistrationVouchers");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Speed");

            migrationBuilder.DropTable(
                name: "SupertaskPretask");

            migrationBuilder.DropTable(
                name: "TaskDebugOutput");

            migrationBuilder.DropTable(
                name: "Zap");

            migrationBuilder.DropTable(
                name: "ApiGroup");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Chunk");

            migrationBuilder.DropTable(
                name: "HealthCheck");

            migrationBuilder.DropTable(
                name: "Pretask");

            migrationBuilder.DropTable(
                name: "Supertask");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CrackerBinary");

            migrationBuilder.DropTable(
                name: "TaskWrapper");

            migrationBuilder.DropTable(
                name: "CrackerBinaryType");

            migrationBuilder.DropTable(
                name: "Hashlist");

            migrationBuilder.DropTable(
                name: "AccessGroups");

            migrationBuilder.DropTable(
                name: "HashType");
        }
    }
}
