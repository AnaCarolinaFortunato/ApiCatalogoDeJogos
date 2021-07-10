using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Exceptions
{
    public class JogoJaCadastradoException: Exception
    {
        public JogoJaCadastradoException()
            :base("Este jogo ja esta cadastrado")
        { }
    }
}
