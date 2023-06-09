using System;
using System.ComponentModel.DataAnnotations;
using myrtex.Domain.Enums;

namespace myrtex.DAL.DtoS
{
    public class CreateEmployeeDto
    {
        public Department Department { get; set; }
        
        [RegularExpression(@"[A-ZА-Я][a-zа-я]+ [A-ZА-Я][a-zа-я]+ [A-ZА-Я][a-zа-я]+", ErrorMessage = "Incorrect Data")]
        public string FullName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        
        [Range(1000, 100000, ErrorMessage = "Зарплата может быть в диапазоне от 1000 до 100000")]
        public Decimal Salary { get; set; }
    }
}