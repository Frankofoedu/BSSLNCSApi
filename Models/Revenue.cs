using System;
using System.Collections.Generic;

namespace BSSLNCSApi
{
    public partial class Revenue
    {
        public string Category { get; set; }
        public string Subcode { get; set; }
        public string Subdesc { get; set; }
        public string Revcode1 { get; set; }
        public string Revcode { get; set; }
        public string Revdesc { get; set; }
        public string Bencode { get; set; }
        public string GlCntCde { get; set; }
        public string GlCntDesc { get; set; }
        public string Whatcode { get; set; }
        public string Whatdesc { get; set; }
        public decimal? Revenuerate { get; set; }
        public DateTime? CommDate { get; set; }
        public string Usecomp { get; set; }
        public string Usemj { get; set; }
        public string Achead { get; set; }
        public string Subhead { get; set; }
        public int? FrequencyPay { get; set; }
        public string Apprv { get; set; }
    }
}
