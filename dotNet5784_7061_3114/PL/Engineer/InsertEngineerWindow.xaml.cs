﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL.Engineer;

/// <summary>
/// Interaction logic for InsertEngineerWindow.xaml
/// </summary>
public partial class InsertEngineerWindow : Window
{
    static readonly BlApi.IBl e_bl = BlApi.Factory.Get();

    public BO.Engineer Engineer
    {
        get { return (BO.Engineer)GetValue(EngineerProperty); }
        set { SetValue(EngineerProperty, value); }
    }

    public static readonly DependencyProperty EngineerProperty =
        DependencyProperty.Register("Engineer", typeof(BO.Engineer), typeof(InsertEngineerWindow), new PropertyMetadata(null));

    public InsertEngineerWindow()
    {
        InitializeComponent();
        Engineer = new();
    }
    
    private void ShowTask_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Engineer = e_bl.Engineer.Read(Engineer.Id);

            //Open the task window of the existing engineer
            if (Engineer?.Task == null)
            {
                new Task.SingleTaskWindow(0).ShowDialog();
            }

            else
            {
                new Task.SingleTaskWindow(Engineer.Task.Id).ShowDialog();
            }
        }
        catch (BO.BlReadNotFoundException ex)
        {
            MessageBox.Show("ERROR: " + ex.Message,"", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void PotentialTasks_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Engineer = e_bl.Engineer.Read(Engineer.Id);

            //Open the task window of the existing engineer
            if (Engineer != null)
            {
                new AllPotentialTasks(Engineer.Id).ShowDialog();
            }
        }
        catch (BO.BlReadNotFoundException ex)
        {
            MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
