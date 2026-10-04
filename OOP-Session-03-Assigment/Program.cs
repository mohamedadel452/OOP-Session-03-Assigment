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

    #region Derived Classes

    #region StandardShipment
    public class StandardShipment : Shipment
    {
        #region Constructors
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination) { }
        #endregion

        #region Methods
        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment\n");
            base.PrintShipment();
            Console.WriteLine("\n------------------------------------------\n");
        }
        #endregion
    }
    #endregion

    #region ExpressShipment
    public class ExpressShipment : Shipment
    {
        #region Fields & Properties
        private decimal extraFee;
        public decimal ExtraFee
        {
            get { return extraFee; }
            set { if (value >= 0) extraFee = value; }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + ExtraFee; }
        }
        #endregion

        #region Constructors
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }
        #endregion

        #region Methods
        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment\n");
            base.PrintShipment();
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine("\n------------------------------------------\n");
        }
        #endregion
    }
    #endregion

    #region InternationalShipment
    public class InternationalShipment : Shipment
    {
        #region Fields & Properties
        private string destinationCountry;
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set { if (!string.IsNullOrWhiteSpace(value)) destinationCountry = value; }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set { if (value >= 0) customsFee = value; }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + CustomsFee; }
        }
        #endregion

        #region Constructors
        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        #endregion

        #region Methods
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report for {TrackingCode} to {DestinationCountry}. Fee: {CustomsFee}");
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment\n");
            base.PrintShipment();
            Console.WriteLine($"Destination Country  : {DestinationCountry}");
            Console.WriteLine($"Customs Fee          : {CustomsFee} EGP");
            Console.WriteLine("\n==========================================\n");
        }
        #endregion
    }
    #endregion

 
    #endregion

    #region DeliveryCenter & Helpers

    #region Driver Class
    public class Driver
    {
        public string Name { get; set; }
        public Driver(string name) { Name = name; }
    }
    #endregion

    #region DeliveryCenter Class
    public class DeliveryCenter
    {
        #region Fields & Properties
        public string CenterName { get; set; }
        public Driver CenterDriver { get; set; }

        private Shipment[] shipments = new Shipment[20];
        #endregion

        #region Constructors
        public DeliveryCenter(string centerName) { CenterName = centerName; }
        #endregion

        #region Indexers
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length) return shipments[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < shipments.Length) shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode) return shipments[i];
                }
                return null;
            }
        }
        #endregion

        #region Methods
        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null) return false;
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine(CenterName);
            Console.WriteLine("==========================================\n");

            if (CenterDriver != null)
                Console.WriteLine($"Driver : {CenterDriver.Name}\n");

            Console.WriteLine("------------------------------------------\n");

            foreach (var ship in shipments)
            {
                //dynamic binding will be used here to call the appropriate PrintShipment method based on the actual object type (StandardShipment, ExpressShipment, InternationalShipment)
                if (ship != null) ship.PrintShipment();
            }
        }
        #endregion
    }
    #endregion

    #region DeliveryHelper Static Class
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment != null)
            {
                shipment.PrintShipment();
            }
        }
    }
    #endregion

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