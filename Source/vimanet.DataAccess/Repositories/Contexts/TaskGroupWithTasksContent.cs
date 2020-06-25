using System.Collections.Generic;

namespace vimanet.DataAccess.Repositories
{
    public class TaskGroupWithTasksContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskContext> UserTasks { get; set; }
    }
}
