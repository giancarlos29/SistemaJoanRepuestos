
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
    
public partial class CobrosVentasCredito
{

    public int CobroVentaCreditoID { get; set; }

    public int LineaCreditoVentaID { get; set; }

    public System.DateTime FechaCobro { get; set; }

    public decimal Monto { get; set; }

    public int UserID { get; set; }

    public string Concepto { get; set; }



    public virtual LineasCreditoVenta LineasCreditoVenta { get; set; }

    public virtual User User { get; set; }

}

}
