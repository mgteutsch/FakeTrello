using FakeTrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTrello.DAL
{
    interface IRepository
    {
        // List of methods to help deliver features
        //Create
        void AddBoard(string name, ApplicationUser owner);
        void AddList(string name, Board board);
        void AddList(string name, int boardId);
        void AddCard(string name, List list, ApplicationUser owner);
        void AddCard(string name, int listId, int ownerId);

        //Read
        List<Card> GetCardsFromList(int listId);
        List<Card> GetCardsFromBoard(int boardId);
        Card GetCard(int cardId);
        List GetList(int listId);
        List<List> GetListsFromBoard(int boardId); // List of Trello Lists
        List<Board> GetBoardsFromUser(string userId);
        Board GetBoard(int boardId);
        List<ApplicationUser> GetCardAttendees(int cardId); //Later, we can create a Count method to see how many users are on a card

        //Update
        bool AttachUser(string userId, int cardId); // Can only have up to 3 users
                                                 // true: successful; false: not successfull
                                                 // This does not have the 3 Max functionality built in naturally
        bool MoveCard(int cardId, int oldListId, int newListId);
        bool CopyCard(int cardId, int newListId, string newOwnerId); //When we create a new card, that copy now has a new owner from the original card 

        //Delete
        //We are using bool here to confirm whether a delete was successful or not
        bool RemoveBoard(int boardId);
        bool RemoveList(int listId);
        bool RemoveCard(int cardId);
    }
}
