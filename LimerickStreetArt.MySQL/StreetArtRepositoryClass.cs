namespace LimerickStreetArt.MySQL
{
	using System.Collections.Generic;
	using System;
	using System.Data;
	using System.Linq;
	using LimerickStreetArt;
	using LimerickStreetArt.Repository;
	using MySql.Data.MySqlClient;
	public class StreetArtRepositoryClass : StreetArtRepository
	{
		public DatabaseClass Database { get; private set; }


		public StreetArtRepositoryClass(DatabaseClass database)
		{
			this.Database = database;
		}

		public void Create(StreetArt streetart)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "Createstreetart";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};
				{
					command.Parameters.AddWithValue("@GpsLatitude", streetart.GpsLatitude);
					command.Parameters.AddWithValue("@GpsLongitude", streetart.GpsLongitude);
					command.Parameters.AddWithValue("@Title", streetart.Title);
					command.Parameters.AddWithValue("@Street", streetart.Street);
					command.Parameters.AddWithValue("@Timestamp", streetart.Timestamp);
					command.Parameters.AddWithValue("@Image", streetart.Image);
					command.Parameters.AddWithValue("@UserAccountId", streetart.UserAccountId);
					command.Parameters.AddWithValue("@Id", streetart.Id);
					command.Prepare();
					command.ExecuteNonQuery();

					//TODO :RD Id not updating
					long id = command.LastInsertedId;
					streetart.Id = (int)id;
				}
			}
		}
		public void Delete(StreetArt streetart)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{

				connection.Open();

				var commandText = "DeleteStreetArt";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};
				{
					command.Parameters.AddWithValue("@Id", streetart.Id);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		public StreetArt GetById(int streetArtId)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetStreetArtById";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};
				{
					command.Parameters.Add(new MySqlParameter("@_id", streetArtId));

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						command.ExecuteNonQuery();
						return this.Transform(dataTable).FirstOrDefault();
					}
				}
			}
		}
		public List<StreetArt> GetStreetArtList()
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetStreetArtList";
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

		public void Update(StreetArt streetart)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "UpdateStreetArt";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};

				{

					command.Parameters.AddWithValue("@GpsLatitude", streetart.GpsLatitude);
					command.Parameters.AddWithValue("@GpsLongitude", streetart.GpsLongitude);
					command.Parameters.AddWithValue("@Title", streetart.Title);
					command.Parameters.AddWithValue("@Street", streetart.Street);
					command.Parameters.AddWithValue("@Timestamp", streetart.Timestamp);
					command.Parameters.AddWithValue("@Image", streetart.Image);
					command.Parameters.AddWithValue("@UserAccountId", streetart.UserAccountId);

					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		private List<StreetArt> Transform(DataTable dataTable)
		{
			var streetArtList = new List<StreetArt>();

			foreach (DataRow dataRow in dataTable.Rows)
			{
				streetArtList.Add(this.Transform(dataRow));

			}
			return streetArtList;
		}
		private StreetArt Transform(DataRow dataRow)
		{
			return new StreetArt
			{
				GpsLatitude = (float)dataRow["GpsLatitude"],
				GpsLongitude = (float)dataRow["GpsLongitude"] ,
				Title = (string)dataRow["Title"],
				Street= (string)dataRow["Street"],
				Timestamp = (DateTime)dataRow["Timestamp"],
				//Image = (String)dataRow["Image"],
				UserAccountId = (int)dataRow["UserAccountId"],
				
			};
		}


	}
}