
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ERP_GMEDINA.Models
{

using System;
    using System.Collections.Generic;
    
public partial class V_CatalogoDePlanillasConIngresosYDeducciones
{

    public int idPlanilla { get; set; }

    public string descripcionPlanilla { get; set; }

    public int frecuenciaEnDias { get; set; }

    public Nullable<int> idIngreso { get; set; }

    public string descripcionIngreso { get; set; }

    public Nullable<int> idDeducciones { get; set; }

    public string descripcionDeduccion { get; set; }

}

}
