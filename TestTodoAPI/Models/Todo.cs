using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTodoAPI.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int PrecentageProgress { get; set; }
        public Boolean IsDone { get; set; }

        public Todo todo { get; set; }
    }

    public class TodoDetail
    {
        public int TodoDetailId { get; set; }
        public string Detail { get; set; }
        public Boolean IsDone { get; set; }
    }
}
