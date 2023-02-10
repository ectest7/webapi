using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductosController(
            AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProductos()
        {
            var productos = _context.Productos.Include(x => x.Categoria).ToList();
            return _mapper.Map<List<ProductoDto>>(productos);
        }

        [HttpGet("{id}", Name = "GetProductoById")]
        public ActionResult<ProductoDto> GetProductoById(int id)
        {
            var producto = _context.Productos.Include(x => x.Categoria).FirstOrDefault(x => x.ProductoId == id);
            if (producto is null)
            {
                return NotFound();
            }

            return _mapper.Map<ProductoDto>(producto);
        }





    }
}