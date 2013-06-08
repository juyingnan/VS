using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using ContactManager.Resources;

namespace ContactManager.APIs
{
    [ServiceContract]
    public class ContactsApi
    {
        [WebGet(UriTemplate = "")]
        public IQueryable<Contact> Get()
        {
            var contacts = new List<Contact>()
        {
            new Contact {ContactId = 1, Name = "Phil Haack"},
            new Contact {ContactId = 2, Name = "HongMei Ge"},
            new Contact {ContactId = 3, Name = "Glenn Block"},
            new Contact {ContactId = 4, Name = "Howard Dierking"},
            new Contact {ContactId = 5, Name = "Jeff Handley"},
            new Contact {ContactId = 6, Name = "Yavor Georgiev"}
        };
            return contacts.AsQueryable();
        }

        [WebGet(UriTemplate = "T")]
        public String Test()
        {
            var contacts = new List<Contact>()
        {
            new Contact {ContactId = 1, Name = "Phil Haack"},
            new Contact {ContactId = 2, Name = "HongMei Ge"},
            new Contact {ContactId = 3, Name = "Glenn Block"},
            new Contact {ContactId = 4, Name = "Howard Dierking"},
            new Contact {ContactId = 5, Name = "Jeff Handley"},
            new Contact {ContactId = 6, Name = "Yavor Georgiev"}
        };
            return contacts[0].Name;
        }
    }
}