using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;


List<Product> items = new List<Product>();


bool enterCategoryName = false;
bool enterProductName = false;
bool enterProductPrice = false;





while (true)
{


    Product newProduct = new Product();

    

    if (!enterCategoryName)
    {
        Console.WriteLine("Add Category Name, Please");
        String categoryName = Console.ReadLine();
        //Category gategory = new Category();


        if (QuitFunction(categoryName))
        {
            break;
        }else if(String.IsNullOrWhiteSpace(categoryName))
        {
            Console.WriteLine("Empty input..");
        }
        else
        {
            newProduct.Category = new Category(categoryName);
            enterCategoryName = true;
        }
    }
    if(enterCategoryName && !enterProductName )
    {

        Console.WriteLine("Add Product Name, Please...");
        string productName = Console.ReadLine();
        if (QuitFunction(productName))
        {
            break;
        }else if (String.IsNullOrWhiteSpace(productName)&& String.IsNullOrWhiteSpace(newProduct.ProductName))
        {
            Console.WriteLine("Empty input..");
        }
        else
        {
           newProduct.ProductName = productName;
            enterProductName = true;
        }
    }
    if (enterProductName && !enterProductPrice)
    {
        Console.WriteLine("Add The Product's Price, Please...");
        string productPrice = Console.ReadLine();
        if (QuitFunction(productPrice))
        {
            break;
        }
        else if (String.IsNullOrWhiteSpace(productPrice))
        {
            Console.WriteLine("Empty input..");
        }
        else if (!productPrice.All(char.IsDigit))
        {
            Console.WriteLine("InvalidEnter...Price Should Be A Number...");
        }

        newProduct.ProductPrice = productPrice;
        items.Add(newProduct);

        enterCategoryName = false;
        enterProductName = false;
        enterProductPrice = false;

    }


}


List<Product> sortProductsList = items.OrderBy(product => Int32.Parse(product.ProductPrice)).ToList();

Console.WriteLine("Category".PadRight(50) + "Product Name".PadRight(50) +
"Price");

foreach (Product product in sortProductsList)
{
    Console.WriteLine(product.Category.CategoryName.PadRight(50) + product.ProductName.PadRight(50) + product.ProductPrice);

}

int totalProductsPrice = sortProductsList.Sum(product => Int32.Parse(product.ProductPrice));
Console.WriteLine("The Total Price For All Products : " + totalProductsPrice);


Console.ReadLine();

static bool QuitFunction(string input)
{
    if (input.ToLower().Trim() == "q")
    {
        return true;
    }
    else
    {
        return false;
    }
}



class Product
{

    public Product() { }
    public Product(string category, string product, string productPrice)
    {
      
        Category = new Category(category);
        ProductName = product;
        ProductPrice = productPrice;
    }


    public Category Category { get; set; }
    public string ProductName { get; set; }
    public string ProductPrice { get; set; }
}

class Category
{
    public Category() { }
    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }

    public string CategoryName { get; set; }
}