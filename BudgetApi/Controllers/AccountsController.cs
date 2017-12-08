using BudgetApi.Entities;
using BudgetApi.Models;
using BudgetApi.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BudgetApi.Controllers
{
    public class AccountsController : ApiController
    {
        private BudgetApiDbContext db = new BudgetApiDbContext();
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

        public HttpResponseMessage PostAccount(NewAccountInputModel model)
        {
            if (_accountService.CreateAccount(model))
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