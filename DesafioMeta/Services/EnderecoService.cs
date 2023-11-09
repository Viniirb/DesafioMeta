using DesafioMeta.Dtos;
using DesafioMeta.Entities;
using DesafioMeta.Entities.Context;
using DesafioMeta.Interface;

namespace DesafioMeta.Services
{
    /// <summary>
    /// Esta é uma classe Service, onde é feita a implementação dos métodos da interface IEnderecoService
    /// </summary>
    public class EnderecoService : IEnderecoService
    {
        /// <summary>
        /// Inicialização da variavei do contexto de dados.
        /// </summary>
        private readonly DesafioDbContext _contexto;

        /// <summary>
        /// Iniciando Construtor da Classe
        /// </summary>
        /// <param name="contexto"></param>
        public EnderecoService(DesafioDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Inicilizando método responsavel por consultar todos os registros de Endereço.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Endereco> GetAll()
        => _contexto.Endereco.ToList();


        /// <summary>
        /// Método responsavel por consultar um registro de Endereço, utilizando ID como parametro de busca.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Endereco GetById(int id)
        {
            return _contexto.Endereco.First(x => x.Id == id);
        }

        /// <summary>
        /// Inicializando método de criação do objeto de Endereço, utilizando DTO para transitar os dados.
        /// </summary>
        /// <param name="enderecodto"></param>
        /// <returns></returns>
        public Endereco Create(EnderecoDto enderecodto)
        {
            var end = new Endereco()
            {
                Id = 0,
                PessoaId = enderecodto.PessoaId,
                Logradouro = enderecodto.Logradouro,
                Numero = enderecodto.Numero,
                Complemento = enderecodto.Complemento,
                Bairro = enderecodto.Bairro,
                Cidade = enderecodto.Cidade,
                Estado = enderecodto.Estado,
                CodigoPostal = enderecodto.CodigoPostal
            };

            _contexto.Endereco.Add(end);
            _contexto.SaveChanges();

            return end;
        }

        /// <summary>
        /// Inicilizando método responsavel por atualizar um registro de Endereço, utilizando ID como parametro de busca do objeto ja existente e DTO para transitar os dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecodto"></param>
        public void Update(int id, EnderecoDto enderecodto)
        {
            var end = GetById(id);
            end.PessoaId = enderecodto.PessoaId;
            end.Logradouro = enderecodto.Logradouro;
            end.Numero = enderecodto.Numero;
            end.Complemento = enderecodto.Complemento;
            end.Bairro = enderecodto.Bairro;
            end.Cidade = enderecodto.Cidade;
            end.Estado = enderecodto.Estado;
            end.CodigoPostal = enderecodto.CodigoPostal;

            _contexto.Endereco.Update(end);
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Inicializando método de deleção do objeto de Endereço, utilizando ID como parametro de busca do objeto ja existente.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _contexto.Endereco.Remove(GetById(id));
            _contexto.SaveChanges();
        }
    }
}
