using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
	public class ShapedEntity
	{
		public ShapedEntity()
		{
			Entity = new BaseEntity();
		}

		public Guid Id { get; set; }
		public BaseEntity Entity { get; set; }
	}
}
