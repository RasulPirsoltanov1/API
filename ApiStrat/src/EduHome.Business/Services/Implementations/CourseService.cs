using AutoMapper;
using EduHome.Business.DTOs.Courses;
using EduHome.Business.Exceptions;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Business.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<List<CourseDTO>> FindAllAsync()
        {
            var courses = await _courseRepository.FindAll().ToListAsync();
            if (courses == null || courses.Count == 0)
            {
                throw new NotFoundException("Not Found!");
            }
            var result = _mapper.Map<List<CourseDTO>>(courses);
            return result;
        }
        public async Task<CourseDTO> FindByIdAsync(int id)
        {
            var course=await _courseRepository.FindByIdAsync(id);
            if (course == null)
            {
                throw new NotFoundException("Not Found");
            }
            var result = _mapper.Map<CourseDTO>(course);
            return result;
        }
        public async Task<List<CourseDTO>> FindByConditionAsync(Expression<Func<Course>> expression)
        {
            var course=await _courseRepository.FindByCondition(expression).ToListAsync();
            var result = _mapper.Map<List<CourseDTO>>(course);
            return result;
        }

        public async Task CreateAsync(CoursePostDTO course)
        {
            if(course == null)
            {
                throw new ArgumentNullException();
            }
            var newCourse=_mapper.Map<Course>(course);
            await _courseRepository.CreateAsync(newCourse);
            await _courseRepository.SaveAsync();
        }

        public void Delete(CourseDTO course)
        {
            throw new NotImplementedException();
        }

      

      
        public void Update(CourseDTO course)
        {
            throw new NotImplementedException();
        }
    }
}
