namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountBalance")]
    public partial class AccountBalance : EntityBase
    {
        [Key]
        public int AccountBalance_Pk { get; set; }

        public int Account_Fk { get; set; }

        public decimal Balance { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
