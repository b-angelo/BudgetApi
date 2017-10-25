using BudgetApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BudgetApi.Services;
using System.Net.Http;
using BudgetApi.ViewModels;

namespace BudgetApi.Controllers
{
    public class AccountsController : ApiController
    {
        private BudgetEntities db = new BudgetEntities();
        private AccountService _accountService = new AccountService();

        public AccountVm GetAccount(int id)
        {
           return _accountService.GetAccountDetails(id);
        }

        public HttpResponseMessage PutAccount(int id, Account account)
        {
            if (account.Account_Pk == 0) account.Account_Pk = id;

            if (_accountService.UpdateAccount(account))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostAccount(Account account)
        {
            if (_accountService.CreateAccount(account))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}