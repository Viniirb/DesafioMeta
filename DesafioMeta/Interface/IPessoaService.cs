using DesafioMeta.Dtos;
using DesafioMeta.Entities;

namespace DesafioMeta.Interface
{
    /// <summary>
    /// Esta é uma interface que executa métodos que criam,atualizam, buscam, e excluem registros da entidade de Pessoa no banco de dados
    /// </summary>
    public interface IPessoaService
    {
        /// <summary>
        /// Método responsavel por realizar uma consulta no banco de dados e retornar todas as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pessoa> GetAll();

        /// <summary>
        /// Método responsavel por realizar uma consulta no banco de dados baseada no id e retornar uma pessoa cadastrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pessoa GetById(int id);

        /// <summary>
        /// Método responsavel por criar um registro de pessoa  no banco de dados
        /// </summary>
        /// <param name="pessoadto"></param>
        /// <returns></returns>
         Pessoa Create(PessoaDto pessoadto);

        /// <summary>
        /// Metodo responsavel por atualizar um registro de pessoa no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoadto"></param>
        void Update(int id, PessoaDto pessoadto);
        
        /// <summary>
        /// Metodo responsavel por excluir um registro de pessoa do banco de dados
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }

    
}
