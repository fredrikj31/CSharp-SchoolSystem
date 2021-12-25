using SchoolSystem.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SchoolSystem {
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window {
		public Login() {
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e) {
			User user = new User(this.inputUsername.Text, this.inputPassword.Password);

			bool result = user.loginUser();

			if (result == true) {
				MessageBox.Show("You are now logged in.", "Login Success", MessageBoxButton.OK, MessageBoxImage.Information);
			} else {
				MessageBox.Show("You typed in the wrong credentials", "Wrong Credentials", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
