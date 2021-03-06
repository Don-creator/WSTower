﻿using System;
using System.Collections.Generic;

namespace Senai.WSTowerWebApi.DataBaseFirst.Domains
{
    //Classe que representa a entidade Jogo
    public partial class Jogo
    {
        public int Id { get; set; }
        public int? SelecaoCasa { get; set; }
        public int? SelecaoVisitante { get; set; }
        public int PlacarCasa { get; set; }
        public int PlacarVisitante { get; set; }
        public int PenaltisCasa { get; set; }
        public int PenaltisVisitante { get; set; }
        public DateTime? Data { get; set; }
        public string Estadio { get; set; }

        public Selecao SelecaoCasaNavigation { get; set; }
        public Selecao SelecaoVisitanteNavigation { get; set; }
    }
}
