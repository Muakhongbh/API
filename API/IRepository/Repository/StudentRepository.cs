using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.IRepository.Repository
{
    public class StudentRepository :IStudentRepository
    {
        private readonly DbConTextApp _dbContext;

        public StudentRepository(DbConTextApp dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Strudent>> GetAllStudents()
        {
            return await _dbContext.Strudents.ToListAsync();
        }

        public async Task<Strudent> GetStudentById(int id)
        {
            try
            {
                var student = await _dbContext.Strudents.FindAsync(id);
                if (student == null)
                {
                    throw new Exception("Student not found");
                }
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student", ex);
            }
        }

        public async Task AddStudent(Strudent student)
        {
            try
            {
                _dbContext.Strudents.Add(student);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding student", ex);
            }        
        }

        public Task UpdateStudent(int id,Strudent student)
        {
            try
            {
                if (student.Id != id)
				{
					throw new ArgumentException("ID in URL does not match student ID");
				}
                _dbContext.Strudents.Update(student);
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student", ex);
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                var student = await GetStudentById(id);
                if (student != null)
                {
                    _dbContext.Strudents.Remove(student);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student", ex);
            }
        }
    }
}
