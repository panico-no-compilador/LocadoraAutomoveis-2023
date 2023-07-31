namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public abstract class ConfiguracaoToolboxBase
    {
        #region tooltips dos botões
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }
        #endregion

        #region estados dos botões
        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        #endregion
    }
}
