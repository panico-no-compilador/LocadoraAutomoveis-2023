using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        protected string mensagemRodape;

        public abstract void Inserir();

        public virtual void Editar() { }

        public abstract void Excluir();

        public virtual void Visualizar() { }
        
        public virtual void Devolver() { }

        public virtual void GerarCupom() { }

        public virtual void GerarParceiro() { }

        public virtual void ConfigurarPrecoCombustiveis() { }

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();

        public string ObterMensagemRodape()
        {
            return mensagemRodape;
        }
    }
}
