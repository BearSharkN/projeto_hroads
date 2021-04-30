using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        // Retorna uma lista de tipos de habilidades
        List<TipoHabilidade> Listar();

        
        // Busca um tipo de habilidade pelo seu id
        TipoHabilidade BuscarPorId(int id);

        
        // Cadastra um novo tipo de  habilidade
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

       
        // Atualiza um tipo de habilidade existente
        void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada);

       
        // Deleta um tipo de habilidade existente
        void Deletar(int id);
    }
}
