//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViaroAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Course
    {
        public Course()
        {
            this.course_alumn = new HashSet<course_alumn>();
        }
    
        public int id_course { get; set; }
        [Required(ErrorMessage = "El campo Curso No puede ser Vacio.")]
        [StringLength(50)]
        public string name { get; set; }
        public Nullable<int> id_teacher { get; set; }
    
        public virtual ICollection<course_alumn> course_alumn { get; set; }
        public virtual teacher teacher { get; set; }
    }
}
