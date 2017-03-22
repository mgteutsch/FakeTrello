using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeTrello.Models;

namespace FakeTrello.DAL
{
    public class ListRepository : IListRepository
    {
        public void AddList(string name, int boardId)
        {
            throw new NotImplementedException();
        }

        public void AddList(string name, Board board)
        {
            throw new NotImplementedException();
        }

        public List GetList(int listId)
        {
            throw new NotImplementedException();
        }

        public List<List> GetListsFromBoard(int boardId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveList(int listId)
        {
            throw new NotImplementedException();
        }
    }
}