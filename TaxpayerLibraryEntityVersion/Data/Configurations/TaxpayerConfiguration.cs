﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TaxpayerLibraryEntityVersion.Data;
using TaxpayerLibraryEntityVersion.Models;

namespace TaxpayerLibraryEntityVersion.Data.Configurations;

public partial class TaxpayerConfiguration : IEntityTypeConfiguration<Taxpayer>
{
    public void Configure(EntityTypeBuilder<Taxpayer> entity)
    {
        entity.Property(e => e.StartDate).HasColumnType("date");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Taxpayer> entity);
}