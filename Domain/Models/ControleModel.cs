using System;
using System.Collections.Generic;
using Domain.DTOs.VendaDTO;

namespace Domain.Models {

    public class ControleModel
    {
        private Guid _idcontrole;
        private ISet<VendaDTOReference> _venda;
        private Char _consolidado;
        private DateTime _dataconsolidacao;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idcontrole{ get{return _idcontrole == Guid.Empty ? Guid.NewGuid() : _idcontrole;}  set{ _idcontrole=value;} }

        public virtual ISet<VendaDTOReference> Venda { get{ return _venda; } set{ _venda = value; } }

        public virtual Char Consolidado { get {return _consolidado; } set { _consolidado= value;} }

        public virtual DateTime Dataconsolidacao { get {return _dataconsolidacao; } set { _dataconsolidacao= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
