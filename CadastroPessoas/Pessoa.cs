using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CadastroPessoas
{
    [Serializable]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DtNascto { get; set; }
        public decimal Dinheiro { get; set; }     
    }

    
}