using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Autofac.Core;
using Autofac.Features.Variance;

namespace Api.Libraries.Infrastructure.MediatR
{
	public class ScopedContravariantRegistrationSource : IRegistrationSource
	{
		private readonly IRegistrationSource _source = new ContravariantRegistrationSource();
		private readonly List<Type> _types = new List<Type>();

		public ScopedContravariantRegistrationSource(params Type[] types)
		{
			Guard.Against.Null(types, nameof(types));

			if (!types.All(type => type.IsGenericTypeDefinition))
			{
				throw new ArgumentException("Supplied types should be generic type definitions");
			}

			_types.AddRange(types);
		}

		public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
		{
			var components = _source.RegistrationsFor(service, registrationAccessor);
			foreach (var component in components)
			{
				var definitions = component.Target.Services
					.OfType<TypedService>()
					.Select(x => x.ServiceType.GetGenericTypeDefinition());

				if (definitions.Any(_types.Contains))
				{
					yield return component;
				}
			}
		}

		public bool IsAdapterForIndividualComponents => _source.IsAdapterForIndividualComponents;
	}
}
