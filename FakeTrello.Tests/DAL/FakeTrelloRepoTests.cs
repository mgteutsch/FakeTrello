using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeTrello.DAL;
using Moq;
using FakeTrello.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeTrello.Tests.DAL
{
    [TestClass]
    public class FakeTrelloRepoTests
    {
        [TestMethod]
        public void EnsureICanCreateInstanceOfRepo()
        {
            FakeTrelloRepository repo = new FakeTrelloRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureIHaveANotNullContext()
        {
            FakeTrelloRepository repo = new FakeTrelloRepository();

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanInjectContextInstance()
        {
            FakeTrelloContext context = new FakeTrelloContext();
            FakeTrelloRepository repo = new FakeTrelloRepository(context);

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanAddBoard()
        {
            //Arrange
            List<Board> fake_board_table = new List<Board>();

            //IQueryable<Board> is the type of this thing below:
            var query_boards = fake_board_table.AsQueryable(); //Re-express this list as something that understands queries

            Mock<FakeTrelloContext> fake_context = new Mock<FakeTrelloContext>();
            Mock<DbSet<Board>> mock_boards_set = new Mock<DbSet<Board>>();

            //This is basically lying and saying we have a database, but nope, we just have these mocks
            //Hey LINQ, use the Provider from our *cough* fake *cough* board table/list 
            mock_boards_set.As<IQueryable<Board>>().Setup(b => b.Provider).Returns(query_boards.Provider);
            mock_boards_set.As<IQueryable<Board>>().Setup(b => b.Expression).Returns(query_boards.Expression); //In this case, the Expression is a SQL Query statement
            mock_boards_set.As<IQueryable<Board>>().Setup(b => b.ElementType).Returns(query_boards.ElementType); //Make sure what you return is instantiated as the same type
            mock_boards_set.As<IQueryable<Board>>().Setup(b => b.GetEnumerator()).Returns(() => query_boards.GetEnumerator()); //Because the amount of instances will change... but I need a little more explanation on this

            mock_boards_set.Setup(b => b.Add(It.IsAny<Board>())).Callback((Board board) => fake_board_table.Add(board)); //This mocks the Add call from Line 28 in FakeTrelloRepository.cs
            fake_context.Setup(c => c.Boards).Returns(mock_boards_set.Object); //This is the fake board table, which is a List.... Context.Boards returns fake_board_table (a list)

            FakeTrelloRepository repo = new FakeTrelloRepository(fake_context.Object);
            ApplicationUser a_user = new ApplicationUser
            {
                Id = "my-user-id",
                UserName = "Sammy",
                Email = "sammy@gmail.com"
            };

            //Act
            repo.AddBoard("My Board", a_user);

            //Assert
            Assert.AreEqual(1, repo.Context.Boards.Count());
        }
    }
}
