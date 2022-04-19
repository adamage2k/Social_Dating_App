using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialDatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Infrastructure.Configuration
{
    public class ConnectionConfiguration : IEntityTypeConfiguration<Connection>
    {
        public void Configure(EntityTypeBuilder<Connection> builder)
        {
            builder.ToTable("Connection");

            builder
                .HasOne(c => c.User1)
                .WithMany(u => u.Sent)
                .HasForeignKey(c => c.UserId1);

            builder
                .HasOne(c => c.User2)
                .WithMany(u => u.Received)
                .HasForeignKey(c => c.UserId2);
        }
    }
}
