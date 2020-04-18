namespace LimerickStreetArt.MySQL
{
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using MySql.Data.MySqlClient;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;

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

				var commandText = "CreateUserAccount";
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
			using var connection = new MySqlConnection(Database.ConnectionString);
			{

				connection.Open();

				var commandText = "DeleteUserAccount";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
				};
				{
					command.Parameters.AddWithValue("@Id", userAccount.Id);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		public UserAccount GetById(int id)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetUserAccountById";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
				};
				{
					command.Parameters.Add(new MySqlParameter("@Id_", id));
					command.Parameters.Add(new MySqlParameter("@id", id));

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable).FirstOrDefault();
					}
				}
			}
		}

		public List<UserAccount> GetActiveUserAccounts()
		{
			throw new System.NotImplementedException();
		}

		public UserAccount GetUserAccountByCredentials(string username, string password)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetUserAccountByCredentials";
				var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
				};

				command.Parameters.Add(new MySqlParameter("@username", username));
				command.Parameters.Add(new MySqlParameter("@password", password));

				command.Prepare();
				var dataTable = new DataTable("Table");
				using var dataAdapter = new MySqlDataAdapter(command);
				{
					dataAdapter.Fill(dataTable);
					return this.Transform(dataTable).FirstOrDefault();
				}

			}
		}

		public List<UserAccount> Query(object query)
		{
			throw new System.NotImplementedException();
		}

		public List<UserAccount> GetUserAccounts()
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetUserAccounts";
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
				Active = (SByte)dataRow["Active"] == 1 ? true : false,
				AccessLevel = (int)dataRow["AccessLevel"],
				DateOfBirth = (DateTime)dataRow["DateOfBirth"],
				Email = (String)dataRow["Email"],
				Id = (int)dataRow["Id"],
				Username = (String)dataRow["Username"],
			};
		}
	}
}