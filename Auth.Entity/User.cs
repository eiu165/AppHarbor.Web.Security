namespace Auth.Enitity
{
	public class User : Entity
	{
		public virtual string Username { get; set; }
		public virtual string Password { get; set; }
	}
}
