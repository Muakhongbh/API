using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Strudent
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Tên không được bỏ trống")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Họ không được bỏ trống")]                 
        public string LastName { get; set; }   
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ")]
		public string Email { get; set; }
		[Required(ErrorMessage = "SĐT không được bỏ trống")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
		public DateTime BirthDate { get; set; }
    }
}
