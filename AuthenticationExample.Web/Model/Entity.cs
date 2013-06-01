using System;

namespace AuthenticationExample.Castle.Web.Model
{
	public abstract class Entity
	{
		public virtual Guid Id { get; set; }
	}
}
