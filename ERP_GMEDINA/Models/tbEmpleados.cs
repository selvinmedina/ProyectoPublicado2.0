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
    
    public partial class tbEmpleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEmpleados()
        {
            this.tbAdelantoSueldo = new HashSet<tbAdelantoSueldo>();
            this.tbDecimoTercerMes = new HashSet<tbDecimoTercerMes>();
            this.tbDeduccionInstitucionFinanciera = new HashSet<tbDeduccionInstitucionFinanciera>();
            this.tbEmpleadoBonos = new HashSet<tbEmpleadoBonos>();
            this.tbEmpleadoComisiones = new HashSet<tbEmpleadoComisiones>();
            this.tbHistorialDePago = new HashSet<tbHistorialDePago>();
            this.tbLiquidaciones = new HashSet<tbLiquidaciones>();
            this.tbEquipoEmpleados = new HashSet<tbEquipoEmpleados>();
            this.tbHistorialAmonestaciones = new HashSet<tbHistorialAmonestaciones>();
            this.tbHistorialAudienciaDescargo = new HashSet<tbHistorialAudienciaDescargo>();
            this.tbHistorialCargos = new HashSet<tbHistorialCargos>();
            this.tbHistorialHorasTrabajadas = new HashSet<tbHistorialHorasTrabajadas>();
            this.tbHistorialIncapacidades = new HashSet<tbHistorialIncapacidades>();
            this.tbHistorialLiquidaciones = new HashSet<tbHistorialLiquidaciones>();
            this.tbHistorialPermisos = new HashSet<tbHistorialPermisos>();
            this.tbHistorialRefrendamientos = new HashSet<tbHistorialRefrendamientos>();
            this.tbHistorialSalidas = new HashSet<tbHistorialSalidas>();
            this.tbHistorialVacaciones = new HashSet<tbHistorialVacaciones>();
            this.tbSueldos = new HashSet<tbSueldos>();
            this.tbVacaciones = new HashSet<tbVacaciones>();
        }
    
        public int emp_Id { get; set; }
        public int per_Id { get; set; }
        public int car_Id { get; set; }
        public int area_Id { get; set; }
        public int depto_Id { get; set; }
        public int jor_Id { get; set; }
        public int cpla_IdPlanilla { get; set; }
        public int fpa_IdFormaPago { get; set; }
        public string emp_CuentaBancaria { get; set; }
        public bool emp_Reingreso { get; set; }
        public System.DateTime emp_Fechaingreso { get; set; }
        public string emp_RazonSalida { get; set; }
        public Nullable<int> emp_CargoAnterior { get; set; }
        public Nullable<System.DateTime> emp_FechaDeSalida { get; set; }
        public bool emp_Estado { get; set; }
        public string emp_RazonInactivo { get; set; }
        public int emp_UsuarioCrea { get; set; }
        public System.DateTime emp_FechaCrea { get; set; }
        public Nullable<int> emp_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> emp_FechaModifica { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbAdelantoSueldo> tbAdelantoSueldo { get; set; }
        public virtual tbCatalogoDePlanillas tbCatalogoDePlanillas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDecimoTercerMes> tbDecimoTercerMes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDeduccionInstitucionFinanciera> tbDeduccionInstitucionFinanciera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleadoBonos> tbEmpleadoBonos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleadoComisiones> tbEmpleadoComisiones { get; set; }
        public virtual tbFormaPago tbFormaPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialDePago> tbHistorialDePago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLiquidaciones> tbLiquidaciones { get; set; }
        public virtual tbAreas tbAreas { get; set; }
        public virtual tbCargos tbCargos { get; set; }
        public virtual tbDepartamentos tbDepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEquipoEmpleados> tbEquipoEmpleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialAmonestaciones> tbHistorialAmonestaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialAudienciaDescargo> tbHistorialAudienciaDescargo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialCargos> tbHistorialCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialHorasTrabajadas> tbHistorialHorasTrabajadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialIncapacidades> tbHistorialIncapacidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialLiquidaciones> tbHistorialLiquidaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialPermisos> tbHistorialPermisos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialRefrendamientos> tbHistorialRefrendamientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialSalidas> tbHistorialSalidas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialVacaciones> tbHistorialVacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSueldos> tbSueldos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbVacaciones> tbVacaciones { get; set; }
        public virtual tbJornadas tbJornadas { get; set; }
        public virtual tbPersonas tbPersonas { get; set; }
    }
}
