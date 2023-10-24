using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

//Т76. The INotifyPropertyChanged interface
// Implementing the interface generates an event to send notification for when the values of either the view or the model
//change so that both of them stay updated.
//A. OneWay -> View stays updated with the values from the model, but the model doesn't get updated by the view
//B. TwoWay -> The model stays updated with the values from the view and vice versa.

//T76.1 How it works
/*
 A.The data model class implements the interface, so changes to any of the properties trigger an event, so
 
changes to all of the bound properties trigger an event
 B. Changes to a property trigger an event, both from the model to the view and vice versa.
 C. Bound properties respond to the event.

 --Example: User class with 3x properties - Name, Email and Password, bound TwoWay to the UI. If a property is 
assigned from C# the UI gets updated with it, and when the UI property is assigned by the user the model is updated with it.
=>(T80.)
*/
//T80. The ICommand Interface
/*
  - Replaces Event Handlers in the code behind
  A. Why use it
    - Commands cam move the code behind logic into the View Model => Cleans up the View and can be reused between Windows, projects and applications
  B. Exists as a property for the Buttons -> Command=""
    - Perfect replacement for Event Handlers
    - Needs the view to have the DataContext set to the ViewModel
     
 */
//T80.1 How it works
/*
    - A. The ViewModel implements the ICommand interface.
        - It has an .Execute() method which is the action method and the .CanExecute() method which evaluates if the action can be performed.
    - B. The functionality is added to the Execute() action method member
    - C. The Optional CanExecute() method evaluates if the Execute() can be performed.
    - D. The command is assigned
 */
//T84. ObservableCollection<T> class
    //- It's a List that is aware of changes -> It updates the view and vice versa when changes to the list occur(Add/Remove).
//T84.1 How it works
/*
    - A. A class inherits from the ObservableCollection<T>
    - B. The class already implements INotifyCollectionChanged
    - C. Binding source is established
    - D. Changes update the UI
 */
namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
