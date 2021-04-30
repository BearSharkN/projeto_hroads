using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {

        hroadsContext ctx = new hroadsContext();


        //Atualiza uma Habilidade
        public void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada)
        {

            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidade.Find(id);

            if (tipoHabilidadeBuscada.Tipo != null)
            {
                tipoHabilidadeBuscada.Tipo = tipoHabilidadeAtualizada.Tipo;
            }
            
            ctx.Update(tipoHabilidadeBuscada);

            ctx.SaveChanges();
        }

        //Busca uma Habilidade por id
        public TipoHabilidade BuscarPorId(int id)
        {
            return ctx.TipoHabilidade.FirstOrDefault(t => t.idTipo == id);
        }

        //Cadastra um novo tipo de Habilidade
        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidade.Add(novoTipoHabilidade);

            ctx.SaveChanges();
        }

        //Deleta um tipo de Habilidade
        public void Deletar(int id)
        {
            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidade.FirstOrDefault(t => t.idTipo == id);

            ctx.TipoHabilidade.Remove(tipoHabilidadeBuscada);

            ctx.SaveChanges();
        }

        //Retorna uma lista de todos os tipo de habilidade
        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidade.ToList();
        }
    }
}
