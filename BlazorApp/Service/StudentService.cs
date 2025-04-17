using API.Data;

namespace BlazorApp.Service
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("Student");
        }

        public async Task<List<Strudent>> GetAllStudents()
        {
            return await _httpClient.GetFromJsonAsync<List<Strudent>>("api/Student");
        }

        public async Task<Strudent> GetStudentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Strudent>($"api/Student/{id}");
        }

        public async Task AddStudent(Strudent student)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Student", student);
            // var để lấy ra kết quả trả về từ API
            response.EnsureSuccessStatusCode();
            // EnsureSuccessStatusCode để đảm bảo rằng yêu cầu đã thành công 
        }

        public async Task UpdateStudent(int id,Strudent student)
        {
			if (student.Id != id)
			{
				throw new ArgumentException("ID in URL does not match student ID");
			}

			var response = await _httpClient.PutAsJsonAsync($"api/Student/{id}", student);
			response.EnsureSuccessStatusCode();
		}

        public async Task DeleteStudent(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Student/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
