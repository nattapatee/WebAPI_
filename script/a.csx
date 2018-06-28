using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 
namespace ConsoleApplication2
{
    class Program : ParendClass
    {
        static void Main(string[] args)
        {
 
            ParendClass p = new ParendClass();
            p.sayHello();
            sayHello("AmplySoft");
 
            Console.ReadLine();         
 
        }
 
        public static void sayHello(string n)
        {
 
            Console.WriteLine("Hello, {0} with Overide Method :)", n);
 
        }
 
    }
 
    class ParendClass
    {
 
        public void sayHello()
        {
 
            Console.WriteLine( "Hello, AmplySoft :) with Inheritance C#" );
 
        }
 
    }
 
}