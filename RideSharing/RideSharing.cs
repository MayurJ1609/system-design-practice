using System.Collections.Generic;
using System;

namespace RideSharing
{
    enum RideStatus
    {
        IDLE,
        CREATED,
        WITHDRAWN,
        COMPLETED
    }
    class Ride
    {
        const int AMT_PER_KM = 20;
        public Ride()
        {
            id = origin = destination = seats = 0;
            rideStatus = RideStatus.IDLE;
        }
        public double CalculateFare(bool isPriorityRider)
        {
            int dist = destination - origin;
            if(seats < 2)
            {
                return dist * AMT_PER_KM * (isPriorityRider ? 0.75 : 1);
            }
            return dist * seats * AMT_PER_KM * (isPriorityRider ? 0.5 : 0.75);
        }
        public int id { get; set; }
        public int origin { get; set; }
        public int destination { get; set; }
        public int seats { get; set; }
        public RideStatus rideStatus { get; set; }

    }

    class Person
    {
        public string name;
    }

    class Driver : Person
    {
        public Driver(string name)
        {
            this.name = name;
        }
    }

    class Rider : Person
    {
        List<Ride> completedRides;
        Ride currentRide;

        public Rider(string name)
        {
            this.name = name;
        }

        public void CreateRide(int id, int origin, int destination, int seats)
        {
            if(origin >= destination)
            {
                Console.WriteLine("Wrong values of Origin and Destination provided. Cannot create ride");
                return;
            }
            currentRide.id = id;
            currentRide.origin = origin;
            currentRide.destination = destination;
            currentRide.seats = seats;
            currentRide.rideStatus = RideStatus.CREATED;
        }

        public void UpdateRide(int id, int origin, int destination, int seats)
        {
            if(currentRide.rideStatus == RideStatus.WITHDRAWN)
            {
                Console.WriteLine("Cannot update ride. Ride was withdrawn");
                return;
            }
            if(currentRide.rideStatus == RideStatus.COMPLETED)
            {
                Console.WriteLine("Cannot update ride. Ride is already completed");
                return;
            }
            CreateRide(id, origin, destination, seats);
        }

        public void WithdrawRide(int id)
        {
            if(currentRide.id != id)
            {
                Console.WriteLine("Wrong ride ID as input. Cannot withdraw current ride");
                return;
            }
            if(currentRide.rideStatus != RideStatus.CREATED)
            {
                Console.WriteLine("Ride wasn't in progress. Cannot withdraw current ride");
                return;
            }
            currentRide.rideStatus = RideStatus.WITHDRAWN;
        }
        
        public double CloseRide()
        {
            if(currentRide.rideStatus != RideStatus.CREATED)
            {
                Console.WriteLine("Ride wasn't in progress. Cannot close current ride");
                return 0;
            }
            currentRide.rideStatus = RideStatus.COMPLETED;
            completedRides.Add(currentRide);
            return currentRide.CalculateFare(completedRides.Count >= 10);
        }

    }

    class TestClass
    {
        public void TestRideSharing()
        {
            Rider rider = new Rider("Lucifer");
            Driver driver = new Driver("Driver1");

            rider.CreateRide(1, 50, 60, 1);
            Console.WriteLine(rider.CloseRide());
            rider.UpdateRide(1, 50, 60, 2);
            Console.WriteLine(rider.CloseRide());
            Console.WriteLine("****************************************************");

            rider.CreateRide(1, 50, 60, 1);
            rider.WithdrawRide(1);
            rider.UpdateRide(1, 50, 60, 2);
            Console.WriteLine(rider.CloseRide());
            Console.WriteLine("****************************************************");

            rider.CreateRide(1, 50, 60, 1);
            rider.UpdateRide(1, 50, 60, 2);
            Console.WriteLine(rider.CloseRide());
            
        }
    }
}