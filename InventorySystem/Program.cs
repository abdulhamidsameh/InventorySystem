namespace InventorySystem
{
	internal class Program
	{
		private static string[,] Inventory = new string[100, 3];
		private static int ProductCount = 0;
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome In Our Inventory Mangement System");
			Console.WriteLine("==========================================");
			string UserChoice;
			while (true)
			{
				Console.WriteLine("1- Add Product");
				Console.WriteLine("2- Update Product");
				Console.WriteLine("3- View Products");
				Console.WriteLine("4- Exit");
				Console.Write("Please Select What You Want To Do :");
				UserChoice = Console.ReadLine()!;
				Console.Clear();
				switch (UserChoice)
				{
					case "1":
						AddProduct();
						break;
					case "2":
						UpdateProduct();
						break;
					case "3":
						ViewProducts();
						break;
					case "4":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please Enter Correct Number Between 1 to 4");
						break;
				}
			}
		}

		private static void AddProduct()
		{
			string ProductName;
			string ProductQuantity;
			string ProductPrice;
			bool Flag = false;
			do
			{
				Console.Write("Enter The Product Name :");
				ProductName = Console.ReadLine()!;
				if (string.IsNullOrEmpty(ProductName))
				{
					Console.WriteLine("Product Name Must Be Not Null Or Empty");
					Flag = true;
				}

			} while (Flag);
			do
			{
				Console.Write("Enter The Product Quantity :");
				ProductQuantity = Console.ReadLine()!;
				if (string.IsNullOrEmpty(ProductQuantity))
				{
					Console.WriteLine("Product Quantity Must Be Not Null Or Empty");
					Flag = true;
				}
				else
				{
					Flag = false;
					int Quantity;
					if (!int.TryParse(ProductQuantity, out Quantity) || Quantity <= 0)
					{
						Console.WriteLine("Product Quantity Must Be A Vaild Number And Greater Than 0");
						Flag = true;
					}
				}

			} while (Flag);
			do
			{
				Console.Write("Enter The Product Price :");
				ProductPrice = Console.ReadLine()!;
				if (string.IsNullOrEmpty(ProductPrice))
				{
					Console.WriteLine("Product Price Must Be Not Null Or Empty");
					Flag = true;
				}
				else
				{
					Flag = false;
					int Price;
					if (!int.TryParse(ProductPrice, out Price) || Price <= 0)
					{
						Console.WriteLine("Product Price Must Be A Vaild Number And Greater Than 0");
						Flag = true;
					}
				}

			} while (Flag);
			Inventory[ProductCount, 0] = ProductName;
			Inventory[ProductCount, 1] = ProductQuantity;
			Inventory[ProductCount++, 2] = ProductPrice;
			Console.WriteLine("Product Added Successfully");
		}

		private static void ViewProducts()
		{
			if (ProductCount == 0)
				Console.WriteLine("Sorry Your Inventory Not Have Any Item");
			else
				for (int i = 0; i < ProductCount; i++)
					Console.WriteLine($"Product Id :{i + 1},Product Name :{Inventory[i, 0]},Product Quantity :{Inventory[i, 1]},Product Price :{Inventory[i, 2]:c}");
		}

		private static void UpdateProduct()
		{
			string ProductName;
			int ProductIndex = -1;
			bool Flag = false;
			do
			{
				Console.Write("Enter The Product Name :");
				ProductName = Console.ReadLine()!;
				if (string.IsNullOrEmpty(ProductName))
				{
					Console.WriteLine("Product Name Must Be Not Null Or Empty");
					Flag = true;
				}
			} while (Flag);
			for (int i = 0; i < ProductCount; i++)
			{
				if (Inventory[i, 0].ToLower() == ProductName.ToLower())
				{
					ProductIndex = i;
					break;
				}

			}
			if (ProductIndex == -1)
			{
				Console.WriteLine("This Product Not Exict In Our Inventory");
			}
			else
			{
				Console.WriteLine("That Product In Our Inventory");
				Console.WriteLine("Update The Product Data");
				string ProductQuantity;
				string ProductPrice;
				Flag = false;
				do
				{
					Console.Write("Enter The Product Name :");
					ProductName = Console.ReadLine()!;
					if (string.IsNullOrEmpty(ProductName))
					{
						Console.WriteLine("Product Name Must Be Not Null Or Empty");
						Flag = true;
					}

				} while (Flag);
				do
				{
					Console.Write("Enter The Product Quantity :");
					ProductQuantity = Console.ReadLine()!;
					if (string.IsNullOrEmpty(ProductQuantity))
					{
						Console.WriteLine("Product Quantity Must Be Not Null Or Empty");
						Flag = true;
					}
					else
					{
						Flag = false;
						int Quantity;
						if (!int.TryParse(ProductQuantity, out Quantity) || Quantity <= 0)
						{
							Console.WriteLine("Product Quantity Must Be A Vaild Number And Greater Than 0");
							Flag = true;
						}
					}

				} while (Flag);
				do
				{
					Console.Write("Enter The Product Price :");
					ProductPrice = Console.ReadLine()!;
					if (string.IsNullOrEmpty(ProductPrice))
					{
						Console.WriteLine("Product Price Must Be Not Null Or Empty");
						Flag = true;
					}
					else
					{
						Flag = false;
						int Price;
						if (!int.TryParse(ProductPrice, out Price) || Price <= 0)
						{
							Console.WriteLine("Product Price Must Be A Vaild Number And Greater Than 0");
							Flag = true;
						}
					}

				} while (Flag);
				Inventory[ProductIndex, 0] = ProductName;
				Inventory[ProductIndex, 1] = ProductQuantity;
				Inventory[ProductIndex++, 2] = ProductPrice;
				Console.WriteLine("Product Updated Successfully");
			}
		}

	}
}
