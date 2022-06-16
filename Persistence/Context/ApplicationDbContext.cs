
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConnectionManager connectionManager)
            : base(options)
        {
            //ArticulosMarcas.FromSqlRaw("[dbo].[usp_ConsultaArticulos]").AsAsyncEnumerable();
            this.connectionManager = connectionManager;
            //this.ArticulosMarcas = new DbSet<ArticuloMarca>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Rate).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<Articulo>().HasKey(e => new { e.IdArticulo});
            modelBuilder.Entity<Marca>().HasKey(e => new { e.IdMarca });
            modelBuilder.Entity<ArticuloMarca>().HasKey(e => new { e.IdArticulo });// .HasNoKey();
            //modelBuilder.Query<DbSe t<ArticuloMarca>>()

            base.OnModelCreating(modelBuilder);
        }
        #region Atributos
        private readonly IConnectionManager connectionManager;
        #endregion

        //public ArticuloMarcaDA(DataAccess.Interface.IConnectionManager connectionManager)
        //{
        //    this.connectionManager = connectionManager;
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<ArticuloMarca> ArticulosMarcas { get; set; }

        //private DbSet<ArticuloMarca> _ArticulosMarcas;
        //public DbSet<ArticuloMarca> ArticulosMarcas {
        //    get
        //    {
        //        return _ArticulosMarcas;
        //    }
        //    set
        //    {
        //        _ArticulosMarcas = (DbSet<ArticuloMarca>)ListarAriculosMarcas();
        //    }
        //}

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public IEnumerable<ArticuloMarca> ListarAriculosMarcas()
        {
            var cn = connectionManager.CreateConnection(ConnectionManager.Prueba_Key);
            using (cn)
            {

                var resultado = cn.Query<ArticuloMarca>(
                    sql: "usp_ConsultaArticulos",
                    commandType: System.Data.CommandType.StoredProcedure);
                //var resultado = cn.Query<Model.ArticuloMarca>(
                //    "usp_ConsultaArticulos", new Model.ArticuloMarca(),
                //    commandType: System.Data.CommandType.StoredProcedure);

                return  resultado;
            }
        }
    }
}
