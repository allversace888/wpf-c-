//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sql
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            this.indent = new HashSet<indent>();
        }
    
        public string login { get; set; }
        public string password { get; set; }
        public int id_role { get; set; }
        public string second_name { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
    
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<indent> indent { get; set; }
    }
}
