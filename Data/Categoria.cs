using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    [Table("Categoria")]
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
    }
}