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
    
    public partial class tbEmpleadoBonos
    {
        public int cb_Id { get; set; }
        public int emp_Id { get; set; }
        public int cin_IdIngreso { get; set; }
        public decimal cb_Monto { get; set; }
        public System.DateTime cb_FechaRegistro { get; set; }
        public bool cb_Pagado { get; set; }
        public int cb_UsuarioCrea { get; set; }
        public System.DateTime cb_FechaCrea { get; set; }
        public Nullable<int> cb_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> cb_FechaModifica { get; set; }
        public bool cb_Activo { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        public virtual tbCatalogoDeIngresos tbCatalogoDeIngresos { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
    }
}
