using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EcommerceAPI.Data
{
    public class CategoriaContext : DbContext //torna o acesso ao banco de dados +fácil e rápido
    {
        //cria o construtor com os parametros e opções do contexto
        public CategoriaContext(DbContextOptions<CategoriaContext> opt) : base(opt)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
