﻿// -----------------------------------------------------------------------
// <copyright file="SpinWait.cs" company="Microsoft">
// Copyright © Microsoft. All Rights Reserved.
// </copyright>
// <author>Sergei Nikitin: sergeyni@microsoft.com</author>
// <summary></summary>
// -----------------------------------------------------------------------

namespace Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing
{
    using System;
    using System.Threading;

    internal static class SpinWait
    {
        internal static void ExecuteSpinWaitLock(this object syncRoot, Action action)
        {
            while (false == Monitor.TryEnter(syncRoot, 0))
            {
            }

            try
            {
                action();
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
        }
    }
}
