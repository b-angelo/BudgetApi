namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logging.ChangeLog")]
    public partial class ChangeLog : EntityBase
    {
        [Key]
        public int Change_Pk { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        [Required]
        [StringLength(50)]
        public string ColumnName { get; set; }

        public int RecordPk { get; set; }

        [Required]
        [StringLength(1000)]
        public string OldValue { get; set; }

        [Required]
        [StringLength(1000)]
        public string NewValue { get; set; }
    }
}
