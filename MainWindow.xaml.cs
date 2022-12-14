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
using YellowCarrot_App.Data;
using YellowCarrot_App.Models;
using YellowCarrot_App.Services;

namespace YellowCarrot_App
{
    public partial class MainWindow : Window
    {
        private User? _signInUser;

        public MainWindow()
        {
            InitializeComponent();

            using (AppDbContext context = new())
            {

                UserRepository userRepo = new UserRepository(context);
                //userRepo.AddDefaultUsers();
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool isFoundUser = false;

            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                string userName = txtUsername.Text;
                string password = txtPassword.Password;

                User? user = uow.UserRepo.GetUser(userName);
                _signInUser = user;
                if (txtUsername.Text != null)
                {
                    if (user != null)
                    {
                        if (user.Password == password)
                        {
                            isFoundUser = true;
                            if (isFoundUser)
                            {
                                RecipeWindow recipeWindow = new(_signInUser!);
                                recipeWindow.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password don't match");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The user cant't be found!");
                    }
                }
                else { MessageBox.Show("Fill in the gaps!"); }
                
            }   
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new();
            this.Close();
            signUpWindow.Show();
        }
    }
}
