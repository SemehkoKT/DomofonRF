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
    
    public partial class Склад
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Склад()
        {
            this.Пользователь = new HashSet<Пользователь>();
        }
    
        public int Код_склада { get; set; }
        public int Код_нового_материала { get; set; }
        public int Код_нового_инвентаря { get; set; }
    
        public virtual Новый_инвентарь_со_склада Новый_инвентарь_со_склада { get; set; }
        public virtual Новый_материал_со_склада Новый_материал_со_склада { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пользователь> Пользователь { get; set; }
    }
}
