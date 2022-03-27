using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPersonelGorevDagitim.Models
{
    public class DBOperationResult
    {
        public bool Ok = true;
        public Exception exception;
        public string HataAciklama = string.Empty;
        public int AffectedRows = 0;

        public DBOperationResult()
        {
            
        }
        
        public DBOperationResult(bool Ok, Exception exception)
        {
            this.Ok = Ok;
            this.exception = exception;
        }
    }
}
