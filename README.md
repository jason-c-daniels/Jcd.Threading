# Jcd.Tasks

A *netstandard2.0* library that provides utility classes to help with creating and managing unstarted `Task`s.

Read the API docs carefully.

## Types Provided.

* The main types provided are:
   * `BlockingTaskProcessor` a Task-consumer in a Producer-Consumer model that starts tasks one at a time and waits
     for their completion before executing the next task.
   * `SynchronizedValue` a more flexible and CLS compliant re-imagining of `Interlocked`.
   * `TaskExtensions` some simple task extension methods for working with unstarted tasks.
   * `UnstartedTask` a static factory class for creating unstarted tasks.

## Examples

See [EXAMPLES.md](./EXAMPLES.md) for detailed examples.

## Badges

[![GitHub](https://img.shields.io/github/license/jason-c-daniels/Jcd.Tasks)](https://github.com/jason-c-daniels/Jcd.Tasks/blob/main/LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/sbmfvmr1jmcf1pic?svg=true)](https://ci.appveyor.com/project/jason-c-daniels/jcd-tasks)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/jason-c-daniels/Jcd.Tasks)](https://www.codefactor.io/repository/github/jason-c-daniels/Jcd.Tasks)

[![MyGet](https://img.shields.io/myget/jason-c-daniels/v/Jcd.Tasks?logo=nuget)](https://www.myget.org/feed/jason-c-daniels/package/nuget/Jcd.Tasks)
[![Nuget](https://img.shields.io/nuget/v/Jcd.Tasks?logo=nuget)](https://www.nuget.org/packages/Jcd.Tasks)

[![API Docs](https://img.shields.io/badge/Read-The%20API%20Documentation-blue?style=for-the-badge)](https://github.com/jason-c-daniels/Jcd.Tasks/blob/main/docs/Jcd.Tasks.md)