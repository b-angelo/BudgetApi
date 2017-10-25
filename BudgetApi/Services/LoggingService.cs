using BudgetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApi.Services
{
    public class LoggingService
    {
        private BudgetEntities db = new BudgetEntities();

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