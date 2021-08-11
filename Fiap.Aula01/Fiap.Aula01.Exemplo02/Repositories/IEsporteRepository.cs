using Fiap.Aula01.Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exemplo02.Repositories
{

    //Criar a classe EsporteRepository e implementar a interface
    interface IEsporteRepository
    {
        void Cadastrar(Esporte esporte);

        IList<Esporte> Listar();
    }
}
