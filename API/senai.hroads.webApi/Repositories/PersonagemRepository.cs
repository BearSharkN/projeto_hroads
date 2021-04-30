using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace senai.hroads.webApi_.Repositories
{
     public class PersonagemRepository : IPersonagemRepository
    {

        hroadsContext ctx = new hroadsContext();

        
        //Atualiza personagem existente
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagens.Find(id);
            
            if (personagemAtualizado.Nome != null)
            {
                personagemBuscado.Nome = personagemAtualizado.Nome;
            }

            if (personagemAtualizado.CapacidadeMaxVida != null)
            {
                personagemBuscado.CapacidadeMaxVida = personagemAtualizado.CapacidadeMaxVida;
            }
           
            if (personagemAtualizado.CapacidadeMaxMana != null)
            {
                personagemBuscado.CapacidadeMaxMana = personagemAtualizado.CapacidadeMaxMana;
            }
      
            if (personagemAtualizado.DataAtualizacao != null)
            {
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;
            }

            if (personagemAtualizado.DataCriacao != null)
            {
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
            }

            ctx.Update(personagemBuscado);

            ctx.SaveChanges();
        }

       //Busca um personagem por id
        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.FirstOrDefault(p => p.idPersonagem == id);
        }

       //Cadastra um novo personagem
        public void Cadastrar(Personagem novaPersonagem)
        {
            ctx.Personagens.Add(novaPersonagem);

            ctx.SaveChanges();
        }

        //Deleta um personagem
        public void Deletar(int id)
        {
            Personagem personagemBuscado = ctx.Personagens.FirstOrDefault(p => p.idPersonagem == id);

            ctx.Personagens.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

       //Retorna uma lista de personagem
        public List<Personagem> Listar()
        {
            return ctx.Personagens.ToList();
        }

        //Lista todos os tipos de personagem
        public List<Personagem> ListarClasse()
        {
            return ctx.Personagens.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
