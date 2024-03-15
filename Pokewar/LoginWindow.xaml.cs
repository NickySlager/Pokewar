using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Pokewar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pokewar
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class LoginWindow : Window
	{
		private int user_id;
		public LoginWindow()
		{
			this.InitializeComponent();
			using var db = new AppDbContext();

			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();
		}

		private async void Login_Pokewar(object sender, RoutedEventArgs e)
		{
			string email = txtEmail.Text;
			string password = txtPassword.Password;

			using (var db = new AppDbContext())
			{
				// Find the user in the database based on the provided email
				var user = db.Users.FirstOrDefault(u => u.Email == email);

				if (user != null)
				{
					// Hash the entered password using the retrieved salt

					// Compare the hashed password with the one stored in the database
					if (AppDbContext.VerifyPassword(password,user.Password))
					{
						user_id = user.Id;
						var active_window = new PokemonTeamSelection(user_id);
						active_window.Activate();
						this.Close();
						

					}
					else
					{
					}
				}
				else
				{
					
				}
			}

		}

	}

}
