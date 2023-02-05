using EduHome.Business.DTOs.Courses;
using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> FindAllAsync();
        Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course>> expression);
        Task<CourseDTO> FindByIdAsync(int id);
        Task CreateAsync(CoursePostDTO course);
        void Update(CourseDTO course);
        void Delete(CourseDTO course);
    }
}
