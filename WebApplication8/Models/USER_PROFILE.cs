using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class USER_PROFILE
    {
        // ID книги
        [Key]
        public int Id { get; set; }
        // название книги
        [MaxLength(100)]
        public string PROFILE { get; set; }
       
        // автор книги
        [ForeignKey("ROLE")]
        public int IDPROFILEROLE { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}