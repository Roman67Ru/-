//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ателье
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ткань
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ткань()
        {
            this.Изделия_из_ткани = new HashSet<Изделия_из_ткани>();
            this.Склад_ткани = new HashSet<Склад_ткани>();
        }
    
        public string Артикул_ткани { get; set; }
        public string Название { get; set; }
        public string Цвет { get; set; }
        public string Рисунок { get; set; }
        public string Картинка { get; set; }
        public string Состав { get; set; }
        public Nullable<decimal> Ширина { get; set; }
        public Nullable<decimal> Длинна { get; set; }
        public Nullable<decimal> Цена { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Изделия_из_ткани> Изделия_из_ткани { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Склад_ткани> Склад_ткани { get; set; }
    }
}
