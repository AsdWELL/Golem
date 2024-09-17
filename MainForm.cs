namespace Golem
{
    public partial class MainForm : Form
    {
        private static Figure _figure;

        public MainForm()
        {
            InitializeComponent();

            _figure = new Figure(10, 10, Width / 2, Height / 2);

            _figure.FigureChanged += Refresh;

            MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Лабораторная работа №1{Environment.NewLine}" +
                $"Годов, Поршнев, Тында{Environment.NewLine}" +
                $"Перемещение - стрелочки{Environment.NewLine}" +
                $"Поворот - Q, E{Environment.NewLine}" +
                $"Масштаб - колёсико мыши", "Приветствие");
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _figure.Draw(e.Graphics);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _figure.Move(0, 0.1F);
                    break;
                case Keys.Down:
                    _figure.Move(0, -0.1F);
                    break;
                case Keys.Left:
                    _figure.Move(-0.1F, 0);
                    break;
                case Keys.Right:
                    _figure.Move(0.1F, 0);
                    break;
                case Keys.Q:
                    _figure.Rotate(-0.1F);
                    break;
                case Keys.E:
                    _figure.Rotate(0.1F);
                    break;
            }
        }

        private void MainForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _figure.Scale(1.25F);
            else
                _figure.Scale(0.8F);
        }
    }
}
