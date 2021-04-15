using System;
using System.Collections.Generic;
using Domain.DTOs.LojaDTO;

namespace Domain.Models {

    public class CaixaModel
    {
        private Guid _idcaixa;
        private ISet<LojaDTOReference> _loja;
        private String _codigo;
        private String _descrição;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idcaixa{ get{return _idcaixa == Guid.Empty ? Guid.NewGuid() : _idcaixa;}  set{ _idcaixa=value;} }

        public virtual ISet<LojaDTOReference> Loja { get{ return _loja; } set{ _loja = value; } }

        public virtual String Codigo { get {return _codigo; } set { _codigo= value;} }

        public virtual String Descrição { get {return _descrição; } set { _descrição= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
