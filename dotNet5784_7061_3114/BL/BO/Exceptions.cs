﻿
using DO;

namespace BO;

/// <summary>
/// The item is already exists
/// </summary>
[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string msg, DO.DalDoesExistException ex) : base(msg, ex) { }
}

/// <summary>
/// The datails is not correct
/// </summary>
[Serializable]
public class BlIncorrectDatailException : Exception
{
    public BlIncorrectDatailException(string msg) : base(msg) { }
}

/// <summary>
/// The entity cannot be deleted
/// </summary>
[Serializable]
public class BlEntityCanNotRemoveException : Exception
{
    public BlEntityCanNotRemoveException(string msg) : base(msg) { }
}

/// <summary>
/// 
/// </summary>
[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string msg, DO.DalDoesNotExistException ex) : base(msg, ex) { }
}