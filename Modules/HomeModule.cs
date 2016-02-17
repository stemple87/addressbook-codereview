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
      Get["/all_contacts/"] = _ => {
        var allContacts = Contact.GetAll();
        return View["all_contacts.cshtml", allContacts];
      };
      Post["/contact_created"] = _ => {
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-address"], Request.Form["new-number"]);
        return View["contact_created.cshtml", newContact];
      };
      Get["/contact/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["/contacts.cshtml", contact];
      };
      Post["/contacts_deleted/"] = _ => {
        Contact.Clear();
        return View["contacts_cleared.cshtml"];
      };
    }
  }
}
