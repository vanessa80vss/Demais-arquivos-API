using AutoMapper;
using EcommerceAPI.Data;
using EcommerceAPI.Data.Dtos;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {   //inicializamos e utilizar para acessar, guardar e recuperar informações no banco

        private CategoriaContext _context;
        private IMapper _mapper;
        public CategoriaController(CategoriaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //private static List<Categoria> listcategorias = new List<Categoria>();
        //private static int id = 1;

        //[HttpPost]
        //public void AdicionaCategoria([FromBody] Categoria categoria)
        //{
        //    categoria.Id = id++;
        //    listcategorias.Add(categoria);
        //    Console.WriteLine(categoria.NomeCategoria);
        //}
        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            //categoria.Id = id++;
            //listcategorias.Add(categoria);

            //Categoria categoria = new Categoria /- substituido pelo Automapper
            //{
            //    NomeCategoria = categoriaDto.NomeCategoria,
            //    StatusCategoria = categoriaDto.StatusCategoria
            //};

            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCategoriasPorId), new { Id = categoria.Id }, categoria);
            //qual a açao q vamos usar: recuperarcategoriaporid(nameof), passamos o id, igual o id da categoria q criamos e o object q está sendo tratado
        }
        //[HttpGet]
        //public IEnumerable<Categoria> RecuperarCategoria() mais para frente vamos usar IEnumerable
        //{
        //    return listcategorias;
        //}
        [HttpGet]
        public IEnumerable<Categoria> RecuperarCategoria()
        {
            return _context.Categorias;
        }
        //public  IActionResult RecuperarCategoria()
        //{
        //    return Ok(_context.Categorias);
        //}
        //[HttpGet("{id}")] podemos usar dessa forma ou fazer exp lambda 
        //public Categoria RecuperaCategoriasPorId(int id)
        //{
        //    foreach (Categoria categoria in listcategorias)
        //    {
        //        if(categoria.Id == id)
        //        {
        //            return categoria;
        //        }
        //    }
        //    return null;
        //}

        [HttpGet("{id}")]
        //public Categoria RecuperaCategoriasPorId(int id)

        //{
        //    return listcategorias.FirstOrDefault(categoria => categoria.Id == id);
        //}
        public IActionResult RecuperaCategoriasPorId(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria != null)
            {
                //ReadCategoriaDto categoriaDto = new ReadCategoriaDto //substituido pelo Automapper
                //{
                //    NomeCategoria = categoria.NomeCategoria,
                //    StatusCategoria = categoria.StatusCategoria,
                //    Id = categoria.Id,
                //    DataInicio = DateTime.Now
                //};
                ReadCategoriaDto categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);

                return Ok(categoriaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] UpDateCategoriaDto categoriaDto)
        {//recup pelo id. 
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            //categoria.NomeCategoria = categoriaDto.NomeCategoria;
            //categoria.StatusCategoria = categoriaDto.StatusCategoria; 
            // substituido pelo auto mapper - converter dois objs entre si. e devidp categoria profile onde indicamos a conversão
           _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return NoContent();
        }
        // para deletar
        [HttpDelete("{id}")]

        public IActionResult DeletarCategoria(int id)
        { 
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NotFound();
             }
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();

    }
}
}


