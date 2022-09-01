namespace Again
{
    public partial class Form1 : Form
    {
        Button currentButton;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            currentButton = new Button();
            currentButton.Location = e.Location;
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
            currentButton.Size = new Size(e.Location.X - currentButton.Location.X, e.Location.Y - currentButton.Location.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseMove -= Form1_MouseMove;
        }
    }
}