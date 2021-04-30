using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        
        ///Retorna uma lista de personagens
        List<Personagem> Listar();

        
        // Busca um personagem pelo seu id
        Personagem BuscarPorId(int id);

        //Cadastra um Personagem
        void Cadastrar(Personagem novaPersonagem);

       //Atualiza um personagem
        void Atualizar(int id, Personagem personagemAtualizado);

       //Deleta um personagem
        void Deletar(int id);

        //Lista todos os personagens com suas classes
        List<Personagem> ListarClasse();
    }
}