using BudgetApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace BudgetApi.Controllers
{
    public class AccountRolesController : ApiController
    {
        private BudgetEntities db = new BudgetEntities();

        // GET: api/AccountRoles
        public IQueryable<AccountRole> GetAccountRoles()
        {
            return db.AccountRoles;
        }

        // GET: api/AccountRoles/5
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult GetAccountRole(int id)
        {
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return NotFound();
            }

            return Ok(accountRole);
        }

        // PUT: api/AccountRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountRole(int id, AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountRole.AccountRole_Pk)
            {
                return BadRequest();
            }

            db.Entry(accountRole).State = EntityState.Modified;
            db.SaveChanges();

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AccountRoles
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult PostAccountRole(AccountRole accountRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountRoles.Add(accountRole);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accountRole.AccountRole_Pk }, accountRole);
        }

        // DELETE: api/AccountRoles/5
        [ResponseType(typeof(AccountRole))]
        public IHttpActionResult DeleteAccountRole(int id)
        {
            AccountRole accountRole = db.AccountRoles.Find(id);
            if (accountRole == null)
            {
                return NotFound();
            }

            db.AccountRoles.Remove(accountRole);
            db.SaveChanges();

            return Ok(accountRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountRoleExists(int id)
        {
            return db.AccountRoles.Count(e => e.AccountRole_Pk == id) > 0;
        }
    }
}