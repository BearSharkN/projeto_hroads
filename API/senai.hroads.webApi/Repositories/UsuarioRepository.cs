using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
    
        hroadsContext ctx = new hroadsContext();

        //Atualiza um tipo de usuario
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.usuarios.Find(id);

            if (usuarioAtualizado.email != null)
            {
                usuarioBuscado.email = usuarioAtualizado.email;
            }
            if (usuarioAtualizado.senha != null)
            {
                usuarioBuscado.senha = usuarioAtualizado.senha;
            }
            ctx.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            var usuarioBuscado = ctx.usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);

            return usuarioBuscado;
        }

        //Busca um usuario por ID
        public Usuario BuscarPorId(int id)
        {
            return ctx.usuarios.FirstOrDefault(u => u.idUsuario == id);
        }

        //Cadastra um usuario
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

       //Deleta um usuario
        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.usuarios.FirstOrDefault(u => u.idUsuario == id);

            ctx.usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        //Retorna uma lista de usuario
        public List<Usuario> Listar()
        {
           
            return ctx.usuarios.ToList();
        }

        // Lista todos os tipos de usuario
        public List<Usuario> ListarTipoUsuario()
        {
            return ctx.usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        
    }
}