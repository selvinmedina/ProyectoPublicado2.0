//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_GMEDINA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbSucursales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbSucursales()
        {
            this.tbAreas = new HashSet<tbAreas>();
        }
    
        public int suc_Id { get; set; }
        public int empr_Id { get; set; }
        public string mun_Codigo { get; set; }
        public int bod_Id { get; set; }
        public int pemi_Id { get; set; }
        public string suc_Descripcion { get; set; }
        public string suc_Correo { get; set; }
        public string suc_Direccion { get; set; }
        public string suc_Telefono { get; set; }
        public bool suc_Estado { get; set; }
        public string suc_RazonInactivo { get; set; }
        public int suc_UsuarioCrea { get; set; }
        public System.DateTime suc_FechaCrea { get; set; }
        public Nullable<int> suc_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> suc_FechaModifica { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbAreas> tbAreas { get; set; }
        public virtual tbEmpresas tbEmpresas { get; set; }
    }
}