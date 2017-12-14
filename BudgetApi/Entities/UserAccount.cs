namespace BudgetApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount : EntityBase
    {
        [Key]
        public int UserAccount_Pk { get; set; }

        public int Account_Fk { get; set; }

        public int AccountRole_Fk { get; set; }

        public int User_Fk { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Account Account { get; set; }

        public virtual AccountRole AccountRole { get; set; }

        public virtual User User { get; set; }
    }
}
