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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    MVVMDemo.ViewModel.StudentViewModel svmo = new ViewModel.StudentViewModel();
    public MainWindow()
    {
      InitializeComponent();
      //kovakoodatut oppilaat
      //svmo.LoadStudents();
      try
      {
        //oppilaat tietokannnasta
        svmo.LoadStudentsFromMysql();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void StudenViewControl_Loaded(object sender, RoutedEventArgs e)
    {
      StudenViewControl.DataContext = svmo;
    }

    private void dgStudents_Loaded(object sender, RoutedEventArgs e)
    {
      dgStudents.DataContext = svmo.Students;
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
      //luodaan observabelcollectioniin uusi Student-olio
      MVVMDemo.Model.Student uusi = new Model.Student();
      uusi.FirstName = txtFirstName.Text;
      uusi.LastName = txtLastName.Text;
      svmo.Students.Add(uusi);
      //tyhjätään textboxit
      txtFirstName.Text = ""; txtLastName.Text = "";
    }
  }
}
