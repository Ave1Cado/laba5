//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Returns
    {
        public int ReturnID { get; set; }
        public Nullable<int> OrderDetailID { get; set; }
        public string ReturnReason { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public int OrderID { get; internal set; }
        public int ProductID { get; internal set; }
    }
}
