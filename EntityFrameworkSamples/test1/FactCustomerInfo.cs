//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace test1
{
    using System;
    using System.Collections.Generic;
    
    public partial class FactCustomerInfo
    {
        public int CustomeId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLogonName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerTel { get; set; }
        public System.DateTime CustomerBirthday { get; set; }
        public Nullable<int> CustomerAreaID { get; set; }
        public Nullable<int> CustomerBirthAreaID { get; set; }
        public Nullable<int> CustomerCreateDateKey { get; set; }
        public int CustomerAge { get; set; }
        public int AgeArea { get; set; }
    
        public virtual test1 CustomerNameT { get; set; }
    }
}