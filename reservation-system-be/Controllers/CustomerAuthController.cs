﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using reservation_system_be.Data;
using reservation_system_be.Models;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using reservation_system_be.Services.CustomerAuthServices;
using reservation_system_be.DTOs;

namespace reservation_system_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAuthController : ControllerBase
    {
        private readonly CustomerAuthService _customerAuthService;


        public CustomerAuthController(CustomerAuthService customerAuthService)
        {
            _customerAuthService = customerAuthService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerAuthDTO customer)
        {
            try
            {
                var result = await _customerAuthService.Register(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerAuthDTO customer)
        {
            try
            {
                var token = await _customerAuthService.Login(customer);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        
        
        [HttpPost("Forgot password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var result = await _customerAuthService.ForgotPassword(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

