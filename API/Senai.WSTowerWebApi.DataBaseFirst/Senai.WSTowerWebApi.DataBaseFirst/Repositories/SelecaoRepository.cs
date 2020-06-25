using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using Senai.WSTowerWebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WSTowerWebApi.DataBaseFirst.Repositories
{
    public class SelecaoRepository : ISelecaoRepository
    {
        WSTowerContext ctx = new WSTowerContext();

        public void Atualizar(int id, Selecao selecaoAtualizada)
        {
            Selecao selecaoBuscada = ctx.Selecao.Find(id);

            if (selecaoAtualizada.Nome != null)
            {
                selecaoBuscada.Nome = selecaoAtualizada.Nome;
            }

            ctx.Selecao.Update(selecaoBuscada);

            ctx.SaveChanges();
        }

        public Selecao BuscarPorId(int id)
        {
            return ctx.Selecao.FirstOrDefault(s => s.Id == id);
        }

        public void Cadastrar(Selecao novaSelecao)
        {
            ctx.Selecao.Add(novaSelecao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Selecao.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Selecao> Listar()
        {
            return ctx.Selecao.ToList();
        }
    }
}
