
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CapaDatos
{

using System;
    using System.Collections.Generic;
    
public partial class LineasCreditoVenta
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public LineasCreditoVenta()
    {

        this.CobrosVentasCreditoes = new HashSet<CobrosVentasCredito>();

    }


    public int LineaCreditoVentaID { get; set; }

    public int FacturaID { get; set; }

    public bool Estatus { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CobrosVentasCredito> CobrosVentasCreditoes { get; set; }

    public virtual Factura Factura { get; set; }

}

}
