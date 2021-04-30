using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
       //Retorna uma lista de tipos de usuario
        List<TipoUsuario> Listar();

       //Busca um tipo de usuario por id
        TipoUsuario BuscarPorId(int id);

        //Cadastra um tipo usuario por ID
        void Cadastrar(TipoUsuario novoTipoUsuario);

       //Atualiza um tipo usuario por id
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        //deleta um tipo de usuario por id
        void Deletar(int id);
    }
}