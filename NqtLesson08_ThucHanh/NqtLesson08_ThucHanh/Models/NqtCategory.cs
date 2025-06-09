using System.ComponentModel.DataAnnotations;

namespace NqtLesson08_ThucHanh.Models
{
    public class NqtCategory
    {
        public int NqtId { get; set; }

        [Required(ErrorMessage = "Tên danh mục là bắt buộc.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên danh mục phải từ 6 đến 150 ký tự.")]
        public string NqtName { get; set; }
    }
}