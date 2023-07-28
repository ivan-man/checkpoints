using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    global_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    access_time_from = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    access_time_to = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    days_of_week = table.Column<int>(type: "integer", nullable: false),
                    holidays_access = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "access_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    global_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_multiple_stage = table.Column<bool>(type: "boolean", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    normalized_name = table.Column<string>(type: "text", nullable: false),
                    iso2 = table.Column<string>(type: "text", nullable: false),
                    iso3 = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customizable_property",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    interface_id = table.Column<string>(type: "text", nullable: false),
                    type_name = table.Column<string>(type: "text", nullable: false),
                    type_full_name = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customizable_property", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    sn = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    pass_type = table.Column<int>(type: "integer", nullable: false),
                    cause = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_devices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    contract_description = table.Column<string>(type: "text", nullable: true),
                    external_id = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    inn = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    kpp = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okpo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okato = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    imns = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    imns_name = table.Column<string>(type: "text", nullable: true),
                    okopf = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okved = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    oktmo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    disband_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pass_request_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    max_period = table.Column<TimeSpan>(type: "interval", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pass_request_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "access_level_access_point",
                columns: table => new
                {
                    access_levels_id = table.Column<int>(type: "integer", nullable: false),
                    access_points_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_level_access_point", x => new { x.access_levels_id, x.access_points_id });
                    table.ForeignKey(
                        name: "fk_access_level_access_point_access_levels_access_levels_id",
                        column: x => x.access_levels_id,
                        principalTable: "access_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_access_level_access_point_access_points_access_points_id",
                        column: x => x.access_points_id,
                        principalTable: "access_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approve_chain_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_chain_template", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_chain_template_pass_request_type_type_id",
                        column: x => x.type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order = table.Column<int>(type: "integer", nullable: false),
                    stage_type_id = table.Column<int>(type: "integer", nullable: false),
                    approve_chain_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage_template", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_stage_template_approve_chain_template_approve_chain_t",
                        column: x => x.approve_chain_id,
                        principalTable: "approve_chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_stage_template_approve_stage_type_stage_type_id",
                        column: x => x.stage_type_id,
                        principalTable: "approve_stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approve_chain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    approve_state = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    pass_request_id = table.Column<int>(type: "integer", nullable: false),
                    current_stage_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_chain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chain_id = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    pass_request_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    approver_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_stage_approve_chain_approve_chain_id",
                        column: x => x.chain_id,
                        principalTable: "approve_chain",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage_approve_stage",
                columns: table => new
                {
                    next_stages_id = table.Column<int>(type: "integer", nullable: false),
                    prev_stages_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage_approve_stage", x => new { x.next_stages_id, x.prev_stages_id });
                    table.ForeignKey(
                        name: "fk_approve_stage_approve_stage_approve_stage_next_stages_id",
                        column: x => x.next_stages_id,
                        principalTable: "approve_stage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_stage_approve_stage_approve_stage_prev_stages_id",
                        column: x => x.prev_stages_id,
                        principalTable: "approve_stage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "device_pass_request",
                columns: table => new
                {
                    devices_id = table.Column<int>(type: "integer", nullable: false),
                    pass_requests_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_pass_request", x => new { x.devices_id, x.pass_requests_id });
                    table.ForeignKey(
                        name: "fk_device_pass_request_devices_devices_id",
                        column: x => x.devices_id,
                        principalTable: "devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pass_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    request_type_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expired_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    visit_purpose = table.Column<string>(type: "text", nullable: true),
                    additional = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pass_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_pass_requests_pass_request_type_request_type_id",
                        column: x => x.request_type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    approve_stage_id = table.Column<int>(type: "integer", nullable: true),
                    pass_request_id = table.Column<int>(type: "integer", nullable: true),
                    subdivision_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.id);
                    table.ForeignKey(
                        name: "fk_persons_approve_stage_approve_stage_id",
                        column: x => x.approve_stage_id,
                        principalTable: "approve_stage",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_persons_pass_requests_pass_request_id",
                        column: x => x.pass_request_id,
                        principalTable: "pass_requests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subdivision",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    external_id = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    kpp = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okpo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okato = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    manager_id = table.Column<int>(type: "integer", nullable: false),
                    disband_date = table.Column<DateOnly>(type: "date", nullable: true),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    parent_subdivision_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subdivision", x => x.id);
                    table.ForeignKey(
                        name: "fk_subdivision_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subdivision_persons_manager_id",
                        column: x => x.manager_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subdivision_subdivision_parent_subdivision_id",
                        column: x => x.parent_subdivision_id,
                        principalTable: "subdivision",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    roles_value = table.Column<int>(type: "integer", nullable: true),
                    access_level_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_access_levels_access_level_id",
                        column: x => x.access_level_id,
                        principalTable: "access_levels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_persons_employee_id",
                        column: x => x.employee_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    position_title = table.Column<string>(type: "text", nullable: false),
                    subdivision_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_position", x => x.id);
                    table.ForeignKey(
                        name: "fk_position_subdivision_subdivision_id",
                        column: x => x.subdivision_id,
                        principalTable: "subdivision",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "property_metadata",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    request_type_id = table.Column<int>(type: "integer", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false),
                    column_default_visibility = table.Column<bool>(type: "boolean", nullable: false),
                    property_id = table.Column<int>(type: "integer", nullable: false),
                    property_id1 = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_property_metadata", x => x.id);
                    table.ForeignKey(
                        name: "fk_property_metadata_customizable_property_property_id1",
                        column: x => x.property_id1,
                        principalTable: "customizable_property",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_property_metadata_pass_request_type_request_type_id",
                        column: x => x.request_type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_property_metadata_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    first_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    last_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    disabled_date = table.Column<DateOnly>(type: "date", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: true),
                    is_employee = table.Column<bool>(type: "boolean", nullable: false),
                    external_id = table.Column<Guid>(type: "uuid", nullable: true),
                    external_individual = table.Column<Guid>(type: "uuid", nullable: true),
                    tab_n = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    inn = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    employment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    dismissal_date = table.Column<DateOnly>(type: "date", nullable: true),
                    position_code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okpdtr = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    okpdtr_title = table.Column<string>(type: "text", nullable: true),
                    position_id = table.Column<int>(type: "integer", nullable: true),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profile", x => x.id);
                    table.ForeignKey(
                        name: "fk_profile_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_profile_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_profile_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_profile_position_position_id",
                        column: x => x.position_id,
                        principalTable: "position",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_access_level_access_point_access_points_id",
                table: "access_level_access_point",
                column: "access_points_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_chain_current_stage_id",
                table: "approve_chain",
                column: "current_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_chain_pass_request_id",
                table: "approve_chain",
                column: "pass_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_chain_template_type_id",
                table: "approve_chain_template",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_approver_id",
                table: "approve_stage",
                column: "approver_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_chain_id",
                table: "approve_stage",
                column: "chain_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_pass_request_id",
                table: "approve_stage",
                column: "pass_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_approve_stage_prev_stages_id",
                table: "approve_stage_approve_stage",
                column: "prev_stages_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_template_approve_chain_id",
                table: "approve_stage_template",
                column: "approve_chain_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_template_stage_type_id",
                table: "approve_stage_template",
                column: "stage_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_pass_request_pass_requests_id",
                table: "device_pass_request",
                column: "pass_requests_id");

            migrationBuilder.CreateIndex(
                name: "ix_pass_requests_author_id",
                table: "pass_requests",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_pass_requests_request_type_id",
                table: "pass_requests",
                column: "request_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_persons_approve_stage_id",
                table: "persons",
                column: "approve_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_persons_pass_request_id",
                table: "persons",
                column: "pass_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_persons_subdivision_id",
                table: "persons",
                column: "subdivision_id");

            migrationBuilder.CreateIndex(
                name: "ix_position_subdivision_id",
                table: "position",
                column: "subdivision_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_country_id",
                table: "profile",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_organization_id",
                table: "profile",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_person_id",
                table: "profile",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_phone_first_name_last_name_date_of_birth_organizati",
                table: "profile",
                columns: new[] { "phone", "first_name", "last_name", "date_of_birth", "organization_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_profile_position_id",
                table: "profile",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_property_metadata_property_id1",
                table: "property_metadata",
                column: "property_id1");

            migrationBuilder.CreateIndex(
                name: "ix_property_metadata_request_type_id",
                table: "property_metadata",
                column: "request_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_property_metadata_user_id",
                table: "property_metadata",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_subdivision_manager_id",
                table: "subdivision",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "ix_subdivision_organization_id",
                table: "subdivision",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_subdivision_parent_subdivision_id",
                table: "subdivision",
                column: "parent_subdivision_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_access_level_id",
                table: "user",
                column: "access_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_employee_id",
                table: "user",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "fk_approve_chain_approve_stage_current_stage_id",
                table: "approve_chain",
                column: "current_stage_id",
                principalTable: "approve_stage",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_approve_chain_pass_requests_pass_request_id",
                table: "approve_chain",
                column: "pass_request_id",
                principalTable: "pass_requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_pass_requests_pass_request_id",
                table: "approve_stage",
                column: "pass_request_id",
                principalTable: "pass_requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_persons_approver_id",
                table: "approve_stage",
                column: "approver_id",
                principalTable: "persons",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_device_pass_request_pass_requests_pass_requests_id",
                table: "device_pass_request",
                column: "pass_requests_id",
                principalTable: "pass_requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pass_requests_persons_author_id",
                table: "pass_requests",
                column: "author_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_persons_subdivision_subdivision_id",
                table: "persons",
                column: "subdivision_id",
                principalTable: "subdivision",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_chain_approve_stage_current_stage_id",
                table: "approve_chain");

            migrationBuilder.DropForeignKey(
                name: "fk_persons_approve_stage_approve_stage_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "fk_persons_pass_requests_pass_request_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "fk_subdivision_persons_manager_id",
                table: "subdivision");

            migrationBuilder.DropTable(
                name: "access_level_access_point");

            migrationBuilder.DropTable(
                name: "approve_stage_approve_stage");

            migrationBuilder.DropTable(
                name: "approve_stage_template");

            migrationBuilder.DropTable(
                name: "device_pass_request");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "property_metadata");

            migrationBuilder.DropTable(
                name: "access_points");

            migrationBuilder.DropTable(
                name: "approve_chain_template");

            migrationBuilder.DropTable(
                name: "approve_stage_type");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "position");

            migrationBuilder.DropTable(
                name: "customizable_property");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "access_levels");

            migrationBuilder.DropTable(
                name: "approve_stage");

            migrationBuilder.DropTable(
                name: "approve_chain");

            migrationBuilder.DropTable(
                name: "pass_requests");

            migrationBuilder.DropTable(
                name: "pass_request_type");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "subdivision");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
