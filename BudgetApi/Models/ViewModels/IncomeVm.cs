namespace BudgetApi.Models
{
    public class IncomeVm : BaseVm
    {
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxRate { get; set; }
        public IncomeScheduleVm IncomeSchedule { get; set; }
    }

    public class IncomeScheduleVm : BaseVm
    {
        public int NextPayDate { get; set; }
    }
}