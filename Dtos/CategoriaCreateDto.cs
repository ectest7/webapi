using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class CategoriaCreateDto
    {
        public string Nombre { get; set; }
        public List<ProductoCategoriaDto> Productos { get; set; }
    }
}