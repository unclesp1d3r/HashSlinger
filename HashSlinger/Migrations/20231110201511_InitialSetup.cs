﻿using System;
using System.Collections.Generic;
using System.Net;
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
                name: "CrackerBinaryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsChunkingAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    TypeName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrackerBinaryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDeletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDeletes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    HashcatId = table.Column<int>(type: "integer", nullable: false),
                    IsSalted = table.Column<bool>(type: "boolean", nullable: false),
                    IsSlowHash = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Issuer = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
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
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    RegisteredSince = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    FileGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    IsSecret = table.Column<bool>(type: "boolean", nullable: false),
                    LineCount = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: true),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Voucher = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationVouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationVouchers_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreconfiguredTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttackCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ChunkTime = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsCpuTask = table.Column<bool>(type: "boolean", nullable: false),
                    IsMaskImport = table.Column<bool>(type: "boolean", nullable: false),
                    IsSmall = table.Column<bool>(type: "boolean", nullable: false),
                    MaxAgents = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    StatusTimer = table.Column<int>(type: "integer", nullable: false),
                    UseNewBench = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreconfiguredTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreconfiguredTask_CrackerBinaryTypes_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hashlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HashTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    BrainFeatures = table.Column<short>(type: "smallint", nullable: false),
                    BrainId = table.Column<int>(type: "integer", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    HashCount = table.Column<int>(type: "integer", nullable: false),
                    HexSalt = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsSalted = table.Column<bool>(type: "boolean", nullable: false),
                    IsSecret = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    SaltSeparator = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hashlists_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hashlists_HashTypes_HashTypeId",
                        column: x => x.HashTypeId,
                        principalTable: "HashTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupUser",
                columns: table => new
                {
                    AccessGroupsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupUser", x => new { x.AccessGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_AccessGroups_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientSignature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CommandParameters = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CpuOnly = table.Column<bool>(type: "boolean", nullable: false),
                    Devices = table.Column<List<string>>(type: "text[]", nullable: true),
                    IgnoreErrors = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsTrusted = table.Column<bool>(type: "boolean", nullable: false),
                    LastAction = table.Column<int>(type: "integer", nullable: false),
                    LastSeenIpAddress = table.Column<IPAddress>(type: "inet", nullable: true),
                    LastSeenTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OperatingSystem = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Uid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ApiKey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessCount = table.Column<int>(type: "integer", nullable: false),
                    AccessKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ApiGroupId = table.Column<int>(type: "integer", nullable: false),
                    EndValid = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartValid = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Notification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ObjectId = table.Column<int>(type: "integer", nullable: true),
                    Receiver = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSetting_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    LastActionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessionKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    SessionLifetime = table.Column<int>(type: "integer", nullable: false),
                    SessionStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadableBinaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: true),
                    DownloadUrl = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Executable = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    OperatingSystems = table.Column<List<string>>(type: "text[]", nullable: false),
                    Version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UpdateAvailable = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UpdateTrack = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: true),
                    KeyspaceCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LimitCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    SkipCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadableBinaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadableBinaries_CrackerBinaryTypes_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DownloadableBinaries_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileDownload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDownload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDownload_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilePreconfiguredTask",
                columns: table => new
                {
                    FilesId = table.Column<int>(type: "integer", nullable: false),
                    PreconfiguredTasksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePreconfiguredTask", x => new { x.FilesId, x.PreconfiguredTasksId });
                    table.ForeignKey(
                        name: "FK_FilePreconfiguredTask_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilePreconfiguredTask_PreconfiguredTask_PreconfiguredTasksId",
                        column: x => x.PreconfiguredTasksId,
                        principalTable: "PreconfiguredTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupertaskPretask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreconfiguredTaskId = table.Column<int>(type: "integer", nullable: false),
                    PretaskId = table.Column<int>(type: "integer", nullable: false),
                    SupertaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupertaskPretask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupertaskPretask_PreconfiguredTask_PreconfiguredTaskId",
                        column: x => x.PreconfiguredTaskId,
                        principalTable: "PreconfiguredTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupertaskPretask_Supertask_SupertaskId",
                        column: x => x.SupertaskId,
                        principalTable: "Supertask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskWrapper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: true),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    TaskType = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
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
                        name: "FK_TaskWrapper_Hashlists_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupAgent",
                columns: table => new
                {
                    AccessGroupsId = table.Column<int>(type: "integer", nullable: false),
                    AgentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupAgent", x => new { x.AccessGroupsId, x.AgentsId });
                    table.ForeignKey(
                        name: "FK_AccessGroupAgent_AccessGroups_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupAgent_Agents_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    SolveTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zap_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zap_Hashlists_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrackerBinaryId = table.Column<int>(type: "integer", nullable: false),
                    HashTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttackCmd = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CheckType = table.Column<int>(type: "integer", nullable: false),
                    ExpectedCracks = table.Column<int>(type: "integer", nullable: false),
                    HashListAlias = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TestHashes = table.Column<List<string>>(type: "text[]", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthChecks_DownloadableBinaries_CrackerBinaryId",
                        column: x => x.CrackerBinaryId,
                        principalTable: "DownloadableBinaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthChecks_HashTypes_HashTypeId",
                        column: x => x.HashTypeId,
                        principalTable: "HashTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrackerBinaryId = table.Column<int>(type: "integer", nullable: true),
                    CrackerBinaryTypeId = table.Column<int>(type: "integer", nullable: true),
                    PreprocessorId = table.Column<int>(type: "integer", nullable: true),
                    AttackCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ChunkSize = table.Column<int>(type: "integer", nullable: false),
                    ChunkTime = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EnforcePipe = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsCpuTask = table.Column<bool>(type: "boolean", nullable: false),
                    IsSmall = table.Column<bool>(type: "boolean", nullable: false),
                    Keyspace = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    KeyspaceProgress = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    MaxAgents = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    PreprocessorCommand = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    SkipKeyspace = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    StaticChunks = table.Column<int>(type: "integer", nullable: false),
                    StatusTimer = table.Column<int>(type: "integer", nullable: false),
                    TaskWrapperId = table.Column<int>(type: "integer", nullable: false),
                    UseNewBenchmark = table.Column<bool>(type: "boolean", nullable: false),
                    UsePreprocessor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_CrackerBinaryTypes_CrackerBinaryTypeId",
                        column: x => x.CrackerBinaryTypeId,
                        principalTable: "CrackerBinaryTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_DownloadableBinaries_CrackerBinaryId",
                        column: x => x.CrackerBinaryId,
                        principalTable: "DownloadableBinaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tasks_DownloadableBinaries_PreprocessorId",
                        column: x => x.PreprocessorId,
                        principalTable: "DownloadableBinaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskWrapper_TaskWrapperId",
                        column: x => x.TaskWrapperId,
                        principalTable: "TaskWrapper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    HealthCheckId = table.Column<int>(type: "integer", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: true),
                    End = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    Errors = table.Column<List<string>>(type: "text[]", nullable: false),
                    NumGpus = table.Column<int>(type: "integer", nullable: true),
                    Start = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckAgents_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthCheckAgents_HealthChecks_HealthCheckId",
                        column: x => x.HealthCheckId,
                        principalTable: "HealthChecks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    Benchmark = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chunks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: true),
                    Checkpoint = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Cracked = table.Column<int>(type: "integer", nullable: false),
                    DispatchTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Length = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Progress = table.Column<float>(type: "real", nullable: true),
                    Skip = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    SolveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Speed = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chunks_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chunks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileTask",
                columns: table => new
                {
                    FilesId = table.Column<int>(type: "integer", nullable: false),
                    TasksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTask", x => new { x.FilesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_FileTask_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    SpeedValue = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Speed_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskDebugOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Output = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDebugOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDebugOutput_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
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
                    ChunkId = table.Column<int>(type: "integer", nullable: true),
                    Error = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                        name: "FK_AgentError_Chunks_ChunkId",
                        column: x => x.ChunkId,
                        principalTable: "Chunks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentError_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HashBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChunkId = table.Column<int>(type: "integer", nullable: true),
                    CrackPos = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    HashlistId = table.Column<int>(type: "integer", nullable: false),
                    IsCracked = table.Column<bool>(type: "boolean", nullable: false),
                    Plaintext = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TimeCracked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Essid = table.Column<string>(type: "text", nullable: true),
                    HashBytes = table.Column<byte[]>(type: "bytea", nullable: true),
                    HashValue = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashBase_Chunks_ChunkId",
                        column: x => x.ChunkId,
                        principalTable: "Chunks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HashBase_Hashlists_HashlistId",
                        column: x => x.HashlistId,
                        principalTable: "Hashlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CrackerBinaryTypes",
                columns: new[] { "Id", "IsChunkingAvailable", "TypeName" },
                values: new object[] { 1, true, "hashcat" });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAgent_AgentsId",
                table: "AccessGroupAgent",
                column: "AgentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupUser_UsersId",
                table: "AccessGroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentError_AgentId",
                table: "AgentError",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentError_ChunkId",
                table: "AgentError",
                column: "ChunkId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentError_TaskId",
                table: "AgentError",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Token",
                table: "Agents",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Uid",
                table: "Agents",
                column: "Uid");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentStat_AgentId",
                table: "AgentStat",
                column: "AgentId");

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
                name: "IX_Chunks_AgentId",
                table: "Chunks",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Chunks_TaskId",
                table: "Chunks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableBinaries_CrackerBinaryTypeId",
                table: "DownloadableBinaries",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableBinaries_FileId",
                table: "DownloadableBinaries",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableBinaries_Type",
                table: "DownloadableBinaries",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_FileDownload_FileId",
                table: "FileDownload",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePreconfiguredTask_PreconfiguredTasksId",
                table: "FilePreconfiguredTask",
                column: "PreconfiguredTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AccessGroupId",
                table: "Files",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileGuid",
                table: "Files",
                column: "FileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileName",
                table: "Files",
                column: "FileName");

            migrationBuilder.CreateIndex(
                name: "IX_FileTask_TasksId",
                table: "FileTask",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_HashBase_ChunkId",
                table: "HashBase",
                column: "ChunkId");

            migrationBuilder.CreateIndex(
                name: "IX_HashBase_HashlistId",
                table: "HashBase",
                column: "HashlistId");

            migrationBuilder.CreateIndex(
                name: "IX_HashBase_IsCracked",
                table: "HashBase",
                column: "IsCracked");

            migrationBuilder.CreateIndex(
                name: "IX_Hashlists_AccessGroupId",
                table: "Hashlists",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Hashlists_HashTypeId",
                table: "Hashlists",
                column: "HashTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hashlists_IsSecret",
                table: "Hashlists",
                column: "IsSecret");

            migrationBuilder.CreateIndex(
                name: "IX_HashTypes_HashcatId",
                table: "HashTypes",
                column: "HashcatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckAgents_AgentId",
                table: "HealthCheckAgents",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckAgents_HealthCheckId",
                table: "HealthCheckAgents",
                column: "HealthCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthChecks_CrackerBinaryId",
                table: "HealthChecks",
                column: "CrackerBinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthChecks_HashTypeId",
                table: "HealthChecks",
                column: "HashTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSetting_UserId",
                table: "NotificationSetting",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreconfiguredTask_CrackerBinaryTypeId",
                table: "PreconfiguredTask",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationVouchers_AccessGroupId",
                table: "RegistrationVouchers",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationVouchers_Voucher",
                table: "RegistrationVouchers",
                column: "Voucher",
                unique: true);

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
                name: "IX_SupertaskPretask_PreconfiguredTaskId",
                table: "SupertaskPretask",
                column: "PreconfiguredTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SupertaskPretask_SupertaskId",
                table: "SupertaskPretask",
                column: "SupertaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDebugOutput_TaskId",
                table: "TaskDebugOutput",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CrackerBinaryId",
                table: "Tasks",
                column: "CrackerBinaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CrackerBinaryTypeId",
                table: "Tasks",
                column: "CrackerBinaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PreprocessorId",
                table: "Tasks",
                column: "PreprocessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskWrapperId",
                table: "Tasks",
                column: "TaskWrapperId");

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
                name: "ApiKey");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "FileDeletes");

            migrationBuilder.DropTable(
                name: "FileDownload");

            migrationBuilder.DropTable(
                name: "FilePreconfiguredTask");

            migrationBuilder.DropTable(
                name: "FileTask");

            migrationBuilder.DropTable(
                name: "HashBase");

            migrationBuilder.DropTable(
                name: "HealthCheckAgents");

            migrationBuilder.DropTable(
                name: "LogEntries");

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
                name: "Chunks");

            migrationBuilder.DropTable(
                name: "HealthChecks");

            migrationBuilder.DropTable(
                name: "PreconfiguredTask");

            migrationBuilder.DropTable(
                name: "Supertask");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DownloadableBinaries");

            migrationBuilder.DropTable(
                name: "TaskWrapper");

            migrationBuilder.DropTable(
                name: "CrackerBinaryTypes");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Hashlists");

            migrationBuilder.DropTable(
                name: "AccessGroups");

            migrationBuilder.DropTable(
                name: "HashTypes");
        }
    }
}
