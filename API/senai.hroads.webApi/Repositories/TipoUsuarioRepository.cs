using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace senai.hroads.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        hroadsContext ctx = new hroadsContext();

       //Atualiza um tipo de usuário
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.tipoUsuario.Find(id);

            if (tipoUsuarioBuscado.titulo != null)
            {
                tipoUsuarioBuscado.titulo = tipoUsuarioAtualizado.titulo;
            }

            ctx.Update(tipoUsuarioAtualizado);

            ctx.SaveChanges();
        }

        //Busca um usuário por ID
        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.tipoUsuario.FirstOrDefault(t => t.idTipoUsuario == id);
        }

       //Cadastra um tipo de usuario
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.tipoUsuario.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        //Deleta um tipo de usuario
        public void Deletar(int id)
        { 
            TipoUsuario tipoUsuarioBuscada = ctx.tipoUsuario.FirstOrDefault (t => t.idTipoUsuario == id);

            ctx.tipoUsuario.Remove(tipoUsuarioBuscada);

            ctx.SaveChanges();
        }
        //Retorna uma lista de tipos de usuario

        public List<TipoUsuario> Listar()
        {
            return ctx.tipoUsuario.ToList();
        }
    }
}