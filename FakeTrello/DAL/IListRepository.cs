using FakeTrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTrello.DAL
{
    interface IListRepository
    {
        //Create
        #region
        void AddList(string name, Board board);
        void AddList(string name, int boardId);
        #endregion
        //Nathan showed us how to use #region... look, it is collapsible now

        //Read
        List GetList(int listId);
        List<List> GetListsFromBoard(int boardId);

        //Update (none)

        //Delete
        bool RemoveList(int listId);

    }
}
