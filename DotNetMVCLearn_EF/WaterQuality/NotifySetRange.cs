namespace DotNetMVCLearn_EF.WaterQuality
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NotifySetRange")]
    public partial class NotifySetRange
    {
        public int Id { get; set; }

        public int? AquariumId { get; set; }

        [Required]
        [StringLength(50)]
        public string AquariumUnitNum { get; set; }

        [Required]
        [StringLength(50)]
        public string temperatureUpperBound { get; set; }

        [Required]
        [StringLength(50)]
        public string temperatureLowerBound { get; set; }

        [Required]
        [StringLength(50)]
        public string pHUpperBound { get; set; }

        [Required]
        [StringLength(50)]
        public string phLowerBound { get; set; }

        [Required]
        [StringLength(50)]
        public string TDSUpperBound { get; set; }

        [Required]
        [StringLength(50)]
        public string TDSLowerBound { get; set; }

        [Required]
        [StringLength(50)]
        public string TurbidityUpperBound { get; set; }

        [Required]
        [StringLength(50)]
        public string WaterLevelLowerBound { get; set; }

        [StringLength(50)]
        public string NotifyTag { get; set; }
    }
}
