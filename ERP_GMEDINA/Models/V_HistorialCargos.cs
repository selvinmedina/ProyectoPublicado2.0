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
    
    public partial class V_HistorialCargos
    {
        public int hcar_Id { get; set; }
        public string Nombre_Completo { get; set; }
        public string CargoAnterior { get; set; }
        public string CargoNuevo { get; set; }
        public Nullable<System.DateTime> Fecha_de_Historial { get; set; }
        public string Usuario_Crea { get; set; }
        public System.DateTime Fecha_Crea { get; set; }
        public string Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Fecha_Modifica { get; set; }
    }
}
