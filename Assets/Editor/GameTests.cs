using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Libs.Logic.Interfaces.Player;
using Assets.Libs.Logic.Interfaces.Managers;
using Assets.Libs.Logic.Player;
using Assets.Libs.Logic.Managers;
using AssemblyCSharp.Assets.Libs.Logic.Managers;

public class GameTests
{

    #region Test Resolve Logic
    [Test]
    public void CheckRockAndPaperRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterRock();
        secondInputManager.RegisterPaper();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Lose);
    }

    [Test]
    public void CheckRockAndScissorsRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterRock();
        secondInputManager.RegisterScissors();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Win);
    }

    [Test]
    public void CheckRockAndRockRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterRock();
        secondInputManager.RegisterRock();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Draw);
    }

    [Test]
    public void CheckPaperAndPaperRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterPaper();
        secondInputManager.RegisterPaper();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Draw);
    }

    [Test]
    public void CheckPaperAndScissorsRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterPaper();
        secondInputManager.RegisterScissors();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Lose);
    }

    [Test]
    public void CheckPaperAndRockRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterPaper();
        secondInputManager.RegisterRock();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Win);
    }

    [Test]
    public void CheckScissorsAndPaperRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterScissors();
        secondInputManager.RegisterPaper();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Win);
    }

    [Test]
    public void CheckScissorsAndScissorsRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterScissors();
        secondInputManager.RegisterScissors();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Draw);
    }

    [Test]
    public void CheckScissorsAndRockRoundResult()
    {
        //Arrange
        IPlayerInput firstInputManager = new PlayerInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IPlayerInput secondInputManager = new PlayerInputManager();
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        firstInputManager.RegisterScissors();
        secondInputManager.RegisterRock();
        gameManager.ResolveRound();

        //Assert
        Assert.AreEqual(gameManager.LastRoundResult, RoundResultType.Lose);
    }
    #endregion

    #region Test Cheat AI

    [Test]
    public void AiCheaterAlwaysWin()
    {
        //Arrange
        IInput firstInputManager = new HonestAiInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IInput secondInputManager = new CheatInputManager(firstPlayer, 1f);
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        for (int i = 0; i < 1000; i++)
        {
			gameManager.ResolveRound();
        }

        //Assert
        Assert.AreEqual(gameManager.AIPlayer.Score, 1000);
    }

    [Test]
    public void AiCheaterAlwaysLose()
    {
        //Arrange
        IInput firstInputManager = new HonestAiInputManager();
        IPlayer firstPlayer = new Player(firstInputManager);

        IInput secondInputManager = new CheatInputManager(firstPlayer, 0f);
        IPlayer secondPlayer = new Player(secondInputManager);

        IGameManager gameManager = new GameManager(firstPlayer, secondPlayer);

        //Act
        for (int i = 0; i < 1000; i++)
        {
            gameManager.ResolveRound();
        }

        //Assert
        Assert.AreEqual(gameManager.AIPlayer.Score, 0);
    }

    #endregion
}
