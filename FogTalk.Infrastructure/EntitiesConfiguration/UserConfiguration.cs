﻿using FogTalk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FogTalk.Infrastructure.EntitiesConfiguration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Bio).IsRequired(false);
        builder.Property(u => u.ProfilePicture).IsRequired(false);
        
        //SentMessages
        builder
            .HasMany(u => u.SentMessages)
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId);
        
        // Notifications
        // builder
        //     .HasMany(u => u.ReceivedNotifications)
        //     .WithOne(n => n.User)
        //     .HasForeignKey(n => n.UserId);

        //Chats
        builder
            .HasMany(u => u.Chats)
            .WithMany(c => c.Participants);
        
        // Friends
        builder
            .HasMany(u => u.Friends)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserFriend",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("FriendId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
            );
        
        // FriendRequests
        builder
            .HasMany(u => u.FriendRequests)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "FriendRequest",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("RequestedUserId"),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("RequestingUserId")
            );
    }
}