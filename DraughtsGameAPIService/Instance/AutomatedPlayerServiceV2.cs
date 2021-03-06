using DraughtsGameAPIModels;
using DraughtsGameAPIModels.Service;
using DraughtsGameAPIService.Helpers;
using DraughtsGameAPIService.Instance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DraughtsGameAPIService.Interface
{
    public class AutomatedPlayerServiceV2 : IAutomatedPlayerService
    {
        public NextMove GetNextMoveForAutomatedPlayer(GetNextMove getNextMove)
        {
            MinimaxOutcome result = minimax(getNextMove.Board, getNextMove.Depth, true);

            return new NextMove
            {
                CurrentHeight = result.Board.CurrentHeight,
                CurrentWidth = result.Board.CurrentWidth,
                NextHeight = result.Board.NextHeight,
                NextWidth = result.Board.NextWidth,
                Takes = result.Board.Takes
            };
        }

        public MinimaxOutcome minimax (int[,] board, int depth, bool minOrMax)
        {
            if (depth == 0)
            {
                return new MinimaxOutcome
                {
                    Evaluation = evaluate(board)
                };
            }

            if (minOrMax)
            {
                int maxEval = -1000;
                AvailableBoard bestMove = null;
                List<AvailableBoard> player2MovesBoards = GetAvailableBoards(board, 2);
                foreach (AvailableBoard player2MovesBoard in player2MovesBoards)
                {
                    MinimaxOutcome evaluation = minimax(player2MovesBoard.Board, depth - 1, false);
                    maxEval = Math.Max(maxEval, evaluation.Evaluation);
                    if (maxEval == evaluation.Evaluation)
                    {
                        bestMove = player2MovesBoard;
                    }
                }

                return new MinimaxOutcome
                {
                    Board = bestMove,
                    Evaluation = maxEval
                };
            }
            else
            {
                int minEval = 1000;
                AvailableBoard bestMove = null;
                List<AvailableBoard> player1MovesBoards = GetAvailableBoards(board, 1);
                foreach (AvailableBoard player1MovesBoard in player1MovesBoards)
                {
                    MinimaxOutcome evaluation = minimax(player1MovesBoard.Board, depth - 1, true);
                    minEval = Math.Min(minEval, evaluation.Evaluation);
                    if (minEval == evaluation.Evaluation)
                    {
                        bestMove = player1MovesBoard;
                    }
                }

                return new MinimaxOutcome
                {
                    Board = bestMove,
                    Evaluation = minEval
                };
            }
        }

        private List<AvailableBoard> GetAvailableBoards(int[,] board, int player)
        {
            List<AvailableBoard> results = new List<AvailableBoard>();

            List<NextMove> moves = FindMove.FindAvailableMoves(board, player);

            foreach (NextMove move in moves)
            {
                //Copy board
                int[,] moveBoard = (int[,])board.Clone();

                //Remove taken pieces form the board
                if (move.Takes != null)
                {
                    foreach (Take take in move.Takes)
                    {
                        moveBoard[take.Height, take.Width] = 5;
                    }
                }

                //Add kings
                if (player == 1 && move.NextHeight == 0)
                {
                    moveBoard[move.CurrentHeight, move.CurrentWidth] = 5;
                    moveBoard[move.NextHeight, move.NextWidth] = 3;
                }
                else if (player == 2 && move.NextHeight == 7)
                {
                    moveBoard[move.CurrentHeight, move.CurrentWidth] = 5;
                    moveBoard[move.NextHeight, move.NextWidth] = 4;
                }
                else
                {
                    int tempValue = moveBoard[move.CurrentHeight, move.CurrentWidth];
                    moveBoard[move.CurrentHeight, move.CurrentWidth] = 5;
                    moveBoard[move.NextHeight, move.NextWidth] = tempValue;
                }

                results.Add(new AvailableBoard
                {
                    Board = moveBoard,
                    CurrentHeight = move.CurrentHeight,
                    CurrentWidth = move.CurrentWidth,
                    NextHeight = move.NextHeight,
                    NextWidth = move.NextWidth,
                    Takes = move.Takes
                });
            }

            return results;
        }

        private int evaluate(int[,] board)
        {
            int player1Counter = 0;
            int player2Counter = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 1 - (i % 2); j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        player1Counter++; ;
                    }
                    else if (board[i, j] == 2)
                    {
                        player2Counter++; ;
                    }
                    else if (board[i, j] == 3)
                    {
                        player1Counter = player1Counter + 2;
                    }
                    else if (board[i, j] == 4)
                    {
                        player2Counter = player2Counter + 2;
                    }
                }
            }

            return player2Counter - player1Counter;
        }
    }
}
