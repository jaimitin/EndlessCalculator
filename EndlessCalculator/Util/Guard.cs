﻿using EndlessCalculator.Extensions;
using System;
using System.Runtime.CompilerServices;

namespace EndlessCalculator.Util
{
    public static class Guard
    {
        public static void IsNotNullOrEmpty(string? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            if (param.IsNullOrEmpty())
            {
                throw new ArgumentException($"[Guard] String parameter '{paramName}' cannot be null or empty.", paramName);
            }
        }

        public static void IsNotNull(object? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            if (param is null)
            {
                throw new ArgumentNullException(nameof(param), $"[Guard] Parameter '{paramName}' cannot be null.");
            }
        }
    }
}
