//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Проект2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Новый_инвентарь_со_склада
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Новый_инвентарь_со_склада()
        {
            this.Склад = new HashSet<Склад>();
        }
    
        public int ID { get; set; }
        public string Производитель { get; set; }
        public string Артикул { get; set; }
        public System.DateTime Дата_прибытия { get; set; }
        public string Название { get; set; }
        public int Количество { get; set; }
        public decimal Цена { get; set; }
        public string Адрес_производителя { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Склад> Склад { get; set; }
    }
}
