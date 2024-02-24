﻿using System;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class FourStaThreadsPerCpuTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public FourStaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount * 4) { }
}