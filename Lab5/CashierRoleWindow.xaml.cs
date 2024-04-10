using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab5
{
    public partial class CashierRoleWindow : Window
    {
        private tabachkEntities context = new tabachkEntities();
        private string currentTableName;

        public object ThirdValueTextBox { get; private set; }
        public object FourthValueTextBox { get; private set; }

        public CashierRoleWindow()
        {
            InitializeComponent();
            LoadProductsTable();
        }

        private void LoadProductsTable()
        {
            currentTableName = "Products";
            CashierDataGrid.ItemsSource = context.Products.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ProductID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Name") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Описание", Binding = new Binding("Description") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("Price") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Количество на складе", Binding = new Binding("QuantityInStock") });

            clientsButtons.Visibility = Visibility.Collapsed;
            productButtons.Visibility = Visibility.Visible;
            ordersButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Collapsed;
            yButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;
        }

        private void LoadOrdersTable()
        {
            currentTableName = "Orders";
            CashierDataGrid.ItemsSource = context.Orders.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("OrderID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID клиента", Binding = new Binding("CustomerID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата", Binding = new Binding("OrderDate") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Общая сумма", Binding = new Binding("TotalAmount") });
            productButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility= Visibility.Collapsed;
            ordersButtons.Visibility = Visibility.Visible;
            clientsButtons.Visibility = Visibility.Collapsed;
            detailsButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;

            yButtons.Visibility = Visibility.Collapsed;
        }

        private void LoadProductCategoriesTable()
        {
            currentTableName = "ProductCategories";
            CashierDataGrid.ItemsSource = context.ProductCategories.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("CategoryID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("CategoryName") });
            productButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Visible;
            ordersButtons.Visibility = Visibility.Collapsed;
            clientsButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;

            detailsButtons.Visibility = Visibility.Collapsed;
            yButtons.Visibility = Visibility.Collapsed;
        }

        private void LoadCustomersTable()
        {
            currentTableName = "Customers";
            CashierDataGrid.ItemsSource = context.Customers.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("CustomerID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("FirstName") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new Binding("LastName") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Email", Binding = new Binding("Email") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Телефон", Binding = new Binding("Phone") });
            clientsButtons.Visibility = Visibility.Visible;
            productButtons.Visibility = Visibility.Collapsed;
            ordersButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;

            detailsButtons.Visibility = Visibility.Collapsed;
            yButtons.Visibility = Visibility.Collapsed;
        }

        private void LoadOrderDetailsTable()
        {
            currentTableName = "OrderDetails";
            CashierDataGrid.ItemsSource = context.OrderDetails.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("OrderDetailID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID Заказа", Binding = new Binding("OrderID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID Продукта", Binding = new Binding("ProductID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Quantity") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("UnitPrice") });

            detailsButtons.Visibility = Visibility.Visible;
            clientsButtons.Visibility = Visibility.Collapsed;
            productButtons.Visibility = Visibility.Collapsed;
            ordersButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;
            yButtons.Visibility = Visibility.Collapsed;
        }

        private void LoadServicesTable()
        {
            currentTableName = "Services";
            CashierDataGrid.ItemsSource = context.Services.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ServiceID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Описание", Binding = new Binding("Description") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("Price") });

            yButtons.Visibility = Visibility.Visible;
            detailsButtons.Visibility = Visibility.Collapsed;
            clientsButtons.Visibility = Visibility.Collapsed;
            productButtons.Visibility = Visibility.Collapsed;
            ordersButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Collapsed;

        }

        private void LoadReturnsTable()
        {
            currentTableName = "Returns";
            CashierDataGrid.ItemsSource = context.Returns.ToList();

            CashierDataGrid.Columns.Clear();
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ReturnID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID Заказа", Binding = new Binding("OrderDetailID") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Причина возврата", Binding = new Binding("ReturnReason") });
            CashierDataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата возврата", Binding = new Binding("ReturnDate") });
            yButtons.Visibility = Visibility.Collapsed;
            detailsButtons.Visibility = Visibility.Collapsed;
            clientsButtons.Visibility = Visibility.Collapsed;
            productButtons.Visibility = Visibility.Collapsed;
            ordersButtons.Visibility = Visibility.Collapsed;
            categoriesButtons.Visibility = Visibility.Collapsed;
            returnButtons.Visibility = Visibility.Visible;
            
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            LoadProductsTable();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            LoadOrdersTable();
        }

        private void ProductCategories_Click(object sender, RoutedEventArgs e)
        {
            LoadProductCategoriesTable();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomersTable();
        }

        private void OrderDetails_Click(object sender, RoutedEventArgs e)
        {
            LoadOrderDetailsTable();
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            LoadServicesTable();
        }

        private void Returns_Click(object sender, RoutedEventArgs e)
        {
            LoadReturnsTable();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTableName)
            {
                case "Orders":
                    var newOrder = new Orders
                    {
                        CustomerID = int.Parse(OrderValueTextBox.Text),
                        OrderDate = DateTime.Now,
                        TotalAmount = (int?)decimal.Parse(SecondOrderValueTextBox.Text)
                    };
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    LoadOrdersTable();
                    break;
                case "ProductCategories":
                    var newCategory = new ProductCategories
                    {
                        CategoryName = CategoryValueTextBox.Text,
                        Description = SecondCategoryValueTextBox.Text
                    };
                    context.ProductCategories.Add(newCategory);
                    context.SaveChanges();
                    LoadProductCategoriesTable();
                    break;
                case "Customers":
                    var newCustomer = new Customers
                    {
                        FirstName = ClientValueTextBox.Text,
                        LastName = SecondClientValueTextBox.Text,
                        Email = triClientValueTextBox.Text,
                        Phone = forClientValueTextBox.Text
                    };
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    LoadCustomersTable();
                    break;
                case "OrderDetails":
                    var newOrderDetail = new OrderDetail
                    {
                        OrderID = int.Parse(NewValueTextBox.Text),
                        ProductID = int.Parse(SecondValueTextBox.Text),
                        Quantity = int.Parse(ThirdValueTextBox.Text),
                        UnitPrice = decimal.Parse(FourthValueTextBox.Text)
                    };
                    context.OrderDetails.Add(newOrderDetail);
                    context.SaveChanges();
                    LoadOrderDetailsTable();
                    break;
                case "Services":
                    var newService = new Services
                    {
                        ServicesName = NewValueTextBox.Text,
                        Description = SecondValueTextBox.Text,
                        Price = decimal.Parse(ThirdValueTextBox.Text)
                    };
                    context.Services.Add(newService);
                    context.SaveChanges();
                    LoadServicesTable();
                    break;
                case "Returns":
                    var newReturn = new Returns
                    {
                        OrderID = int.Parse(NewValueTextBox.Text),
                        ProductID = int.Parse(SecondValueTextBox.Text),
                        ReturnReason = ThirdValueTextBox.Text,
                        ReturnDate = DateTime.Parse(FourthValueTextBox.Text)
                    };
                    context.Returns.Add(newReturn);
                    context.SaveChanges();
                    LoadReturnsTable();
                    break;
            }
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CashierDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                switch (currentTableName)
                {
                    case "Products":
                        var product = selectedItem as Products;
                        if (product != null)
                        {
                            product.Name = NewValueTextBox.Text;
                            product.Description = SecondValueTextBox.Text;
                            context.SaveChanges();
                            LoadProductsTable();
                        }
                        break;
                    case "Orders":
                        var order = selectedItem as Orders;
                        if (order != null)
                        {
                            order.CustomerID = int.Parse(NewValueTextBox.Text);
                            order.OrderDate = DateTime.Parse(SecondValueTextBox.Text);
                            context.SaveChanges();
                            LoadOrdersTable();
                        }
                        break;
                    case "ProductCategories":
                        var category = selectedItem as ProductCategories;
                        if (category != null)
                        {
                            category.CategoryName = NewValueTextBox.Text;
                            category.Description = SecondValueTextBox.Text;
                            context.SaveChanges();
                            LoadProductCategoriesTable();
                        }
                        break;
                    case "Customers":
                        var customer = selectedItem as Customers;
                        if (customer != null)
                        {
                            customer.FirstName = NewValueTextBox.Text;
                            customer.LastName = SecondValueTextBox.Text;
                            context.SaveChanges();
                            LoadCustomersTable();
                        }
                        break;
                    case "OrderDetails":
                        var orderDetail = selectedItem as OrderDetail;
                        if (orderDetail != null)
                        {
                            orderDetail.OrderID = int.Parse(NewValueTextBox.Text);
                            orderDetail.ProductID = int.Parse(SecondValueTextBox.Text);
                            context.SaveChanges();
                            LoadOrderDetailsTable();
                        }
                        break;
                    case "Services":
                        var service = selectedItem as Services;
                        if (service != null)
                        {
                            service.Name = NewValueTextBox.Text;
                            service.Description = SecondValueTextBox.Text;
                            context.SaveChanges();
                            LoadServicesTable();
                        }
                        break;
                    case "Returns":
                        var @return = selectedItem as Returns;
                        if (@return != null)
                        {
                            @return.OrderDetailID = int.Parse(NewValueTextBox.Text);
                            @return.ReturnReason = SecondValueTextBox.Text;
                            context.SaveChanges();
                            LoadReturnsTable();
                        }
                        break;
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = CashierDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                switch (currentTableName)
                {
                    case "Products":
                        var product = selectedItem as Products;
                        if (product != null)
                        {
                            context.Products.Remove(product);
                            context.SaveChanges();
                            LoadProductsTable();
                        }
                        break;
                    case "Orders":
                        var order = selectedItem as Orders;
                        if (order != null)
                        {
                            context.Orders.Remove(order);
                            context.SaveChanges();
                            LoadOrdersTable();
                        }
                        break;
                    case "ProductCategories":
                        var category = selectedItem as ProductCategories;
                        if (category != null)
                        {
                            context.ProductCategories.Remove(category);
                            context.SaveChanges();
                            LoadProductCategoriesTable();
                        }
                        break;
                    case "Customers":
                        var customer = selectedItem as Customers;
                        if (customer != null)
                        {
                            context.Customers.Remove(customer);
                            context.SaveChanges();
                            LoadCustomersTable();
                        }
                        break;
                    case "OrderDetails":
                        var orderDetail = selectedItem as OrderDetail;
                        if (orderDetail != null)
                        {
                            context.OrderDetails.Remove(orderDetail);
                            context.SaveChanges();
                            LoadOrderDetailsTable();
                        }
                        break;
                    case "Services":
                        var service = selectedItem as Services;
                        if (service != null)
                        {
                            context.Services.Remove(service);
                            context.SaveChanges();
                            LoadServicesTable();
                        }
                        break;
                    case "Returns":
                        var @return = selectedItem as Returns;
                        if (@return != null)
                        {
                            context.Returns.Remove(@return);
                            context.SaveChanges();
                            LoadReturnsTable();
                        }
                        break;
                }
            }
        }
    }
}