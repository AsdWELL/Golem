namespace GolemApp
{
    public partial class MainForm : Form
    {
        private static Golem _golem;

        public MainForm()
        {
            InitializeComponent();

            _golem = new Golem(10, Width / 2, Height / 2);
            _golem.FigureChanged += Refresh;

            MouseWheel += MainForm_MouseWheel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"������������ ������ �2{Environment.NewLine}" +
                $"�����, �������, �����{Environment.NewLine}" +
                $"����������� - WASD{Environment.NewLine}" +
                $"������� �� X - ��������� �����, ����{Environment.NewLine}" +
                $"������� �� Y - ��������� �����, ������, {Environment.NewLine}" +
                $"������� �� Z - Q, E{Environment.NewLine}" +
                $"������� - ������� ����{Environment.NewLine}" +
                "C���� ������� - R", "�����������");
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _golem.Draw(e.Graphics);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _golem.MoveUp(1);
                    break;
                case Keys.S:
                    _golem.MoveDown(1);
                    break;
                case Keys.A:
                    _golem.MoveLeft(1);
                    break;
                case Keys.D:
                    _golem.MoveRight(1);
                    break;
                case Keys.Q:
                    _golem.RotateZ(0.1f);
                    break;
                case Keys.E:
                    _golem.RotateZ(-0.1f);
                    break;
                case Keys.Up:
                    _golem.RotateX(-0.1f);
                    break;
                case Keys.Down:
                    _golem.RotateX(0.1f);
                    break;
                case Keys.Left:
                    _golem.RotateY(-0.1f);
                    break;
                case Keys.Right:
                    _golem.RotateY(0.1f);
                    break;
                case Keys.R:
                    _golem.RestorePosition();
                    break;
            }
        }

        private void MainForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _golem.Scale(1.25F);
            else
                _golem.Scale(0.8F);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {           
            _golem.MoveTo(Width / 2, Height / 2);
        }
    }
}
