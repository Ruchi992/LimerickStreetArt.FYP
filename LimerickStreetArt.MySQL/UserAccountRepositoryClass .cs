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
				//var ID = Database.LastInsertId();

				var commandText = "CreateUserAccount";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};
				{

					command.Parameters.AddWithValue("@AccessLevel", userAccount.AccessLevel);
					command.Parameters.AddWithValue("@Active", userAccount.Active);
					command.Parameters.AddWithValue("@DateOfBirth", userAccount.DateOfBirth);
					command.Parameters.AddWithValue("@Email", userAccount.Email);
					command.Parameters.AddWithValue("@Password", userAccount.Password);

					command.Parameters.AddWithValue("@Username", userAccount.Username);
					command.Parameters.AddWithValue("@id", userAccount.Id);


					command.Prepare();
					command.ExecuteNonQuery();

					//TODO :RD Id not updating : always returns 0, should return next number in column say 8
					//TODO: out and fix why command.LastInsertedI isn't working
					//TODO: out paramaters in stored procedures
					//TODO: return select statementt from the stored procedure
					//TODO: call a asepeerate stroed procedure to get LastInsertedId;
					long id = command.LastInsertedId;
					userAccount.Id = (int)id;
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
						CommandType = CommandType.StoredProcedure,
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
						CommandType = CommandType.StoredProcedure,
					};
					{
						command.Parameters.Add(new MySqlParameter("Id_", id));

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
				using var connection = new MySqlConnection(Database.ConnectionString);
				{
					connection.Open();

					var commandText = "GetActiveUserAccounts";
					var command = new MySqlCommand
					{
						Connection = connection,
						CommandText = commandText,
						CommandType = CommandType.StoredProcedure,
					};

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable);
					}

				}
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
						CommandType = CommandType.StoredProcedure,
					};

					command.Parameters.Add(new MySqlParameter("username", username));
					command.Parameters.Add(new MySqlParameter("password", password));

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						return this.Transform(dataTable).FirstOrDefault();
					}

				}
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
				using var connection = new MySqlConnection(Database.ConnectionString);
				{
					connection.Open();

					var commandText = "UpdateUserAccount";
					using var command = new MySqlCommand
					{
						Connection = connection,
						CommandText = commandText,
						CommandType = CommandType.StoredProcedure,
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