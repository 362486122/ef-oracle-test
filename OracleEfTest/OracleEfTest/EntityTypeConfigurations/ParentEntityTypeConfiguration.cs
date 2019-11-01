using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OracleEfTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OracleEfTest.EntityTypeConfigurations
{
    public class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("PARENT");
            builder.Property(x => x.Id).HasColumnName("ID"); 
        }
    }
}
