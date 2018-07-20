using AutoMapper;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid Add(UserDto dto)
        {
            var model = Mapper.Map<UserDto, User>(dto);
            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.UserId;
        }
        public bool Edit(UserDto dto)
        {
            User user = Mapper.Map<UserDto, User>(dto);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            User user = _unitOfWork.UserRepository.FindById(id);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public UserDto GetById(Guid id)
        {
            var model = _unitOfWork.UserRepository.FindById(id);
            return Mapper.Map<User, UserDto>(model);
        }

        public List<UserDto> GetAll()
        {
            return Mapper.Map<List<User>, List<UserDto>>(_unitOfWork.UserRepository.GetAll());
        }
        public bool HasRole(Guid id,String role)
        {
            return GetById(id).Role == role;
        }
        public bool Exists(Guid id)
        {
            return GetById(id) == null ? false : true;
        }


        public List<UserDto> GetUsersByRole(string role)
        {
            return GetAll().AsEnumerable().Where(u => HasRole(u.UserId, role)).ToList();
        }

        public bool IsEmailUnique(string email)
        {
            return true;
        }
    }
}
