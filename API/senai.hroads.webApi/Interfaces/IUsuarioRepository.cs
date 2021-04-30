using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        //Retorna uma lista de usuario
        List<Usuario> Listar();

        //Busca usuario por id
        Usuario BuscarPorId(int id);

        //Cadastra um novo usuario
        void Cadastrar(Usuario novoUsuario);

        //Atualiza um usuari por id
        void Atualizar(int id, Usuario usuarioAtualizado);

       //Deleta um usuario existente
        void Deletar(int id);

       //Lista todos os tipos de usuario
        List<Usuario> ListarTipoUsuario();

        //valida se os dados estão corretos(email e senha)
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}