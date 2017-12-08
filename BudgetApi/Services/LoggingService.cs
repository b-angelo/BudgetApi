using BudgetApi.Entities;
using System;

namespace BudgetApi.Services
{
    public class LoggingService
    {
        private BudgetApiDbContext db = new BudgetApiDbContext();

        public void LogError(int errorCode, string error)
        {
            try
            {
                var errorLog = new ErrorLog
                {
                    ErrorCode = errorCode,
                    ErrorMessage = error,
                    CreatedBy = Environment.UserName,
                    CreateDate = DateTime.Now                    
                };

                db.ErrorLogs.Add(errorLog);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
              
        }

        public void LogAcces()
        {

        }
        
        public void LogChange()
        {

        }
    }
}