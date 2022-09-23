using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Threading;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using System.Data;

namespace ChessOnline
{
    public partial class White_O : Window
    {
        DataTable dt = new DataTable();

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "BRP2Q67vJAB0bKphB3ImXOYA8h01ar64w2bUlVVa",
            BasePath = "https://chess-db-d7706-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        public int[,] board = new int[8, 8]

           {
            {-2,-3,-4,-5,-6,-4,-3,-2 },
            {-1,-1,-1,-1,-1,-1,-1,-1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 3, 4, 5, 6, 4, 3, 2 },

            //{-2, 0, 0, 0,-6, 0, 0, 0 },
            //{-1,-1,-1,-1,-1,-1, 2,-1 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 1, 1, 1, 1, 1, 1, 1, -2 },
            //{ 2, 0, 0, 0, 6, 0, 0, 2},

            // { 0, 0, 0, 0, 6, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, -5, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0 },
            // { 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, -6, 0, 0, 0 },
           };
        public int[] Click1 = { 1, 1 };
        bool Click1Made = false;
        bool FigrAreSelect = false;
        int fromWhere = 1;
        int fromWhere1 = 1;
        int whereTo = -1;
        int whereTo1 = -1;
        int SuperPawn0 = -1;
        string save_bd_board = "";
        SetMove obj = new SetMove();


        //static AutoResetEvent eventAReady ;
        int firstRun = 1;

        public bool? turnMove = true;

        BitmapImage Img_W_King = new BitmapImage(new Uri(@"image\KingWHITE.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_W_Queen = new BitmapImage(new Uri(@"image\QueenWHITE.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_W_Bishop = new BitmapImage(new Uri(@"image\BishopWHITE.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_W_Knight = new BitmapImage(new Uri(@"image\KnightWHITE.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_W_Rook = new BitmapImage(new Uri(@"image\RookWHITE.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_W_Pawn = new BitmapImage(new Uri(@"image\PawnWHITE.png", UriKind.RelativeOrAbsolute));

        BitmapImage Img_B_King = new BitmapImage(new Uri(@"image\KingBLACK.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_Queen = new BitmapImage(new Uri(@"image\QueenBLACK.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_Bishop = new BitmapImage(new Uri(@"image\BishopBLACK.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_Knight = new BitmapImage(new Uri(@"image\KnightBLACK.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_Rook = new BitmapImage(new Uri(@"image\RookBLACK.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_Pawn = new BitmapImage(new Uri(@"image\PawnBLACK.png", UriKind.RelativeOrAbsolute));

        BitmapImage Img_W_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));
        BitmapImage Img_B_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));

        //BitmapImage Img_B_Rook =  new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));


        public White_O()
        {


            InitializeComponent();
            LiveCall();
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]);
            draw();
            client = new FireSharp.FirebaseClient(config);
            if (firstRun == 1) { SetMoveTurnBD(); firstRun = 0; }
            dt.Columns.Add("login");
            dt.Columns.Add("password");


            //string r = "";

            //SetOpBoard();
            //GetOpBoard();


            //r = ArrayToString(board_test);

        }

        //public int[,] board2 = new int[8, 8]

        //   {
        //    //{-2,-3,-4,-5,-6,-4,-3,-2 },
        //    //{-1,-1,-1,-1,-1,-1,-1,-1 },
        //    //{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    //{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    //{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    //{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    //{ 1, 1, 1, 1, 1, 1, 1, 1 },
        //    //{ 2, 3, 4, 5, 6, 4, 3, 2 },

        //    ////{-2, 0, 0, 0,-6, 0, 0, 0 },
        //    ////{-1,-1,-1,-1,-1,-1, 2,-1 },
        //    ////{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    ////{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    ////{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    ////{ 0, 0, 0, 0, 0, 0, 0, 0 },
        //    ////{ 1, 1, 1, 1, 1, 1, 1, -2 },
        //    ////{ 2, 0, 0, 0, 6, 0, 0, 2},

        //     { 0, 0, 0, 0, 6, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, -5, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0 },
        //     { 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, -6, 0, 0, 0 },
        //   };

        async void LiveCall()
        {
            while (true)
            {
                await Task.Delay(1000);
                //FirebaseResponse res = await client.GetTaskAsync(@"/MoveData/0/Move");
                //string data = res.Body.ToString();
                ////UpdateRTB(data);
                //WhatGet.Text = data.ToString();
                //save_bd_board = data.ToString();
                //Array.Copy(getMove(save_bd_board), board, board.Length);
                FirebaseResponse response2 = await client.GetTaskAsync("MoveData/0/");
                SetMove obj = response2.ResultAs<SetMove>();

                save_bd_board = obj.Move;
                Array.Copy(getMove(save_bd_board), board, board.Length);
                draw();
            }
        }
        async void SetOpBoard()
        {

            var data = new SetMove
            {
                ID = "0",
                Move = ArrayToString(board),
            };
            SetResponse response = await client.SetTaskAsync("MoveData/" + data.ID, data);
            SetMove result = response.ResultAs<SetMove>();
            turnMove = null;
            
        }

        async void GetOpBoard()
        {
            //var data = new SetMove
            //{
            //    White = "0",
            //    Black = "1",
            //};


            //SetResponse response = await client.SetTaskAsync("Game/", data);
            //SetMove result = response.ResultAs<SetMove>();

            FirebaseResponse response2 = await client.GetTaskAsync("MoveData/0/");
            SetMove obj = response2.ResultAs<SetMove>();

            save_bd_board = obj.Move;
            Array.Copy(getMove(save_bd_board), board, board.Length);


            draw();

        }

        async void SetMoveTurnBD()
        {
            var data = new SetMove
            {
                White = "0",
                Black = "1",
            };


            SetResponse response = await client.SetTaskAsync("Game/", data);
            SetMove result = response.ResultAs<SetMove>();


        }
        async void OponentMadeMove1(int[,] board)
        {

            FirebaseResponse response = await client.GetTaskAsync("Game/");
            SetMove obj = response.ResultAs<SetMove>();

            //MessageBox.Show(obj.White);
            //System.();
           // eventAReady.Set();
            MoveT.Text += obj.White + "\n";

            if (obj.White == "1")
            {
                //int x = 50;
                turnMove = true;
                //MessageBox.Show(obj.White);
                //eventAReady.Set();

                GetOpBoard();
            }
            else { OponentMadeMove1(this.board); }
        }
        string ArrayToString(int[,] board)
        {
            string x = "";
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {

                    //MessageBox.Show("work");
                    x = x + board[i, j].ToString();
                }
                //x = x + "\n"; 
            }
            return x;
        }

        int[,] getMove(string x)
        {
            //MessageBox.Show(x.Length.ToString());

            int[,] board2 = new int[8, 8];
            for (int s = 0; s <= 63; s += 0)
            {
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        //MessageBox.Show(j.ToString());
                        //MessageBox.Show("work");
                        if (x[s].ToString() == "-") { s++; board2[i, j] = int.Parse(x[s].ToString()) * -1; }

                        else
                            board2[i, j] = int.Parse(x[s].ToString());
                        //MessageBox.Show(int.Parse(x[55].ToString()).ToString());
                        //if (x[s].ToString() == "-") MessageBox.Show(x[s].ToString());
                        //MessageBox.Show(s.ToString());
                        s++;
                    }
                    //x = x + "\n"; 
                }
            }
            return board2;
        }
        //int[,] getMove(string x)
        //{
        //    return ;
        //}

        public void testPos(string i, string j)
        {
            //test.ItemsSource =  i + j;
        }
        public void testItem(int i, int j)
        {
            //test2.ItemsSource = board[i,j].ToString();
            //test3.ItemsSource = Click1Made.ToString();

        }



        BitmapImage drawByNum(int i)
        {
            switch (i)
            {
                case 1: return Img_W_Pawn;
                case 2: return Img_W_Rook;
                case 3: return Img_W_Knight;
                case 4: return Img_W_Bishop;
                case 5: return Img_W_Queen;
                case 6: return Img_W_King;

                case 7: return Img_W_SuperPawn;

                case -1: return Img_B_Pawn;
                case -2: return Img_B_Rook;
                case -3: return Img_B_Knight;
                case -4: return Img_B_Bishop;
                case -5: return Img_B_Queen;
                case -6: return Img_B_King;

                case -7: return Img_B_SuperPawn;
                default: return null;
            }
        }
        void draw()
        {

            a8.Source = drawByNum(board[0, 0]); b8.Source = drawByNum(board[0, 1]); c8.Source = drawByNum(board[0, 2]); d8.Source = drawByNum(board[0, 3]); e8.Source = drawByNum(board[0, 4]); f8.Source = drawByNum(board[0, 5]); g8.Source = drawByNum(board[0, 6]); h8.Source = drawByNum(board[0, 7]);
            a7.Source = drawByNum(board[1, 0]); b7.Source = drawByNum(board[1, 1]); c7.Source = drawByNum(board[1, 2]); d7.Source = drawByNum(board[1, 3]); e7.Source = drawByNum(board[1, 4]); f7.Source = drawByNum(board[1, 5]); g7.Source = drawByNum(board[1, 6]); h7.Source = drawByNum(board[1, 7]);
            a6.Source = drawByNum(board[2, 0]); b6.Source = drawByNum(board[2, 1]); c6.Source = drawByNum(board[2, 2]); d6.Source = drawByNum(board[2, 3]); e6.Source = drawByNum(board[2, 4]); f6.Source = drawByNum(board[2, 5]); g6.Source = drawByNum(board[2, 6]); h6.Source = drawByNum(board[2, 7]);
            a5.Source = drawByNum(board[3, 0]); b5.Source = drawByNum(board[3, 1]); c5.Source = drawByNum(board[3, 2]); d5.Source = drawByNum(board[3, 3]); e5.Source = drawByNum(board[3, 4]); f5.Source = drawByNum(board[3, 5]); g5.Source = drawByNum(board[3, 6]); h5.Source = drawByNum(board[3, 7]);
            a4.Source = drawByNum(board[4, 0]); b4.Source = drawByNum(board[4, 1]); c4.Source = drawByNum(board[4, 2]); d4.Source = drawByNum(board[4, 3]); e4.Source = drawByNum(board[4, 4]); f4.Source = drawByNum(board[4, 5]); g4.Source = drawByNum(board[4, 6]); h4.Source = drawByNum(board[4, 7]);
            a3.Source = drawByNum(board[5, 0]); b3.Source = drawByNum(board[5, 1]); c3.Source = drawByNum(board[5, 2]); d3.Source = drawByNum(board[5, 3]); e3.Source = drawByNum(board[5, 4]); f3.Source = drawByNum(board[5, 5]); g3.Source = drawByNum(board[5, 6]); h3.Source = drawByNum(board[5, 7]);
            a2.Source = drawByNum(board[6, 0]); b2.Source = drawByNum(board[6, 1]); c2.Source = drawByNum(board[6, 2]); d2.Source = drawByNum(board[6, 3]); e2.Source = drawByNum(board[6, 4]); f2.Source = drawByNum(board[6, 5]); g2.Source = drawByNum(board[6, 6]); h2.Source = drawByNum(board[6, 7]);
            a1.Source = drawByNum(board[7, 0]); b1.Source = drawByNum(board[7, 1]); c1.Source = drawByNum(board[7, 2]); d1.Source = drawByNum(board[7, 3]); e1.Source = drawByNum(board[7, 4]); f1.Source = drawByNum(board[7, 5]); g1.Source = drawByNum(board[7, 6]); h1.Source = drawByNum(board[7, 7]);
            for (int i = 0; i <= 7; i++)
            {
                if (board[0, i] == 1)
                {
                    SuperPawnW(i);
                }
            }
            for (int i = 0; i <= 7; i++)
            {
                if (board[7, i] == -1)
                {
                    SuperPawnB(i);
                }
            }
        }

        void SuperPawnW(int i)
        {
            t1.Visibility = b3.Visibility;
            t2.Visibility = b3.Visibility;
            t3.Visibility = b3.Visibility;
            t4.Visibility = b3.Visibility;
            SuperPawn0 = i;
            turnMove = null;
            //MessageBox.Show("wadawd");
            //while (true) { if (t1.Visibility != b3.Visibility) break; };
            //if (t1.Visibility == b3.Visibility)
            //{

            //    SuperPawnW(i);

            //}

        }
        void SuperPawnB(int i)
        {
            t1b.Visibility = b3.Visibility;
            t2b.Visibility = b3.Visibility;
            t3b.Visibility = b3.Visibility;
            t4b.Visibility = b3.Visibility;
            SuperPawn0 = i;
            turnMove = null;
            //SuperPawnB(i);

        }
        int selFigr(int i)
        {
            if (turnMove == true)
                switch (i)
                {
                    case 1: return Move.Move_PawnW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 2: return Move.Move_RookW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 3: return Move.Move_KnightW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 4: return Move.Move_BishopW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 5: return Move.Move_QueenW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 6: return King_Move.Move_KingW(board, fromWhere1, fromWhere, whereTo1, whereTo);

                    default: /*test3.ItemsSource = "LOOOOOL";*/ return 0;
                }

            //if (turnMove == false)
            //    switch (i)
            //    {
            //        case -1: return Move.Move_PawnB(board, fromWhere1, fromWhere, whereTo1, whereTo);
            //        case -2: return Move.Move_RookB(board, fromWhere1, fromWhere, whereTo1, whereTo);
            //        case -3: return Move.Move_KnightB(board, fromWhere1, fromWhere, whereTo1, whereTo);
            //        case -4: return Move.Move_BishopB(board, fromWhere1, fromWhere, whereTo1, whereTo);
            //        case -5: return Move.Move_QueenB(board, fromWhere1, fromWhere, whereTo1, whereTo);
            //        case -6: return King_Move.Move_KingB(board, fromWhere1, fromWhere, whereTo1, whereTo);

            //        default: /*test3.ItemsSource = "LOOOOOL";*/ return 0;
            //    }
            return 0;
        }
        void OnClick() // коли я це написав як це працювало знав я і бог, тепер знає тільки бог. 
        {
            
            //test5.ItemsSource = King_Move.right_towerW_first_move.ToString();
            //test6.ItemsSource = King_Move.left_towerW_first_move.ToString();
            //int[,] board_save = board;
            if (Click1Made)
            {
                fromWhere = Click1[0];
                fromWhere1 = Click1[1];
                FigrAreSelect = true;
            }
            if (!Click1Made)
            {
                whereTo = Click1[0];
                whereTo1 = Click1[1];


                if ((selFigr(board[fromWhere, fromWhere1]) == 1) || (selFigr(board[fromWhere, fromWhere1]) == 2 || (selFigr(board[fromWhere, fromWhere1]) == 3)))
                {

                    if (selFigr(board[fromWhere, fromWhere1]) == 2)
                    {
                        if ((board[fromWhere, fromWhere1] == -1))
                        {
                            board[4, Move.en_passantW] = 0;
                        }
                        if ((board[fromWhere, fromWhere1] == 1))
                        {
                            board[3, Move.en_passantB] = 0;
                        }
                    }
                    if (selFigr(board[fromWhere, fromWhere1]) == 3)
                    {
                        if ((board[fromWhere, fromWhere1] == 1))
                        {
                            Move.en_passantW = fromWhere1;
                        }
                        else Move.en_passantW = -1;
                        if ((board[fromWhere, fromWhere1] == -1))
                        {
                            Move.en_passantB = fromWhere1;
                        }
                        else Move.en_passantB = -1;
                    }
                    else { Move.en_passantB = -1; Move.en_passantW = -1; }


                    int[,] board_save = new int[8, 8];

                    Array.Copy(board, board_save, board.Length);
                    int temp = board[whereTo, whereTo1];
                    int temp2 = board[fromWhere, fromWhere1];

                    board[whereTo, whereTo1] = board[fromWhere, fromWhere1];
                    if (temp != board[fromWhere, fromWhere1]) board[fromWhere, fromWhere1] = 0;



                    if (turnMove == true)
                    {
                        if (King_Move.Checkforwhite(board) == 1)
                        {
                            Array.Copy(board_save, board, board.Length);
                            turnMove = !turnMove;

                        }
                    }
                    if (turnMove == false)
                    {
                        if (King_Move.Checkforblack(board) == 1)
                        {
                            Array.Copy(board_save, board, board.Length);
                            turnMove = !turnMove;
                        }
                    }
                    King_Move.Checkforblack(board);
                    King_Move.Checkforwhite(board);
                    for (int i = 0; i <= 7; i++)
                    {
                        if (board[0, i] == 1)
                        {
                            SuperPawnW(i);
                        }
                    }
                    for (int i = 0; i <= 7; i++)
                    {
                        if (board[7, i] == -1)
                        {
                            SuperPawnB(i);
                        }
                    }
                    draw();
                    //if (temp2 > 0) turnMove = false;
                    //if (temp2 < 0) turnMove = true;

                    turnMove = !turnMove;

                    Array.Copy(board, board_save, board.Length);

                    if (turnMove == true)
                    {
                        if (MateAndStaleMateCheckW(board) > 0)
                        {
                            MatchRez on = new MatchRez(2, MateAndStaleMateCheckW(board)); on.ShowDialog();
                            this.Close();
                        }
                    } /*MessageBox.Show(MateAndStaleMateCheckW(board).ToString() + " MateWif1");*/
                    if (turnMove == false)
                    {
                        if (MateAndStaleMateCheckB(board) > 0)
                        {
                            MatchRez on = new MatchRez(1, MateAndStaleMateCheckB(board)); on.ShowDialog();
                            this.Close();
                        }
                    }
                    // MessageBox.Show(MateAndStaleMateCheckB(board).ToString() + " MateBif1");
                    Array.Copy(board_save, board, board.Length);
                    //MessageBox.Show("uyhujkhj");
                    if (t1.Visibility != b3.Visibility)
                    {
                        
                        SetMoveTurnBD();
                        
                        OponentMadeMove1(board);
                        SetOpBoard();

                    }
                    //test4.ItemsSource = turnMove.ToString();
                }
            }

            wm.Text = turnMove.ToString();
        }

        int leagalMove(int[,] board, int fromWhere1, int fromWhere, int whereTo1, int whereTo)
        {
            int[,] board_save = new int[8, 8];

            Array.Copy(board, board_save, board.Length);
            int temp = board[whereTo, whereTo1];
            int temp2 = board[fromWhere, fromWhere1];

            board[whereTo, whereTo1] = board[fromWhere, fromWhere1];
            if (temp != board[fromWhere, fromWhere1]) board[fromWhere, fromWhere1] = 0;



            if (turnMove == true)
            {
                if (King_Move.Checkforwhite(board) == 1)
                {
                    //MessageBox.Show("nani?");
                    Array.Copy(board_save, board, board.Length);
                    //turnMove = !turnMove;
                    return 1;
                }
            }
            if (turnMove == false)
            {
                if (King_Move.Checkforblack(board) == 1)
                {
                    Array.Copy(board_save, board, board.Length);
                    // turnMove = !turnMove;
                    return 1;
                }
            }

            return 0;
        }

        public int MateAndStaleMateCheckW(int[,] board)
        {
            Move.test_move = 1;

            //int ok = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j ");
                    if (board[i, j] > 0)
                    {
                        //MessageBox.Show(board[i, j].ToString() + "tets_0");
                        if (board[i, j] == 1)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    //MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");

                                    if (Move.Move_PawnW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__1");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };

                                }
                            }
                        }
                        if (board[i, j] == 2)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_RookW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }

                        }
                        if (board[i, j] == 3)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_KnightW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == 4)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_BishopW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == 5)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_QueenW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == 6)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (King_Move.Move_KingW(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                    }
                }
            }
            Move.test_move = 0;
            if (King_Move.Checkforwhite(board) == 1) return 1;
            else return 2;
        }

        public int MateAndStaleMateCheckB(int[,] board)
        {
            Move.test_move = 1;
            //int ok = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j ");
                    if (board[i, j] < 0)
                    {
                        //MessageBox.Show(board[i, j].ToString() + "tets_0");
                        if (board[i, j] == -1)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    //MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");

                                    if (Move.Move_PawnB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__1");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };

                                }
                            }
                        }
                        if (board[i, j] == -2)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_RookB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }

                        }
                        if (board[i, j] == -3)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_KnightB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == -4)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_BishopB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == -5)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (Move.Move_QueenB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                        if (board[i, j] == -6)
                        {
                            for (int i2 = 0; i2 < 8; i2++)
                            {
                                for (int j2 = 0; j2 < 8; j2++)
                                {
                                    if (King_Move.Move_KingB(board, j, i, i2, j2) == 1)
                                    {
                                        if (leagalMove(board, j, i, i2, j2) == 0)
                                        {
                                            //MessageBox.Show(board[i, j].ToString() + "tets__");
                                            //MessageBox.Show(i.ToString() + "= i " + j.ToString() + "= j "); MessageBox.Show(i2.ToString() + "= i2 " + j2.ToString() + "= j2 ");
                                            Move.test_move = 0;
                                            return 0;
                                        }
                                    };
                                }
                            }
                        }
                    }
                }
            }
            Move.test_move = 0;
            if (King_Move.Checkforblack(board) == 1) return 1;
            else return 2;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //board[0, 0] = 7;
            //draw();
            Click1[0] = 0;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

            // a.Background = Color.;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Click1[0] = 0;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_37(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_38(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_39(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();


        }

        private void Button_Click_40(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_41(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();

        }

        private void Button_Click_42(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_43(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_44(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_45(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_46(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_47(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_48(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_49(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_50(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_51(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_52(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_53(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_54(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_55(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
            //WhatGet.Text += "\n" + WhatSent.Text;
        }

        private void Button_Click_56(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 0;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_57(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 1;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_58(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 2;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_59(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 3;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_60(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 4;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_61(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 5;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_62(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 6;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        private void Button_Click_63(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 7;
            if (board[Click1[0], Click1[1]] != 0 || Click1Made == true) { Click1Made = !Click1Made; }
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick();
        }

        //private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        //{

        //}

        private void t1_Click(object sender, RoutedEventArgs e)
        {
            board[0, SuperPawn0] = 5;
            //turnMove = false;
            t1.Visibility = t1b.Visibility;
            t2.Visibility = t1b.Visibility;
            t3.Visibility = t1b.Visibility;
            t4.Visibility = t1b.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t2_Click(object sender, RoutedEventArgs e)
        {
            board[0, SuperPawn0] = 2;
            //turnMove = false;
            t1.Visibility = t1b.Visibility;
            t2.Visibility = t1b.Visibility;
            t3.Visibility = t1b.Visibility;
            t4.Visibility = t1b.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t3_Click(object sender, RoutedEventArgs e)
        {
            board[0, SuperPawn0] = 4;
            // turnMove = false;
            t1.Visibility = t1b.Visibility;
            t2.Visibility = t1b.Visibility;
            t3.Visibility = t1b.Visibility;
            t4.Visibility = t1b.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t4_Click(object sender, RoutedEventArgs e)
        {
            board[0, SuperPawn0] = 3;
            //turnMove = false;
            t1.Visibility = t1b.Visibility;
            t2.Visibility = t1b.Visibility;
            t3.Visibility = t1b.Visibility;
            t4.Visibility = t1b.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t1b_Click(object sender, RoutedEventArgs e)
        {
            board[7, SuperPawn0] = -5;
            //turnMove = true;
            t1b.Visibility = t1.Visibility;
            t2b.Visibility = t1.Visibility;
            t3b.Visibility = t1.Visibility;
            t4b.Visibility = t1.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t2b_Click(object sender, RoutedEventArgs e)
        {
            board[7, SuperPawn0] = -2;
            //turnMove = true;
            t1b.Visibility = t1.Visibility;
            t2b.Visibility = t1.Visibility;
            t3b.Visibility = t1.Visibility;
            t4b.Visibility = t1.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();
            SetOpBoard();
            OponentMadeMove1(board);
        }

        private void t3b_Click(object sender, RoutedEventArgs e)
        {
            board[7, SuperPawn0] = -4;
            //turnMove = true;
            t1b.Visibility = t1.Visibility;
            t2b.Visibility = t1.Visibility;
            t3b.Visibility = t1.Visibility;
            t4b.Visibility = t1.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);

            draw();
            //SetOpBoard();
            //OponentMadeMove1(board);
        }

        private void t4b_Click(object sender, RoutedEventArgs e)
        {
            board[7, SuperPawn0] = -3;
            //turnMove = true;
            t1b.Visibility = t1.Visibility;
            t2b.Visibility = t1.Visibility;
            t3b.Visibility = t1.Visibility;
            t4b.Visibility = t1.Visibility;
            King_Move.Checkforblack(board);
            King_Move.Checkforwhite(board);
            draw();

            //SetOpBoard();
            //OponentMadeMove1(board);
        }

        private void WhatGet_TextChanged(object sender, TextChangedEventArgs e)
        {
            WhatGet.ScrollToEnd();
            MoveT.ScrollToEnd();
            //WhatGet.TextAlignment = TextAlignment.Right;

        }
    }


}
//int Check_Black(int kingx, int kingy)
//{
//    int ok = 0;
//    for (int i = 0; i < 8; i++)
//    {
//        for (int j = 0; j < 8; j++)
//        {
//            if (board[i, j] < 0)
//            {
//                if (board[i, j] == PawnWHITE)
//                {
//                    ok = Check_PawnW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == TowerWHITE)
//                {
//                    ok = Check_TowerW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == KnightWHITE)
//                {
//                    ok = Check_KnightW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == BishopWHITE)
//                {
//                    ok = Check_BishopW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == QueenWHITE)
//                {
//                    ok = Check_QueenW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == KingWHITE)
//                {
//                    ok = Check_KingW(j, i, kingx, kingy);
//                }
//                if (ok == 1)
//                {
//                    return 0;
//                }
//            }
//        }
//    }
//    return 1;
//}