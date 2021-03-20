using DraughtsGameAPIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DraughtsGameAPIService.Helpers
{
    public class FindMove
    {
        public static List<NextMove> FindAvailableMoves(int[,] board, int player)
        {
            List<NextMove> results = new List<NextMove>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // Skip over pieces that cant be player
                for (int j = 1 - (i % 2); j < board.GetLength(1); j += 2)
                {
                    int piece = board[i, j];
                    if (piece == 1 && player == 1)
                    {
                        if (CheckMove.checkMoveUpLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j - 1
                            });
                        }
                        if (CheckMove.checkMoveUpRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j + 1
                            });
                        }

                        Tree resultTree = CheckMove.checkTakeUp(board, i, j, new int[] { 2 }, new Tree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                        }));
                        if (resultTree.Left != null || resultTree.Right != null)
                        {
                            List<List<TreeTake>> treeArray = Tree.TreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                    else if (piece == 2 && player == 2)
                    {
                        if (CheckMove.checkMoveDownLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j - 1
                            });
                        }
                        if (CheckMove.checkMoveDownRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j + 1
                            });
                        }

                        Tree resultTree = CheckMove.checkTakeDown(board, i, j, new int[] { 1 }, new Tree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                        }));
                        if (resultTree.Left != null || resultTree.Right != null)
                        {
                            List<List<TreeTake>> treeArray = Tree.TreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                    else if ((piece == 3 && player == 1) || (piece == 4 && player == 2))
                    {
                        if (CheckMove.checkMoveUpLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j - 1
                            });
                        }
                        if (CheckMove.checkMoveUpRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j + 1
                            });
                        }
                        if (CheckMove.checkMoveDownLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j - 1
                            });
                        }
                        if (CheckMove.checkMoveDownRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j + 1
                            });
                        }

                        int[] countersToTake = piece == 3 ? new int[] { 2, 4 } : new int[] { 1, 3 };
                        KingTree resultTree = CheckMove.checkKingTake(board, i, j, i, j, countersToTake, new KingTree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                        }));
                        if (resultTree.DownLeft != null || resultTree.DownRight != null || resultTree.UpLeft != null || resultTree.UpRight != null)
                        {
                            List<List<TreeTake>> treeArray = KingTree.KingTreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                }
            }

            return results;
        }

        public static List<NextMove> FindAvailableMoves(int[,] board)
        {
            List<NextMove> results = new List<NextMove>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // Skip over pieces that cant be player
                for (int j = 1 - (i % 2); j < board.GetLength(1); j += 2)
                {
                    int piece = board[i, j];
                    if (piece == 1)
                    {
                        if (CheckMove.checkMoveUpLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j - 1,
                                Piece = 1
                            });
                        }
                        if (CheckMove.checkMoveUpRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j + 1,
                                Piece = 1
                            });
                        }

                        Tree resultTree = CheckMove.checkTakeUp(board, i, j, new int[] { 2 }, new Tree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                            Piece = 1
                        }));
                        if (resultTree.Left != null || resultTree.Right != null)
                        {
                            List<List<TreeTake>> treeArray = Tree.TreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                    else if (piece == 2)
                    {
                        if (CheckMove.checkMoveDownLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j - 1,
                                Piece = 2
                            });
                        }
                        if (CheckMove.checkMoveDownRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j + 1,
                                Piece = 2
                            });
                        }

                        Tree resultTree = CheckMove.checkTakeDown(board, i, j, new int[] { 1 }, new Tree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                            Piece = 2

                        }));
                        if (resultTree.Left != null || resultTree.Right != null)
                        {
                            List<List<TreeTake>> treeArray = Tree.TreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                    else if ((piece == 3) || (piece == 4))
                    {
                        if (CheckMove.checkMoveUpLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j - 1,
                                Piece = piece == 3 ? 1 : 2
                            });
                        }
                        if (CheckMove.checkMoveUpRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i - 1,
                                NextWidth = j + 1,
                                Piece = piece == 3 ? 1 : 2
                            });
                        }
                        if (CheckMove.checkMoveDownLeft(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j - 1,
                                Piece = piece == 3 ? 1 : 2
                            });
                        }
                        if (CheckMove.checkMoveDownRight(board, i, j))
                        {
                            results.Add(new NextMove
                            {
                                CurrentHeight = i,
                                CurrentWidth = j,
                                NextHeight = i + 1,
                                NextWidth = j + 1,
                                Piece = piece == 3 ? 1 : 2
                            });
                        }

                        int[] countersToTake = piece == 3 ? new int[] { 2, 4 } : new int[] { 1, 3 };
                        KingTree resultTree = CheckMove.checkKingTake(board, i, j, i, j, countersToTake, new KingTree(new TreeTake
                        {
                            CurrentHeight = i,
                            CurrentWidth = j,
                            Piece = piece == 3 ? 1 : 2
                        }));
                        if (resultTree.DownLeft != null || resultTree.DownRight != null || resultTree.UpLeft != null || resultTree.UpRight != null)
                        {
                            List<List<TreeTake>> treeArray = KingTree.KingTreeToArray(resultTree);
                            results.AddRange(ProcessTreeArray(treeArray));
                        }
                    }
                }
            }

            return results;
        }

        public static List<NextMove> ProcessTreeArray(List<List<TreeTake>> treeArray)
        {
            List<NextMove> takeMoves = new List<NextMove>();

            foreach(List<TreeTake> takes in treeArray)
            {
                takeMoves.AddRange(processTakeMove(takes));
            }

            return takeMoves;
        }

        public static List<NextMove> processTakeMove(List<TreeTake> takeMoves)
        {
            List<NextMove> results = new List<NextMove>();

            List<Take> takes = new List<Take>();

            foreach(TreeTake take in takeMoves.Skip(1))
            {
                takes.Add(new Take
                {
                    Height = take.TakeHeight,
                    Width = take.TakeWidth
                });

                results.Add(new NextMove
                {
                    CurrentHeight = takeMoves[0].CurrentHeight,
                    CurrentWidth = takeMoves[0].CurrentWidth,
                    NextHeight = take.NextHeight,
                    NextWidth = take.NextWidth,
                    Takes = takes,
                    Piece = takeMoves[0].Piece
                });
            }

            return results;
        }
    }
}
