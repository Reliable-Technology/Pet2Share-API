
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
    
public partial class PostLike
{

    public int ID { get; set; }

    public Nullable<int> PostID { get; set; }

    public int PersonID { get; set; }

    public System.DateTime DateAdded { get; set; }

    public System.DateTime DateModified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }



    public virtual Person Person { get; set; }

    public virtual Post Post { get; set; }

}

}
