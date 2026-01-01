using CommentsAndActivityLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentActivityLog.Infrastructure.Data;

public class CommentActivityLogDbContext : DbContext
{
    public DbSet<CommentEntity> Comment { get; set; }
    public DbSet<TaskEntity> Task { get; set; }
    public DbSet<UserEntity> User { get; set; }
    public DbSet<ActivityLogEntity> ActivityLog { get; set; }

    public CommentActivityLogDbContext(DbContextOptions option) : base(option)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Comment
        modelBuilder.Entity<CommentEntity>().ToTable("Comment");

        modelBuilder.Entity<CommentEntity>().HasKey(comment => comment.Id);

        modelBuilder.Entity<CommentEntity>().Property(comment => comment.Content)
            .IsRequired()
            .HasMaxLength(500);

        modelBuilder.Entity<CommentEntity>().HasOne(comment => comment.Task)
            .WithMany(task => task.CommentList)
            .HasForeignKey(comment => comment.TaskId);

        modelBuilder.Entity<CommentEntity>().HasOne(comment => comment.User)
            .WithMany(user => user.CommentList)
            .HasForeignKey(comment => comment.UserId);

        modelBuilder.Entity<CommentEntity>().HasMany(comment => comment.ActivitiyLogList)
            .WithOne(activityLog => activityLog.Comment)
            .HasForeignKey(activityLog => activityLog.CommentId);
        #endregion

        #region Task
        // TODO : implement by mahya

        modelBuilder.Entity<TaskEntity>().ToTable("Task");

        modelBuilder.Entity<TaskEntity>().HasKey(task => task.Id);

        modelBuilder.Entity<TaskEntity>()
            .Property(task => task.Title)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<TaskEntity>()
            .Property(task => task.Description)
            .HasMaxLength(500)
            .IsRequired();

        modelBuilder.Entity<TaskEntity>()
            .HasMany(task => task.CommentList)
            .WithOne(comment => comment.Task)
            .HasForeignKey(comment => comment.TaskId);

        modelBuilder.Entity<TaskEntity>().HasData(
            new TaskEntity { Id = 1, Title = "ایجاد پروژه ی جدید", Description = "لطفا در ویژوال استادیو یک پروژه وب جدید ایجاد کنید" },
            new TaskEntity { Id = 2, Title = "ایجاد معماری", Description = "لطفا معماری پروژه را تعیین کنید" },
            new TaskEntity { Id = 3, Title = "ایجاد مدل", Description = "لطفا مدل و موجودیت های خود را مشخص کنید" });

        #endregion

        #region User
        // TODO : implement by mahya
        modelBuilder.Entity<UserEntity>().ToTable("User");

        modelBuilder.Entity<UserEntity>()
            .HasKey(user => user.Id);

        modelBuilder.Entity<UserEntity>()
            .Property(user => user.UserName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<UserEntity>()
            .Property(user => user.Email)
            .IsRequired().HasMaxLength(100);

        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.CommentList)
            .WithOne(comment => comment.User)
            .HasForeignKey(comment => comment.UserId);

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity { Id = 1, UserName = "Mahya", Email = "mahyaaa.khashkhashi@gmail.com" },
            new UserEntity { Id = 2, UserName = "Hosein", Email = "HosseinDinarvand@gmail.com" },
            new UserEntity { Id = 3, UserName = "Alireza", Email = "AlirezaEntezari@gmail.com" });

        #endregion

        #region Activity
        // TODO : implement by alireza
        modelBuilder.Entity<ActivityLogEntity>().ToTable("ActivityLog");

        modelBuilder.Entity<ActivityLogEntity>()
            .HasKey(activityLog => activityLog.Id);

        modelBuilder.Entity<ActivityLogEntity>()
            .Property(activityLog => activityLog.Action)
            .IsRequired();

        modelBuilder.Entity<ActivityLogEntity>()
            .Property(activityLog => activityLog.Created_at)
            .IsRequired();

        modelBuilder.Entity<ActivityLogEntity>()
            .HasOne(activityLog => activityLog.Comment)
            .WithMany(comment => comment.ActivitiyLogList)
            .HasForeignKey(activityLog => activityLog.CommentId);

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}