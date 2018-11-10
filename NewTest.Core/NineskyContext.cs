using System.Data.Entity;

namespace NewTest.Core
{
    public class NineskyContext: DbContext
    {
        /// <summary>
        /// 管理员集合
        /// </summary>
        public DbSet<Administrator> Administrators { get; set; }

        public NineskyContext() : base("DefaultConnection")
        {
            Database.SetInitializer<NineskyContext>(new CreateDatabaseIfNotExists<NineskyContext>());
        }
    }
}
