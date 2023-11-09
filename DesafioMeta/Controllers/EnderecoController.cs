using DesafioMeta.Dtos;
using DesafioMeta.Interface;
using DesafioMeta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMeta.Controllers
{
    /// <summary>
    /// Aqui esta a Controller referente a  métodos e chamadas executadas para a entedidade de endereço.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        /// <summary>
        /// inicializando variavel da interface.
        /// </summary>
        private readonly IEnderecoService _enderecoService;

        /// <summary>
        /// Inicializando a interface no construtor.
        /// </summary>
        /// <param name="enderecoService"></param>
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// Método http get para retornar todos os endereços.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var enderecos = _enderecoService.GetAll();
                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// Método http get para retornar um endereço pelo parametro de busca id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var endereco = _enderecoService.GetById(id);
                return Ok(endereco);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        /// <summary>
        /// Método http post para criar um novo registro de endereço.
        /// </summary>
        /// <param name="enderecodto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoDto enderecodto)
        {
            try
            {
                var endereco = _enderecoService.Create(enderecodto);
                return Ok(endereco);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método http put para atualizar um registro de endereço, utilizando id como parametro de busca.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecodto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnderecoDto enderecodto)
        {
            try
            {
                 _enderecoService.Update(id, enderecodto);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método para deletar um registro de endereço, utilizando id como parametro de busca.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _enderecoService.Delete(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
