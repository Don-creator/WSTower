using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WSTowerWebApi.DataBaseFirst.Interfaces
{
    // Interface responsável pelo SelecaoRepository
    interface ISelecaoRepository
    {
        // Abaixo dessa linha são criados os metodos
        List<Selecao> Listar();

        void Cadastrar(Selecao novaSelecao);

        void Atualizar(int id, Selecao selecaoAtualizada);

        void Deletar(int id);

        Selecao BuscarPorId(int id);

    }
}
