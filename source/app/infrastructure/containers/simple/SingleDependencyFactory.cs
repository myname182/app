using System;

namespace app.infrastructure.containers.simple
{
	public class SingleDependencyFactory : ICreateASingleDependency
	{
		private IMatchAType type_criteria;

		public SingleDependencyFactory(IMatchAType type_criteria)
		{
			this.type_criteria = type_criteria;

		}

		public object create()
		{
			throw new NotImplementedException();
		}

		public bool can_create(Type type)
		{
			return type_criteria.matches(type);
		}
	}
}