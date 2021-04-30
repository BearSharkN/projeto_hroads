using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        //Retorna uma lista de habilidade
        List<Habilidade> Listar();

     //Retorna uma Habilidade por seu id
        Habilidade BuscarPorId(int id);

        //Cadastra uma nova Habilidade
        void Cadastrar(Habilidade novaHabilidade);

        //Atualiza uma Habilidade
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        //Deleta uma Habilidade
        void Deletar(int id);

        //Lista todas os tipos de  Habilidades
        List<Habilidade> ListarTipoHabilidade();
    }
}
