using System.ComponentModel.DataAnnotations;

namespace NqtLesson08_ThucHanh.Models
{
    public class NqtProduct
    {
        public int NqtId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự.")]
        public string NqtName { get; set; }

        [Required(ErrorMessage = "Giá gốc là bắt buộc.")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá gốc phải lớn hơn hoặc bằng 100,000.")]
        public float NqtPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải lớn hơn hoặc bằng 0.")]
        [CustomSalePriceValidation(ErrorMessage = "Giá khuyến mãi không được vượt quá 10% giá gốc.")]
        public float NqtSalePrice { get; set; }

        [Required(ErrorMessage = "Hình ảnh là bắt buộc.")]
        [DataType(DataType.Upload)]
        public string NqtImage { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc.")]
        [StringLength(1500, MinimumLength = 6, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự.")]
        [CustomDescriptionValidation]
        public string NqtDescription { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc.")]
        public int NqtCategoryId { get; set; }

        // Custom validation cho SalePrice
        public class CustomSalePriceValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var product = (NqtProduct)validationContext.ObjectInstance;
                if (value != null && product.NqtPrice > 0)
                {
                    float salePrice = (float)value;
                    if (salePrice > product.NqtPrice * 1.1)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                return ValidationResult.Success;
            }
        }

        // Custom attribute để kiểm tra giá trị trong NqtDescription
        public class CustomDescriptionValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var restrictedValues = new[] { "die", "admin", "fack" };
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    string description = value.ToString().ToLower();
                    if (restrictedValues.Any(v => description.Contains(v)))
                    {
                        return new ValidationResult("Mô tả không được chứa các giá trị như die, admin, hoặc fack.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}