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
    
    public partial class Продукт
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Продукт()
        {
            this.Заказать_продукт = new HashSet<Заказать_продукт>();
            this.Изделия_из_ткани = new HashSet<Изделия_из_ткани>();
            this.Изделия_с_фурнитурой = new HashSet<Изделия_с_фурнитурой>();
        }
    
        public string Артикул_продукта { get; set; }
        public string Название { get; set; }
        public decimal Ширина { get; set; }
        public decimal Длинна { get; set; }
        public string Картинка { get; set; }
        public string Комментарий { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заказать_продукт> Заказать_продукт { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Изделия_из_ткани> Изделия_из_ткани { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Изделия_с_фурнитурой> Изделия_с_фурнитурой { get; set; }
    }
}
