using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(
            AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<CategoriaDto>> GetCategorias()
        {
            var categorias = _context.Categorias.ToList();
            return _mapper.Map<List<CategoriaDto>>(categorias);
        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        public ActionResult<CategoriaDto> GetCategoriaById(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoriaDto>(categoria);
        }

        [HttpPost]
        public ActionResult<CategoriaDto> Create(CategoriaCreateDto categoriaCreateDto)
        {

            var categoria = _mapper.Map<Categoria>(categoriaCreateDto);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return CreatedAtRoute(nameof(GetCategoriaById), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CategoriaCreateDto categoriaCreateDto)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound();
            }

            _mapper.Map(categoriaCreateDto, categoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}