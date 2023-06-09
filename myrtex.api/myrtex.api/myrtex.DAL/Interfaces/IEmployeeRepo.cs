using System;
using System.Threading.Tasks;
using myrtex.DAL.DtoS;
using myrtex.Domain.Models;

namespace myrtex.DAL.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<bool> CreateEmployeeAsync(CreateEmployeeDto model);

        Task<bool> EditEmployeeAsync(Guid id, UpdateEmployeeDto model);

        Task<bool> DeleteEmployeeAsync(Guid id);

        Task<Employee> GetEmployeeAsync(Guid id);

        Task<Employee[]> GetEmployeesAsync();
    }
}