using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokewar.Models
{
	internal class Pokemon
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Byte[] Image { get; set; }
		public int Health { get; set; }
		public List<Skill> Skills { get; set; }
		public List<Type> Types { get; set; }

	}
}
