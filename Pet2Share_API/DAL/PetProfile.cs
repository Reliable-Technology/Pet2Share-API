
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
    
public partial class PetProfile
{

    public int Id { get; set; }

    public string Name { get; set; }

    public string FamilyName { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<int> PetTypeId { get; set; }

    public Nullable<System.DateTime> DOB { get; set; }

    public string ProfilePicture { get; set; }

    public string CoverPicture { get; set; }

    public string About { get; set; }

    public string FavFood { get; set; }

    public bool IsVirtual { get; set; }

    public System.DateTime DateAdded { get; set; }

    public System.DateTime DateModified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }



    public virtual PetType PetType { get; set; }

    public virtual User User { get; set; }

}

}
