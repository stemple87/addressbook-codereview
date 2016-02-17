using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _name;
    private string _address;
    private int _phoneNumber;
    private int _id;
    private static List<Contact> _instancesObjects = new List<Contact>();

    //Contact constructor
    public Contact(string name, string address, int phoneNumber)
    {
      _name = name;
      _address = address;
      _phoneNumber = phoneNumber;
      _instancesObjects.Add(this);
      _id = _instancesObjects.Count;
    }


    //Getters and setters
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public int GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(int newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    //Method to return list of all contacts
    public static List<Contact> GetAll()
    {
      return _instancesObjects;
    }
    // this method takes newly created contact object (from the HomeModule.cs file) and adds it to the list of contact objects
    public void Save()
    {
      _instancesObjects.Add(this);
    }
    // clears all objects from list
    public static void Clear()
    {
      _instancesObjects.Clear();
    }
    // gets the id number
    public int GetId()
    {
      return _id;
    }
    // finds the id location of the object in the list
    public static Contact Find(int searchId)
    {
      return _instancesObjects[searchId - 1];
    }
  }

}
