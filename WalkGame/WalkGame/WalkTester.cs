using System;
using System.Collections.Generic;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WalkGame
{
    [TestClass]
    public class WalkTester
    {
        [TestMethod]
        public void TestCreationPlayerIsAlive()
        {
            var player = new Player(2);
            
            Assert.AreNotEqual(0, player.Pos);
        }

        [TestMethod]
        [ExpectedException(typeof(DeadPlayerException))]
        public void TestCreationDeadPlayer()
        {
           
            var player =new Player(0);

        }

        [TestMethod]
        public void TestIsPlayerAlive()
        {
            var player = new Player(2);
            Assert.AreEqual(true, player.Alive);

        }

        [TestMethod]
        public void TestIsPlayerDead()
        {
            var player = new Player(2);
            player.Pos = 0;
            Assert.AreEqual(false, player.Alive);

        }

        [TestMethod]
        public void TestAddPlayer()
        {
            var player = new Player(2);
            var players = new List<Player>();
            players.Add(player);

            var game = new Game(players, null);

            Assert.AreEqual(1 ,game.PlayerNumber);

        }

        [TestMethod]
        public void TestPlayerExist()
        {
            var player = new Player(2);
            var players = new List<Player>();
            players.Add(player);

            var game = new Game(players, null);

            Assert.IsTrue(game.ContainsPlayer(player));
            
            var player2 = new Player(2);

            Assert.IsFalse(game.ContainsPlayer(player2));

        }

        [TestMethod]
        [ExpectedException(typeof(EmptyGameException))]

        public void TestListOfPlayerIsNotEmpty()
        {
            var players = new List<Player>();
      
            var game = new Game(players, null);
            
        }

        [TestMethod]
        public void TestMoveLivePlayerToDeadPlayer()
        {
            var player = new Player(-1);
            var randomEngineMock = new Mock<IMoveEngine>();

            randomEngineMock.Setup(x => x.Play())
                .Returns(() => 1);

            //var engine = new DeterministEngine();
            var game = new Game(new List<Player>(){player}, randomEngineMock.Object);
            game.Play();
            Assert.IsFalse(player.Alive);
        }

        [TestMethod]
        public void TestLivePlayerToLivelayer()
        {
            var player = new Player(3);
            // var moveEngine = new DeterministEngine();
            var randomEngineMock = new Mock<IMoveEngine>();

            randomEngineMock.Setup(x => x.Play())
                .Returns(() => 1);
            var game = new Game(new List<Player>() { player }, randomEngineMock.Object);
            game.Play();
            Assert.IsTrue(player.Alive);
        }

        [TestMethod]
        public void TestGameEndAfterThreeIteration()
        {
            var player = new Player(-2);
            // var moveEngine = new DeterministEngine();
            var randomEngineMock = new Mock<IMoveEngine>();

            randomEngineMock.Setup(x => x.Play())
                .Returns(() => 1);

            var game = new Game(new List<Player>() { player }, randomEngineMock.Object);
            
            for (int i = 0; i < 3; i++)
            {
                game.Play();
            }

           Assert.IsTrue(game.IsOver);
        }
    }
}
