using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Persistance.Configuration
{
    public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasOne(task => task.Progress)
                .WithMany(progress => progress.Tasks)
                .HasForeignKey(task => task.TaskProgressionLevelsId);
        }
    }
}
