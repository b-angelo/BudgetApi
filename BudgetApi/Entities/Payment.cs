namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment : EntityBase
    {
        [Key]
        public int Payment_PK { get; set; }

        public int Payee_Fk { get; set; }

        public decimal? AmountPaid { get; set; }

        public DateTime? DatePaid { get; set; }

        public virtual Expense Expense { get; set; }
    }
}
