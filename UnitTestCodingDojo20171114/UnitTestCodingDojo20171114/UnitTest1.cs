using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCodingDojo20171114
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(PlayerNullException))]
        public void TestPlayer1MustBeValid()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Game game = new Game(player1, null);
           
        }

        [TestMethod]
        [ExpectedException(typeof(PlayerNullException))]
        public void TestPlayer2MustBeValid()
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Game game = new Game(null, player2);

        }



        [TestMethod]
        public void TestPlayersAreTheSame()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Assert.AreEqual(player1.Name, "player1");
            Assert.AreEqual(player2.Name, "player2");
        }


        [TestMethod]
        public void TestPlayersAreTheSameInGame()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            Assert.AreEqual(game.Player1.Name, "player1");
            Assert.AreEqual(game.Player2.Name, "player2");
        }

        [TestMethod]
        public void TestPRecorded()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);

            Assert.AreEqual(1,game.GetScore(player1));
            Assert.AreEqual(0, game.GetScore(player2));

        }

        [TestMethod]
        public void TestGetScoreTennisWay()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);

            Assert.AreEqual("15 - 0", (new GameDecorator(game)).GetScoreSetString());

        }

        [TestMethod]
        public void TestAllScoreTennis()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);

            Assert.AreEqual("15 - 0", (new GameDecorator(game)).GetScoreSetString(), "Score need to be 15 - 0");
            game.PlayRound(player2);
            Assert.AreEqual("15 - 15", (new GameDecorator(game)).GetScoreSetString());
            game.PlayRound(player1);
            Assert.AreEqual("30 - 15", (new GameDecorator(game)).GetScoreSetString());
            game.PlayRound(player2);
            Assert.AreEqual("30 - 30", (new GameDecorator(game)).GetScoreSetString());
            game.PlayRound(player1);
            Assert.AreEqual("40 - 30", (new GameDecorator(game)).GetScoreSetString());
            game.PlayRound(player2);
            Assert.AreEqual("40 - 40", (new GameDecorator(game)).GetScoreSetString(), "Score need to be 40 - 40");
        }

        [TestMethod]
        public void TestIsGameWin()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player1);

            Assert.AreEqual((new GameDecorator(game)).Winner, player1);
        }

        [TestMethod]
        public void TestAdvantage()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player1);


            Assert.AreEqual("Advantage player 1", (new GameDecorator(game)).GetScoreSetString(), "Score need to be Advantage player 1");
            game.PlayRound(player2);
            game.PlayRound(player2);
            Assert.AreEqual("Advantage player 2", (new GameDecorator(game)).GetScoreSetString(), "Score need to be Advantage player 1");
        }


        [TestMethod]
        public void testDraw()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player1);
            game.PlayRound(player2);

            Assert.AreEqual("Draw", (new GameDecorator(game)).GetScoreSetString(), "Score need to Draw");
        }

        [TestMethod]
        public void TestWinner()
        {
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            Game game = new Game(player1, player2);

            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player1);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player2);
            game.PlayRound(player1);
            game.PlayRound(player1);

            Assert.AreEqual("player1 Win", (new GameDecorator(game)).GetScoreSetString(), "Score need to Player1 Win");
        }
         
      
    }
}
