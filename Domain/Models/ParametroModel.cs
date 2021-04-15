using System;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.Models {

    public class ParametroModel
    {
        private Guid _idparametro;
        private ISet<GrupoDTOReference> _grupo;
        private String _chave;
        private String _valor;
        private DateTime _validode;
        private DateTime _validoate;
        private Char _ativo;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idparametro{ get{return _idparametro == Guid.Empty ? Guid.NewGuid() : _idparametro;}  set{ _idparametro=value;} }

        public virtual ISet<GrupoDTOReference> Grupo { get{ return _grupo; } set{ _grupo = value; } }

        public virtual String Chave { get {return _chave; } set { _chave= value;} }

        public virtual String Valor { get {return _valor; } set { _valor= value;} }

        public virtual DateTime Validode { get {return _validode; } set { _validode= value;} }

        public virtual DateTime Validoate { get {return _validoate; } set { _validoate= value;} }

        public virtual Char Ativo { get { return _ativo == '\0' ? 'A' : _ativo; } set { _ativo= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
