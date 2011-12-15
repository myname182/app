using System;

namespace app.infrastructure.containers.simple
{
	public class SingleDependencyFactory : ICreateASingleDependency
	{
		private IMatchAType asd;

		public SingleDependencyFactory(IMatchAType asd)
		{
			this.asd = asd;

		}

		public object create()
		{
			throw new NotImplementedException();
		}

		public bool can_create(Type type)
		{
			return asd.matches(type);
		}
	}
}