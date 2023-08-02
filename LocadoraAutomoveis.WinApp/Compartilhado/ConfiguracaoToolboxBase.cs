namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public abstract class ConfiguracaoToolboxBase
    {
        #region tooltips dos botões
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public virtual string TooltipVisualizar { get; }

        public virtual string TooltipDevolver { get; }

        public virtual string TooltipCupom { get; }

        public virtual string TooltipParceiros { get; }

        public virtual string TooltipCombustiveis { get; }

        #endregion

        #region estados dos botões
        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool VisualizarHabilitado { get { return true; } }

        public virtual bool DevolverHabilitado { get { return true; } }

        public virtual bool CumpoHabilitado { get { return true; } }

        public virtual bool ParceirosHabilitado { get { return true; } }

        public virtual bool CombustiveisHabilitado { get { return true; } }

        #endregion
    }
}
