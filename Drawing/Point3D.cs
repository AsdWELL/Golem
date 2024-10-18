namespace GolemApp.Drawing
{
    public class Point3D(double x, double y, double z)
    {
        public double X { get; set; } = x;

        public double Y { get; set; } = y;

        public double Z { get; set; } = z;

        public double W { get; set; } = 1;

        public void Deconstruct(out double x, out double y, out double z, out double w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
