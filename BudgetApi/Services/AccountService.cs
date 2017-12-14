using BudgetApi.Entities;
using BudgetApi.Models;
using System;
using System.Data.Entity;
using System.Linq;
using BudgetApi.Repositories.Concrete;

namespace BudgetApi.Services
{
    public class AccountService
    {
        private BudgetApiDbContext db = new BudgetApiDbContext();
        private LoggingService _loggingService = new LoggingService();
        private AccountRepository _accountRepository = new AccountRepository();

        public AccountVm GetAccountDetails(int accountId)
        {
            AccountExists(accountId);

            var account = (from a in db.Accounts
                           join ab in db.AccountBalances on a.Account_Pk equals ab.Account_Fk into gab
                           from ab in gab.DefaultIfEmpty()
                           join abh in db.AccountBalanceHistories on a.Account_Pk equals abh.Account_Fk into gabh
                           from abh in gabh.DefaultIfEmpty()
                           join ua in db.UserAccounts on a.Account_Pk equals ua.Account_Fk into gua
                           from ua in gua.DefaultIfEmpty()
                           join ar in db.AccountRoles on ua.AccountRole_Fk equals ar.AccountRole_Pk into gar
                           from ar in gar.DefaultIfEmpty()
                           where a.Account_Pk == accountId
                           select new AccountVm
                           {
                               Id = a.Account_Pk,
                               Role = ar.Name,
                               Balance = (decimal?)ab.Balance ?? 0,
                               AccountNumber = a.AccountNumber.Value,
                               BalanceHistory = (from abh in db.AccountBalanceHistories
                                                 where abh.Account_Fk == accountId
                                                 select new BalanceHistoryVm
                                                 {
                                                     Id = abh.AccountBalanceHistory_Pk,
                                                     Balance = (decimal?)abh.Balance ?? 0,
                                                     StartDate = abh.StartDate,
                                                     EndDate = abh.EndDate.Value
                                                 }).ToList(),
                               StartDate = a.StartDate,
                               EndDate = a.EndDate,
                               Name = a.Name,
                               Description = a.Description
                           }).FirstOrDefault();

            return account;
        }

        public bool CreateAccount(NewAccountInputModel model)
        {
            try
            {
                var account = new Account()
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    CreatedBy = Environment.UserName
                };

                db.Accounts.Add(account);
                db.SaveChanges();
                                
                return true;
            }
            catch (Exception e)
            {
                _loggingService.LogError(0, e.Message);
                return false;
            }        
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                if (AccountExists(account.Account_Pk))
                {
                    var modAccount = db.Accounts.Where(a => a.Account_Pk == account.Account_Pk).FirstOrDefault();
                    modAccount.Name = account.Name;
                    modAccount.Description = account.Description;
                    modAccount.ModifiedBy = Environment.UserName;
                    modAccount.ModifiedDate = DateTime.Now;
                    modAccount.AccountNumber = RandAccountNum();
                    db.Entry(modAccount).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    _loggingService.LogError(0, $"Account Id {account.Account_Pk} does not exist, cannot update.");
                    return false;
                }
            }
            catch (Exception e)
            {
                _loggingService.LogError(0, e.Message);
                return false;
            }
        }

        private bool AccountExists(int id)
        {
            return db.Accounts.Count(e => e.Account_Pk == id) > 0;
        }

        public AccountVm GetAccountById(int id)
        {
            var account = _accountRepository.GetEntity(id);

            var accountVm = new AccountVm
            {
                Id = account.Account_Pk,
                Name = account.Name,
                Description = account.Description
            };

            return accountVm;
        }

        private long RandAccountNum()
        {
            var accountNums = (from a in db.Accounts
                               select a.AccountNumber).ToList();

            var ran = new Random();
            var ranNum = ran.Next(111111111, 999999999);

            var checkDigit = 001;

            while (accountNums.Contains(ranNum))
            {
                ranNum = ran.Next(111111111, 999999999);
            }

            return ranNum;
        }
    }
}