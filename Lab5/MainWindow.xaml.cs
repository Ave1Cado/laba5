using System;
using System.Windows;
using Lab5.tabachkDataSetTableAdapters;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        RolesTableAdapter adapter = new RolesTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == LoginTbx.Text &&
                    allLogins[i][3].ToString() == PasswordTbx.Password)
                {
                    int roleid = (int)allLogins[i][0];

                    switch (roleid)
                    {
                        case 1:
                            AdminRoleWindow role = new AdminRoleWindow();
                            role.Show();
                            this.Close();
                            break;
                        case 15:
                            CashierRoleWindow second = new CashierRoleWindow();
                            second.Show();
                            this.Close();
                            break;
                    }
                }
            }
        }
    }
}