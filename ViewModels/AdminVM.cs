﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _1262228_Arosh.Models;
using System.Web.Mvc;

namespace _1262228_Arosh.ViewModels
{
    public class AdminVM
    {
        public int StudentID { get; set; }
        //[Required(ErrorMessage = "This Field is Required!")]
        //[StringLength(20, MinimumLength = 4, ErrorMessage = "You Must be Give Minimum 4 and Maximum 20 Chrecter")]
        public string firstName { get; set; }
        //[Required(ErrorMessage = "This Field is Required!")]
        //[StringLength(20, MinimumLength = 4, ErrorMessage = "You Must be Give Minimum 2 and Maximum 15 Chrecter")]
        public string lastName { get; set; }
        //[Required(ErrorMessage = "This Field is Required!")]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        //[Remote("EmailisExists", "MyStudent", ErrorMessage = "This Email Address Exist")]

        public string Email { get; set; }
       // [StringLength(11, MinimumLength = 11, ErrorMessage = "You Must be Give Minimum 11 and Maximum 11 Chrecter")]
       // [Required(ErrorMessage = "This Field is Required!")]
       // [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }
        public string Gender { get; set; }
       // [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
       // [MyDateTimeValidation(ErrorMessage = "Date Must be 1990 and 2008")]
        public Nullable<System.DateTime> DOB { get; set; }
        //[Required(ErrorMessage ="This Field is Required!")]
        public Nullable<int> ClassID { get; set; }
       // [Required(ErrorMessage = "This Field is Required!")]
        public string Shift { get; set; }
        public string Address { get; set; }
        //[Required(ErrorMessage = "This Field is Required!")]
        public string Picture { get; set; }
        public Nullable<bool> Status { get; set; } = false;
        public Nullable<int> ParentsID { get; set; }

        public virtual Classess Classess { get; set; }
        public virtual Parent Parent { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }

        [NotMapped]
        //[System.ComponentModel.DataAnnotations.Compare("Mobile")]
        [Display(Name = "Confirm Mobile Number")]
        public string ConfirmMobile { get; set; }
    }
}