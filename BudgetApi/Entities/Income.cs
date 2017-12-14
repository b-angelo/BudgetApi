namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Income")]
    public partial class Income : EntityBase
    {
        [Key]
        public int Income_Pk { get; set; }

        public int Account_Fk { get; set; }

        public int IncomeSchedule_Fk { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal? TaxRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Account Account { get; set; }

        public virtual IncomeSchedule IncomeSchedule { get; set; }
    }
}
