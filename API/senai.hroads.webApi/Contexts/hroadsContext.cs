using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Contexts
{
    public class hroadsContext : DbContext
    {
        public DbSet<TipoUsuario> tipoUsuario { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Personagem> Personagens { get; set; }

        public DbSet<ClasseHabilidade> ClassHab { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Habilidade> Habilidades { get; set; }

        public DbSet<TipoHabilidade> TipoHabilidade { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DANIEL-PC\\SQLEXPRESS; Initial Catalog=HROADS.WebApi; User Id=sa; pwd=1Senhasegur@;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define as entidades já com dados
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    idTipoUsuario = 1,
                    titulo = "Administrador"
                },
                new TipoUsuario
                {
                    idTipoUsuario = 2,
                    titulo = "Cliente"
                });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasData(
                   new Usuario
                   {
                       idUsuario = 1,
                       email = "admin@admin.com",
                       senha = "admin",
                       idTipoUsuario = 1
                   },
                   new Usuario
                   {
                       idUsuario = 2,
                       email = "cliente@cliente.com",
                       senha = "cliente",
                       idTipoUsuario = 2
                   });


                entity.HasIndex(u => u.email).IsUnique();
            });

            modelBuilder.Entity<TipoHabilidade>().HasData(

                 new TipoHabilidade
                 {
                     idTipo = 1,
                     Tipo = "Ataque"
                 },
                 new TipoHabilidade
                 {
                     idTipo = 2,
                     Tipo = "Defesa"
                 },
                 new TipoHabilidade
                 {
                     idTipo = 3,
                     Tipo = "Cura"
                 },
                 new TipoHabilidade
                 {
                     idTipo = 4,
                     Tipo = "Magia"
                 });


            modelBuilder.Entity<Habilidade>().HasData(
                new Habilidade
                {
                    idHabilidade = 1,
                    habilidade = "Lança Mortal",
                    idTipo = 1
                },
                new Habilidade
                {
                    idHabilidade = 2,
                    habilidade = "Escudo Supremo",
                    idTipo = 2
                },
                new Habilidade
                {
                    idHabilidade = 3,
                    habilidade = "Recuperar Vida",
                    idTipo = 3
                });

            modelBuilder.Entity<Classe>().HasData(
                new Classe
                {
                    idClasse = 1,
                    Nome = "Bárbaro"
                },
                new Classe
                {
                    idClasse = 2,
                    Nome = "Cruzado"
                },
                new Classe
                {
                    idClasse = 3,
                    Nome = "Caçadora de Demônios"
                },
                new Classe
                {
                    idClasse = 4,
                    Nome = "Monge"
                },
                new Classe
                {
                    idClasse = 5,
                    Nome = "Necromante"
                },
                new Classe
                {
                    idClasse = 6,
                    Nome = "Feiticeiro"
                },
                new Classe
                {
                    idClasse = 7,
                    Nome = "Arcanista"
                });


            modelBuilder.Entity<ClasseHabilidade>().HasData(
                new ClasseHabilidade
                {

                    idClassHab = 1,
                    idClasse = 1,
                    idHabilidade = 1
                },
                new ClasseHabilidade
                {
                    idClassHab = 2,
                    idClasse = 1,
                    idHabilidade = 2
                },
                new ClasseHabilidade
                {
                    idClassHab = 3,
                    idClasse = 2,
                    idHabilidade = 2
                },
                new ClasseHabilidade
                {
                    idClassHab = 4,
                    idClasse = 3,
                    idHabilidade = 1
                },
                new ClasseHabilidade
                {
                    idClassHab = 5,
                    idClasse = 4,
                    idHabilidade = 2
                },
                new ClasseHabilidade
                {
                    idClassHab = 6,
                    idClasse = 4,
                    idHabilidade = 3
                },
                new ClasseHabilidade
                {
                    idClassHab = 7,
                    idClasse = 6,
                    idHabilidade = 3
                });



            modelBuilder.Entity<Personagem>().HasData(


                 new Personagem
                 {
                     idPersonagem = 1,
                     Nome = "DeuBug",
                     CapacidadeMaxVida = Convert.ToInt32("100"),
                     CapacidadeMaxMana = Convert.ToInt32("80"),
                     DataAtualizacao = Convert.ToDateTime("2021/03/01"),
                     DataCriacao = Convert.ToDateTime("2019/01/18"),
                     idClasse = 1
                 },
                 new Personagem
                 {
                     idPersonagem = 2,
                     Nome = "BitBug",
                     CapacidadeMaxVida = Convert.ToInt32("70"),
                     CapacidadeMaxMana = Convert.ToInt32("100"),
                     DataAtualizacao = Convert.ToDateTime("2021/03/01"),
                     DataCriacao = Convert.ToDateTime("2016/03/17"),
                     idClasse = 4
                 },
                 new Personagem
                 {
                     idPersonagem = 3,
                     Nome = "Fer8",
                     CapacidadeMaxVida = Convert.ToInt32("75"),
                     CapacidadeMaxMana = Convert.ToInt32("60"),
                     DataAtualizacao = Convert.ToDateTime("2021/03/01"),
                     DataCriacao = Convert.ToDateTime("2018/03/17"),
                     idClasse = 7
                 });

            base.OnModelCreating(modelBuilder);

        }
    }
}