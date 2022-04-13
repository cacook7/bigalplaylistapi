using System.Data;
using Api.Interfaces;
using System.Dynamic;
using System.Collections.Generic;
using Api.Models;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Api.Data
{
	public class SongDataHandler : ISongDataHandler
	{
		private Database db;
		
		public SongDataHandler()
		{
			db = new Database();
		}
		
		public void Delete(Song song)
		{
			string sql = "UPDATE songs SET deleted='Y' WHERE id=@id and deleted='N'";
			// sql += "UPDATE songs SET deleted='N' WHERE id=@id and deleted='Y";
			var values = GetValues(song);
			db.Open();
			db.Update(sql, values);
			db.Close();
		}
		
		public void Insert(Song song)
		{
			System.Console.WriteLine(song.ID);
			song.Date = DateTime.Now;
			string sql = "INSERT INTO songs (title, date)";
			sql += "VALUES (@title, @date);";
			
			var values = GetValues(song);
			db.Open();
			db.Insert(sql, values);
			db.Close();
		}
		
		public List<Song> Select()
		{
			db.Open();
			string sql = "SELECT * FROM songs WHERE deleted = 'N' ORDER BY date desc";
			List<ExpandoObject> results = db.Select(sql);
			
			List<Song> song = new List<Song>();
			foreach(dynamic item in results)
			{
				Song temp = new Song()
				{
					ID = item.id,
					Title = item.title,
					Date = item.date,
					Favorited = item.favorited
				};
				song.Add(temp);
			}
			db.Close();
			return song;
		}
		
		public Dictionary<string, object> GetValues(Song song)
		{
			var values = new Dictionary<string, object>()
			{
				{"@id", song.ID},
				{"@title", song.Title},
				{"@date", song.Date},
				{"@favorited", song.Favorited}
			};
			return values;
		}
		
		public void Update(Song song)
		{
			string sql = "UPDATE songs SET favorited = 'Y' WHERE id=@id";
			var values = GetValues(song);
			db.Open();
			db.Update(sql, values);
			db.Close();
		}
	}
}