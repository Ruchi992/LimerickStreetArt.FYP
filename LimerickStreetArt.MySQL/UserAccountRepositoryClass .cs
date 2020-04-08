namespace LimerickStreetArt.MySQL
{
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using MySql.Data.MySqlClient;
	using System;
	using System.Collections.Generic;
	using System.Data;

	public class UserAccountRepositoryClass : UserAccountRepository
	{
		public DatabaseClass Database { get; private set; }
		public UserAccountRepositoryClass(DatabaseClass database)
		{
			this.Database = database;
		}
		public void Create(UserAccount userAccount)
		{

			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "InsertUserAccount";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
				};
				{

					command.Parameters.AddWithValue("@AccessLevel", userAccount.AccessLevel);
					command.Parameters.AddWithValue("@Active", userAccount.Active);
					command.Parameters.AddWithValue("@DateOfBirth", userAccount.DateOfBirth);
					command.Parameters.AddWithValue("@Email", userAccount.Email);
					command.Parameters.AddWithValue("@Username", userAccount.Username);


					command.Prepare();

					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(UserAccount userAccount)
		{
			throw new System.NotImplementedException();
		}

		public UserAccount GetById(int id)
		{
			throw new System.NotImplementedException();
		}

		public List<UserAccount> GetActiveUserAccounts()
		{
			throw new System.NotImplementedException();
		}

		public UserAccount Login(string username, string password)
		{
			throw new System.NotImplementedException();
		}

		public List<UserAccount> Query(object query)
		{
			throw new System.NotImplementedException();
		}

		public List<UserAccount> SelectAll()
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "InsertUserAccount";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
				};
				{
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable);
					}
				}
			}
		}

		public void Update(UserAccount userAccount)
		{
			throw new System.NotImplementedException();
		}

		private List<UserAccount> Transform(DataTable dataTable)
		{
			var userAccounts = new List<UserAccount>();

			foreach (DataRow dataRow in dataTable.Rows)
			{
				userAccounts.Add(this.Transform(dataRow));

			}
			return userAccounts;
		}

		private UserAccount Transform(DataRow dataRow)
		{
			return new UserAccount
			{
				Active = (SByte)dataRow["Active"] ==1?true:false,
				AccessLevel = (int)dataRow["AccessLevel"],
				Email = (String)dataRow["Email"],
				Id = (int)dataRow["Id"],

			};
		}
	}
}
