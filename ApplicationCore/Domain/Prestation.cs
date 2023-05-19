using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeP { Coiffure, Maquillage, Onglerie, Soin}

namespace ApplicationCore.Domain
{
    public class Prestation
    {

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int PrestationId { get; set; }
        public string Intitule { get; set; }

        public TypeP PrestationType { get; set; }


        [DataType(DataType.Currency)]
        public double Prix { get; set; }

        public int PrestataireFK { get; set; }

        //FK
        [ForeignKey("PrestataireFK")]
        public virtual Prestataire Prestataire { get; set; }

        public virtual IEnumerable<RDV> RDVs { get; set; }

    }
}
