namespace GolemApp
{
    public partial class MainForm : Form
    {
        private static Golem _golem;

        private Dictionary<Keys, Action> _keyBindings;

        private float OffsetValue { get; set; } = 1f;
        private float RotationValue { get; set; } = 0.1f;

        public MainForm()
        {
            InitializeComponent();

            _golem = new Golem(10, Width / 2, Height / 2);
            BindKeys();

            MouseWheel += MainForm_MouseWheel;
        }

        private void BindKeys()
        {
            _keyBindings = new Dictionary<Keys, Action>
            {
                { Keys.W, () => _golem.MoveUp(OffsetValue) },
                { Keys.S, () => _golem.MoveDown(OffsetValue) },
                { Keys.A, () => _golem.MoveLeft(OffsetValue) },
                { Keys.D, () => _golem.MoveRight(OffsetValue) },
                { Keys.Q, () => _golem.RotateZ(RotationValue) },
                { Keys.E, () => _golem.RotateZ(-RotationValue) },
                { Keys.Up, () => _golem.RotateX(-RotationValue) },
                { Keys.Down, () => _golem.RotateX(RotationValue) },
                { Keys.Left, () => _golem.RotateY(-RotationValue) },
                { Keys.Right, () => _golem.RotateY(RotationValue) },
                { Keys.R, _golem.RestorePosition },
                { Keys.X, _golem.DrawProjectionX },
                { Keys.Y, _golem.DrawProjectionY},
                { Keys.Z, _golem.DrawProjectionZ },
                {Keys.F, () => _golem.IsFill = !_golem.IsFill },
                {Keys.C, SetGolemFillColor }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"������������ ������ �4{Environment.NewLine}" +
                $"�����, �������, �����{Environment.NewLine}" +
                $"����������� - WASD{Environment.NewLine}" +
                $"������� �� X - ��������� �����, ����{Environment.NewLine}" +
                $"������� �� Y - ��������� �����, ������, {Environment.NewLine}" +
                $"������� �� Z - Q, E{Environment.NewLine}" +
                $"������� - ������� ����{Environment.NewLine}" +
                $"���������� �������� �� ��� X - X{Environment.NewLine}" +
                $"���������� �������� �� ��� Y - Y{Environment.NewLine}" +
                $"���������� �������� �� ��� Z - Z{Environment.NewLine}" +
                $"������������ ������� - F{Environment.NewLine}" +
                $"����� ����� ������� - C{Environment.NewLine}" +
                "C���� ������� - R", "�����������");
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            
            pictureBox.Image = _golem.Draw(bitmap);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_keyBindings.TryGetValue(e.KeyCode, out var action))
                action.Invoke();

            OnPaint(null);
        }

        private void MainForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            _golem.Scale(e.Delta > 0 ? 1.25f : 0.8f);

            OnPaint(null);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {           
            _golem.MoveTo(Width / 2, Height / 2);

            OnPaint(null);
        }

        private void SetGolemFillColor()
        {
            if (ColorPicker.ShowDialog() == DialogResult.Cancel)
                return;

            _golem.FillColor = ColorPicker.Color;
            _golem.IsFill = true;

            OnPaint(null);
        }
    }
}
