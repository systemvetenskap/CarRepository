using CarDbProject.Models;
using CarDbProject.Repositories;
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // var car =  GetCar(1);
            //car.Model = "XC70";
            //car.Id = 123;
            //SaveCar(car);
            var car = new Car
            {
                Make = "BMW",
                Model = "X6"
            };
            // AddCar(car);
            DeleteCar(1);
            //var cars = GetCars();
        }
    }
}
