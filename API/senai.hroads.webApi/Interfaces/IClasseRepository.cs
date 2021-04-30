using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
  
    interface IClasseRepository
    {
       //Retorna uma Lista de Classes
        List<Classe> Listar();

     
        // Busca uma classe atraves do id
        Classe BuscarPorId(int id);

        //Cadastra uma nova classe
        void Cadastrar(Classe novaClasse);

        //Atualiza uma classe
        void Atualizar(int id, Classe classeAtualizada);

        //Deleta uma classe
        void Deletar(int id);
    }
}
