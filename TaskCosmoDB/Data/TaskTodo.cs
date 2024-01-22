using Newtonsoft.Json;
using System.Security.Cryptography;
using TaskCosmoDB.Shared;

namespace TaskCosmoDB.Data
{
    public class TaskTodo : ActionModelProvider<TaskTodo>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int sort {  get; set; } = 0;
        public string Description { get; set; }
        public bool Status { get; set; } = false;

    }
}
