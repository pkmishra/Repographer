﻿#region License
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
#endregion
using Repographer.Components;
using Repographer.Components.Validation;
using Repographer.Modules.Main.Settings;
using Repographer.Modules.Main.Settings.Builders;
using Repographer.Mono.Options;

namespace Repographer.Modules.SwitchToNuget.Settings.Builders
{
    public class SwitchToNugetSettingsBuilder : ISettingsBuilder<RepoActionSettings>
    {
        private readonly IValidator<SwitchToNugetSettings> _validator;
        private string[] _args;
        private bool _help;

        public SwitchToNugetSettingsBuilder(IValidator<SwitchToNugetSettings> validator)
        {
            _validator = validator;
        }

        public void SetArgs(string[] args)
        {
            _args = args;
        }

        public void SetHelp(bool help)
        {
            _help = help;
        }

        public IRepoActionSettings Build()
        {
            var options = new OptionSet();

            var settings = new SwitchToNugetSettings(options);
            settings.Parse(_args);

            if (_help)
                return new ShowHelpSettings("Switch to Nuget Reference", options);

            _validator.Validate(settings).ThrowIfAny(options);

            return settings;
        }

        public bool IsBuilderFor(RepoActionSettings repoActionSettings)
        {
            return repoActionSettings.SwitchToNuget;
        }
    }
}