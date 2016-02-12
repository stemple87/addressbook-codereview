using Nancy;
using System.Collections.Generic;
using Contact.Objects

namespace AddressBook
{
  public class HomeModule : nancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"]
      }
      Get["/contacts"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts]
      };
      Get["/contact/new"] = _ => {
        return View["contact_form.cshtml"]
      }
    }
  }
}
