using System.Drawing;

namespace TheGame
{
    struct Cells
    {
        public Button cell;
        public bool IsTail;
        public bool IsBait;
        public bool IsHead;
    }

    enum Direction
    {
        Up,
        Right,
        Left,
        Down
    }
    
    public partial class Form1 : Form
    {
        Cells[,] GameCells = new Cells[30, 30];
        Direction dir;
        Point headPosition;
        

        int posX;
        int posY;

        bool GameOver = false;
        int HighScore = 0;
        int Score = 0;
        readonly Color BaitColor = Color.Red;
        readonly Color SnakeHeadColor = Color.DarkGreen;
        readonly Color SnakeTailColor = Color.LightGreen;
        readonly Color BlankSpace = Color.Black;

        bool IsBaitEaten = true;
        Random BaitLocation = new Random();
        Point[] TailLocations;


        
        public Form1()
        {
            InitializeComponent();
            Restart_Button.TabStop = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            CreateCells();
            StartGame();
        }
      
        private void StartGame()
        {
            
            timer1.Interval = 100;
            Point headPosition = new Point(0,0);
            dir = Direction.Right;
            TailLocations = new Point[3];
            
            for (int i = 0; i < GameCells.GetLength(0); i++)
                for (int j = 0; j < GameCells.GetLength(1); j++)
                {
                    GameCells[i, j].IsBait = false;
                    GameCells[i, j].IsTail = false;
                    GameCells[i, j].IsHead = false;

                }
            GameCells[headPosition.X, headPosition.Y].IsHead = true;
            

            BaitCreate();
            timer1.Enabled = true;
            Restart_Button.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {   
            MoveHead();
            AteBait();
            ScreenRefresh();
            GameState();
            TailManager();
            if (IsBaitEaten)
                BaitCreate();

        }
    
        private void CreateCells()
        {
            int posX = 40, posY = 120;
            Point point = new Point(posX, posY);
            Size buttonSize = new Size(25, 25);

            for (int i = 0; i < GameCells.GetLength(0); i++)
            {
                for (int j = 0; j < GameCells.GetLength(1); j++)
                {
                    GameCells[i, j].cell = new Button
                    {
                        Text = "",
                        Location = point,
                        Size = buttonSize,
                        Visible = true,
                        ForeColor = Color.Black,
                        BackColor = Color.Black,
                        Font = new Font("Times New Roman", 16),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,
                        TabIndex= 0,
                        
                    };


                    GameCells[i, j].cell.BringToFront();
                    Controls.Add(GameCells[i, j].cell);
                    GameCells[i, j].cell.KeyDown += new KeyEventHandler(TakeInput);
                    
                    point.X += buttonSize.Width - 5;

                }
                point.Y += buttonSize.Height - 5;
                point.X = 40;
            }
        }
      
        void BaitCreate()
        {
            Point BaitPos;
            do
            {
                BaitPos = new Point(BaitLocation.Next(0, GameCells.GetLength(0)),
                    BaitLocation.Next(0, GameCells.GetLength(1)));

            } while (GameCells[BaitPos.X, BaitPos.Y].IsHead || GameCells[BaitPos.X, BaitPos.Y].IsTail); 
            
            GameCells[BaitPos.X, BaitPos.Y].IsBait = true;
            IsBaitEaten = false;
            
        }

        private void TakeInput(object? sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W && dir != Direction.Up && dir != Direction.Down)
                dir = Direction.Up;
            else if (e.KeyCode == Keys.A && dir != Direction.Left && dir != Direction.Right)
                dir = Direction.Left;
            else if (e.KeyCode == Keys.S && dir != Direction.Down && dir != Direction.Up)
                dir = Direction.Down;
            else if (e.KeyCode == Keys.D && dir != Direction.Right && dir != Direction.Left)
                dir = Direction.Right;

        }


        void GameState()
        {
            if (GameCells[headPosition.Y, headPosition.X].IsTail)
            {
                timer1.Stop();
                GameOver = true;
            }
            if(IsBaitEaten)
                Score_Label.Text = "Score: " + Score.ToString();

        }
        void AteBait()
        {
            if (GameCells[headPosition.Y, headPosition.X].IsBait)
            {
                IsBaitEaten = true;
                GameCells[headPosition.Y, headPosition.X].IsBait = false;
                Score++;
            }

        }
      
        void TailManager()
        {
            if(IsBaitEaten)
                Array.Resize<Point>(ref TailLocations, TailLocations.Length + 1);

            for(int i= TailLocations.Length - 2; i >= 0; i--)
            {
                TailLocations[i + 1] = TailLocations[i];
            }
            TailLocations[0] = headPosition;
            
            for (int i = 0; i <= TailLocations.Length - 1; i++)
            {
                GameCells[TailLocations[i].Y, TailLocations[i].X].IsTail = true;
            }
            GameCells[TailLocations[TailLocations.Length-1].Y,
                      TailLocations[TailLocations.Length-1].X].IsTail = false;
        }

        private void MoveHead()
        {
            Point oldHeadPos = headPosition;

            switch (dir)
            {
                case Direction.Up:
                    if (headPosition.Y - 1 >= 0)
                        headPosition.Y--;
                    else if (headPosition.Y - 1 < 0)
                        headPosition.Y = GameCells.GetLength(1) - 1;
                    break;
                case Direction.Right:
                    if (headPosition.X + 1 < GameCells.GetLength(0))
                        headPosition.X++;
                    else if (headPosition.X + 1 == GameCells.GetLength(0))
                        headPosition.X = 0;
                    break;
                case Direction.Left:
                    if (headPosition.X - 1 >= 0)
                        headPosition.X--;
                    else if (headPosition.X - 1 < 0)
                        headPosition.X = GameCells.GetLength(0)-1;
                    break;
                case Direction.Down:
                    if (headPosition.Y + 1 < GameCells.GetLength(1))
                        headPosition.Y++;
                    else if (headPosition.Y + 1 == GameCells.GetLength(1))
                        headPosition.Y = 0;
                    break;
                default:
                    break;
            }

            if (oldHeadPos.Equals(headPosition))
                return;

            GameCells[oldHeadPos.Y, oldHeadPos.X].IsHead = false;
            GameCells[headPosition.Y, headPosition.X].IsHead = true;

            
        }


        void ScreenRefresh()
        {
            foreach (Cells cells in GameCells)
            {
                if (cells.IsBait)
                    cells.cell.BackColor = BaitColor;
                else if (cells.IsHead)
                    cells.cell.BackColor = SnakeHeadColor;

                else if (cells.IsTail)
                    cells.cell.BackColor = SnakeTailColor;
                else
                    cells.cell.BackColor = BlankSpace;
            }
        }

        private void Restart_Button_Click(object sender, EventArgs e)
        {
            GameOver  = false;
            if (Score > HighScore)
            {
                HighScore = Score;
                HighScore_Label.Text = "High Score: " + HighScore.ToString();

            }
            
            Array.Clear(TailLocations);
            headPosition.X = 0;
            headPosition.Y = 0;
            Restart_Button.Enabled = false;
            StartGame();

        }
    }
}