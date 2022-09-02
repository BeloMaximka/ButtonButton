namespace Again
{
    public partial class Form1 : Form
    {
        Button currentButton;
        Point anchor;
        DateTime startuptime;
        LinkedList<Button> buttons = new LinkedList<Button>();

        public Form1()
        {
            InitializeComponent();
            startuptime = DateTime.Now;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            currentButton = new Button();
            currentButton.Location = e.Location;
            anchor = e.Location;
            currentButton.Size = new Size(0, 0);
            currentButton.Text = " нопока";

            Random random = new Random();
            currentButton.BackColor = Color.FromArgb(random.Next(2147483647));

            currentButton.MouseClick += button1_MouseClick;
            this.Controls.Add(currentButton);
            currentButton.BringToFront();
            this.MouseMove += Form1_MouseMove;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.Location.X - anchor.X;
            int y = e.Location.Y - anchor.Y;
            Point newLocation = currentButton.Location;
            Size newSize = currentButton.Size;

            if (x < 0)
            {
                newLocation.X = e.Location.X;
                newSize.Width = anchor.X - e.Location.X;
            }
            else newSize.Width = x;

            if (y < 0)
            {
                newLocation.Y = e.Location.Y;
                newSize.Height = anchor.Y - e.Location.Y;
            }
            else newSize.Height = y;

            currentButton.Size = newSize;
            currentButton.Location = newLocation;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseMove -= Form1_MouseMove;
            buttons.AddLast(currentButton);
            CalcPhysics();
        }

        private void CalcPhysics()
        {
            foreach (Button button in buttons)
            {

                if (button.Location.Y + button.Size.Height > this.ClientSize.Height)
                    continue;
                bool failed = false;
                foreach (Button anotherButton in buttons)
                {
                    if (button != anotherButton)
                    {
                        Rectangle origin = new Rectangle(button.Location, button.Size);
                        origin.Offset(0, 2);
                        Rectangle another = new Rectangle(anotherButton.Location, anotherButton.Size);
                        if (origin.IntersectsWith(another))
                        {
                            failed = true;
                            break;
                        }
                    }
                }
                if (failed) continue;
                button.Location = new Point(button.Location.X, button.Location.Y + 2);

            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            buttons.Remove(button);
            this.Controls.Remove(button);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point offset = new Point();
            Point newLocation = this.Location;
            foreach (Screen screen in Screen.AllScreens)
                if (screen.Bounds.Contains(this.Location))
                {
                    newLocation = new Point(this.Location.X - screen.Bounds.Left,
                                     this.Location.Y - screen.Bounds.Top);
                    offset = new Point(screen.Bounds.Left, screen.Bounds.Top);
                }

            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    if (newLocation.X - 50 < 0)
                        newLocation.X = 0;
                    else
                        newLocation.X -= 50;
                    break;
                case Keys.Right:
                case Keys.D:
                    if (newLocation.X + this.Width + 50 > Screen.GetWorkingArea(this.Location).Width)
                        newLocation.X = Screen.GetWorkingArea(this.Location).Width - this.Width;
                    else
                        newLocation.X += 50;
                    break;
                case Keys.Up:
                case Keys.W:
                    if (newLocation.Y - 50 < 0)
                        newLocation.Y = 0;
                    else
                        newLocation.Y -= 50;
                    break;
                case Keys.Down:
                case Keys.S:
                    if (newLocation.Y + this.Height + 50 > Screen.GetWorkingArea(this.Location).Height)
                        newLocation.Y = Screen.GetWorkingArea(this.Location).Height - this.Height;
                    else
                        newLocation.Y += 50;
                    break;
            }
            newLocation.X += offset.X;
            newLocation.Y += offset.Y;
            this.Location = newLocation;
        }

        private void physicsTimer_Tick(object sender, EventArgs e)
        {
            CalcPhysics();
        }

        private void uptimeTimer_Tick(object sender, EventArgs e)
        {
            int ms = (int)(DateTime.Now - startuptime).TotalMilliseconds;
            if (ms >= 5000)
            {
                System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
                timer.Enabled = false;
            }
            this.Text = $" нопоки - {ms} мс";
        }
    }
}