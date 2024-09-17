namespace Golem
{
    public class Figure
    {
        /// <summary>
        /// Список точек
        /// </summary>
        private List<Point> _points;

        /// <summary>
        /// Матрица переходов
        /// </summary>
        private int[][] _transitions;

        /// <summary>
        /// Масштаб по Х
        /// </summary>
        private float _scaleX;

        /// <summary>
        /// Масштаб по У
        /// </summary>
        private float _scaleY;

        /// <summary>
        /// Смещение по Х
        /// </summary>
        private float _offsetX;

        /// <summary>
        /// Смещение по У
        /// </summary>
        private float _offsetY;

        /// <summary>
        /// Событие, срабатывающее при изменении масштаба или смещения фигуры
        /// </summary>
        public event Action FigureChanged;

        public Figure(float scaleX, float scaleY, float offsetX, float offsetY)
        {
            _scaleX = scaleX;
            _scaleY = scaleY;
            _offsetX = offsetX;
            _offsetY = offsetY;

            _points = [];
            
            AddPoints();
            AddTransitions();
        }

        private void AddPoints()
        {
            //тело
            _points.Add(new Point(-2, 12, 1)); //1
            _points.Add(new Point(-2, 7, 1)); //2
            _points.Add(new Point(-7, 7, 1)); //3
            _points.Add(new Point(-7, -11, 1)); //4
            _points.Add(new Point(-5, -11, 1)); //5
            _points.Add(new Point(-5, -1, 1)); //6
            _points.Add(new Point(-3, -1, 1)); //7
            _points.Add(new Point(-3, -3, 1)); //8
            _points.Add(new Point(-4, -3, 1)); //9
            _points.Add(new Point(-4, -13, 1)); //10
            _points.Add(new Point(-1, -13, 1)); //11
            _points.Add(new Point(-1, -3, 1)); //12
            _points.Add(new Point(2, -3, 1)); //13
            _points.Add(new Point(2, -13, 1)); //14
            _points.Add(new Point(5, -13, 1)); //15
            _points.Add(new Point(5, -3, 1)); //16
            _points.Add(new Point(4, -3, 1)); //17
            _points.Add(new Point(4, -1, 1)); //18
            _points.Add(new Point(6, -1, 1)); //19
            _points.Add(new Point(6, -11, 1)); //20
            _points.Add(new Point(8, -11, 1)); //21
            _points.Add(new Point(8, 7, 1)); //22
            _points.Add(new Point(3, 7, 1)); //23
            _points.Add(new Point(3, 12, 1)); //24

            //лицо
            _points.Add(new Point(-2, 10.5F, 1)); //25
            _points.Add(new Point(3, 10.5F, 1)); //26
            _points.Add(new Point(3, 10, 1)); //27
            _points.Add(new Point(2, 10, 1)); //28
            _points.Add(new Point(2, 8, 1)); //29
            _points.Add(new Point(1, 8, 1)); //30
            _points.Add(new Point(1, 9, 1)); //31
            _points.Add(new Point(0, 9, 1)); //32
            _points.Add(new Point(0, 8, 1)); //32
            _points.Add(new Point(-1, 8, 1)); //34
            _points.Add(new Point(-1, 10, 1)); //35
            _points.Add(new Point(-2, 10, 1)); //36
        }

        private void AddTransitions()
        {
            _transitions = new int[][]
            {
                [2, 24],
                null,
                [4, 22],
                [5],
                [6],
                [7],
                [8],
                [9],
                [10],
                [11],
                [12],
                [13],
                [14],
                [15],
                [16],
                [17],
                [18],
                [19],
                [20],
                [21],
                [22],
                [23],
                [24],
                null,
                [26],
                [27],
                [28],
                [29],
                [30],
                [31],
                [32],
                [33],
                [34],
                [35],
                [36]
            };
        }

        private List<PointF> TransformPoints()
        {
            return [.. _points.Select(point =>
                new PointF
                {
                    X = point.X * _scaleX + _offsetX,
                    Y = -point.Y * _scaleY + _offsetY
                }
            )];
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.White);

            var screenPoints = TransformPoints();

            for (int i = 0; i < _transitions.Length; i++)
            {
                if (_transitions[i] == null)
                    continue;
                foreach (int j in _transitions[i])
                    g.DrawLine(Pens.Black, screenPoints[i], screenPoints[j - 1]);
            }
        }

        public void Move(float offsetX, float offsetY)
        {
            _offsetX += offsetX;
            _offsetY += offsetY;

            FigureChanged?.Invoke();
        }

        public void Scale(float scale)
        {
            _scaleX *= scale;
            _scaleY *= scale;

            FigureChanged?.Invoke();
        }

        public void Rotate(float angle)
        {
            _points.ForEach(point =>
            {
                float X = point.X, Y = point.Y;
                
                point.X = X * MathF.Cos(angle) - Y * MathF.Sin(angle);
                point.Y = X * MathF.Sin(angle) + Y * MathF.Cos(angle);
            });

            FigureChanged?.Invoke();
        }
    }
}
