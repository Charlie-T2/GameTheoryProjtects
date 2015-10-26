﻿using System;
using MiniMax.Interface;
using TicTacToe.Interface;

namespace TicTacToe.TicTacToeGameElement
{
  public class TicTacToeGame 
  {
    public TicTacTocState GameState { get; set; }
    public ITicTacToePlayer PlayerA { get; private set; }
    public ITicTacToePlayer PlayerB { get; private set; }


    public TicTacToeGame(int size)
    {
      GameState = new TicTacTocState(size);

      var tokenX = new Token(0, 'X');
      PlayerA = new HumanPlayer(tokenX, 1);

      var tokenY = new Token(1, 'Y');
      PlayerB = new IAPlayer(tokenY, 1);
    }

    public void Play()
    {
      ITicTacToePlayer currentPlayer = PlayerA;

      while (!GameState.IsGameOver)
      {
        GameState.Display();
        bool isMoveValid = false;
        do
        {
          var move = currentPlayer.GetMove(this);
          isMoveValid = GameState.PlayMove(move);
        } while (!isMoveValid);


        currentPlayer = currentPlayer == PlayerA ? PlayerB : PlayerA;
      }
      Console.WriteLine("\n\n\n*************** Game Over **************");
      GameState.Display();
    }
  }
}