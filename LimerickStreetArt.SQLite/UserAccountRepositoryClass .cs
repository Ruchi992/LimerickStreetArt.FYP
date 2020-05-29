namespace LimerickStreetArt.SQLite
{
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SQLite;
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

			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();
				//var ID = Database.LastInsertId();

				var commandText = "CreateUserAccount";
				using var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};
				{
					command.Parameters.AddWithValue("@AccessLevel", userAccount.AccessLevel);
					command.Parameters.AddWithValue("@Active", userAccount.Active);
					command.Parameters.AddWithValue("@DateOfBirth", userAccount.DateOfBirth);
					command.Parameters.AddWithValue("@Email", userAccount.Email);
					command.Parameters.AddWithValue("@Password", userAccount.Password);
					command.Parameters.AddWithValue("@Username", userAccount.Username);

					var idParamater = new SQLiteParameter
					{
						Direction = ParameterDirection.Output,
						ParameterName = "@id_",
					};
					command.Parameters.Add(idParamater);

					command.Prepare();
					command.ExecuteNonQuery();

					userAccount.Id = (int)idParamater.Value;
				}
			}
		}


		public void Delete(UserAccount userAccount)
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{

				connection.Open();

				var commandText = "DeleteUserAccount";
				using var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};
				{
					command.Parameters.AddWithValue("@Id_", userAccount.Id);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		public UserAccount GetById(int id)
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetUserAccountById";
				using var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};
				{
					command.Parameters.Add(new SQLiteParameter("Id_", id));

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new SQLiteDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable).FirstOrDefault();
					}
				}
			}
		}

		public List<UserAccount> GetActiveUserAccounts()
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetActiveUserAccounts";
				var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};

				command.Prepare();
				var dataTable = new DataTable("Table");
				using var dataAdapter = new SQLiteDataAdapter(command);
				{
					dataAdapter.Fill(dataTable);
					return this.Transform(dataTable);
				}

			}
		}


		public UserAccount GetUserAccountByCredentials(string username, string password)
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = @"select * from `useraccount` U
where U.`Username` = @username And U.`Password` = @password; ";
				var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};

				command.Parameters.Add(new SQLiteParameter("@username", username));
				command.Parameters.Add(new SQLiteParameter("@password", password));

				command.Prepare();
				var dataTable = new DataTable("Table");
				using var dataAdapter = new SQLiteDataAdapter(command);
				{
					dataAdapter.Fill(dataTable);
					return this.Transform(dataTable).FirstOrDefault();
				}

			}
		}

		public List<UserAccount> GetUserAccounts()
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "select * from `useraccount` U";
				using var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
				};
				{
					var dataTable = new DataTable("Table");
					using var dataAdapter = new SQLiteDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable);
					}
				}
			}
		}

		public void Update(UserAccount userAccount)
		{
			using var connection = new SQLiteConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "UpdateUserAccount";
				using var command = new SQLiteCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.Text,
				};

				{
					command.Parameters.AddWithValue("@AccessLevel", userAccount.AccessLevel);
					command.Parameters.AddWithValue("@Active", userAccount.Active);
					command.Parameters.AddWithValue("@DateOfBirth", userAccount.DateOfBirth);
					command.Parameters.AddWithValue("@Email", userAccount.Email);
					command.Parameters.AddWithValue("@Username", userAccount.Username);
					command.Parameters.AddWithValue("@Password", userAccount.Password);
					command.Parameters.AddWithValue("@Id_", userAccount.Id);


					command.Prepare();

					command.ExecuteNonQuery();
				}
			}
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
				Password = (String)dataRow["Password"],

				Username = (String)dataRow["Username"],
			};
		}


	}
}