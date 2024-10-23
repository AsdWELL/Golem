using GolemApp.Drawing;
using static GolemApp.Extensions.Utils;

namespace GolemApp
{   
    public class Golem
    {
        /// <summary>
        /// Список точек текущего положения фигуры
        /// </summary>
        private List<Point3D> _points;

        /// <summary>
        /// Матрица переходов
        /// </summary>
        private int[][] _transitions;

        /// <summary>
        /// Массив кубов, из которых состоит фигура
        /// </summary>
        private Cube[] _cubes;

        /// <summary>
        /// Масштаб фигуры
        /// </summary>
        private double _scale;

        /// <summary>
        /// Смещение по Х
        /// </summary>
        private double _offsetX;

        /// <summary>
        /// Смещение по У
        /// </summary>
        private double _offsetY;

        /// <summary>
        /// z-буфер
        /// </summary>
        private ZBuffer _zBuffer;

        /// <summary>
        /// Цвет заднего фона
        /// </summary>
        public Color BackgroundColor {  get; set; } = Color.White;

        /// <summary>
        /// Цвет обводки
        /// </summary>
        public Color StrokeColor { get; set; } = Color.Black;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color FillColor { get; set; } = Color.LightBlue;

        /// <summary>
        /// Указывает, нужно ли заливать фигуру
        /// </summary>
        public bool IsFill { get; set; } = false;

        /// <summary>
        /// Конструктор фигуры
        /// </summary>
        /// <param name="scale">Масштаб</param>
        /// <param name="offsetX">Смещение по оси X</param>
        /// <param name="offsetY">Смещение по оси Y</param>
        public Golem(double scale, double offsetX, double offsetY)
        {
            _scale = scale;
            _offsetX = offsetX;
            _offsetY = offsetY;

            _zBuffer = new ZBuffer();
            
            AddPoints();
            AddTransitions();
        }

        private void AddPoints()
        {
            //передняя сторона
            //тело
            _points =
            [
                new Point3D(-2, 12, 10), //1
                new Point3D(-2, 7, 10), //2
                new Point3D(-7, 7, 10), //3
                new Point3D(-7, -11, 10), //4
                new Point3D(-5, -11, 10), //5
                new Point3D(-5, -1, 10), //6
                new Point3D(-3, -1, 10), //7
                new Point3D(-3, -3, 10), //8
                new Point3D(-4, -3, 10), //9
                new Point3D(-4, -13, 10), //10
                new Point3D(-1, -13, 10), //11
                new Point3D(-1, -3, 10), //12
                new Point3D(2, -3, 10), //13
                new Point3D(2, -13, 10), //14
                new Point3D(5, -13, 10), //15
                new Point3D(5, -3, 10), //16
                new Point3D(4, -3, 10), //17
                new Point3D(4, -1, 10), //18
                new Point3D(6, -1, 10), //19
                new Point3D(6, -11, 10), //20
                new Point3D(8, -11, 10), //21
                new Point3D(8, 7, 10), //22
                new Point3D(3, 7, 10), //23
                new Point3D(3, 12, 10), //24
                //лицо
                new Point3D(-2, 10.5, 10), //25
                new Point3D(3, 10.5, 10), //26
                new Point3D(3, 10, 10), //27
                new Point3D(2, 10, 10), //28
                new Point3D(2, 8, 10), //29
                new Point3D(1, 8, 10), //30
                new Point3D(1, 9, 10), //31
                new Point3D(0, 9, 10), //32
                new Point3D(0, 8, 10), //32
                new Point3D(-1, 8, 10), //34
                new Point3D(-1, 10, 10), //35
                new Point3D(-2, 10, 10), //36
                //задняя сторона
                //тело
                new Point3D(-2, 12, 4), //37
                new Point3D(-2, 7, 4), //38
                new Point3D(-7, 7, 4), //39
                new Point3D(-7, -11, 4), //40
                new Point3D(-5, -11, 4), //41
                new Point3D(-5, -1, 4), //42
                new Point3D(-3, -1, 4), //43
                new Point3D(-3, -3, 4), //44
                new Point3D(-4, -3, 4), //45
                new Point3D(-4, -13, 4), //46
                new Point3D(-1, -13, 4), //47
                new Point3D(-1, -3, 4), //48
                new Point3D(2, -3, 4), //49
                new Point3D(2, -13, 4), //50
                new Point3D(5, -13, 4), //51
                new Point3D(5, -3, 4), //52
                new Point3D(4, -3, 4), //53
                new Point3D(4, -1, 4), //54
                new Point3D(6, -1, 4), //55
                new Point3D(6, -11, 4), //56
                new Point3D(8, -11, 4), //57
                new Point3D(8, 7, 4), //58
                new Point3D(3, 7, 4), //59
                new Point3D(3, 12, 4), //60
                new Point3D(-5, 7, 10), //61 (вспомогательная точка для разделения левой руки и туловища)
                new Point3D(-5, 7, 4), //62 (вспомогательная точка для разделения левой руки и туловища)
                new Point3D(6, 7, 10), //63 (вспомогательная точка для разделения правой руки и туловища)
                new Point3D(6, 7, 4), //64 (вспомогательная точка для разделения правой руки и туловища)
            ];
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
                [60]
            ];
        }

        private void InitializeCubes(List<Point3D> points)
        {
            _cubes = [
                new Cube([points[1], points[0], points[22], points[23], 
                    points[37], points[36], points[58], points[59]]), //голова
                
                new Cube([points[3], points[2], points[4], points[60],
                    points[39], points[38], points[40], points[61]]), //левая рука
                
                new Cube([points[19], points[62], points[20], points[21],
                    points[55], points[63], points[56], points[57]]), //правая рука

                new Cube([points[5], points[60], points[18], points[62],
                    points[41], points[61], points[54], points[63]]), //туловище

                new Cube([points[7], points[6], points[16], points[17],
                    points[43], points[42], points[52], points[53]]), //между ногами и туловищем

                new Cube([points[9], points[8], points[10], points[11],
                    points[45], points[44], points[46], points[47]]), //левая нога

                new Cube([points[13], points[12], points[14], points[15],
                    points[49], points[48], points[50], points[51]]), //правая нога
                ];
        }

        private List<Point3D> TransformPoints()
        {
            return [.. _points.Select(point =>
                new Point3D(point.X * _scale + _offsetX,
                    -point.Y * _scale + _offsetY,
                    point.Z * _scale)
            )];
        }

        public void RestorePosition()
        {
            AddPoints();
        }

        private Color GetFillColor(double z, double minZ, double maxZ)
        {
            double k = (z - minZ) / (maxZ - minZ);

            //сглаживание коэффициента для более плавного перехода цветов
            k = 1 - Math.Exp(-3.3 * k);

            return Color.FromArgb(
                Floor(Math.Clamp(FillColor.R * k, 0, 255)),
                Floor(Math.Clamp(FillColor.G * k, 0, 255)),
                Floor(Math.Clamp(FillColor.B * k, 0, 255))
                );
        }

        /// <summary>
        /// Отрисовывает фигуру
        /// </summary>
        /// <param name="g"></param>
        public Bitmap Draw(Bitmap bitmap)
        {
            _zBuffer.InitializeZBuffer(bitmap.Size);
            
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(BackgroundColor);

            var screenPoints = TransformPoints();

            double maxZ = screenPoints.Max(point => point.Z);
            double minZ = screenPoints.Min(point => point.Z);

            InitializeCubes(screenPoints);

            //закрашиваем фигуру
            foreach (var cube in _cubes)
                foreach (var side in cube.GetSidesAsTriangles())
                    foreach (var triangle in side)
                        foreach (var point in Rasterizer.GetTrianglePoints([.. triangle.Vertices]))
                            if (_zBuffer.CheckAndSetZValue(point) && IsFill)
                                bitmap.SetPixel(Floor(point.X), Floor(point.Y),
                                    GetFillColor(point.Z, minZ, maxZ));

            //отрисовываем линии
            for (int i = 0; i < _transitions.Length; i++)
            {
                if (_transitions[i] == null)
                    continue;
                foreach (int j in _transitions[i])
                    foreach (var point in GetLinePoints(screenPoints[i], screenPoints[j - 1]))
                        bitmap.SetPixel(Floor(point.X), Floor(point.Y), StrokeColor);
            }

            return bitmap;
        }

        /// <summary>
        /// Построения проекции на ось X
        /// </summary>
        public void DrawProjectionX()
        {
            double[,] matrix = new double[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };

            MultiplyBy(matrix);

            _points.ForEach(point => (point.X, point.Y) = (point.Y, point.Z));
        }

        /// <summary>
        /// Построения проекции на ось Y
        /// </summary>
        public void DrawProjectionY()
        {
            double[,] matrix = new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };

            MultiplyBy(matrix);

            _points.ForEach(point => point.Y = point.Z);
        }

        /// <summary>
        /// Построения проекции на ось Z
        /// </summary>
        public void DrawProjectionZ()
        {
            double[,] matrix = new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        /// <summary>
        /// Перемещает фигуру
        /// </summary>
        /// <param name="dx">Смещение по X</param>
        /// <param name="dy">Смещение по Y</param>
        /// <param name="dz">Смещение по Z</param>
        public void Move(double dx, double dy, double dz)
        {
            double[,] matrix = new double[,]
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
        public void MoveUp(double offset) => Move(0, offset, 0);

        /// <summary>
        /// Перемещает фигуру вниз
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveDown(double offset) => Move(0, -offset, 0);

        /// <summary>
        /// Перемещает фигуру вправо
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveRight(double offset) => Move(offset, 0, 0);

        /// <summary>
        /// Перемещает фигуру влево
        /// </summary>
        /// <param name="offset">Смещение</param>
        public void MoveLeft(double offset) => Move(-offset, 0, 0);
        /// <summary>
        /// Перемещает фигуру в указанную точку
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        public void MoveTo(double x, double y)
        {           
            _offsetX = x;
            _offsetY = y;
        }

        /// <summary>
        /// Увеличивает фигуру
        /// </summary>
        /// <param name="scale">Множитель увеличения</param>
        public void Scale(double scale)
        {
            double[,] matrix = new double[,]
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
        public void RotateX(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double[,] matrix = new double[,]
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
        public void RotateY(double angle)
        {
            double sin = Math.Sin(-angle);
            double cos = Math.Cos(-angle);

            double[,] matrix = new double[,]
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
        public void RotateZ(double angle)
        {
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            double[,] matrix = new double[,]
            {
                {cos, -sin, 0, 0},
                {sin, cos, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1 }
            };

            MultiplyBy(matrix);
        }

        private void MultiplyBy(double[,] matrix)
        {
            _points.ForEach(point =>
            {
                (double x, double y, double z, double w) = point;

                point.X = x * matrix[0, 0] + y * matrix[0, 1] + z * matrix[0, 2] + w * matrix[0, 3];
                point.Y = x * matrix[1, 0] + y * matrix[1, 1] + z * matrix[1, 2] + w * matrix[1, 3];
                point.Z = x * matrix[2, 0] + y * matrix[2, 1] + z * matrix[2, 2] + w * matrix[2, 3];
            });
        }

        /// <summary>
        /// Алгоритм Брезенхема для нахождения точек отрезка
        /// </summary>
        /// <param name="p1">Начало отрезка</param>
        /// <param name="p2">Конец отрезка</param>
        /// <returns>Список точек отрезка</returns>
        private IEnumerable<Point3D> GetLinePoints(Point3D p1, Point3D p2)
        {
            double zError = _scale;
            
            if (_zBuffer.CheckAndSetZValue(p1.X, p1.Y, p1.Z + zError))
                yield return p1;

            double dE = 1;

            double dx = Math.Abs(p2.X - p1.X);
            double dy = Math.Abs(p2.Y - p1.Y);
            double dz = Math.Abs(p2.Z - p1.Z);

            double xs = p2.X > p1.X ? 1 : -1;
            double ys = p2.Y > p1.Y ? 1 : -1;
            double zs = p2.Z > p1.Z ? 1 : -1;

            double d1, d2;
            (double x1, double y1, double z1, _) = p1;

            if (dx >= dy && dx >= dz)
            {
                d1 = 2 * dy - dx;
                d2 = 2 * dz - dx;
                while (Math.Abs(x1 - p2.X) > dE)
                {
                    x1 += xs;
                    if (d1 >= 0)
                    {
                        y1 += ys;
                        d1 -= 2 * dx;
                    }
                    if (d2 >= 0)
                    {
                        z1 += zs;
                        d2 -= 2 * dx;
                    }
                    d1 += 2 * dy;
                    d2 += 2 * dz;
                    if (_zBuffer.CheckAndSetZValue(x1, y1, z1 + zError))
                        yield return new Point3D(x1, y1, z1);
                }
            }
            else if (dy >= dx && dy >= dz)
            {
                d1 = 2 * dx - dy;
                d2 = 2 * dz - dy;
                while (Math.Abs((int)y1 - (int)p2.Y) > dE)
                {
                    y1 += ys;
                    if (d1 >= 0)
                    {
                        x1 += xs;
                        d1 -= 2 * dy;
                    }
                    if (d2 >= 0)
                    {
                        z1 += zs;
                        d2 -= 2 * dy;
                    }
                    d1 += 2 * dx;
                    d2 += 2 * dz;
                    if (_zBuffer.CheckAndSetZValue(x1, y1, z1 + zError))
                        yield return new Point3D(x1, y1, z1);
                }
            }
            else
            {
                d1 = 2 * dy - dz;
                d2 = 2 * dx - dz;
                while (Math.Abs((int)z1 - (int)p2.Z) > dE)
                {
                    z1 += zs;
                    if (d1 >= 0)
                    {
                        y1 += ys;
                        d1 -= 2 * dz;
                    }
                    if (d2 >= 0)
                    {
                        x1 += xs;
                        d2 -= 2 * dz;
                    }
                    d1 += 2 * dy;
                    d2 += 2 * dx;
                    if (_zBuffer.CheckAndSetZValue(x1, y1, z1 + zError))
                        yield return new Point3D(x1, y1, z1);
                }
            }

            if (_zBuffer.CheckAndSetZValue(p2.X, p2.Y, p2.Z + zError))
                yield return p2;
        }
    }
}