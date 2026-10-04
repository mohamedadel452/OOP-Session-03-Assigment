using System;

namespace OOP03_SmartDelivery
{
    #region PART 01: THEORETICAL QUESTIONS

    #region Q1: Overloading, Overriding, and Binding
    /*
   a) What is the difference between Method Overloading and Method Overriding?
      - Overloading: Having multiple methods with the SAME NAME but DIFFERENT PARAMETERS in the same class. (Resolved at Compile-Time).
      - Overriding: Changing the implementation of an inherited virtual/abstract method in a child class, keeping the SAME SIGNATURE. (Resolved at Run-Time).

   b) What is the difference between Static Binding and Dynamic Binding?
      - Static Binding (Early Binding): The compiler determines which method to call at compile-time (used with Overloading).
      - Dynamic Binding (Late Binding): The CLR determines which method to call at run-time based on the actual object type (used with Overriding/Polymorphism).

   */

    #endregion

    #endregion


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Smart Delivery System V3 (OOP) \n");


        }
    }
    #endregion
}