using System;
using System.Collections.Generic;

class Hotel 
{
    string name;
    int id;
    Location hotelLocation;
    List<Room> roomList;
}

class Location
{
    int pin;
    string street;
    string area;
    string city;
    string country;
}

class Room 
{
    string roomNumber;
    RoomStyle roomStyle;
    RoomStatus roomStatus;
    double bookingPrice;
    List<RoomKey> roomKeys;
    List<HouseKeepingLog> houseKeepingLogs;
}

public enum RoomStyle
{
    STANDARD, DELUXE, FAMILY_SUITE
}

public enum RoomStatus
{
    AVAILABLE, RESERVED, NOT_AVAILABLE, OCCUPIED, SERVICE_IN_PROGRESS
}

class RoomKey
{
    string keyId;
    string barcode;
    DateTime issuedAt;
    bool isActive;
    bool isMasterKey;

    public void AssignRoom(Room room)
    {

    }
}

class HouseKeepingLog 
{
    string desc;
    DateTime startDate;
    int duration;
    HouseKeeper housekeeper;

    public void AddRoom(Room room)
    {

    }
}

abstract class Person
{
    string name;
    Account accountDetail;
    string phone;
}

public class Account
{
    string username;
    string password;

    AccountStatus accountStatus;
}

public enum AccountStatus 
{
    ACTIVE, CLOSED, BLOCKED
}

class HouseKeeper: Person 
{
    public List<Room> GetRoomsServiced(DateTime date)
    {
        return null;
    }
}

class Guest: Person 
{
    Search searchObj;
    Booking bookingObj;

    public void CheckInGuest(Guest guest, RoomBooking bookingInfo)
    {

    }
    public void CheckOutGuest(Guest guest, RoomBooking bookingInfo)
    {

    }
}

class Admin: Person 
{
    public void AddRoom(Room roomDetail)
    {

    }
    public Room DeleteRoom(string roomId)
    {
        return null;
    }
    public Room EditRoom(Room roomDetail)
    {
        return null;
    }
}

class Search 
{
    public List<Room> SearchRoom(RoomStyle roomStyle, DateTime startDate, int duration)
    {
        return null;
    }
}

class Booking 
{
    public RoomBooking CreateBooking(Guest guestInfo)
    {
        return null;
    }
    public RoomBooking CancelBooking(int bookingId)
    {
        return null;
    }
}
public enum BookingStatus
{
    BOOKED, INPROGRESS
}
public class BaseRoomCharge
{

}
class RoomBooking 
{
    string bookingId;
    DateTime startDate;
    int durationDays;
    BookingStatus bookingStatus;
    List<Guest> guestList;
    List<Room> roomInfo;
    BaseRoomCharge totalRoomCharges;
}

// Decorator pattern is used to decorate price

interface IBaseRoomCharge
{
    public double cost { get; set; }
}

class RoomServiceCharge : IBaseRoomCharge 
{
    double cost;
    BaseRoomCharge baseRoomCharge;
    Double GetCost()
    {
        // baseRoomCharge.cost = baseRoomCharge + cost;
        baseRoomCharge.SetCost(baseRoomCharge.GetCost() + cost);
        return baseRoomCharge.GetCost();
    }
}

class InRoomPurchaseCharges : IBaseRoomCharge 
{
    double cost;
    BaseRoomCharge baseRoomCharge;
    Double GetCost() 
    {
        baseRoomCharge.SetCost(baseRoomCharge.GetCost() + cost);
        return baseRoomCharge.GetCost();
    }
}

//Test push