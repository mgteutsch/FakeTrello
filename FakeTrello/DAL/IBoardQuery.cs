using FakeTrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTrello.DAL
{
    //Following the Interface Segregation Principle
    //We took Board-related Query methods (under READ from IRepository)

    interface IBoardQuery
    {
        List<Board> GetBoardsFromUser(string userId);
        Board GetBoard(int boardId);
    }
}
