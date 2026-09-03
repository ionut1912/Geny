using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geny.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Color = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AvatarUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsPro = table.Column<bool>(type: "boolean", nullable: false),
                    ProExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PreferredCategories = table.Column<string>(type: "jsonb", nullable: false),
                    DefaultMood = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "mixed"),
                    TotalXp = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsProfilePublic = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "facts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HookSentence = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Level1 = table.Column<string>(type: "text", nullable: false),
                    Level2 = table.Column<string>(type: "text", nullable: false),
                    Level3 = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    CalendarDate = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    NarrativeHint = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SourceUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "narrative_threads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FactIds = table.Column<string>(type: "jsonb", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsExclusive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_narrative_threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_narrative_threads_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "badges",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    badge_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EarnedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_badges", x => new { x.UserId, x.badge_type });
                    table.ForeignKey(
                        name: "FK_badges_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ShareToken = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_collections_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "intellectual_profiles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TopCategories = table.Column<string>(type: "jsonb", nullable: false),
                    CuriosityScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    BreadthScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    RetentionScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ProfileTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WeeklyInsight = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PreviousTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastCalculatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intellectual_profiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_intellectual_profiles_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "live_events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
                    QuestionIds = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ParticipantCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    WinnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_live_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_live_events_users_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "notification_settings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DailyFactEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DailyFactTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false, defaultValue: new TimeOnly(8, 0, 0)),
                    StreakReminderEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LiveEventReminderEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    PushToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_settings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_notification_settings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_referrals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InviterId = table.Column<Guid>(type: "uuid", nullable: false),
                    InviteeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferralToken = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    XpAwarded = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_referrals_users_InviteeId",
                        column: x => x.InviteeId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_referrals_users_InviterId",
                        column: x => x.InviterId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "daily_events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FactId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ContextText = table.Column<string>(type: "text", nullable: false),
                    TotalReactions = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    PercentCorrectGuess = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 0m),
                    IsLive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daily_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_daily_events_facts_FactId",
                        column: x => x.FactId,
                        principalTable: "facts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quiz_questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FactId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    WrongAnswers = table.Column<string>(type: "jsonb", nullable: false),
                    XpReward = table.Column<int>(type: "integer", nullable: false, defaultValue: 25),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quiz_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quiz_questions_facts_FactId",
                        column: x => x.FactId,
                        principalTable: "facts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_progresses",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FactId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeenAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepthReached = table.Column<int>(type: "integer", nullable: false),
                    TimeSpentSec = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    QuizAnswered = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    QuizCorrect = table.Column<bool>(type: "boolean", nullable: true),
                    NextReviewAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_progresses", x => new { x.UserId, x.FactId });
                    table.ForeignKey(
                        name: "FK_user_progresses_facts_FactId",
                        column: x => x.FactId,
                        principalTable: "facts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_progresses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_narrative_progresses",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    NarrativeThreadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentPosition = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_narrative_progresses", x => new { x.UserId, x.NarrativeThreadId });
                    table.ForeignKey(
                        name: "FK_user_narrative_progresses_narrative_threads_NarrativeThread~",
                        column: x => x.NarrativeThreadId,
                        principalTable: "narrative_threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_narrative_progresses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collection_facts",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    FactId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_facts", x => new { x.CollectionId, x.FactId });
                    table.ForeignKey(
                        name: "FK_collection_facts_collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collection_facts_facts_FactId",
                        column: x => x.FactId,
                        principalTable: "facts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "live_event_participants",
                columns: table => new
                {
                    LiveEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinalScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    FinalRank = table.Column<int>(type: "integer", nullable: true),
                    XpAwarded = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_live_event_participants", x => new { x.LiveEventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_live_event_participants_live_events_LiveEventId",
                        column: x => x.LiveEventId,
                        principalTable: "live_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_live_event_participants_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "social_feed_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    action_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FactId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThreadId = table.Column<Guid>(type: "uuid", nullable: true),
                    LiveEventId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_feed_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_social_feed_items_facts_FactId",
                        column: x => x.FactId,
                        principalTable: "facts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_social_feed_items_live_events_LiveEventId",
                        column: x => x.LiveEventId,
                        principalTable: "live_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_social_feed_items_narrative_threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "narrative_threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_social_feed_items_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_reactions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DailyEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    GuessedBeforeReveal = table.Column<bool>(type: "boolean", nullable: true),
                    reaction_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReactedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SharedToday = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_reactions", x => new { x.UserId, x.DailyEventId });
                    table.ForeignKey(
                        name: "FK_event_reactions_daily_events_DailyEventId",
                        column: x => x.DailyEventId,
                        principalTable: "daily_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_reactions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "live_event_answers",
                columns: table => new
                {
                    LiveEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    AnsweredAtMs = table.Column<int>(type: "integer", nullable: false),
                    PointsEarned = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_live_event_answers", x => new { x.LiveEventId, x.UserId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_live_event_answers_live_events_LiveEventId",
                        column: x => x.LiveEventId,
                        principalTable: "live_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_live_event_answers_quiz_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "quiz_questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_live_event_answers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_Slug",
                table: "categories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collection_facts_FactId",
                table: "collection_facts",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_collections_ShareToken",
                table: "collections",
                column: "ShareToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_collections_UserId",
                table: "collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_daily_events_EventDate",
                table: "daily_events",
                column: "EventDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_daily_events_FactId",
                table: "daily_events",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_event_reactions_DailyEventId",
                table: "event_reactions",
                column: "DailyEventId");

            migrationBuilder.CreateIndex(
                name: "IX_facts_CalendarDate",
                table: "facts",
                column: "CalendarDate");

            migrationBuilder.CreateIndex(
                name: "IX_facts_CategoryId",
                table: "facts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_live_event_answers_QuestionId",
                table: "live_event_answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_live_event_answers_UserId",
                table: "live_event_answers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_live_event_participants_UserId",
                table: "live_event_participants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_live_events_WinnerId",
                table: "live_events",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_narrative_threads_CategoryId",
                table: "narrative_threads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_questions_FactId",
                table: "quiz_questions",
                column: "FactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_social_feed_items_FactId",
                table: "social_feed_items",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_social_feed_items_LiveEventId",
                table: "social_feed_items",
                column: "LiveEventId");

            migrationBuilder.CreateIndex(
                name: "IX_social_feed_items_ThreadId",
                table: "social_feed_items",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_social_feed_items_UserId_CreatedAt",
                table: "social_feed_items",
                columns: new[] { "UserId", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_user_narrative_progresses_NarrativeThreadId",
                table: "user_narrative_progresses",
                column: "NarrativeThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_user_progresses_FactId",
                table: "user_progresses",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_user_referrals_InviteeId",
                table: "user_referrals",
                column: "InviteeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_referrals_InviterId",
                table: "user_referrals",
                column: "InviterId");

            migrationBuilder.CreateIndex(
                name: "IX_user_referrals_ReferralToken",
                table: "user_referrals",
                column: "ReferralToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "badges");

            migrationBuilder.DropTable(
                name: "collection_facts");

            migrationBuilder.DropTable(
                name: "event_reactions");

            migrationBuilder.DropTable(
                name: "intellectual_profiles");

            migrationBuilder.DropTable(
                name: "live_event_answers");

            migrationBuilder.DropTable(
                name: "live_event_participants");

            migrationBuilder.DropTable(
                name: "notification_settings");

            migrationBuilder.DropTable(
                name: "social_feed_items");

            migrationBuilder.DropTable(
                name: "user_narrative_progresses");

            migrationBuilder.DropTable(
                name: "user_progresses");

            migrationBuilder.DropTable(
                name: "user_referrals");

            migrationBuilder.DropTable(
                name: "collections");

            migrationBuilder.DropTable(
                name: "daily_events");

            migrationBuilder.DropTable(
                name: "quiz_questions");

            migrationBuilder.DropTable(
                name: "live_events");

            migrationBuilder.DropTable(
                name: "narrative_threads");

            migrationBuilder.DropTable(
                name: "facts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
