namespace DotNetMVCLearn_EF.WaterQuality
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AquariumSituation")]
    public partial class AquariumSituation
    {
        public int Id { get; set; }

        public int AquariumId { get; set; }

        [Required]
        [StringLength(50)]
        public string temperature { get; set; }

        [Required]
        [StringLength(50)]
        public string Turbidity { get; set; }

        [Required]
        [StringLength(50)]
        public string PH { get; set; }

        [Required]
        [StringLength(50)]
        public string TDS { get; set; }

        [StringLength(50)]
        public string WaterLevel { get; set; }

        public DateTime? createTime { get; set; }

        [StringLength(50)]
        public string WaterLevelNum { get; set; }
    }
}
