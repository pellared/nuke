﻿// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Utilities;

namespace Nuke.Core
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnvironmentInfo
    {
        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        public static void SetVariables<T>(string name, IEnumerable<T> values, char separator)
        {
            SetVariable(name, values.Select(x => x.ToString()).Join(separator));
        }

        #region Parameter

        /// <summary>
        /// Provides access to a command-line argument or environment variable switch.
        /// </summary>
        public static bool ParameterSwitch(string name)
        {
            return ParameterService.GetParameter<bool>(name);
        }

        /// <summary>
        /// Provides access to a command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static string Parameter(string name)
        {
            return ParameterService.GetParameter<string>(name);
        }

        /// <summary>
        /// Provides access to a converted command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static T Parameter<T>(string name)
        {
            return ParameterService.GetParameter<T>(name);
        }

        /// <summary>
        /// Provides ensured access to a command-line argument or environment variable.
        /// </summary>
        public static string EnsureParameter(string name)
        {
            return Parameter(name).NotNull($"Parameter('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted command-line argument or environment variable.
        /// </summary>
        [CanBeNull]
        public static T EnsureParameter<T> (string name)
        {
            return Parameter<T>(name).NotNull($"Parameter<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to command-line arguments or environment variables.
        /// </summary>
        public static T[] Parameters<T>(string name, char? separator = null)
        {
            return ParameterService.GetParameter<T[]>(name, separator).NotNull();
        }

        #endregion

        #region Variable

        /// <summary>
        /// Provides access to an environment variable switch.
        /// </summary>
        public static bool VariableSwitch (string name)
        {
            return ParameterService.GetEnvironmentVariable<bool>(name);
        }

        /// <summary>
        /// Provides access to an environment variable.
        /// </summary>
        [CanBeNull]
        public static string Variable (string name)
        {
            return ParameterService.GetEnvironmentVariable<string>(name);
        }

        /// <summary>
        /// Provides access to a converted environment variable.
        /// </summary>
        [CanBeNull]
        public static T Variable<T> (string name)
        {
            return ParameterService.GetEnvironmentVariable<T>(name);
        }

        /// <summary>
        /// Provides ensured access to an environment variable.
        /// </summary>
        public static string EnsureVariable (string name)
        {
            return Variable(name).NotNull($"Variable('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted environment variable.
        /// </summary>
        public static T EnsureVariable<T> (string name)
        {
            return Variable<T>(name).NotNull($"Variable<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to environment variables.
        /// </summary>
        public static T[] Variables<T>(string name, char? separator = null)
        {
            return ParameterService.GetEnvironmentVariable<T[]>(name, separator).NotNull();
        }

        #endregion

        #region Argument

        /// <summary>
        /// Provides access to a command-line argument switch.
        /// </summary>
        public static bool ArgumentSwitch (string name)
        {
            return ParameterService.GetCommandLineArgument<bool>(name);
        }

        /// <summary>
        /// Provides access to a command-line argument.
        /// </summary>
        [CanBeNull]
        public static string Argument (string name)
        {
            return ParameterService.GetCommandLineArgument<string>(name);
        }

        /// <summary>
        /// Provides access to a converted command-line argument.
        /// </summary>
        [CanBeNull]
        public static T Argument<T> (string name)
        {
            return ParameterService.GetCommandLineArgument<T>(name);
        }

        /// <summary>
        /// Provides ensured access to a command-line argument.
        /// </summary>
        public static string EnsureArgument (string name)
        {
            return Argument(name).NotNull($"Argument('{name}') != null");
        }

        /// <summary>
        /// Provides ensured access to a converted command-line argument.
        /// </summary>
        public static T EnsureArgument<T> (string name)
        {
            return Argument<T>(name).NotNull($"Argument<{typeof(T).Name}>('{name}') != null");
        }

        /// <summary>
        /// Provides access to command-line arguments.
        /// </summary>
        public static T[] Arguments<T>(string name, char? separator = null)
        {
            return ParameterService.GetCommandLineArgument<T[]>(name, separator).NotNull();
        }

        #endregion
    }
}