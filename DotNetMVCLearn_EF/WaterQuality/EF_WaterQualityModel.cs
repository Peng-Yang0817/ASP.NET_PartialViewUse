using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DotNetMVCLearn_EF.WaterQuality
{
    public partial class EF_WaterQualityModel : DbContext
    {
        public EF_WaterQualityModel()
            : base("name=EF_WaterQualityModel")
        {
        }

        public virtual DbSet<Aquarium> Aquarium { get; set; }
        public virtual DbSet<AquariumSituation> AquariumSituation { get; set; }
        public virtual DbSet<Auth001> Auth001 { get; set; }
        public virtual DbSet<NotifySetRange> NotifySetRange { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
