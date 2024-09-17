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
        private double _scaleX;

        /// <summary>
        /// Масштаб по У
        /// </summary>
        private double _scaleY;

        /// <summary>
        /// Смещение по Х
        /// </summary>
        private double _offsetX;

        /// <summary>
        /// Смещение по У
        /// </summary>
        private double _offsetY;

        public Figure(double scaleX, double scaleY, double offsetX, double offsetY)
        {
            _scaleX = scaleX;
            _scaleY = scaleY;
            _offsetX = offsetX;
            _offsetY = offsetY;
            
            AddPoints();
        }

        private void AddPoints()
        {
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
            _points.Add(new Point(5, 3, 1)); //16
            _points.Add(new Point(4, -3, 1)); //17
            _points.Add(new Point(4, -1, 1)); //18
            _points.Add(new Point(6, -1, 1)); //19
            _points.Add(new Point(6, -11, 1)); //20
            _points.Add(new Point(8, -11, 1)); //21
            _points.Add(new Point(8, 7, 1)); //22
            _points.Add(new Point(3, 7, 1)); //23
            _points.Add(new Point(3, 12, 1)); //24
            _points.Add(new Point(-2, 10.5, 1)); //25
            _points.Add(new Point(3, 10.5, 1)); //26
            _points.Add(new Point(3, 10, 1)); //27
            _points.Add(new Point(2, 10, 1)); //28
            _points.Add(new Point(2, 8, 1)); //29
            _points.Add(new Point(1, 8, 1)); //30
            _points.Add(new Point(1, 10, 1)); //31
            _points.Add(new Point(0, 10, 1)); //32
            _points.Add(new Point(0, 8, 1)); //33
            _points.Add(new Point(-1, 8, 1)); //34
            _points.Add(new Point(-1, 10, 1)); //35
            _points.Add(new Point(-2, 10, 1)); //36
        }
    }
}
