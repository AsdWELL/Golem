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
            _golem.FigureChanged += Refresh;
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
                { Keys.R, _golem.RestorePosition }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Лабораторная работа №2{Environment.NewLine}" +
                $"Годов, Поршнев, Тында{Environment.NewLine}" +
                $"Перемещение - WASD{Environment.NewLine}" +
                $"Поворот по X - стрелочки вверх, вниз{Environment.NewLine}" +
                $"Поворот по Y - стрелочки влево, вправо, {Environment.NewLine}" +
                $"Поворот по Z - Q, E{Environment.NewLine}" +
                $"Масштаб - колёсико мыши{Environment.NewLine}" +
                "Cброс позиции - R", "Приветствие");
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _golem.Draw(e.Graphics);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_keyBindings.TryGetValue(e.KeyCode, out var action))
                action.Invoke();
        }

        private void MainForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            _golem.Scale(e.Delta > 0 ? 1.25f : 0.8f);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {           
            _golem.MoveTo(Width / 2, Height / 2);
        }
    }
}
