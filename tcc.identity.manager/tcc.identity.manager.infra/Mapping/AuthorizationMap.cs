using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.domain.AuthorizationAggregate;

namespace tcc.identity.manager.infra.Mapping
{
    public class AuthorizationMap : IEntityTypeConfiguration<Authorization>
    {
        public void Configure(EntityTypeBuilder<Authorization> builder)
        {
            builder.ToTable("Authorization");

            builder.HasKey(authorization => authorization.Id);

            builder.Property(authorization => authorization.Id)
                               .HasDefaultValue(Guid.NewGuid());


            builder.Property<string>("_profile")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Authorization.UserIdentity));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
