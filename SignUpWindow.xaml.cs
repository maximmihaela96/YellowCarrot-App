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
using System.Windows.Shapes;
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;
using YellowCarrot_App.Services;

namespace YellowCarrot_App
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }
        private void ClearUi()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            
            string userNamn = txtUsername.Text;
            string password = txtPassword.Password;

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);

                uow.UserRepo.AddUser(new User()
                {
                    UserNamn = userNamn,
                    Password = password
                });

                uow.SaveChanges();

                ClearUi();
            }
            
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
        }
    }
}
