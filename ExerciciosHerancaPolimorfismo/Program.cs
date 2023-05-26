using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ExerciciosHerancaPolimorfismo.Entities;

namespace ExerciciosHerancaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> product = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Product #{0} data:", i);

                Console.Write("Common, used or imported (c/u/i)? ");
                char escolha = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (escolha == 'u')
                {
                    Console.Write("Manufactured date (DD//MM/YYYY): ");
                    DateTime manufacturedDate = DateTime.Parse(Console.ReadLine());
                    product.Add(new UsedProduct(name, price, manufacturedDate));

                }
                else if(escolha == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    product.Add(new ImportedProduct(name, price, customsFee));
                }
                else
                {
                    product.Add(new Product(name, price));
                }
            }
            Console.WriteLine("");
            Console.WriteLine("PRICE TAGS:");
            foreach (Product item in product)
            {
                Console.WriteLine(item.PriceTag());
            }
        }
    }
}
