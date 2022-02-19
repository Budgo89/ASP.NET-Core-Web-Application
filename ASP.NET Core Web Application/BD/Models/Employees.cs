using System;
using System.ComponentModel.DataAnnotations;

namespace BD.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}