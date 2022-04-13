using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Interfaces;
using MySql.Data.MySqlClient;
using Api.Models;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongController : ControllerBase
	{
		// GET: api/Song
		[EnableCors("OpenPolicy")]
		[HttpGet]
		public List<Song> Get()
		{
			ISongDataHandler dataHandler = new SongDataHandler();
			return dataHandler.Select();
		}

		// GET: api/Song/5
		[EnableCors("OpenPolicy")]
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Song
		[EnableCors("OpenPolicy")]
		[HttpPost]
		public void Post([FromBody] Song value)
		{
			value.dataHandler.Insert(value);
		}

		// PUT: api/Song/5
		[EnableCors("OpenPolicy")]
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Song value)
		{
			value.ID = id;
			System.Console.WriteLine(value.Favorited);
			value.dataHandler.Update(value);
		}

		// DELETE: api/Song/5
		[EnableCors("OpenPolicy")]
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			Song value = new Song(){ID=id};
			value.dataHandler.Delete(value);
		}
	}
}
