namespace Course
{
    internal class Ventas
    {
		private string _Product;
		private int _Quantity;

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}


		public string Product
		{
			get { return _Product; }
			set { _Product = value; }
		}

		public double AssignPrice()
		{
			switch (Product)
			{
				case "Teclado":
					return 50;
				case "Celular":
					return 700;
				case "Reloj":
					return 100;
				case "Cuatro":
					return 350;
			}
			return 0;
		}

		public double CalculateSubtotal()
		{
			return AssignPrice() * Quantity;
		}

		public double CalculateDiscount()
		{
			double subtotal = CalculateSubtotal();

			if (subtotal <= 300) return 5.0 / 100 * subtotal;
			else if (subtotal > 300 && subtotal <= 500) return 10.0 / 100 * subtotal;
			else return 15.0 / 100 * subtotal;
		}

		public double CalculateNet()
		{
			return CalculateSubtotal() - CalculateDiscount();
		}
	}
}
