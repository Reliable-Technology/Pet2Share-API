
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
    
public partial class GetMyConnection_Result
{

    public int Id { get; set; }

    public string Username { get; set; }

    public byte[] Password { get; set; }

    public int PrimaryPersonId { get; set; }

    public string Email { get; set; }

    public string AlternateEmail { get; set; }

    public string Phone { get; set; }

    public Nullable<int> SocialMediaSourceId { get; set; }

    public string SocialMediaUsername { get; set; }

    public Nullable<int> UserTypeId { get; set; }

    public System.DateTime DateAdded { get; set; }

    public System.DateTime DateModified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

}

}
