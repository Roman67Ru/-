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
    
    public partial class Склад_фурнитуры
    {
        public int Партия { get; set; }
        public string Артикул_фурнитуры { get; set; }
        public int Количиство { get; set; }
    
        public virtual Фурнитура Фурнитура { get; set; }
    }
}
