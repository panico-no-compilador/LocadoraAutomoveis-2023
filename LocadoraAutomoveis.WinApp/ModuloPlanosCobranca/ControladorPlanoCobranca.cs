﻿using LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        IRepositorioGrupoAutomoveis _repositorioGrupo;
        IRepositorioPlanoCobranca _repositorioPlano;
        ServicoPlanoCobranca servicoPlano;
        TabelaPlanoCobranca tabelaPlanoCobranca;
        public ControladorPlanoCobranca(
            IRepositorioGrupoAutomoveis repositorioGrupo,
            IRepositorioPlanoCobranca repositorioPlano,
            ServicoPlanoCobranca servicoPlano
            )
        {
            _repositorioGrupo = repositorioGrupo;
            _repositorioPlano = repositorioPlano;
            this.servicoPlano = servicoPlano;
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobranca();

            CarregarPlanoCobranca();

            return tabelaPlanoCobranca;
        }
        private void CarregarPlanoCobranca()
        {
            List<PlanoCobranca> planosCobrancaList = _repositorioPlano.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(planosCobrancaList);

            mensagemRodape = string.Format("Visualizando {0} Plano{1} de Cobrança{1}", planosCobrancaList.Count, planosCobrancaList.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
