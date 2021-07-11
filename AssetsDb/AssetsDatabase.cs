using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsDb.Entity;

namespace AssetsDb
{
    public class AssetsDatabase : DbContext
    {
        public AssetsDatabase() : base("AssetsDatabase")
        {
            System.Data.Entity.Database.SetInitializer(new AssetsInitializer());
        }
        /// <summary>
        /// Предприятия
        /// </summary>
        public DbSet<Company> Companies { get; set; }
        /// <summary>
        /// Активы предприятий
        /// </summary>
        public DbSet<Asset> Assets { get; set; }
        /// <summary>
        /// Места нахождения активов
        /// </summary>
        public DbSet<Location> Locations { get; set; }

    }
    public class AssetsInitializer
        : DropCreateDatabaseIfModelChanges<AssetsDatabase>
    {
        // В этом методе можно заполнить таблицу по умолчанию
        protected override void Seed(AssetsDatabase db)
        {
            Company[] companies = new []
            {
                new Company{Name = "ООО \"Зеленоглазое такси\""},
                new Company{Name = "ООО \"Какой большой потенциал\""}
            };

            Location[] locations = new[]
            {
                new Location{Name = "Деньги в кассе"},
                new Location{Name = "Собственность предприятия"}
            };
            db.Companies.AddRange(companies);
            db.Locations.AddRange(locations);
            db.SaveChanges();
            base.Seed(db);
        }
    }

}
