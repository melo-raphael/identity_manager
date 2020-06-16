using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.domain.AuthorizationAggregate;

namespace tcc.identity.manager.infra.Mapping
{
    public class UserIdentityMap : IEntityTypeConfiguration<UserIdentity>
    {
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                               .HasDefaultValue(Guid.NewGuid());


            builder.Property<string>("_email")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();


            builder.Property<string>("_password")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();


            builder.Property<string>("_name")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();
        }
    }
}
