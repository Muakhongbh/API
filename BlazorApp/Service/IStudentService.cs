using API.Data;

namespace BlazorApp.Service
{
    public interface IStudentService
    {
        Task<List<Strudent>> GetAllStudents();
        Task<Strudent> GetStudentById(int id);
        Task AddStudent(Strudent student);
        Task UpdateStudent(int id,Strudent student);
        Task DeleteStudent(int id);
    }
}
