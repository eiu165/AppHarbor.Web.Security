using System;

namespace AuthenticationExample.StructureMap.Web.Model
{
	public abstract class Entity
	{
		public virtual Guid Id { get; set; }
	}
}
