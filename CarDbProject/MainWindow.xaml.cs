using CarDbProject.Models;
using CarDbProject.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CarDbProject.Repositories.CarRepository;

namespace CarDbProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /* Agenda
         * 
         * 1. Lägga till transaktioner
         * 2. Hantera "ajdå, det här gick inte bra"
         * 3. Eventuellt: "Smart, kan man koppla ihop C# objekt sådär"
         * 4. Ännu mer eventuellt: "ok, kan man trimma frågorna!"
         * 
         */

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Make="Audi",
                    Model="Q10"
                },
                new Car
                {
                    Make="Audi",
                    Model="Q11"
                },
                new Car
                {
                    Make="Audi med långt namn"
                }
            };
            try
            {
               //AddCars(cars);

            }
            catch (PostgresException ex)
            {
                var code = ex.SqlState;
                
                MessageBox.Show(ex.Message);
            }
             var car =  GetCarWithOwners(3);
            //car.Model = "XC70";
            //car.Id = 123;
            //SaveCar(car);
            car = new Car
            {
                Make = "BMW",
                Model = "X7"
            };

           
            // AddCar(car);
           // DeleteCar(1);
            //var cars = GetCars();
        }
    }
}
