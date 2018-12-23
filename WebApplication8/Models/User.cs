using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class User
    {
        // ID книги
        [Key]
        public int Id { get; set; }
        // название книги
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string login { get; set; }
        // автор книги
        [MaxLength(200)]
        public string FIO { get; set; }
        [MaxLength(100)]
        public string IdPROFILECODE { get; set; }
        [ForeignKey("USER_PROFILE")]
        public int IdPROFILE { get; set; }
        public virtual USER_PROFILE USER_PROFILE { get; set; }
    }
}