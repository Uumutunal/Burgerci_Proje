﻿using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using BLL.Hasher;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userViewModel.PhotoUrl != null)
                {
                    var fileName = Path.GetFileName(userViewModel.PhotoUrl.FileName);
                    var filePath = Path.Combine("wwwroot", "Images", fileName);

                    // Klasörün var olup olmadığını kontrol et, yoksa oluştur
                    var directory = Path.GetDirectoryName(filePath);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await userViewModel.PhotoUrl.CopyToAsync(stream);
                    }

                    userViewModel.Photo = fileName;
                }

                var hashedPassword = SHA_Hasher.ComputeSha256Hash(userViewModel.Password);
                userViewModel.Password = hashedPassword;

                var userDto = _mapper.Map<UserDto>(userViewModel);
                await _userService.Register(userDto);
                return RedirectToAction("Login");
            }

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
           // var hashedPassword = SHA_Hasher.ComputeSha256Hash(password);

            var userDto = await _userService.Login(username, password);
            if (userDto != null)
            {
                var userViewModel = _mapper.Map<UserViewModel>(userDto);

                HttpContext.Session.SetString("UserId", userViewModel.Id.ToString());
                HttpContext.Session.SetString("Username", userViewModel.Username);
                HttpContext.Session.SetString("IsAdmin", userViewModel.IsAdmin.ToString());
                var isAdmin = HttpContext.Session.GetString("IsAdmin");
                if (isAdmin == "True")
                {

                    return RedirectToAction("MenuList", "Menu");

                }
                else
                {
                    return RedirectToAction("UserHomePage");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            ViewData["Title"] = "Logout";
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        public IActionResult UserHomePage()
        {
            return View();
        }

        
    }
}
