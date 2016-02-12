using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Get["/contacts"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contact/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contacts"] = _ => {
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-address"], Request.Form["new-number"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["/contacts.cshtml", contact];
      };
    }
  }
}
