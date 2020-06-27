using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using Senai.WSTowerWebApi.DataBaseFirst.Interfaces;
using Senai.WSTowerWebApi.DataBaseFirst.Repositories;

namespace Senai.WSTowerWebApi.DataBaseFirst.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]

    public class JogadorController : ControllerBase
    {
        // Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        private IJogadorRepository _jogadorRepository;

        // Instancia este objeto para que haja a referência aos métodos no repositório
        public JogadorController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        // Abaixo dessa linha estão todos os metodos definidos na interface
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogadorRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return StatusCode(200, _jogadorRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(Jogador novoJogador)
        {
            _jogadorRepository.Cadastrar(novoJogador);

            return StatusCode(201);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogadorRepository.Deletar(id);

            return StatusCode(204);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogador jogadorAtualizado)
        {
            Jogador jogadorBuscado = _jogadorRepository.BuscarPorId(id);

            if (jogadorBuscado != null)
            {
                try
                {
                    _jogadorRepository.Atualizar(id, jogadorAtualizado);

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