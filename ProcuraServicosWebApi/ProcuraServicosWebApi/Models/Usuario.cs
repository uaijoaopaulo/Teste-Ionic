//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcuraServicosWebApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.AvaliacaoItem = new HashSet<AvaliacaoItem>();
            this.RecomendacaoUsuario = new HashSet<RecomendacaoUsuario>();
            this.Servico = new HashSet<Servico>();
        }
    
        public int id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string tipousuario { get; set; }
        public string nickname { get; set; }
        public bool status { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AvaliacaoItem> AvaliacaoItem { get; set; }
        [JsonIgnore]
        public virtual Conta Conta { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecomendacaoUsuario> RecomendacaoUsuario { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servico> Servico { get; set; }
    }
}
