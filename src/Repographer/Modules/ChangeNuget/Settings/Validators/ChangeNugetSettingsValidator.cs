#region License
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
#endregion
using System.Collections.Generic;
using Repographer.Components.Validation;

namespace Repographer.Modules.ChangeNuget.Settings.Validators
{
    public class ChangeNugetSettingsValidator : IValidator<ChangeNugetSettings>
    {
        public IEnumerable<ValidationCondition> Validate(ChangeNugetSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Directory))
                yield return new ValidationCondition("Missing required argument: directory", ValidationConditionLevel.Error);

            if (string.IsNullOrWhiteSpace(settings.NewPath))
                yield return new ValidationCondition("Missing required argument: new path", ValidationConditionLevel.Error);
        }
    }
}