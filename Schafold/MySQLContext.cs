using Surveillance.Models;
using Microsoft.EntityFrameworkCore;


namespace Surveillance.Schafold {

    /// <summary>
    /// MySQL上下文
    /// </summary>
    public class MySQLContext : DbContext {

        #region "建構"

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_Option">選項</param>
        public MySQLContext(DbContextOptions<MySQLContext> _Option) : base(_Option) {
            // NOTHING
        }


        /// <summary>
        /// 模型建立
        /// </summary>
        /// <param name="_MB">建立器</param>
        protected override void OnModelCreating(ModelBuilder _MB) {
            // 對映資料表
            _MB.Entity<UserModel>().ToTable("User");

            // 設定主鍵
            _MB.Entity<UserModel>().HasKey(x => x.Seq).HasName("PK_User");

            // 設定索引
            _MB.Entity<UserModel>().HasIndex(x => x.Account).IsUnique().HasDatabaseName("Idx_Account");
            _MB.Entity<UserModel>().HasIndex(x => x.Name).HasDatabaseName("Idx_Name");

            // 設定關聯
            //_MB.Entity<UserModel>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }

        #endregion




        #region "資料表"

        public DbSet<UserModel> User { get; set; }

        #endregion

    }
}