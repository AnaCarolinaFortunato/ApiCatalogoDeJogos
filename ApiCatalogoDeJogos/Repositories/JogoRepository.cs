using ApiCatalogoDeJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("48119358-6ba5-4f5e-a46c-f3de3b5ffe37"), new Jogo { Id = Guid.Parse("48119358-6ba5-4f5e-a46c-f3de3b5ffe37"), Nome = "Fifa 21", Produtora = "EA", Preco = 400} }, 

            {Guid.Parse("7252c190-e101-4610-971c-44a9717fe474"), new Jogo { Id = Guid.Parse("7252c190-e101-4610-971c-44a9717fe474"), Nome = "Fifa 20", Produtora = "EA", Preco = 300} },
            {Guid.Parse("8a3f44bd-44b7-41b1-9c29-76e8befa7ea9"), new Jogo { Id = Guid.Parse("8a3f44bd-44b7-41b1-9c29-76e8befa7ea9"), Nome = "Fifa 19", Produtora = "EA", Preco = 200} },
            {Guid.Parse("d7608d56-718c-437d-b409-854c817f9f85"), new Jogo { Id = Guid.Parse("d7608d56-718c-437d-b409-854c817f9f85"), Nome = "Fifa 18", Produtora = "EA", Preco = 150} },
            {Guid.Parse("0a9ef012-9098-493f-a6f7-5960147f2f6f"), new Jogo { Id = Guid.Parse ("0a9ef012-9098-493f-a6f7-5960147f2f6f"),Nome = "Fifa 17", Produtora = "EA", Preco = 100} },

        };

       public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter (Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>>Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();
            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }
            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
         {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
         }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }
        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            
        }


    }
}
