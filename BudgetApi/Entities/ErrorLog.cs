namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("logging.ErrorLog")]
    public partial class ErrorLog
    {
        [Key]
        public int ErrorLog_Pk { get; set; }

        public int ErrorCode { get; set; }

        [Required]
        [StringLength(500)]
        public string ErrorMessage { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
