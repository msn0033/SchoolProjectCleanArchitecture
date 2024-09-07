using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Context.Config
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.AccessToken)
              .HasColumnType("NvarChar(Max)")
              
               .IsRequired();

            builder.Property(x => x.RefreshTokenString)
           .HasColumnType("nvarchar")
           .HasMaxLength(500)
             .IsRequired();

            builder.Property(x => x.AddTime)
                .IsRequired();

            builder.Property(x => x.ExpireAt)
  
                .IsRequired();

            builder.Property(x => x.JwtSecurityTokenId)
                .HasColumnType("nvarchar")
                .HasMaxLength(300)
                .IsRequired(false);
           

            #region relationShip
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRefreshTokens)
                .HasForeignKey(x =>x.UserId);

            #endregion
            builder.ToTable("UserRefreshTokens");
        }
    }
}
