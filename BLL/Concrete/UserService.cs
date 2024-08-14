using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllUsers()
        {
            var allUsers = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDto>>(allUsers);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var theUser = await _userRepository.GetByIdAsync(id);
            if (theUser == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserDto>(theUser);
        }

        public async Task<UserDto> Login(string username, string password)
        {
            var allUsers = await _userRepository.GetAllAsync();
            var theUser = allUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
            
            return null;
        }

        public async Task Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);

            user.Photo = userDto.Photo;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Address = userDto.Address;
            user.Username = userDto.Username;
            user.Password = userDto.Password;

            await _userRepository.UpdateAsync(user);
        }
    }
}
