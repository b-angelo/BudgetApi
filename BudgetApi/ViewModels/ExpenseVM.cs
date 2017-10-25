using System;
using System.Collections.Generic;

namespace BudgetApi.ViewModels
{
    public class ExpenseVM : BaseVm
    {
        public decimal MinDue { get; set; }
        public DateTime DueDate { get; set; }
        public bool AutoPay { get; set; }
        public ExpenseScheduleVM ExpenseSchedule { get; set; }
        public List<PaymentVM> Payments { get; set; }
    }

    public class ExpenseScheduleVM : BaseVm
    {
        public int NextDueDate { get; set; }
    }

    public class PaymentVM : BaseVm
    {
        public decimal AmountPaid { get; set; }
        public DateTime DatePaid { get; set; }
    }
}