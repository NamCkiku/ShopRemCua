namespace RemCua.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Họ Và Tên")]
        [StringLength(256)]
        public string CustomerName { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Địa Chỉ")]
        [StringLength(256)]
        public string CustomerAddress { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Email")]
        [StringLength(256)]
        public string CustomerEmail { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Số Điện Thoại")]
        [StringLength(50)]
        public string CustomerMobile { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Vui Lòng Để Lại Lời Nhắn")]
        [StringLength(256)]
        public string CustomerMessage { get; set; }

        [StringLength(256)]
        public string PaymentMethod { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string PaymentStatus { get; set; }

        public bool Status { get; set; }

        [StringLength(128)]
        public string CustomerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
