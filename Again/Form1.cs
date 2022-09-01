namespace Again
{
    public partial class Form1 : Form
    {
        Button currentButton;
        Point anchor;
        LinkedList<Button> buttons = new LinkedList<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            currentButton = new Button();
            currentButton.Location = e.Location;
            anchor = e.Location;
            currentButton.Size = new Size(0, 0);
            currentButton.Text = "Кнопока";

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
                        origin.Offset(0, 1);
                        Rectangle another = new Rectangle(anotherButton.Location, anotherButton.Size);
                        if (origin.IntersectsWith(another))
                        {
                            failed = true;
                            break;
                        }
                    }
                }
                if (failed) continue;
                button.Location = new Point(button.Location.X, button.Location.Y + 1);

            }

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            CalcPhysics();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            CalcPhysics();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            buttons.Remove(button);
            this.Controls.Remove(button);
        }
    }
}