﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class Kind
    {
        public string Value { get; }
		private static readonly List<string> ValidKindValues = new List<string> { "ProcessDefinition", "ProcessInstance" };

		public Kind(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));

			if (ValidKindValues.All(kind => kind != value))
			{
				throw new ArgumentException("No valid kind value");
			}

			Value = value;
        }

        public override string ToString() => Value;
    }
}
