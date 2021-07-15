using Todo.Web.Api.Models.Enums;

namespace Todo.Web.Api.Models.Models
{
    public class TodoItem
    {
        public string Code { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public TodoState State { get; set; }
    }
}
