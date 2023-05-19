using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum Zone { Raoued,ArianaVille, LaSoukra}

namespace ApplicationCore.Domain
{
    public class Prestataire
    {
        [Range(0,5)]
        public int Note { get; set; }
        public string PageInstagram { get; set; }
        public int PrestataireId { get; set; }
        public string PrestataireNom { get; set; }
        public string PrestataireTel { get; set; }
        public Zone Zone;

        public virtual IEnumerable<Prestation> Prestations { get; set; }
    }
}
