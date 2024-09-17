namespace Golem
{
    public partial class MainForm : Form
    {
        private static Figure _figure;

        public MainForm()
        {
            InitializeComponent();

            _figure = new Figure(10, 10, Width / 2, Height / 2);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _figure.Draw(e.Graphics);
        }
    }
}
