using System;
using System.ComponentModel.DataAnnotations;
using myrtex.Domain.Enums;

namespace myrtex.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Department Department { get; set; }
        
        [RegularExpression(@"[A-ZА-Я][a-zа-я]+ [A-ZА-Я][a-zа-я]+ [A-ZА-Я][a-zа-я]+", ErrorMessage = "Incorrect Data")]
        public string FullName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JobStart { get; set; }
        
        public Decimal Salary { get; set; }
    }
}