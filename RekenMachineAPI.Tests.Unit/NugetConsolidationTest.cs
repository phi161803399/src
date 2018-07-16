using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet;
using Xunit;

namespace RekenMachineAPI.Tests.Unit
{
    public class NugetConsolidationTest
    {
        private readonly List<string> _ignoredPackages = new List<string>();

        [Fact]
        public void all_nuget_packages_are_consolidated()
        {
            var packageVersionMapping = new Dictionary<string, List<string>>();
            
            foreach (var packageFile in GetPackageFiles())
            {
                var file = new PackageReferenceFile(packageFile);                

                foreach (var packageRef in file.GetPackageReferences(true))
                {
                    if (_ignoredPackages.Contains(packageRef.Id))
                        continue;

                    if (!packageVersionMapping.ContainsKey(packageRef.Id))
                        packageVersionMapping[packageRef.Id] = new List<string> {packageRef.Version.ToFullString()};
                    else
                    {
                        if (packageVersionMapping[packageRef.Id].All(x => !x.Equals(packageRef.Version.ToFullString(),
                            StringComparison.InvariantCultureIgnoreCase)))
                            packageVersionMapping[packageRef.Id].Add(packageRef.Version.ToFullString());
                    }
                }
            }

            var errors = packageVersionMapping
                .Where(x => x.Value.Count > 1)
                .Select(x =>
                    $"Package {x.Key} has {x.Value.Count} separate versions installed! Current versions are {string.Join(", ", x.Value)}");

            Assert.Empty(errors);            
        }

        private static IEnumerable<string> GetPackageFiles()
        {
            var parentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;

            return Directory.GetFiles(parentDir ?? throw new InvalidOperationException(), "packages.config",
                SearchOption.AllDirectories);            
        }
    }
}