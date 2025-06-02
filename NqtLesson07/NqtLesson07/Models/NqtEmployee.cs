using System.ComponentModel.DataAnnotations;

namespace NqtLesson07.Models
{
    public class NqtEmployee
    {
        public int NqtID { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự")]
        public string NqtName { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string NqtEmail { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [DataType(DataType.Date)]
        public DateTime NqtBirthDay { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string NqtPhone { get; set; }

        [Required(ErrorMessage = "Lương là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Lương phải là số không âm")]
        public double NqtSalary { get; set; }

        public bool NqtStatus { get; set; }
    }
}
