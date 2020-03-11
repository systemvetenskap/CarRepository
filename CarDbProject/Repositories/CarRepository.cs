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
        #region CREATE
        public static int AddCar(Car car)
        {
            string stmt = "INSERT INTO car(make, model) values(@make,@model) returning id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("make", car.Make);
                    command.Parameters.AddWithValue("model", car.Model);
                    int id = (int)command.ExecuteScalar();
                    car.Id = id;
                    return id;
                }
            }
        }
        #endregion
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
        public static void SaveCar(Car car)
        {
            string stmt = "UPDATE car set model = @model, make=@make where id=@id";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("make", car.Make);
                    command.Parameters.AddWithValue("model", car.Model);
                    command.Parameters.AddWithValue("id", car.Id);
                    command.ExecuteScalar();
                }
            }
        }
        #endregion
        #region DELETE
        public static void DeleteCar(int id)
        {
            string stmt = "DELETE FROM car WHERE id = @id";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteScalar();
                }
            }
        }

        public static void Delete(object poco)
        {

        }
        #endregion
    }
}
