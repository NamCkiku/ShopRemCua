namespace RemCua.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Tags1 = new HashSet<Tag>();
        }

        public int ID { get; set; }

        [StringLength(256)]
        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Tên Sản Phẩm")]
        public string Name { get; set; }

        [Display(Name = "Tiêu Đề Seo")]
        [Required(ErrorMessage = "Bạn Phải Nhập Tiêu Đề Seo")]
        [StringLength(256)]
        public string Alias { get; set; }

        public int CategoryID { get; set; }

        [StringLength(256)]
        [Display(Name = "Ảnh Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Ảnh Sản Phẩm")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [Display(Name = "Gía Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Gía Sản Phẩm")]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public string Warranty { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }
        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Bạn Phải Nhập Số Lượng")]
        public int Quantity { get; set; }

        public decimal OriginalPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(256)]
        public string UpdatedBy { get; set; }

        [StringLength(256)]
        public string MetaKeyword { get; set; }

        [StringLength(256)]
        public string MetaDescription { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Bạn Phải Nhập Trạng Thái")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags1 { get; set; }
    }
}
