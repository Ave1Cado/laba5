using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab5
{
    public partial class AdminRoleWindow : Window
    {
        private tabachkEntities context = new tabachkEntities();
        private string currentTableName;

        public AdminRoleWindow()
        {
            InitializeComponent();
            LoadRolesTable();
        }

        private void LoadRolesTable()
        {
            currentTableName = "Roles";
            AdminDataGrid.ItemsSource = context.Roles.ToList();

            AdminDataGrid.Columns.Clear();
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("RoleID") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("RoleName") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Пароль", Binding = new Binding("Password") });
            AdminDataGrid.Columns.Add(new DataGridCheckBoxColumn { Header = "Может управлять БД", Binding = new Binding("CanManageDatabase") });
        }

        private void LoadEmployeesTable()
        {
            currentTableName = "Employees";
            AdminDataGrid.ItemsSource = context.Employees.ToList();

            AdminDataGrid.Columns.Clear();
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("EmployeeID") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("FirstName") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new Binding("LastName") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Должность", Binding = new Binding("Position") });
            AdminDataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата найма", Binding = new Binding("HireDate") });
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            LoadRolesTable();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployeesTable();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (currentTableName == "Roles")
            {
                Roles newRole = new Roles
                {
                    RoleName = RoleNameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    CanManageDatabase = CanManageDatabaseCheckBox.IsChecked
                };

                context.Roles.Add(newRole);
                context.SaveChanges();
                LoadRolesTable();
            }
            else if (currentTableName == "Employees")
            {
                Employees newEmployee = new Employees
                {
                    FirstName = NewValueTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Position = PositionTextBox.Text,
                    HireDate = HireDatePicker.SelectedDate
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                LoadEmployeesTable();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Roles")
                {
                    Roles selectedRole = (Roles)AdminDataGrid.SelectedItem;
                    selectedRole.RoleName = RoleNameTextBox.Text;
                    selectedRole.Password = PasswordTextBox.Text;
                    selectedRole.CanManageDatabase = CanManageDatabaseCheckBox.IsChecked;
                    context.SaveChanges();
                    LoadRolesTable();
                }
                else if (currentTableName == "Employees")
                {
                    Employees selectedEmployee = (Employees)AdminDataGrid.SelectedItem;
                    selectedEmployee.FirstName = NewValueTextBox.Text;
                    selectedEmployee.LastName = LastNameTextBox.Text;
                    selectedEmployee.Position = PositionTextBox.Text;
                    selectedEmployee.HireDate = HireDatePicker.SelectedDate;
                    context.SaveChanges();
                    LoadEmployeesTable();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDataGrid.SelectedItem != null)
            {
                if (currentTableName == "Roles")
                {
                    context.Roles.Remove(AdminDataGrid.SelectedItem as Roles);
                    context.SaveChanges();
                    LoadRolesTable();
                }
                else if (currentTableName == "Employees")
                {
                    context.Employees.Remove(AdminDataGrid.SelectedItem as Employees);
                    context.SaveChanges();
                    LoadEmployeesTable();
                }
            }
        }
    }
}
