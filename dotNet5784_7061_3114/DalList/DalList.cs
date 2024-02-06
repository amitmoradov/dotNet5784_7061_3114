﻿namespace Dal;
using DalApi;

/// <summary>
/// sealed : The class cannot be inherited
/// </summary>
sealed internal class DalList : IDal
{
    public static IDal Instance { get; } = new DalList();
    private DalList() { }

    public IDependency Dependency => new DependencyImplementation();

    public IEngineer Engineer =>  new EngineerImplementation();

    public ITask Task => new TaskImplementation();
    public void SaveStartProjectDate(DateTime startProject) { }
}

