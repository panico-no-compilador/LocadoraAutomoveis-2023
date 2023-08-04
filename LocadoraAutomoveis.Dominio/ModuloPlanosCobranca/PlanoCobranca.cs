using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public GrupoAutomovel CategoriaGrupAuto { get; set; }
        public TipoPlanoEnum TipoPlano { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoKm { get; set; }
        public int KmDisponiveis { get; set; }
        public PlanoCobranca()
        {
            
        }
        public override void Atualizar(PlanoCobranca registro)
        {
            this.CategoriaGrupAuto = registro.CategoriaGrupAuto;
            this.TipoPlano = registro.TipoPlano;
            this.PrecoDiaria = registro.PrecoDiaria;
            this.PrecoKm = registro.PrecoKm;
            this.KmDisponiveis = registro.KmDisponiveis;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CategoriaGrupAuto, TipoPlano, PrecoDiaria, PrecoKm, KmDisponiveis);
        }
        public override string ToString()
        {
            return TipoPlano.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca grupAuto &&
                   Id == grupAuto.Id &&
            TipoPlano == grupAuto.TipoPlano &&
            PrecoDiaria == grupAuto.PrecoDiaria &&
            PrecoKm == grupAuto.PrecoKm &&
            KmDisponiveis == grupAuto.KmDisponiveis;
        }
    }
}
