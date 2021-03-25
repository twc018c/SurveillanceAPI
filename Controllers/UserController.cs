using Microsoft.AspNetCore.Mvc;
using Surveillance.Interfaces;
using Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Controllers {

    /// <summary>
    /// 使用者
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {

        private readonly IUserRepository UserRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_UserRepository"></param>
        public UserController(IUserRepository _UserRepository) {
            UserRepository = _UserRepository;
        }


        /// <summary>
        /// 取得使用者清單
        /// </summary>
        [HttpGet]
        public async Task<List<UserModel>> GetList() {
            return await UserRepository.GetList();
        }
    }
}