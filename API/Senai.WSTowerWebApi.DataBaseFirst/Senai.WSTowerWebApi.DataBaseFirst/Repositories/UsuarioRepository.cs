using Senai.WSTowerWebApi.DataBaseFirst.Domains;
using Senai.WSTowerWebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.WSTowerWebApi.DataBaseFirst.Repositories
{
    // Repositório dos Estúdios
    public class UsuarioRepository : IUsuarioRepository
    {
        // Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        WSTowerContext ctx = new WSTowerContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Nome = usuarioAtualizado.Nome;

            usuarioBuscado.Email = usuarioAtualizado.Email;

            usuarioBuscado.Apelido = usuarioAtualizado.Apelido;

            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            usuarioBuscado.Foto = usuarioAtualizado.Foto;

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Id == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
