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
    
    public partial class V_RPT_HistorialVacaciones
    {
        public int hvac_Id { get; set; }
        public int emp_Id { get; set; }
        public string Nombre_Empleado { get; set; }
        public int hvac_CantDias { get; set; }
        public System.DateTime hvac_FechaInicio { get; set; }
        public bool hvac_DiasPagados { get; set; }
        public int hvac_MesVacaciones { get; set; }
        public int hvac_anioVacaciones { get; set; }
        public System.DateTime hvac_FechaFin { get; set; }
    }
}