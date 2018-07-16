using System;
using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;

namespace RekenMachineAPI.Tests.Component
{
    public class DeepObjectComparer : IEqualityComparer<object>
    {
        private ComparisonConfig _comparisonConfig;

        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            var compareLogic = new CompareLogic
            {
                Config = _comparisonConfig ?? new ComparisonConfig()
            };

            var compareResult = compareLogic.Compare(x, y);
            return compareResult.AreEqual;
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public DeepObjectComparer Configure(Action<ComparisonConfig> callback)
        {
            if (_comparisonConfig == null)
                _comparisonConfig = new ComparisonConfig();

            callback.Invoke(_comparisonConfig);

            return this;
        }
    }
}