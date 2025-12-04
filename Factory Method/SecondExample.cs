namespace Factory_Method;

// IVehicle.cs
public interface IVehicle
{
    void Drive();
}
// Car.cs
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a car!");
    }
}
// Bike.cs
public class Bike : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Riding a bike!");
    }
}
// Truck.cs
public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a truck!");
    }
}

// VehicleFactory.cs
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();

    public void StartJourney()
    {
        IVehicle vehicle = CreateVehicle();
        vehicle.Drive();
    }
}

// CarFactory.cs
public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}
// BikeFactory.cs
public class BikeFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Bike();
    }
}
// TruckFactory.cs
public class TruckFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Truck();
    }
}


public class SecondExample
{
    static void Demo()
    {
        VehicleFactory carFactory = new CarFactory();
        carFactory.StartJourney(); // Output: Driving a car!

        VehicleFactory bikeFactory = new BikeFactory();
        bikeFactory.StartJourney(); // Output: Riding a bike!

        VehicleFactory truckFactory = new TruckFactory();
        truckFactory.StartJourney(); // Output: Driving a truck!
    }
}
