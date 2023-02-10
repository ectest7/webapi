using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    [Table("Producto")]
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }

        public Categoria Categoria { get; set; }
    }
}