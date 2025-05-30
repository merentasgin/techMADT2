﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using techMADT2.Core.Entities;


namespace techMADT2.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            builder.HasData(

                new AppUser
                {
                    Id = 1,

                    UserName = "Admin",
                    Email = "merentasgin@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Muhammed Eren",
                    Password = "123456*",
                    Surname = "TAŞGİN"
                }

                );
        }
    }
}
