using System;
using System.Collections.Generic;

namespace BudgetApi.Models
{
    public class AccountVm : BaseVm
    {
        public string Role { get; set; }
        public decimal Balance { get; set; }
        public long AccountNumber { get; set; }
        public List<BalanceHistoryVm> BalanceHistory { get; set; }
    }

    public class BalanceHistoryVm : BaseVm
    {
        public decimal Balance { get; set; }
    }
}