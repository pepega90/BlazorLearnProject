using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Todo harus diisi!")]
        public string TodoItem { get; set; }
        public bool isDone { get; set; } = false;
    }
}
