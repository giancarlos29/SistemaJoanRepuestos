
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
    
public partial class DetalleFactura
{

    public int DetalleFacturaID { get; set; }

    public int FacturaID { get; set; }

    public int ProductoID { get; set; }

    public double CantVen { get; set; }

    public decimal Precio { get; set; }

    public decimal ITBIS { get; set; }

    public decimal Descuento { get; set; }



    public virtual Factura Factura { get; set; }

    public virtual Producto Producto { get; set; }

}

}
