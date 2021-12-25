using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Classes {
	public class Database {

		private MySqlConnection connection;

		private string databaseAddress;
		private string databaseName;
		private string databasePort;
		private string databaseUsername;
		private string databasePassword;

		public Database() {
			this.databaseAddress = "127.0.0.1";
			this.databasePort = "3306";
			this.databaseUsername = "root";
			this.databasePassword = "";
			this.databaseName = "schoolsystem";
			
			string sqlLoginString = $"Server={this.databaseAddress};Port={this.databasePort};SslMode=none;User Id={this.databaseUsername};Password={this.databasePassword};Database={this.databaseName}";
			this.connection = new MySqlConnection(sqlLoginString);
		}

		public bool connect() {
			try {
				this.connection.Open();
				return true;
			} catch (Exception ex) {
				Debug.WriteLine(ex.Message);
				return false;
			}

			//return this.connection;
		}

		public bool disconnect() {
			try {
				this.connection.Close();
				return true;
			} catch (Exception ex) {
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		public MySqlDataReader query(string inputQuery) {
			MySqlCommand myCmd = new MySqlCommand();
			myCmd.Connection = this.connection;

			myCmd.CommandText = inputQuery;
			MySqlDataReader reader = myCmd.ExecuteReader();

			return reader;
		}

		public List<Dictionary<string, dynamic>> convertData(MySqlDataReader input) {

			List<Dictionary<string, dynamic>> result = new List<Dictionary<string, dynamic>>();

			// Getting the number of columns in the table
			int columns = input.FieldCount;
			
			// Looping thorugh every row
			while (input.Read()) {
				// Making a temporary variable which contains the row values
				Dictionary<string, dynamic> row = new Dictionary<string, dynamic>();
				for (int i = 0; i < columns; i++) {
					//Debug.WriteLine(input.GetName(i) + " : " + input.GetValue(i));
					// Adding it to a dictionary, which includes the row
					row.Add(input.GetName(i), input.GetValue(i));
				}
				// Adding the row to the list of rows
				result.Add(row);
			}

			return result;
		} 

	}
}
