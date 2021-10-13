using HotChocolate;
using PlannerAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerAPI2.GraphQL
{
    public class Queries
    {
        public IQueryable<TodoItem> Read([Service] TodoDbContext context) => context.TodoItems;
    }
}
