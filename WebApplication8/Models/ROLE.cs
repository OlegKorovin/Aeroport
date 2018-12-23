using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ROLE
    {
        // ID книги
        [Key]
        public int Id { get; set; }
        // название книги
        [MaxLength(100)]
        public string NAME { get; set; }
        // автор книги
        [MaxLength(2000)]
        public string DISCRIPTION { get; set; }
    }
}