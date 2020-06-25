using System;
using vimanet.DataAccess.Entities;

namespace vimanet.DataAccess.Repositories
{
    public class TaskContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public int AssignedUserId { get; set; }
    }
}
