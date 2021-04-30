using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repositories
{
   
    public class ClasseRepository : IClasseRepository
    {

        hroadsContext ctx = new hroadsContext();

        //Atualiza uma classe existe
        public void Atualizar(int id, Classe classeAtualizada)
        {
            
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtualizada.Nome != null)
            {
                classeBuscada.Nome = classeAtualizada.Nome;
            }
            ctx.Update(classeBuscada);

            ctx.SaveChanges();
        }

        
        //Busca uma classe por id
        public Classe BuscarPorId(int id)
        {

            return ctx.Classes.FirstOrDefault(c => c.idClasse == id);
        }

        //Cadastra uma nova classe
        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        //Deleta uma classe existente
        public void Deletar(int id)
        {
            Classe classeBuscada = ctx.Classes.FirstOrDefault(c => c.idClasse == id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        //Retorna uma lista de Classe
        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }
    }
}
