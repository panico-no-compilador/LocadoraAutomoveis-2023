using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public class ControladorCupom : ControladorBase
    {
        private IRepositorioCupom repositorioCupom;
        private IRepositorioParceiro RepositorioParceiro;

        private TabelaCupomControl tabelaCupom;

        private ServicoCupom servicoCupom;
         
        public ControladorCupom(IRepositorioCupom repositorioCupom, IRepositorioParceiro repositorioParceiro, ServicoCupom servicoCupom)
        {
            this.repositorioCupom = repositorioCupom;
            this.servicoCupom = servicoCupom;
            this.RepositorioParceiro = repositorioParceiro;
        }
        public override void Inserir()
        {
            List<Parceiro> parceiro = RepositorioParceiro.SelecionarTodos();
            TelaCupomForm tela = new TelaCupomForm(parceiro);

            tela.onGravarRegistro += servicoCupom.Inserir;

            tela.ConfigurarCupom(new Cupom());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Carregarcupons();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionada = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionada == null)
            {
                MessageBox.Show("Selecione um cupom primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<Parceiro> parceiros = RepositorioParceiro.SelecionarTodos();
            TelaCupomForm tela = new TelaCupomForm(parceiros);

            tela.onGravarRegistro += servicoCupom.Editar;

            tela.ConfigurarCupom(cupomSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Carregarcupons();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();
            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um cupom primeiro",
                "Exclusão de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a cupom?",
               "Exclusão de cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCupom.Excluir(cupomSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de cupons",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
                Carregarcupons();
        }
        private void Carregarcupons()
            {
            List<Cupom> cupons = repositorioCupom.SelecionarTodos(incluirParceiro: true);

                tabelaCupom.AtualizarRegistros(cupons);

                mensagemRodape = string.Format("Visualizando {0} cupom{1}", cupons.Count, cupons.Count == 1 ? "" : "s");

                TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
            }

        

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCupom();
        }

        public override UserControl ObtemListagem()
        {
           if(tabelaCupom == null)
                tabelaCupom = new TabelaCupomControl();
            
                Carregarcupons();
                return tabelaCupom;
            
                
        }
    }
}
