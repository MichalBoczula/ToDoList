using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Persistance.Configuration
{
    public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList.Domain.Model.Entities.ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList.Domain.Model.Entities.ToDoList> builder)
        {
            builder.HasKey(list => list.Id);
            builder.HasMany(list => list.ToDoTasks)
                .WithOne(task => task.List)
                .HasForeignKey(task => task.ListId);
        }
    }
}