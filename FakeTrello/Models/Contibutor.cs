using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeTrello.Models
{
    public class Contibutor //Contibutors who can post cards to an approving user's Board (TrelloUser)
    {
        //This is simply a Join/Mapping Table
        //Do NOT need [Key] here, we are not creating a Primary Key

        public List<TrelloUser> Users { get; set; }

        public List<Card> Cards { get; set; }
    }
}