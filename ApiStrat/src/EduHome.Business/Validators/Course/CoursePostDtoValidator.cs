using EduHome.Business.DTOs.Courses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.Validators.Course
{
    public class CoursePostDtoValidator:AbstractValidator<CoursePostDTO>
    {
        public CoursePostDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Must not Null")
                .MaximumLength(150).WithMessage("Maximum length:150");
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Lütfen soyadı boş geçmeyiniz.")
                .MaximumLength(500).WithMessage("Maximum length:150");
            RuleFor(c => c.Image)
                .NotEmpty().WithMessage("Lütfen soyadı boş geçmeyiniz.")
                .MaximumLength(500).WithMessage("Maximum length:150");
        }
    }
}
