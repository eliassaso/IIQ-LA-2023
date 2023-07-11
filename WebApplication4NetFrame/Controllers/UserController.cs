using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4NetFrame.Models.DAO;
using WebApplication4NetFrame.Models.DTO;


namespace WebApplication4NetFrame.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userRepository = new UserDAO();

        public ActionResult Index()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                users = userRepository.ReadUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting users: " + ex.Message);
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDTO user)
        {
            try
            {
                string result = userRepository.InsertUser(user);
                Console.WriteLine("User added: " + result);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                return View(user);
            }
        }
    }
}