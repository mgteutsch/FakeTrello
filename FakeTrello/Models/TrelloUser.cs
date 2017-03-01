using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Entity is our Object Relational Mapper (OBM)

namespace FakeTrello.Models
{
    public class TrelloUser
    {
        [Key] //Had to Build the project first, then the red squiggle appeared and I chose the "Using...." solution
        public int TrelloUserId { get; set; } //This is the Primary Key

        //Stacking of properties applies to multiple annotations
        //to the following property
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(60)]
        public string Username { get; set; }

        [MinLength(10)]
        [MaxLength(60)]
        public string FullName { get; set; }

        //This is a simple reference to ANOTHER table (ApplicationUser, which is an object, too)
        public ApplicationUser BaseUser { get; set; } //This creates the 1 to 1 relationship between ApplicationUser & TrelloUser

        //This is a "navigation property"
        public List<Board> Boards { get; set; } // 1 to Many (boards) relationship
    }
}