using System;
using Api.Data;
using Api.Interfaces;

namespace Api.Models
{
	public class Song
	{
		public int ID {get; set;}
		public string Title{get; set;}
		public DateTime Date{get; set;}
		public string Favorited{get; set;}
		
		public ISongDataHandler dataHandler {get; set;}
		
		public Song()
		{
			dataHandler = new SongDataHandler();
		}
	}
}