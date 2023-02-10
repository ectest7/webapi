using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ProductoCreateDto
    {
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
    }
}