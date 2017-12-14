using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Entities
{
    public abstract class EntityBase
    {
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}