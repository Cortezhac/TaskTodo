namespace TaskCosmoDB.Data
{
    public class Task
    {
        public string Id { get; set; }
        public int sort {  get; set; } = 0;
        public string Description { get; set; }
        public bool Status { get; set; } = false;

    }
}
