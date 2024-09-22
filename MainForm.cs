namespace Golem
{
    public partial class MainForm : Form
    {
        private static Figure _figure;

        public MainForm()
        {
            InitializeComponent();

            _figure = new Figure(10, Width / 2, Height / 2);
            _figure.FigureChanged += Refresh;

            MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Лабораторная работа №2{Environment.NewLine}" +
                $"Годов, Поршнев, Тында{Environment.NewLine}" +
                $"Перемещение - WASD{Environment.NewLine}" +
                $"Поворот по X - стрелочки вверх, вниз{Environment.NewLine}" +
                $"Поворот по Y - стрелочки влево, вправо, {Environment.NewLine}" +
                $"Поворот по Z - Q, E{Environment.NewLine}" +
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
                case Keys.W:
                    _figure.MoveUp(1);
                    break;
                case Keys.S:
                    _figure.MoveDown(1);
                    break;
                case Keys.A:
                    _figure.MoveLeft(1);
                    break;
                case Keys.D:
                    _figure.MoveRight(1);
                    break;
                case Keys.Q:
                    _figure.RotateZ(0.1f);
                    break;
                case Keys.E:
                    _figure.RotateZ(-0.1f);
                    break;
                case Keys.Up:
                    _figure.RotateX(-0.1f);
                    break;
                case Keys.Down:
                    _figure.RotateX(0.1f);
                    break;
                case Keys.Left:
                    _figure.RotateY(-0.1f);
                    break;
                case Keys.Right:
                    _figure.RotateY(0.1f);
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
