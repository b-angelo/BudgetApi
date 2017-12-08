using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BudgetApi.Entities;

namespace BudgetApi.Controllers
{
    public class IncomesController : ApiController
    {
        private BudgetApiDbContext db = new BudgetApiDbContext();

        public IQueryable<Income> GetIncomes()
        {
            return db.Incomes;
        }
        
        [ResponseType(typeof(Income))]
        public IHttpActionResult GetIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }
        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncome(int id, Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != income.Income_Pk)
            {
                return BadRequest();
            }

            db.Entry(income).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        [ResponseType(typeof(Income))]
        public IHttpActionResult PostIncome(Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incomes.Add(income);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = income.Income_Pk }, income);
        }
        
        [ResponseType(typeof(Income))]
        public IHttpActionResult DeleteIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return NotFound();
            }

            db.Incomes.Remove(income);
            db.SaveChanges();

            return Ok(income);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomeExists(int id)
        {
            return db.Incomes.Count(e => e.Income_Pk == id) > 0;
        }
    }
}