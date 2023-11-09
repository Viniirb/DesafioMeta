using DesafioMeta.Dtos;
using DesafioMeta.Entities;
using DesafioMeta.Interface;
using DesafioMeta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMeta.Controllers
{
    /// <summary>
    /// Controller onde executa todos os métodos e chamadas da api referentes a entidade de Pessoa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Inicializando a interface de serviço de pessoa
        /// </summary>
        private readonly IPessoaService _pessoaService;

        /// <summary>
        /// Inicializando o construtor da classe
        /// </summary>
        /// <param name="pessoaService"></param>
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        /// <summary>
        /// Método http get para retornar todas as pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pessoa = _pessoaService.GetAll();
                return Ok(pessoa);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Metodo http get para retornar apenas um registro de pessoa, utilizando ID como parametro de busca. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var pessoa = _pessoaService.GetById(id);
                return Ok(pessoa);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método http post para criar um novo registro de pessoa
        /// </summary>
        /// <param name="pessoadto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PessoaDto pessoadto)
        {
            try
            {
                var pessoa = _pessoaService.Create(pessoadto);
                return Ok(pessoa);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método http put para atualizar um registro de pessoa, utilizando ID como parametro de busca.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pessoadto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PessoaDto pessoadto)
        {
            try
            {
                 _pessoaService.Update(id, pessoadto);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método http delete para deletar um registro de pessoa, utilizando ID como parametro de busca.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pessoaService.Delete(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
