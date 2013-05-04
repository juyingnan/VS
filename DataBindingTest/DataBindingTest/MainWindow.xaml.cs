using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace DataBindingTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //listen for the input validation error on the age input text box
            //Validation.AddErrorHandler(this.ageTextBox, ageTextBox_ValidationError);
        }

        private void birthdayButton_Click(object sender, RoutedEventArgs e)
        {
            //get person from window's resources
            //Person person = (Person)this.FindResource("Tom");            
            ICollectionView view = GetFamilyView();
            Person person = (Person)view.CurrentItem;
            ++person.Age;
            MessageBox.Show(string.Format("Happy Birthday, {0}, age {1}!", person.Name, person.Age), "Birthday");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToFirst();
            }
        }

        private void fowardButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();
            }
        }

        ICollectionView GetFamilyView()
        {
            People people = (People)this.FindResource("Family");
            return CollectionViewSource.GetDefaultView(people);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            People people = (People)this.FindResource("Family");
            people.Add(new Person("Chris", 37));
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view= GetFamilyView();
            if (view.SortDescriptions.Count == 0)
            {
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Descending));
            }
            else
                view.SortDescriptions.Clear();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            if (view.Filter == null)
            {
                view.Filter = delegate(object item) { return ((Person)item).Age >= 25; };
            }
            else
            { view.Filter = null; }
        }

        private void groupButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetFamilyView();
            if (view.GroupDescriptions.Count == 0)
            {                
                view.GroupDescriptions.Add(new PropertyGroupDescription("Age", new AgeToRangeConverter()));
                view.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
            }
            else
            { view.GroupDescriptions.Clear(); }
        }

        //void ageTextBox_ValidationError(object sender, ValidationErrorEventArgs e)
        //{
        //    //show error
        //    ageTextBox.ToolTip = (string)e.Error.ErrorContent;
        //    //MessageBox.Show((string)e.Error.ErrorContent, "Validation Error");
        //}
    }
}
