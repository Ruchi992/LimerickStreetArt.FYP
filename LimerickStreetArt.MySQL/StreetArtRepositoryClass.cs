namespace LimerickStreetArt.MySQL
{

    using System.Collections.Generic;
	using System;
	using System.Collections.Generic;
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
					command.Parameters.AddWithValue("@GpsLatitude", StreetArt.GpsLatitude);
					command.Parameters.AddWithValue("@GpsLongitude", StreetArt.GpsLongitude);
					command.Parameters.AddWithValue("@Title", StreetArt.Title);
					command.Parameters.AddWithValue("@Street", StreetArt.Street);
					command.Parameters.AddWithValue("@Timestamp", StreetArt.Timestamp);
					command.Parameters.AddWithValue("@Image", StreetArt.Image);
					command.Parameters.AddWithValue("@UserAccountId", StreetArt.UserAccountId);


					command.Prepare();

					command.ExecuteNonQuery();
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
	

		public StreetArt GetById(int StreetArtId)
		{
			using var connection = new MySqlConnection(Database.ConnectionString);
			{
				connection.Open();

				var commandText = "GetById";
				using var command = new MySqlCommand
				{
					Connection = connection,
					CommandText = commandText,
					CommandType = CommandType.StoredProcedure,
				};
				{
					command.Parameters.Add("@ID", id);

					command.Prepare();
					var dataTable = new DataTable("Table");
					using var dataAdapter = new MySqlDataAdapter(command);
					{
						dataAdapter.Fill(dataTable);
						command.ExecuteNonQuery();
					}
				}
			}
		}

	}

	public List<StreetArt> SelectAll()
		{
			throw new NotImplementedException();
		}

		public void Update(StreetArt streetart)
		{
			throw new NotImplementedException();
		}
	}
}
