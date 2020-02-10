using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSLNCSApi.Models
{
    
    public class MemberTransaction
    {
        public int Id { get; set; }
        public string ActNo { get; set; }
        public string ActPeriod  { get; set; }
        public string ActYear { get; set; }
        public DateTime? ActDate { get; set; }
        public string InvoiceAmount { get; set; }
        public string CrValue    { get; set; }

        public string CustCode { get; set; }
        public string TransAmount { get; set; }
        public string RecNo { get; set; }

    }
}
