using Newtonsoft.Json;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountVm
    {
        public int Id { get; set; }

        [Display(Name = "活動名稱")]
        [Required(ErrorMessage = "請輸入活動名稱")]
        public string DiscountName { get; set; }

        [Display(Name = "活動類型")]
        [Required(ErrorMessage = "請上傳活動類型")]
        public string DiscountType { get; set; }

        [Display(Name = "活動圖片")]
        [Required(ErrorMessage = "請上傳活動圖片")]
        public string DiscountImage { get; set; }

        [Display(Name = "開始日期")]
        [Required(ErrorMessage = "請選擇開始日期")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "結束日期")]
        [Required(ErrorMessage = "請選擇結束日期")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display(Name = "折扣百分比")]
        [Required(ErrorMessage = "請輸入折扣百分比")]
        [Range(1, 100, ErrorMessage = "折扣百分比必須在 1 到 100 之間")]
        public int Percent { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        public string Game { get; set; }

        [Display(Name = "活動類型")]
        public IEnumerable<SelectListItem> DiscountTypeList { get; set; }

        public int DeveloperId {  get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("結束日期不能早於開始日期", new[] { nameof(EndDate) });
            }
        }
    }



    
}

