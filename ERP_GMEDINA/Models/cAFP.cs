﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_GMEDINA.Models
{

    [MetadataType(typeof(cAFP))]
    public partial class tbAFP
    {
    }

    public class cAFP
    {
        [Display(Name = "AFP")]
        public int afp_Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "AFP")]
        public string afp_Descripcion { get; set; }

        [Range(0.00, 9999999999999999.99, ErrorMessage = "El Aporte no puede ser menor de 0 dígitos, ni mayor que 10 dígitos")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Aporte Mínimo")]
        public decimal afp_AporteMinimoLps { get; set; }

        [Range(0.00, 9999999999999999.99, ErrorMessage = "El Interés por Aporte no puede ser menor de 0 dígitos, ni mayor que 10 dígitos")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Interés por Aporte")]
        public decimal afp_InteresAporte { get; set; }

        [Range(0.00, 9999999999999999.99, ErrorMessage = "El Interés Anual no puede ser menor de 0 dígitos, ni mayor que 10 dígitos")]
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Interés Anual")]
        public decimal afp_InteresAnual { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo Deducción")]
        public int tde_IdTipoDedu { get; set; }

        [Display(Name = "Creado por")]
        public int afp_UsuarioCrea { get; set; }

        [Display(Name = "Fecha de Creación")]
        public System.DateTime afp_FechaCrea { get; set; }

        [Display(Name = "Modificado por")]
        public Nullable<int> afp_UsuarioModifica { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public Nullable<System.DateTime> afp_FechaModifica { get; set; }

        [Display(Name = "Activo")]
        public bool afp_Activo { get; set; }

    }
}