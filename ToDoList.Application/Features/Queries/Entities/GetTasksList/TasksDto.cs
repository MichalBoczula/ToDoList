namespace ToDoList.Application.Features.Queries.Entities.GetTasksList
{
    public class TasksDto
    {
        public int Id { get; set; }
        public string ProgressName { get; set; }
        public string Name { get; set; }
        public int Estimation { get; set; }
        public int Duration { get; set; }
    }
}