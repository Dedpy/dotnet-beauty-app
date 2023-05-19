using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PrestationServiceImp : Service<Prestation>, IPrestation
    {
        public PrestationServiceImp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double PrixMoyenTypeCoiffure()
        {
            IEnumerable<Prestation> prestations = GetAll();
            double prixMoyen = prestations.Average(p => p.Prix);
            return prixMoyen;
        }
    }
}
