namespace Lab5
{
    internal class OrderDetail : OrderDetails
    {
        public object OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}