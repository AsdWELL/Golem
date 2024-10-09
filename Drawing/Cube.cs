namespace GolemApp.Drawing
{
    /// <summary>
    /// Класс, представляющий куб
    /// </summary>
    /// <param name="vertices">Массив вершин куба</param>
    public class Cube(Point3D[] vertices)
    {
        /// <summary>
        /// Массив вершин куба
        /// </summary>
        public Point3D[] Vertices { get; set; } = vertices;

        /// <summary>
        /// Представляет каждую грань куба как массив треугольников
        /// </summary>
        /// <returns>Двумерный массив треугольников</returns>
        public Triangle[][] GetSidesAsTriangles()
        {
            return [
                    [
                        new Triangle(Vertices[0], Vertices[1], Vertices[2]),
                        new Triangle(Vertices[1], Vertices[2], Vertices[3])
                    ],
                    [
                        new Triangle(Vertices[4], Vertices[5], Vertices[6]),
                        new Triangle(Vertices[5], Vertices[6], Vertices[7])
                    ],
                    [
                        new Triangle(Vertices[0], Vertices[4], Vertices[1]),
                        new Triangle(Vertices[5], Vertices[4], Vertices[1])
                    ],
                    [
                        new Triangle(Vertices[3], Vertices[5], Vertices[7]),
                        new Triangle(Vertices[3], Vertices[5], Vertices[1])
                    ],
                    [
                        new Triangle(Vertices[2], Vertices[6], Vertices[3]),
                        new Triangle(Vertices[7], Vertices[6], Vertices[3])
                    ],
                    [
                        new Triangle(Vertices[2], Vertices[6], Vertices[4]),
                        new Triangle(Vertices[2], Vertices[0], Vertices[4])
                    ],
            ];
        }
    }
}
