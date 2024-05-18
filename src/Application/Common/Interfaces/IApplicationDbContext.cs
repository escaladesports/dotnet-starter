﻿using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<ItemMaster> ItemMaster { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
