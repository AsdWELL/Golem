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
            _points.Add(new Point(-2, 12, 0));
        }
    }
}
