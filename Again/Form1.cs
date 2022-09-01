namespace Again
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Random random = new Random();
            
            int x = random.Next(0, this.ClientSize.Width - button.Size.Width);
            int y = random.Next(0, this.ClientSize.Height - button.Size.Height);
            button.Location = new Point(x, y);
        }
    }
}