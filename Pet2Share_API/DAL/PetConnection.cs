
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
    using System.Collections.Generic;
    
public partial class PetConnection
{

    public int Id { get; set; }

    public int IPetId { get; set; }

    public int APetId { get; set; }

    public bool IsApproved { get; set; }

    public System.DateTime DateAdded { get; set; }

    public System.DateTime DateModified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

}

}
