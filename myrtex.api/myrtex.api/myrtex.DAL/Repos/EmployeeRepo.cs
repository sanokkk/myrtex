using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myrtex.DAL.DtoS;
using myrtex.DAL.Interfaces;
using myrtex.Domain.Models;

namespace myrtex.DAL.Repos
{
    public class EmployeeRepo: IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateEmployeeAsync(CreateEmployeeDto model)
        {
            if (model is null)
                return false;
            var Employee = _mapper.Map<Employee>(model);

            try
            {
                await _context.Employees.AddAsync(Employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> EditEmployeeAsync(Guid id, UpdateEmployeeDto model)
        {
            var EmployeeToUpdate = await _context.Employees.FirstOrDefaultAsync(f => f.Id == id);

            if (EmployeeToUpdate is null) return false;

            EmployeeToUpdate.Birthday = model.Birthday;
            EmployeeToUpdate.Department = model.Department;
            EmployeeToUpdate.Salary = model.Salary;
            EmployeeToUpdate.FullName = model.FullName;

            try
            {
                _context.Update(EmployeeToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var EmployeeToDelete = await _context.Employees.FirstOrDefaultAsync(f => f.Id == id);

            if (EmployeeToDelete is null) return false;

            try
            {
                _context.Employees.Remove(EmployeeToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            var Employee = await _context.Employees.FirstOrDefaultAsync(f => f.Id == id);

            return Employee;
        }

        public async Task<Employee[]> GetEmployeesAsync()
        {
            return await _context.Employees.ToArrayAsync();
        }
    }
}