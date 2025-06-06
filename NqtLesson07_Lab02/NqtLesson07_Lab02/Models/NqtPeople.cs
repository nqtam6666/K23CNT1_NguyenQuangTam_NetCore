namespace NqtLesson07_Lab02.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NqtPeople
    {
        public int NqtID { get; set; }

        [Display(Name = "Họ và tên")]
        public string NqtName { get; set; }

        [Display(Name = "Địa chỉ email")]
        public string NqtEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        public string NqtPhone { get; set; }

        [Display(Name = "Địa chỉ")]
        public string NqtAddress { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string NqtAvatar { get; set; }

        [Display(Name = "Ngày sinh nhật")]
        public DateTime NqtBirthday { get; set; }

        [Display(Name = "Giới thiệu")]
        public string NqtBio { get; set; }

        [Display(Name = "Giới tính")]
        public byte NqtGender { get; set; }
    }
}