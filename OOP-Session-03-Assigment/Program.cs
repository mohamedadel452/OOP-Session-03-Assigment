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


    #region PART 02: PRACTICAL

    #region DeliveryAddress Struct
    public struct DeliveryAddress
    {
        #region Fields
        public string City;
        public string Street;
        public int BuildingNumber;
        #endregion

        #region Constructors
        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        #endregion

        #region Methods
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street}, {City}";
        }
        #endregion
    }
    #endregion

    #region  Shipment Class
    public class Shipment
    {
        #region Fields & Properties
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get { return trackingCode; }
            private set { if (!string.IsNullOrWhiteSpace(value)) trackingCode = value; }
        }

        public string Description
        {
            get { return description; }
            set { if (!string.IsNullOrWhiteSpace(value)) description = value; }
        }

        public decimal Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set { if (value > 0) deliveryFee = value; }
        }

        public virtual decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5m); }
        }
        #endregion

        #region Constructors

        // Constructor 1
        public Shipment(string trackingCode)
        {
            this.trackingCode = string.Empty;
            this.description = "Unknown";
            this.weight = 1m;
            this.deliveryFee = 50m;
            this.Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            this.TrackingCode = trackingCode;
        }

        // Constructor 2
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = string.Empty;
            this.description = "Unknown";
            this.weight = 1m;
            this.deliveryFee = 50m;
            this.Destination = destination;

            this.TrackingCode = trackingCode;
            this.Description = description;
            this.Weight = weight;
            this.DeliveryFee = deliveryFee;
        }
        #endregion

        #region Methods
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0) this.DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0) Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight > 0 && extraPackingWeight >= 0)
            {
                Weight = newWeight + extraPackingWeight;
            }
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
        #endregion
    }
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