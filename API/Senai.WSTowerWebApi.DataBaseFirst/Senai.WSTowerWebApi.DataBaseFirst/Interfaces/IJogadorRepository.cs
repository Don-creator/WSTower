using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WSTowerWebApi.DataBaseFirst.Interfaces
{
    // Interface responsável pelo JogadorRepository
    interface IJogadorRepository
    {
        // Abaixo dessa linha são criados os metodos
        List<Jogador> Listar();

        void Cadastrar(Jogador novoJogador);

        void Atualizar(int id, Jogador jogadorAtualizado);

        void Deletar(int id);

        Jogador BuscarPorId(int id);


        
    }
}
