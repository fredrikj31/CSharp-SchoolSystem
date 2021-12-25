using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Classes {
	public class User {

		private int id;
		private string username;
		private string password;
		private string email;

		public User(string inputUsername, string inputPassword, int inputId = 0, string inputEmail = "") {
			this.id = inputId;
			this.username = inputUsername;
			this.password = inputPassword;
			this.email = inputEmail;
		}

		public bool loginUser() {
			bool result = false;

			Database db = new Database();
			db.connect();

			string myQuery = $"SELECT * FROM `users` WHERE `Username`='{this.username}' AND `Password`='{this.password}'";

			MySqlDataReader reader = db.query(myQuery);

			if (reader.HasRows) {
				List<Dictionary<string, dynamic>> rows = db.convertData(reader);

				if (rows.Count == 1) {
					Dictionary<string, dynamic> data = rows[0];

					result = true;
				} else {
					Debug.WriteLine("There are multiple users with these credentials");
					result = false;
				}
			} else {
				Debug.WriteLine("No users found!");
				result = false;
			}

			reader.Close();
			return result;
		}
	}
}
