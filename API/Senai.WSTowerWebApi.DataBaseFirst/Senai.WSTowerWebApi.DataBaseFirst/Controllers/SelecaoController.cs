using Microsoft.AspNetCore.Mvc;
using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using Senai.WSTowerWebApi.DataBaseFirst.Interfaces;
using Senai.WSTowerWebApi.DataBaseFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WSTowerWebApi.DataBaseFirst.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]

    public class SelecaoController : ControllerBase
    {
        // Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        private ISelecaoRepository _selecaoRepository;

        // Instancia este objeto para que haja a referência aos métodos no repositório
        public SelecaoController()
        {
            _selecaoRepository = new SelecaoRepository();
        }

        // Abaixo dessa linha estão todos os metodos definidos na interface
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_selecaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return StatusCode(200, _selecaoRepository.BuscarPorId(Id));
        }
        
        [HttpPost]
        public IActionResult Post(Selecao novaSelecao)
        {
            _selecaoRepository.Cadastrar(novaSelecao);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _selecaoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Selecao selecaoAtualizada)
        {
            Selecao selecaoBuscada = _selecaoRepository.BuscarPorId(id);

            if (selecaoBuscada != null)
            {
                try
                {
                    _selecaoRepository.Atualizar(id, selecaoAtualizada);

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
