using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokewar.Models
{
	internal class Skill
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Damage { get; set; }
		public List<Type> Types { get; set; }
		public int Uses { get; set; }
	}
}
