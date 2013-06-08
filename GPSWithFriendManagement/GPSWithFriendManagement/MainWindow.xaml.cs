using System;
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

namespace GPSWithFriendManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Server.GPSwfriendsClient proxy = new Server.GPSwfriendsClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetUserButton_Click(object sender, RoutedEventArgs e)
        {
            Server.user user = proxy.getUser(GetUserTextBox.Text);
            GetUserTextBox.Text = user.email + " | " + user.uid + " | " + user.lastLoc.latitude + " | " + user.lastLoc.longitude + " | " + user.lastLoc.date;
        }

        private void GetUserByIDButton_Click(object sender, RoutedEventArgs e)
        {
            Server.user user = proxy.getUserByID(int.Parse(GetUserByIDTextBox.Text));
            GetUserByIDTextBox.Text = user.email + " | " + user.uid + " | " + user.lastLoc.latitude + " | " + user.lastLoc.longitude + " | " + user.lastLoc.date;
        }

        private void CreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string[] uids = CreateGroupTextBox.Text.Split(' ');
            int?[] uid = new int?[uids.Length];
            for (int i = 0; i < uids.Length; i++)
            {
                uid[i] = int.Parse(uids[i]);
            }
            Server.status s = proxy.createGroup(uid, 1, CreateGroupNameTextBox.Text);

            CreateGroupTextBox.Text = s.success.ToString() + " | " + s.error;
        }

        private void GetGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            Server.group[] groups = proxy.getGroups(int.Parse(GetGroupsTextBox.Text));
            GetGroupsTextBox.Text = "";
            foreach (var item in groups)
            {
                GetGroupsTextBox.Text += item.gid + " | " + item.name + " | " + item.owner + " || ";
                foreach (var user in item.users)
                {
                    GetGroupsTextBox.Text += user.fName + " , ";
                }
            }
        }

        private void AddmemberButton_Click(object sender, RoutedEventArgs e)
        {
            Server.status s = proxy.addMember(int.Parse(AddMemberTextBox.Text), int.Parse(Addmember2GroupeTextBox.Text));
            AddMemberTextBox.Text = s.success.ToString() + " | " + s.error;
        }

        private void RemoveMemberButton_Click(object sender, RoutedEventArgs e)
        {
            int uid = int.Parse(RemoveMemberTextBox.Text);
            int groupid = int.Parse(RemoveMemberfromGroupeTextBox.Text);
            Server.status s = proxy.removeMember(uid, groupid);
            RemoveMemberTextBox.Text = s.success.ToString() + " | " + s.error;
        }


        private void SetLocation_Click(object sender, RoutedEventArgs e)
        {
            int uid = int.Parse(SetUserIdTextBox.Text);
            string[] location = SetLocationTextBox.Text.Split(' ');
            double latitude = double.Parse(location[0]);
            double longitude = double.Parse(location[1]);
            Server.status s = proxy.setLocation(uid, latitude, longitude);
            SetUserIdTextBox.Text = s.success.ToString() + " | " + s.error;
        }

    }
}
