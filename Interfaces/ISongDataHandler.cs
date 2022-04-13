using System.Collections.Generic;
using Api.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Api.Interfaces
{
	public interface ISongDataHandler
	{
		 public List<Song> Select();
		 
		 public void Delete(Song song);
		 
		 public void Update(Song song);
		 
		 public void Insert(Song song);
	}
}