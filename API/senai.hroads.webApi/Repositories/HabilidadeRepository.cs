using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace senai.hroads.webApi_.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        hroadsContext ctx = new hroadsContext();

        //Atualiza uma Habilidade
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
           Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

           if(habilidadeAtualizada.habilidade != null)
           {
               habilidadeBuscada.habilidade = habilidadeAtualizada.habilidade;
           }
           ctx.Update(habilidadeBuscada);

           ctx.SaveChanges();
        }

        //Busca uma Habilidade por ID
        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.idHabilidade == id);
        }

        //Cadastra uma Habilidade
        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        // Deleta uma Habilidade existente
        public void Deletar(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.FirstOrDefault(h => h.idHabilidade == id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        //Retorna uma Lista de Habilidade
        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        //Lista todos as as 
        public List<Habilidade> ListarTipoHabilidade()
        {
            return ctx.Habilidades.Include(t => t.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
