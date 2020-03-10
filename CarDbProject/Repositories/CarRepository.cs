using CarDbProject.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CarDbProject.Repositories
{
    public static class CarRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["dbLocal"].ConnectionString;
        
        
        // CRUD
        
        #region READ
        public static Car GetCar(int id)
        {
            string stmt = "select id, make,model from car where id=@id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Car car = null;
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car = new Car
                            {
                                Id = (int)reader["id"],
                                Make = (string)reader["make"],
                                Model = (string)reader["model"],
                            };
                        }
                    }
                }
                return car;
            }
        }
        public static IEnumerable<Car> GetCars()
        {
            string stmt = "select id, make,model from car";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Car car = null;
                List<Car> cars = new List<Car>();
                conn.Open();

                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car = new Car
                            {
                                Id = (int)reader["id"],
                                Make = (string)reader["make"],
                                Model = (string)reader["model"],
                            };
                            cars.Add(car);
                        }
                    }
                }
                return cars;
            }
        }

        #endregion
        #region UPDATE

        #endregion
    }
}
