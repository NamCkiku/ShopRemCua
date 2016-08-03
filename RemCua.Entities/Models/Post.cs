namespace RemCua.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        public int ID { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Bạn Phải Nhập Tiêu Đề Tin")]
        [StringLength(256)]
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

        [StringLength(500)]
        [Display(Name = "Mô Tả Ngắn")]
        [Required(ErrorMessage = "Bạn Phải Nhập Mô Tả Ngắn")]
        public string Description { get; set; }
        [Display(Name = "Nội Dung")]
        [Required(ErrorMessage = "Bạn Phải Nhập Nội Dung")]
        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

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

        public bool Status { get; set; }

        public virtual PostCategory PostCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
