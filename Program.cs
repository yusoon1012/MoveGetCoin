using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0613
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[15,15];
            int pos_X;
            int pos_Y;
            int coinPos_X;
            int coinPos_Y;
            int userInput_Size;
            const int PLAYER_POS = 50;
            const int COIN_POS = 30;
            const int ROCK_POS = 40;
            string inputStr=string.Empty;
            char userCharInput = '0';
            Random rnd=new Random();
            int getCoin = 0;
            const int WALL_POS = 60;
            int turnCount = 0;
            int ranDomTurn = 0;
            int rockPos_X = 3;
            int rockPos_Y = 3;

            Console.WriteLine("크기를 입력해 주세요 (5~15) : ");
            while(true) 
            {
            inputStr = Console.ReadLine();
            userInput_Size = (int.Parse(inputStr));
                pos_X = userInput_Size / 2 ;
                pos_Y=userInput_Size/ 2;
                if (userInput_Size > 15 || userInput_Size < 5)
                {
                    Console.WriteLine("값이 잘못되었습니다. 다시입력해주세요.");
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            coinPos_X = rnd.Next(userInput_Size-1);
            coinPos_Y= rnd.Next(userInput_Size - 1);
           
            while(true)
            {
                CursorPosition(0, 0);
                switch (userCharInput)
                {
                    case 'w':
                        if(pos_Y>0)
                            if(pos_Y-1==rockPos_Y&&rockPos_Y==0 && pos_X == rockPos_X)
                            {
                                break;
                            }
                            else 
                            {
                            pos_Y -= 1;

                            }
                        {
                            if(pos_Y==rockPos_Y&&rockPos_Y>0&&pos_X==rockPos_X)
                            {
                                rockPos_Y -= 1;
                            }
                        }
                            turnCount += 1;
                        break;
                    case 's':
                        if(pos_Y<userInput_Size-1)
                        {
                            if (pos_Y + 1 == rockPos_Y && rockPos_Y == userInput_Size-1&&pos_X==rockPos_X)
                            {
                                break;
                            }
                            else
                            {
                                pos_Y += 1;

                            }
                            {
                                if (pos_Y == rockPos_Y && rockPos_Y < userInput_Size&&pos_X==rockPos_X)
                                {
                                Thread.Sleep(50);

                                    rockPos_Y += 1;
                                }
                            }
                           
                        }
                                    turnCount += 1;
                        break;
                    case 'a':
                        if (pos_X > 0)
                        {
                            if (pos_X - 1 == rockPos_X && rockPos_X == 0 && pos_Y == rockPos_Y)
                            {
                                break;
                            }
                            else
                            {
                                pos_X -= 1;

                            }
                            if (pos_X == rockPos_X && rockPos_X > 0 && pos_Y == rockPos_Y)
                            {
                                Thread.Sleep(50);

                                rockPos_X -= 1;
                            }
                        }
                                turnCount += 1;
                        
                        break;
                    case 'd':
                        if(pos_X<userInput_Size-1)
                        {
                            if (pos_X + 1 == rockPos_X && rockPos_X == userInput_Size-1 && pos_Y == rockPos_Y)
                            {
                                break;
                            }
                            else
                            {
                                pos_X += 1;

                            }
                            if (pos_X == rockPos_X && rockPos_X < userInput_Size && pos_Y == rockPos_Y)
                            {
                                Thread.Sleep(50);
                                rockPos_X += 1;
                            }
                        }
                                turnCount += 1;
                        break;
                    default:
                        break;
                }
                for (int y = 0; y < userInput_Size; y++)
                {
                    for (int x = 0; x < userInput_Size; x++)
                    {

                        if (y == pos_Y && x == pos_X)
                        {
                            board[y, x] = PLAYER_POS;
                        }
                        else if (y == coinPos_Y && x == coinPos_X)
                        {

                            board[y, x] = COIN_POS;

                        }
                        else if(y==rockPos_Y&&x==rockPos_X)
                        {
                            board[y,x] = ROCK_POS;
                        }
                        else
                        {
                            board[y, x] = 0;
                        }
                        if (board[y, x] == PLAYER_POS)
                        {
                            Console.Write("0 ");
                        }
                        else if (board[y, x] == COIN_POS)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("@ ");
                            
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[y,x]==ROCK_POS)
                        {
                            Console.Write("$ ");
                        }
                        else
                        {
                            Console.Write("* ");

                        }
                    }
                    Console.WriteLine();
                }
                if (pos_X==coinPos_X&&pos_Y==coinPos_Y)
                {
                    while(pos_X==coinPos_X && pos_Y == coinPos_Y) 
                    {
                    coinPos_X = rnd.Next(userInput_Size);
                    coinPos_Y = rnd.Next(userInput_Size);

                    }
                        
                    getCoin += 1;
                }
                if(turnCount> ranDomTurn)
                {
                    coinPos_X = rnd.Next(userInput_Size);
                    coinPos_Y = rnd.Next(userInput_Size);
                    ranDomTurn=rnd.Next(userInput_Size-1,userInput_Size+2);
                    turnCount = 0;
                }
                CursorPosition(0, 0);
                for (int y = 0; y < userInput_Size; y++)
                {
                    for (int x = 0; x < userInput_Size; x++)
                    {

                        if (y == pos_Y && x == pos_X)
                        {
                            board[y, x] = PLAYER_POS;
                        }
                        else if (y == coinPos_Y && x == coinPos_X)
                        {

                            board[y, x] = COIN_POS;

                        }
                        else if (y == rockPos_Y && x == rockPos_X)
                        {
                            board[y, x] = ROCK_POS;
                        }
                        else
                        {
                            board[y, x] = 0;
                        }
                        if (board[y, x] == PLAYER_POS)
                        {
                            Console.Write("0 ");
                        }
                        else if (board[y, x] == COIN_POS)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("@ ");

                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[y, x] == ROCK_POS)
                        {
                            Console.Write("$ ");
                        }
                        else
                        {
                            Console.Write("* ");

                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("획득한 코인 : {0}개 클리어까지 남은코인 : {1}개",getCoin,15-getCoin);

               if (getCoin == 15)
                {
                    break;
                }
                     CursorPosition(userInput_Size + 2, userInput_Size + 2);
                    ConsoleKeyInfo userKeyInput = Console.ReadKey();
                    userCharInput=userKeyInput.KeyChar;

            }
            Console.WriteLine("===========================");
            Console.WriteLine("        C L E A R");
            Console.WriteLine("===========================");

            Thread.Sleep(1000);



        }
        static void CursorPosition(int x, int y) 
        {
            Console.SetCursorPosition(x, y);

             }
        static void Coin()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("◎");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
