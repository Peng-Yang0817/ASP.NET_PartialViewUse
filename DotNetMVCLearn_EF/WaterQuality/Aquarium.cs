namespace DotNetMVCLearn_EF.WaterQuality
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aquarium")]
    public partial class Aquarium
    {
        public int Id { get; set; }

        public int Auth001Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AquariumUnitNum { get; set; }

        [Required]
        [StringLength(50)]
        public string WaterType { get; set; }

        [StringLength(50)]
        public string BindTag { get; set; }

        public DateTime? createTime { get; set; }

        public DateTime? modifyTime { get; set; }

        [StringLength(50)]
        public string customAquaruimName { get; set; }

        // ÃöÁp
        public virtual Auth001 Auth001 { get; set; }
    }
}
