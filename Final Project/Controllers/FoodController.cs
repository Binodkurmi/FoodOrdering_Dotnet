using Microsoft.AspNetCore.Mvc;
using Final_Project.Models;
using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace Final_Project.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
       
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookTable;Integrated Security=True;Connect Timeout=30;Encrypt=False;MultiSubnetFailover=False";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult BookTable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookTable(User user)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        string sql = "INSERT INTO Customer (Name, PhoneNumber, Email, NumberOfPerson, DateOfBooking) " +
                                     "VALUES (@Name, @PhoneNumber, @Email, @NumberOfPerson, @DateOfBooking)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Name", user.Name);
                            command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                            command.Parameters.AddWithValue("@Email", user.Email);
                            command.Parameters.AddWithValue("@NumberOfPerson", user.NumberOfPerson);
                            command.Parameters.AddWithValue("@DateOfBooking", user.DateOfBooking);

                            command.ExecuteNonQuery();
                        }
                    }

                 
                    ViewBag.Message = "Congratulations! Your table has been booked successfully";
                    TempData["AlertMessage"] = "Your table has been booked successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                   
                    ViewBag.ErrorMessage = "An error occurred while booking the table: " + ex.Message;
                }
            }
            else
            {
                             ViewBag.ErrorMessage = "Please fill in all required fields";
            }

            return View(user);
        }
    }
}
