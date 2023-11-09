using DesafioMeta.Dtos;
using DesafioMeta.Entities;
using DesafioMeta.Entities.Context;
using DesafioMeta.Interface;

namespace DesafioMeta.Services
{
    /// <summary>
    /// Esta é uma classe Service onde é feita a implementação dos métodos da interface IPessoaService
    /// </summary>
    public class PessoaService : IPessoaService
    {
        /// <summary>
        /// Inicializando variavel do Contexto de Dados
        /// </summary>
        private readonly DesafioDbContext _contexto;

        /// <summary>
        /// Inicializando o construtor da classe
        /// </summary>
        /// <param name="contexto"></param>
        public PessoaService(DesafioDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Inicializando método responsavel por consultar todos os registros da tabela Pessoa.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAll()
       => _contexto.Pessoa.ToList();

        /// <summary>
        /// Inicializando método responsavel por consultar um registro da tabela Pessoa passando como parametro de busca o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa GetById(int id)
        {
            return _contexto.Pessoa.First(p => p.Id == id);
        }

        /// <summary>
        /// Inicializando método responsavel por Criar um novo registro da entidade de Pessoa no banco de dados, utilizando DTO como objeto de transição de dados.
        /// </summary>
        /// <param name="pessoadto"></param>
        /// <returns></returns>
        public Pessoa  Create(PessoaDto pessoadto)
        {
            var pessoa = new Pessoa() { 
                Id = 0,
                Nome = pessoadto.Nome,
                Idade = pessoadto.Idade,
                CPF = pessoadto.CPF,
                Email = pessoadto.Email,
                Nacionalidade = pessoadto.Nacionalidade,
                Genero = pessoadto.Genero,
            };
            

            _contexto.Pessoa.Add(pessoa);
            _contexto.SaveChanges();

            return pessoa;

        }

        /// <summary>
        /// Inicializando método responsavel por atualizar um registro da entidade de Pessoa, utilizando um ID como parametro de busca e DTO como objeto de transição de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoadto"></param>
        public void Update(int id, PessoaDto pessoadto)
        {
            var pessoa = GetById(id);
            pessoa.Nome = pessoadto.Nome;
            pessoa.CPF = pessoadto.CPF;
            pessoa.Idade = pessoadto.Idade;
            pessoa.Email = pessoadto.Email;
            pessoa.Nacionalidade = pessoadto.Nacionalidade;
            pessoa.Genero = pessoadto.Genero;

            _contexto.Pessoa.Update(pessoa);
            _contexto.SaveChanges();

        }

        /// <summary>
        /// Inicializando método que passando ID como parametro de busca, deleta um registro da entidade de Pessoa.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _contexto.Pessoa.Remove(GetById(id));
            _contexto.SaveChanges();
        }

    }
}
