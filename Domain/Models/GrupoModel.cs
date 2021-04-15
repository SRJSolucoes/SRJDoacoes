using System;
using System.Collections.Generic;

namespace Domain.Models {

    public class GrupoModel
    {
        private Guid _idgrupo;
        private String _nome;
        private String _responsável;
        private String _logo;
        private DateTime _datadeinclusao;
        private DateTime _datadealteracao;
        private DateTime _datadeinativacao;
        private Guid _usuariodeinclusao;
        private Guid _usuariodealteracao;
        private Guid _usuariodeinativacao;
        private Guid _fkparceiro;
        public virtual Guid Idgrupo{ get{return _idgrupo == Guid.Empty ? Guid.NewGuid() : _idgrupo;}  set{ _idgrupo=value;} }

        public virtual String Nome { get {return _nome; } set { _nome= value;} }

        public virtual String Responsável { get {return _responsável; } set { _responsável= value;} }

        public virtual String Logo { get {return _logo; } set { _logo= value;} }

        public virtual DateTime Datadeinclusao { get {return _datadeinclusao; } set { _datadeinclusao= value;} }

        public virtual DateTime Datadealteracao { get {return _datadealteracao; } set { _datadealteracao= value;} }

        public virtual DateTime Datadeinativacao { get {return _datadeinativacao; } set { _datadeinativacao= value;} }

        public virtual Guid Usuariodeinclusao { get {return _usuariodeinclusao; } set { _usuariodeinclusao= value;} }

        public virtual Guid Usuariodealteracao { get {return _usuariodealteracao; } set { _usuariodealteracao= value;} }

        public virtual Guid Usuariodeinativacao { get {return _usuariodeinativacao; } set { _usuariodeinativacao= value;} }

        public virtual Guid Fkparceiro { get {return _fkparceiro; } set { _fkparceiro= value;} }

    }
}
