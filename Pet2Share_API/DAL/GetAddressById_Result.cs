
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Pet2Share_API.DAL
{

using System;
    
public partial class GetAddressById_Result
{

    public int Id { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public Nullable<bool> IsBillingAddress { get; set; }

    public Nullable<bool> IsShippingAddress { get; set; }

    public System.DateTime DateAdded { get; set; }

    public System.DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }

    public string ZipCode { get; set; }

}

}
