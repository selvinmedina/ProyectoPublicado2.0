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
    
    public partial class tbHistorialRefrendamientos
    {
        public int href_Id { get; set; }
        public int emp_Id { get; set; }
        public string href_Archivo { get; set; }
        public System.DateTime href_FechaRefrendado { get; set; }
        public bool href_Estado { get; set; }
        public string href_RazonInactivo { get; set; }
        public int href_UsuarioCrea { get; set; }
        public System.DateTime href_FechaCrea { get; set; }
        public Nullable<int> href_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> href_FechaModifica { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
    }
}
