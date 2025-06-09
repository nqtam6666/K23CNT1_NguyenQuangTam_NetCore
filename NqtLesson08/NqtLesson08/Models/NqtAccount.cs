using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace NqtLesson08.Models
{
    public class NqtAccount
    {
        [Key]
        public int NqtId { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Họ tên phải từ 6 đến 20 ký tự")]
        public string NqtFullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string NqtEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Remote(action: "VerifyPhone", controller: "NqtAccount", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string NqtPhone { get; set; }

        [Display(Name = "Địa chỉ")]
        public string NqtAddress { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string NqtAvatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime NqtBirthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string NqtGender { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
        [DataType(DataType.Password)]
        public string NqtPassword { get; set; }

        [Display(Name = "Facebook")]
        [Url(ErrorMessage = "Facebook phải là một URL hợp lệ")]
        public string NqtFacebook { get; set; }
    }
}