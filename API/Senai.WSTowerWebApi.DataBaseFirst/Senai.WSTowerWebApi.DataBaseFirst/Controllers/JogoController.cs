using Microsoft.AspNetCore.Mvc;
using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using Senai.WSTowerWebApi.DataBaseFirst.Interfaces;
using Senai.WSTowerWebApi.DataBaseFirst.Repositories;
using System;

namespace Senai.WSTowerWebApi.DataBaseFirst.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController// Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]

    public class JogoController : ControllerBase
    {
        // Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        private IJogoRepository _jogoRepository;

        // Instancia este objeto para que haja a referência aos métodos no repositório
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        // Abaixo dessa linha estão todos os metodos definidos na interface
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return StatusCode(200, _jogoRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(id, jogoAtualizado);

                    return StatusCode(200);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return StatusCode(404);
        }
    }
}
