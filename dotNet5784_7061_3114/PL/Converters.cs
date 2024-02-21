﻿using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using BO;
namespace PL;
/// <summary>
/// Converts between a field from the layer in PL and BL
/// </summary>
class ConvertIdToContent : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0 ? "Add" : "Update";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}

/// <summary>
/// the function checks if the received value (the number) is 0. If the value is 0, the function returns true, 
/// allowing the field to be edited. If the value is different from 0,
/// it returns false, and then the field will not be editable.
/// </summary>
class IdToIsEnabledConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (int)value == 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}


//For Task : Engineer that work on the task
/// <summary>
///The permissions allowed in the project in step 3
/// </summary>
class scheduleWasPalnnedIsEnabled : IValueConverter
{
    // Access to BO .
    static readonly BlApi.IBl e_bl = BlApi.Factory.Get();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (e_bl.Project.ReturnStatusProject() == "scheduleWasPalnned")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}

//For Task : Engineer that work on the task
/// <summary>
///The permissions are not allowed in the project in step 3
/// </summary>
class scheduleWasPalnnedIsNotEnabled : IValueConverter
{
    // Access to BO .
    static readonly BlApi.IBl e_bl = BlApi.Factory.Get();
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    if (e_bl.Project.ReturnStatusProject() == "scheduleWasPalnned")
    {
        return false;
    }
    else
    {
        return true;
    }
}

public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
    throw new NotImplementedException();
}

}

/// <summary>
/// The permissions allowed in the project in step 2
/// </summary>
class ScheduleDeterminationIsEnabled : IValueConverter
{
    // Access to BO .
    static readonly BlApi.IBl e_bl = BlApi.Factory.Get();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (e_bl.Project.ReturnStatusProject() == "ScheduleDetermination")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}


/// <summary>
/// The permissions allowed in the project in step 1
/// </summary>
class planningIsEnabled : IValueConverter
{
    // Access to BO .
    static readonly BlApi.IBl e_bl = BlApi.Factory.Get();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (e_bl.Project.ReturnStatusProject() == "planning")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}
