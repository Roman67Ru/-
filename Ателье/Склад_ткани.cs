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
    
    public partial class Склад_ткани
    {
        public int Рулон { get; set; }
        public string Артикул_ткани { get; set; }
        public decimal Ширина { get; set; }
        public decimal Длинна { get; set; }
    
        public virtual Ткань Ткань { get; set; }
    }
}
