using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PrestatiresServiceImp : Service<Prestataire> , IPrestataires
    {
        public PrestatiresServiceImp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Prestataire> ThreePrestaitairesMieuxNotes()
        {
            //Get thee prestataires have the best notes

            IEnumerable<Prestataire> prestataires = GetAll(); // retrieve the list of Prestataire objects
            return prestataires.OrderByDescending(p => p.Note).Take(3);

        }

    }
}
