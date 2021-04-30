using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPersonale
{
        public class PersonaleAziendale : Persona
        {
            public string Tipologia { get; set; }
            public string Qualifica { get; set; }
            public string Area { get; set; }
            public PersonaleAziendale(string codice_fiscale, string nome, string cognome, string tipologia) : base(codice_fiscale, nome, cognome)
            {
                Tipologia = tipologia;
            }
            public override string ToString()
            {
                return base.ToString() + $",Tipologia:{Tipologia}, Mansione:{Qualifica}, Area:{Area}";

            }
        }
    
}
