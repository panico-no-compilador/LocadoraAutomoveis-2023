﻿using LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System.Drawing.Drawing2D;

namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    public class ControladorTaxasServicos : ControladorBase
    {
        IRepositorioTaxasServicos repositorioTaxasServicos;
        IValidadorTaxasServicos validadorTaxasServicos;
        ServicoTaxasServicos servicoTaxasServicos;

        TabelaTaxasServicosControl tabelaTaxasServicos;
        public ControladorTaxasServicos(
            IRepositorioTaxasServicos repositorioTaxasServicos,
            IValidadorTaxasServicos validadorTaxasServicos,
            ServicoTaxasServicos servicoTaxasServicos
            )
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
            this.servicoTaxasServicos = servicoTaxasServicos;
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
            return new ConfiguracaoToolboxTaxasServicos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxasServicos == null)
                tabelaTaxasServicos = new TabelaTaxasServicosControl();

            CarregarTaxasServicos();

            return tabelaTaxasServicos;
        }

        private void CarregarTaxasServicos()
        {
            List<TaxasServicos> taxasServicos = repositorioTaxasServicos.SelecionarTodos();

            tabelaTaxasServicos.AtualizarRegistros(taxasServicos);

            mensagemRodape = string.Format("Visualizando {0} Taxa{1} de Serviço{1}", taxasServicos.Count, taxasServicos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
