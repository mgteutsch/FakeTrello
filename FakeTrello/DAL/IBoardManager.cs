using FakeTrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTrello.DAL
{
    //Following the Interface Segregation Principle
    //we are looking for Board related Create, Update, & Delete
    interface IBoardManager
    {
        //Create
        void AddBoard(string name, ApplicationUser owner);

        //Update
        void EditBoardName(int boardId, string newname);

        //Delete
        bool RemoveBoard(int boardId);
    }
}
