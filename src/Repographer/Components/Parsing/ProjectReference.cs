#region License
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
#endregion
using System.IO;
using System.Xml.Linq;
using Repographer.DataAccess;
using Repographer.DataAccess.Graphing;

namespace Repographer.Components.Parsing
{
    public static class ProjectReference
    {
        public static bool TryParse(string rootDirectoryPath, string projFilePath, XElement element, out IReference reference)
        {
            reference = null;

            var projDirectory = Path.GetDirectoryName(projFilePath);
            var includeAttr = element.Attribute("Include");

            if (projDirectory == null || includeAttr == null)
                return false;

            var includePath = Path.GetFullPath(Path.Combine(projDirectory, includeAttr.Value));

            var projectElement = element.Element(Constants.MsBuild + "Project");
            var projectValue = projectElement == null
                ? null
                : projectElement.Value;

            var nameElement = element.Element(Constants.MsBuild + "Name");
            var nameValue = nameElement == null ? null : nameElement.Value;

            reference = new Reference<XElement>(rootDirectoryPath, "", nameValue, includePath, projectValue, element, RelationTypes.Reference);

            return true;
        }
    }
}