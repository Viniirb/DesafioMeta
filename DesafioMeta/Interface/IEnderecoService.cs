using DesafioMeta.Dtos;
using DesafioMeta.Entities;

namespace DesafioMeta.Interface
{
    /// <summary>
    /// Esta é uma interface que executa métodos que criam,atualizam, buscam, e excluem registros da entidade de Endereço no banco de dados
    /// </summary>
    public interface IEnderecoService
    {
        /// <summary>
        /// Método responsavel por fazer uma consulta no banco de dados e trazer todos os endereços cadastrados
        /// </summary>
        /// <returns></returns>
        IEnumerable<Endereco> GetAll();

        /// <summary>
        /// Método responsavel por fazer uma consulta no banco de dados baseada no id e trazer um endereço cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Endereco GetById(int id);

        /// <summary>
        /// Método responsavel por criar um registro de endereço no banco de dados
        /// </summary>
        /// <param name="enderecodto"></param>
        /// <returns></returns>
        Endereco Create(EnderecoDto enderecodto);

        /// <summary>
        /// Método responsavel por atualizar um registro de endereço no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecodto"></param>
        void Update(int id, EnderecoDto enderecodto);

        /// <summary>
        /// Método responsavel por excluir um registro de endereço no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
