//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind.Entity
{
    using System;
    
    public partial class Kontrol_Result
    {
        public string name { get; set; }
        public int object_id { get; set; }
        public Nullable<int> principal_id { get; set; }
        public int schema_id { get; set; }
        public int parent_object_id { get; set; }
        public string type { get; set; }
        public string type_desc { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime modify_date { get; set; }
        public bool is_ms_shipped { get; set; }
        public bool is_published { get; set; }
        public bool is_schema_published { get; set; }
        public bool is_auto_executed { get; set; }
        public Nullable<bool> is_execution_replicated { get; set; }
        public Nullable<bool> is_repl_serializable_only { get; set; }
        public Nullable<bool> skips_repl_constraints { get; set; }
    }
}
