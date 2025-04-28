using Azure;
using BookingApp.Helpers;
using BookingApp.Interfaces;
using BookingApp.Models;
using BookingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly string COOKIE_USER_ID = "USER_ID";
        private readonly LoggerSingleton _logger; 

        public AccountController(IUserService userService)
        {
            _userService = userService;
            _logger = LoggerSingleton.Instance;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.Log("Accessed Login page.");
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            CustomResponse customResponse = new CustomResponse();
            try
            {
                customResponse = _userService.Login(login);

                if (customResponse.Code == 200)
                {
                    if (login.RememberMe)
                    {
                        if (Request.Cookies.ContainsKey(COOKIE_USER_ID))
                        {
                            Response.Cookies.Delete(COOKIE_USER_ID);
                        }

                        int userID = _userService.GetUserID(login.Email);
                        Response.Cookies.Append(COOKIE_USER_ID, userID.ToString());
                    }
                    _logger.Log($"Login successful for user: {login.Email}");                }
                else
                {
                    _logger.Log($"Login failed for user: {login.Email} - Reason: {customResponse.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception during login: {ex.Message}");
                throw;
            }
            return Ok(new CustomResponse { Code = customResponse.Code, Message = customResponse.Message });
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.Log("Accessed Register page.");
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromBody] Register register)
        {
            CustomResponse customResponse = new CustomResponse();
            try
            {
                customResponse = _userService.Register(register);

                if (customResponse.Code == 201)
                {
                    _logger.Log($"Registration successful for user: {register.Email}");
                }
                else
                {
                    _logger.Log($"Registration failed for user: {register.Email} - Reason: {customResponse.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception during registration: {ex.Message}");
                throw;
            }

            return Ok(new CustomResponse { Code = customResponse.Code, Message = customResponse.Message });
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            _logger.Log("Accessed ForgotPassword page.");
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword([FromBody] ResetPassword resetPassword)
        {
            CustomResponse customResponse = new CustomResponse();
            try
            {
                customResponse = _userService.ResetPassword(resetPassword);

                if (customResponse.Code == 200)
                {
                    _logger.Log($"Password reset request successful for email: {resetPassword.Email}");
                }
                else
                {
                    _logger.Log($"Password reset request failed for email: {resetPassword.Email} - Reason: {customResponse.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception during password reset: {ex.Message}");
                throw;
            }

            return Ok(new CustomResponse { Code = customResponse.Code, Message = customResponse.Message });
        }
    }
}
