﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// ReSharper disable HeapView.ObjectAllocation

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers;

public class MainWindowViewModel
{
   public ObservableCollection<string> Items   { get; } = [];
   public ObservableCollection<string> Results { get; } = [];

   private string selectedItem   = "";
   private string selectedResult = "";

   public string SelectedItem
   {
      get => selectedItem;

      set
      {
         selectedItem = value;
         OnPropertyChanged();
      }
   }

   public string SelectedResult
   {
      get => selectedResult;

      set
      {
         selectedResult = value;
         OnPropertyChanged();
      }
   }

   // Declare the event
   // ReSharper disable once EventNeverSubscribedTo.Global
   public event PropertyChangedEventHandler? PropertyChanged;

   // Create the OnPropertyChanged method to raise the event
   // The calling member's name will be used as the parameter.
   protected void OnPropertyChanged([CallerMemberName] string? name = null)
   {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
   }
}