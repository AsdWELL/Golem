namespace GolemApp.Drawing
{
    /// <summary>
    /// Класс, представляющий трегуольник
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    public class Triangle(Point3D v1, Point3D v2, Point3D v3)
    {
        public Point3D[] Vertices { get; set; } = [v1, v2, v3];
    }
}
