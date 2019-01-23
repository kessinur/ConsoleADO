using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            int id;
            Supplier supplier = new Supplier();
            MyContext _context = new MyContext();  
            Console.WriteLine("=========Supplier Data=========");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrieve");
            Console.WriteLine("===============================");
            Console.Write("Silahkan masukkan pilihan mu : ");
            int x = Convert.ToInt32(Console.ReadLine());

            switch (x)
            {
                case 1:
                    Console.WriteLine("==============================");
                    Console.WriteLine("Pilihan anda adalah " + x);
                    Console.WriteLine("==============================");
                    // this is for inserting Supplier Name, Join Date, and CreateDate
                    Console.Write("Insert Name of Supplier : ");
                    supplier.Name = Console.ReadLine();
                    supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                    supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;

                    _context.Suppliers.Add(supplier);
                    result = _context.SaveChanges();
                    if(result > 0)
                    {
                        Console.Write("Insert Successfully");
                        Console.Read();
                    } else
                    {
                        Console.Write("Insert Failed");
                        Console.Read();
                    }
                    break;

                case 2:
                    Console.WriteLine("==============================");
                    Console.WriteLine("Pilihan anda adalah " + x);
                    Console.WriteLine("==============================");
                    
                    //input id yang dicari
                    Console.Write("Insert Id to update data ");
                    id = Convert.ToInt16(Console.ReadLine());

                    // mencari data sesuai dengan id di database
                    var get = _context.Suppliers.Find(id);
                    
                    //cek data di database
                    if (get == null)
                    {
                        //jika tidak maka akan menampilkan seperti berikut
                        Console.Write("Sorry, your data is not found my friend");
                        Console.Read();
                    }
                    else
                    {
                        //Jika ada maka akan meminta inputan nama dan akan disimpan di database
                        Console.Write("Insert Name of Supplier : ");
                        get.Name = Console.ReadLine();
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;

                        result = _context.SaveChanges();
                        if(result > 0)
                        {
                            Console.Write("Update Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Update Failed");
                            Console.Read();
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("==============================");
                    Console.WriteLine("Pilihan anda adalah " + x);
                    Console.WriteLine("==============================");
                    //input id yang dicari
                    Console.Write("Insert Id to delete data ");
                    // mencari data sesuai dengan id di database
                    var getData = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));

                    //cek data di database
                    if (getData == null)
                    {
                        //jika tidak maka akan menampilkan seperti berikut
                        Console.Write("Sorry, your data is not found my friend");
                        Console.Read();
                    }
                    else
                    {
                        //jika ada, maka akan mengubah status is Delete dan akan disimpan di database
                        getData.IsDelete = true;
                        getData.DeleteDate = DateTimeOffset.Now.LocalDateTime;

                        result = _context.SaveChanges();
                        if(result > 0)
                        {
                            Console.Write("Delete Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Delete Failed");
                            Console.Read();
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("==============================");
                    Console.WriteLine("Pilihan anda adalah " + x);
                    Console.WriteLine("==============================");
                    var getDatatoDisplay = _context.Suppliers.Where(a => a.IsDelete == false).ToList();
                    
                    if(getDatatoDisplay.Count == 0)
                    {
                        Console.Write("No Data in your database");
                        Console.Read();
                    }
                    else
                    {
                        foreach(var tampilin in getDatatoDisplay)
                        {
                            Console.WriteLine("==============================");
                            Console.WriteLine("Name       : " + tampilin.Name);
                            Console.WriteLine("Join Date  : " + tampilin.JoinDate);
                            Console.WriteLine("==============================");
                        }
                        Console.Write("Total Suppier " + getDatatoDisplay.Count);
                        Console.Read();
                    }
                    break;

                default:
                    Console.WriteLine("==============================");
                    Console.WriteLine("Your choice is not found, try again later, good boi XD");
                    break;
            }
            Console.Read();
        }
    }
}
