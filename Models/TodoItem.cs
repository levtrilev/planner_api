using System;

namespace PlannerAPI2.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public TodoItem(string title = "todo")
        {
            Title = title;
        }

        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int Priority { get; set; }
    }
}


