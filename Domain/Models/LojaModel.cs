using System;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.Models {

    public class LojaModel
    {
        private Guid _idloja;
        private ISet<GrupoDTOReference> _grupo;
        private String _nome;
        private String _responsavel;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idloja{ get{return _idloja == Guid.Empty ? Guid.NewGuid() : _idloja;}  set{ _idloja=value;} }

        public virtual ISet<GrupoDTOReference> Grupo { get{ return _grupo; } set{ _grupo = value; } }

        public virtual String Nome { get {return _nome; } set { _nome= value;} }

        public virtual String Responsavel { get {return _responsavel; } set { _responsavel= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
