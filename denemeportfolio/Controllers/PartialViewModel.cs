using denemeportfolio.Models;
using System.Collections.Generic;

namespace denemeportfolio.Controllers
{
    internal class PartialViewModel
    {
        public List<TblService> Table1Data { get; set; }
        public List<TblProfile> Table2Data { get; set; }
    }
}