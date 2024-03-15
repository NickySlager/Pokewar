using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokewar.Models
{
	internal class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }
		public List<Pokemon> PokemonTeam { get; set; }


	}
}
