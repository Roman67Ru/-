﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class АтельеEntities : DbContext
    {
        public АтельеEntities()
            : base("name=АтельеEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Заказать_продукт> Заказать_продукт { get; set; }
        public virtual DbSet<Заказы> Заказы { get; set; }
        public virtual DbSet<Изделия_из_ткани> Изделия_из_ткани { get; set; }
        public virtual DbSet<Изделия_с_фурнитурой> Изделия_с_фурнитурой { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Продукт> Продукт { get; set; }
        public virtual DbSet<Склад_ткани> Склад_ткани { get; set; }
        public virtual DbSet<Склад_фурнитуры> Склад_фурнитуры { get; set; }
        public virtual DbSet<Ткань> Ткань { get; set; }
        public virtual DbSet<Фурнитура> Фурнитура { get; set; }
    }
}
