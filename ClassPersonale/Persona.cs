using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPersonale
{
    public class Persona
    {
        public string Codice_Fiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Persona(string codice_fiscale, string nome, string cognome)
        {
            Codice_Fiscale = codice_fiscale;
            Nome = nome;
            Cognome = cognome;
        }
        public override string ToString()
        {
            return $"{Nome} {Cognome}";
        }
    }
}
