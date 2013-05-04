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

namespace MySpellChecker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetF1CommandBinding();
        }

        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += new CanExecuteRoutedEventHandler(helpBinding_CanExecute);
            helpBinding.Executed += new ExecutedRoutedEventHandler(helpBinding_Executed);
            CommandBindings.Add(helpBinding);
        }

        void helpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Help is not necessary.", "Help");
        }

        void helpBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            StatusBarText.Text = "Exit the Application";
        }

        private void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            StatusBarText.Text = "Ready";
        }       

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MouseEnterHintArea(object sender, MouseEventArgs e)
        {
            StatusBarText.Text = "Show Spelling Suggestion";
        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;
            
            //Get errors
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                foreach (string s in error.Suggestions)
                {
                    spellingHints += string.Format("{0}\n", s);
                }
                //DISPLAY SPELLING SUGGESTION
                lblSpellingHints.Content = spellingHints;

                //EXPAND
                expanderSpelling.IsExpanded = true;
            }
        }
    }
}
