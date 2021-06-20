using Surveillance.Models;
using Microsoft.EntityFrameworkCore;


namespace Surveillance.Schafold {

    /// <summary>
    /// 資料庫上下文
    /// </summary>
    public class DatabaseContext : DbContext {

        #region "建構"

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_Option">選項</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> _Option) : base(_Option) {
            // NOTHING
        }


        /// <summary>
        /// 模型建立
        /// </summary>
        /// <param name="_MB">建立器</param>
        protected override void OnModelCreating(ModelBuilder _MB) {
            // 對映資料表
            _MB.Entity<CardModel>().ToTable("Card");
            _MB.Entity<CardAuthorityModel>().ToTable("CardAuthority");
            _MB.Entity<CardBatchModel>().ToTable("CardBatch");
            _MB.Entity<CardBatchLogModel>().ToTable("CardBatchLog");
            _MB.Entity<DoorModel>().ToTable("Door");
            _MB.Entity<EventLogModel>().ToTable("EventLog");
            _MB.Entity<FloorModel>().ToTable("Floor");
            _MB.Entity<UserModel>().ToTable("User");
            _MB.Entity<UserLogModel>().ToTable("UserLog");

            // 設定主鍵
            _MB.Entity<CardModel>().HasKey(x => x.Seq).HasName("PK_Card");
            _MB.Entity<CardAuthorityModel>().HasKey(x => x.Seq).HasName("PK_CardAuthority");
            _MB.Entity<CardBatchModel>().HasKey(x => x.Seq).HasName("PK_CardBatch");
            _MB.Entity<CardBatchLogModel>().HasKey(x => x.Seq).HasName("PK_CardBatchLog");
            _MB.Entity<DoorModel>().HasKey(x => x.Seq).HasName("PK_Door");
            _MB.Entity<EventLogModel>().HasKey(x => x.Seq).HasName("PK_EventLog");
            _MB.Entity<FloorModel>().HasKey(x => x.Seq).HasName("PK_Floor");
            _MB.Entity<UserModel>().HasKey(x => x.Seq).HasName("PK_User");
            _MB.Entity<UserLogModel>().HasKey(x => x.Seq).HasName("PK_UserLog");

            // 設定索引
            _MB.Entity<CardModel>().HasIndex(x => x.ID).IsUnique().HasDatabaseName("Idx_Card");
            _MB.Entity<CardAuthorityModel>().HasIndex(x => new { x.DoorID, x.CardID }).HasDatabaseName("Idx_CardAuthority");
            _MB.Entity<CardBatchModel>().HasIndex(x => new { x.CardID, x.StartTime, x.EndTime }).HasDatabaseName("Idx_CardBatch");
            _MB.Entity<CardBatchLogModel>().HasIndex(x => new { x.Time, x.UserSeq }).HasDatabaseName("Idx_CardBatchLog");
            _MB.Entity<DoorModel>().HasIndex(x => x.ID).HasDatabaseName("Idx_Door");
            _MB.Entity<FloorModel>().HasIndex(x => x.Level).HasDatabaseName("Idx_Floor");
            _MB.Entity<UserModel>().HasIndex(x => new { x.Account, x.Name }).HasDatabaseName("Idx_User");
            _MB.Entity<UserLogModel>().HasIndex(x => new { x.Time, x.UserSeq }).HasDatabaseName("Idx_UserLog");

            // 設定關聯
            //_MB.Entity<UserModel>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }

        #endregion




        #region "資料表"

        public DbSet<CardAuthorityModel> CardAuthority { get; set; }
        public DbSet<CardBatchModel> CardBatch { get; set; }
        public DbSet<CardBatchLogModel> CardBatchLog { get; set; }
        public DbSet<CardModel> Card { get; set; }
        public DbSet<DoorModel> Door { get; set; }
        public DbSet<EventLogModel> EventLog { get; set; }
        public DbSet<FloorModel> Floor { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<UserLogModel> UserLog { get; set; }

        #endregion

    }
}