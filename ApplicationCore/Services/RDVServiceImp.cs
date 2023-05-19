using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class RDVServiceImp : Service<RDV>, IRDVs
    {
        public RDVServiceImp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<RDV> RDVsConfirmeGroupedByDate(Client c)
        {
            IEnumerable<RDV> rdvs = GetAll();
            IEnumerable<RDV> rdvsConfirme = rdvs.Where(r => r.Confirmation == true && r.ClientFK == c.Id);
            return rdvsConfirme.GroupBy(r => r.DateRDV).Select(r => r.First());
           
        }
    }
}
