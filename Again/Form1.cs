namespace Again
{
    public partial class Form1 : Form
    {
        Button currentButton;
        Point anchor;
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
        }
    }
}