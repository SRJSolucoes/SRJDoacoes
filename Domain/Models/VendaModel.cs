using System;
using System.Collections.Generic;
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ParametroDTO;

namespace Domain.Models {

    public class VendaModel
    {
        private Guid _idvenda;
        private ISet<CaixaDTOReference> _caixa;
        private ISet<ParametroDTOReference> _parametro;
        private String _cpf;
        private String _nome;
        private DateTime _datahota;
        private Decimal _valortotaldadoacao;
        private Decimal _valorretidoloja;
        private Char _enviodigital;
        private DateTime _datadeenvio;
        private Char _enviofinanceiro;
        private DateTime _datadeenviofinanceiro;
        private Char _consolidado;
        private DateTime _datadeconsolidacao;
        private Char _reciboemitido;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idvenda{ get{return _idvenda == Guid.Empty ? Guid.NewGuid() : _idvenda;}  set{ _idvenda=value;} }

        public virtual ISet<CaixaDTOReference> Caixa { get{ return _caixa; } set{ _caixa = value; } }

        public virtual ISet<ParametroDTOReference> Parametro { get{ return _parametro; } set{ _parametro = value; } }

        public virtual String Cpf { get {return _cpf; } set { _cpf= value;} }

        public virtual String Nome { get {return _nome; } set { _nome= value;} }

        public virtual DateTime Datahota { get {return _datahota; } set { _datahota= value;} }

        public virtual Decimal Valortotaldadoacao { get {return _valortotaldadoacao; } set { _valortotaldadoacao= value;} }

        public virtual Decimal Valorretidoloja { get {return _valorretidoloja; } set { _valorretidoloja= value;} }

        public virtual Char Enviodigital { get {return _enviodigital; } set { _enviodigital= value;} }

        public virtual DateTime Datadeenvio { get {return _datadeenvio; } set { _datadeenvio= value;} }

        public virtual Char Enviofinanceiro { get {return _enviofinanceiro; } set { _enviofinanceiro= value;} }

        public virtual DateTime Datadeenviofinanceiro { get {return _datadeenviofinanceiro; } set { _datadeenviofinanceiro= value;} }

        public virtual Char Consolidado { get {return _consolidado; } set { _consolidado= value;} }

        public virtual DateTime Datadeconsolidacao { get {return _datadeconsolidacao; } set { _datadeconsolidacao= value;} }

        public virtual Char Reciboemitido { get {return _reciboemitido; } set { _reciboemitido= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
