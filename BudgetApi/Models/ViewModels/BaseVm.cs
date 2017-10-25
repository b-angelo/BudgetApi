using Newtonsoft.Json;
using System;

namespace BudgetApi.Models
{
    public abstract class BaseVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? ModfiedDate { get; set; }
        [JsonIgnore]
        public string ModifiedBy { get; set; }
    }
}