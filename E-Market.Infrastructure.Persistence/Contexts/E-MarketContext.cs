using E_Market.Core.Domain.Commons;
using E_Market.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Market.Infrastructure.Persistence.Contexts
{
    public class E_MarketContext : DbContext
    {
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<User> Users{ get; set; }

        public E_MarketContext(DbContextOptions<E_MarketContext> options) : base(options)
        {}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "Default User";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Default User";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table
            modelBuilder.Entity<Anuncio>().ToTable("Anuncios");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<User>().ToTable("Usuarios");

            #endregion
            #region Primary key
            modelBuilder.Entity<Anuncio>().HasKey(anuncio => anuncio.Id);
            modelBuilder.Entity<Categoria>().HasKey(categoria => categoria.Id);
            modelBuilder.Entity<User>().HasKey(user=> user.Id);

            #endregion
            #region Relationships
            modelBuilder.Entity<Categoria>()
                .HasMany<Anuncio>(anuncio => anuncio.Anuncios)
                .WithOne(anuncio => anuncio.Categoria)
                .HasForeignKey(anuncio => anuncio.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasMany<Anuncio>(user => user.Anuncios)
                .WithOne(user => user.Usuario)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion
            #region Properties
            #region Anuncio
            modelBuilder.Entity<Anuncio>()
                    .Property(anuncio=>anuncio.Nombre)
                    .IsRequired();
                modelBuilder.Entity<Anuncio>()
                  .Property(anuncio => anuncio.Precio)
                  .IsRequired();
                modelBuilder.Entity<Anuncio>()
                  .Property(anuncio => anuncio.Imagen)
                  .IsRequired();
                modelBuilder.Entity<Anuncio>()
                  .Property(anuncio => anuncio.Descripcion)
                  .IsRequired();
            #endregion
            #region Categoria
            modelBuilder.Entity<Categoria>()
                 .Property(categoria => categoria.Nombre)
                  .IsRequired();

            modelBuilder.Entity<Categoria>()
                 .Property(categoria => categoria.Descripcion)
                  .IsRequired();

            #endregion
            #region Usuario
            modelBuilder.Entity<User>()
                 .Property(user => user.UserName)
                  .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(user => user.Password)
                  .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(user => user.Nombre)
                  .IsRequired();
            modelBuilder.Entity<User>()
                 .Property(user => user.Email)
                  .IsRequired();
            modelBuilder.Entity<User>()
                 .Property(user => user.Password)
                  .IsRequired();
            #endregion
            #endregion
        }
    }
}
