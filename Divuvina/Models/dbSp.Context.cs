﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Divuvina.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbSp : DbContext
    {
        public dbSp()
            : base("name=dbSp")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Nullable<int>> spTest(Nullable<int> key)
        {
            var keyParameter = key.HasValue ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spTest", keyParameter);
        }
    
        public virtual ObjectResult<sp_LayThongTinXe_Result> sp_LayThongTinXe(string thongTinXe)
        {
            var thongTinXeParameter = thongTinXe != null ?
                new ObjectParameter("ThongTinXe", thongTinXe) :
                new ObjectParameter("ThongTinXe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayThongTinXe_Result>("sp_LayThongTinXe", thongTinXeParameter);
        }
    }
}