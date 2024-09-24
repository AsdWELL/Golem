namespace GolemApp
{   
    public class Golem
    {
        /// <summary>
        /// Список точек текущего положения фигуры
        /// </summary>
        private List<Point> _points;

        /// <summary>
        /// Матрица переходов
        /// </summary>
        private int[][] _transitions;

        /// <summary>
        /// Масштаб фигуры
        /// </summary>
        private float _scale;

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

        /// <summary>
        /// Конструктор фигуры
        /// </summary>
        /// <param name="scale">Масштаб</param>
        /// <param name="offsetX">Смещение по оси X</param>
        /// <param name="offsetY">Смещение по оси Y</param>
        public Golem(float scale, float offsetX, float offsetY)
        {
            _scale = scale;
            _offsetX = offsetX;
            _offsetY = offsetY;

            _points = [];
            
            AddPoints();
            AddTransitions();
        }

        private void AddPoints()
        {
            //передняя сторона
            //тело
            _points.Add(new Point(-2, 12, 10)); //1
            _points.Add(new Point(-2, 7, 10)); //2
            _points.Add(new Point(-7, 7, 10)); //3
            _points.Add(new Point(-7, -11, 10)); //4
            _points.Add(new Point(-5, -11, 10)); //5
            _points.Add(new Point(-5, -1, 10)); //6
            _points.Add(new Point(-3, -1, 10)); //7
            _points.Add(new Point(-3, -3, 10)); //8
            _points.Add(new Point(-4, -3, 10)); //9
            _points.Add(new Point(-4, -13, 10)); //10
            _points.Add(new Point(-1, -13, 10)); //11
            _points.Add(new Point(-1, -3, 10)); //12
            _points.Add(new Point(2, -3, 10)); //13
            _points.Add(new Point(2, -13, 10)); //14
            _points.Add(new Point(5, -13, 10)); //15
            _points.Add(new Point(5, -3, 10)); //16
            _points.Add(new Point(4, -3, 10)); //17
            _points.Add(new Point(4, -1, 10)); //18
            _points.Add(new Point(6, -1, 10)); //19
            _points.Add(new Point(6, -11, 10)); //20
            _points.Add(new Point(8, -11, 10)); //21
            _points.Add(new Point(8, 7, 10)); //22
            _points.Add(new Point(3, 7, 10)); //23
            _points.Add(new Point(3, 12, 10)); //24

            //лицо
            _points.Add(new Point(-2, 10.5F, 10)); //25
            _points.Add(new Point(3, 10.5F, 10)); //26
            _points.Add(new Point(3, 10, 10)); //27
            _points.Add(new Point(2, 10, 10)); //28
            _points.Add(new Point(2, 8, 10)); //29
            _points.Add(new Point(1, 8, 10)); //30
            _points.Add(new Point(1, 9, 10)); //31
            _points.Add(new Point(0, 9, 10)); //32
            _points.Add(new Point(0, 8, 10)); //32
            _points.Add(new Point(-1, 8, 10)); //34
            _points.Add(new Point(-1, 10, 10)); //35
            _points.Add(new Point(-2, 10, 10)); //36

            //задняя сторона
            //тело
            _points.Add(new Point(-2, 12, 4)); //37
            _points.Add(new Point(-2, 7, 4)); //38
            _points.Add(new Point(-7, 7, 4)); //39
            _points.Add(new Point(-7, -11, 4)); //40
            _points.Add(new Point(-5, -11, 4)); //41
            _points.Add(new Point(-5, -1, 4)); //42
            _points.Add(new Point(-3, -1, 4)); //43
            _points.Add(new Point(-3, -3, 4)); //44
            _points.Add(new Point(-4, -3, 4)); //45
            _points.Add(new Point(-4, -13, 4)); //46
            _points.Add(new Point(-1, -13, 4)); //47
            _points.Add(new Point(-1, -3, 4)); //48
            _points.Add(new Point(2, -3, 4)); //49
            _points.Add(new Point(2, -13, 4)); //50
            _points.Add(new Point(5, -13, 4)); //51
            _points.Add(new Point(5, -3, 4)); //52
            _points.Add(new Point(4, -3, 4)); //53
            _points.Add(new Point(4, -1, 4)); //54
            _points.Add(new Point(6, -1, 4)); //55
            _points.Add(new Point(6, -11, 4)); //56
            _points.Add(new Point(8, -11, 4)); //57
            _points.Add(new Point(8, 7, 4)); //58
            _points.Add(new Point(3, 7, 4)); //59
            _points.Add(new Point(3, 12, 4)); //60

            //лицо
            _points.Add(new Point(-2, 10.5F, 4)); //61
            _points.Add(new Point(3, 10.5F, 4)); //62
            _points.Add(new Point(3, 10, 4)); //63
            _points.Add(new Point(2, 10, 4)); //64
            _points.Add(new Point(2, 8, 4)); //65
            _points.Add(new Point(1, 8, 4)); //66
            _points.Add(new Point(1, 9, 4)); //67
            _points.Add(new Point(0, 9, 4)); //68
            _points.Add(new Point(0, 8, 4)); //69
            _points.Add(new Point(-1, 8, 4)); //70
            _points.Add(new Point(-1, 10, 4)); //71
            _points.Add(new Point(-2, 10, 4)); //72
        }

        private void AddTransitions()
        {
            _transitions =
            [
                [2, 24, 37],
                [38],
                [4, 22, 39],
                [5, 40],
                [6, 41],
                [7, 42],
                [8, 43],
                [9, 44],
                [10, 45],
                [11, 46],
                [12, 47],
                [13, 48],
                [14, 49],
                [15, 50],
                [16, 51],
                [17, 52],
                [18, 53],
                [19, 54],
                [20, 55],
                [21, 56],
                [22, 57],
                [23, 58],
                [24, 59],
                [60],
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
                [36],
                null,
                //обратная сторона
                [38, 60],
                null,
                [40, 58],
                [41],
                [42],
                [43],
                [44],
                [45],
                [46],
                [47],
                [48],
                [49],
                [50],
                [51],
                [52],
                [53],
                [54],
                [55],
                [56],
                [57],
                [58],
                [59],
                [60],
                null,
                [62],
                [63],
                [64],
                [65],
                [66],
                [67],
                [68],
                [69],
                [70],
                [71],
                [72]
            ];
        }

        private List<PointF> TransformPoints()
        {
            return [.. _points.Select(point =>
                new PointF
                {
                    X = point.X * _scale + _offsetX,
                    Y = -point.Y * _scale + _offsetY
                }
            )];
        }

        public void RestorePosition()
        {
            _points.Clear();
            AddPoints();

            FigureChanged?.Invoke();
        }

        /// <summary>
        /// Отрисовывает фигуру
        /// </summary>
        /// <param name="g"></param>
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

        /// <summary>
        /// Перемещает фигуру
        /// </summary>
        /// <param name="dx">Смещение по X</param>
        /// <param name="dy">Смещение по Y</param>
        /// <param name="dz">Смещение по Z</param>
        public void Move(float dx, float dy, float dz)
        {
            float[,] matrix = new float[,]
            {
                {1, 0, 0, dx },
                {0, 1, 0, dy },
                {0, 0, 1, dz },
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        /// <summary>
        /// Перемещает фигуру вверх
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveUp(float offset) => Move(0, offset, 0);

        /// <summary>
        /// Перемещает фигуру вниз
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveDown(float offset) => Move(0, -offset, 0);

        /// <summary>
        /// Перемещает фигуру вправо
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveRight(float offset) => Move(offset, 0, 0);

        /// <summary>
        /// Перемещает фигуру влево
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveLeft(float offset) => Move(-offset, 0, 0);

        /// <summary>
        /// Перемещает фигуру в указанную точку
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        public void MoveTo(float x, float y)
        {           
            _offsetX = x;
            _offsetY = y;

            FigureChanged?.Invoke();
        }

        /// <summary>
        /// Увеличивает фигуру
        /// </summary>
        /// <param name="scale">Множитель увеличения</param>
        public void Scale(float scale)
        {
            float[,] matrix = new float[,]
            {
                {scale, 0, 0, 0 },
                {0, scale, 0, 0 },
                {0, 0, scale, 0 },
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        /// <summary>
        /// Врощает фигуру по оси X
        /// </summary>
        /// <param name="angle">Угол поворота</param>
        public void RotateX(float angle)
        {
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            float[,] matrix = new float[,]
            {
                {1, 0, 0, 0},
                {0, cos, -sin, 0},
                {0, sin, cos, 0},
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        /// <summary>
        /// Врощает фигуру по оси Y
        /// </summary>
        /// <param name="angle">Угол поворота</param>
        public void RotateY(float angle)
        {
            float sin = MathF.Sin(-angle);
            float cos = MathF.Cos(-angle);

            float[,] matrix = new float[,]
            {
                {cos, 0, -sin, 0},
                {0, 1, 0, 0},
                {sin, 0, cos, 0},
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        /// <summary>
        /// Врощает фигуру по оси Z
        /// </summary>
        /// <param name="angle">Угол поворота</param>
        public void RotateZ(float angle)
        {
            float sin = MathF.Sin(angle);
            float cos = MathF.Cos(angle);

            float[,] matrix = new float[,]
            {
                {cos, -sin, 0, 0},
                {sin, cos, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        private void MultiplyBy(float[,] matrix)
        {
            _points.ForEach(point =>
            {
                (float x, float y, float z) = point;

                point.X = x * matrix[0, 0] + y * matrix[0, 1] + z * matrix[0, 2] + 1 * matrix[0, 3];
                point.Y = x * matrix[1, 0] + y * matrix[1, 1] + z * matrix[1, 2] + 1 * matrix[1, 3];
                point.Z = x * matrix[2, 0] + y * matrix[2, 1] + z * matrix[2, 2] + 1 * matrix[2, 3];
            });

            FigureChanged?.Invoke();
        }
    }
}
