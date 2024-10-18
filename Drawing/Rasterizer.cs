using static GolemApp.Extensions.Utils;

namespace GolemApp.Drawing
{
    public static class Rasterizer
    {
        public static IEnumerable<Point3D> GetTrianglePoints(List<Point3D> vertices)
        {
            vertices.Sort((x, y) => Floor(x.Y - y.Y));

            Point3D p1 = vertices[0],
                    p2 = vertices[1],
                    p3 = vertices[2];

            double dP1P2, dP1P3;

            if (p2.Y - p1.Y > 0)
                dP1P2 = (p2.X - p1.X) / (p2.Y - p1.Y);
            else
                dP1P2 = 0;

            if (p3.Y - p1.Y > 0)
                dP1P3 = (p3.X - p1.X) / (p3.Y - p1.Y);
            else
                dP1P3 = 0;

            if (dP1P2 > dP1P3)
            {
                for (int y = (int)p1.Y; y <= (int)p3.Y; y++)
                {
                    if (y < p2.Y)
                        foreach (Point3D p in ProcessScanLine(y, p1, p3, p1, p2))
                            yield return p;
                    else
                        foreach (Point3D p in ProcessScanLine(y, p1, p3, p2, p3))
                            yield return p;
                }
            }
            else
            {
                for (int y = (int)p1.Y; y <= (int)p3.Y; y++)
                {
                    if (y < p2.Y)
                        foreach (Point3D p in ProcessScanLine(y, p1, p2, p1, p3))
                            yield return p;
                    else
                        foreach (Point3D p in ProcessScanLine(y, p2, p3, p1, p3))
                            yield return p;
                }
            }
        }

        private static double Clamp(double value, double min = 0, double max = 1)
        {
            return Math.Max(min, Math.Min(value, max));
        }

        private static double Interpolate(double min, double max, double gradient)
        {
            return min + (max - min) * Clamp(gradient);
        }

        private static IEnumerable<Point3D> ProcessScanLine(int y, Point3D pa, Point3D pb, Point3D pc, Point3D pd)
        {
            double gradient1 = pa.Y != pb.Y ? (y - pa.Y) / (pb.Y - pa.Y) : 1;
            double gradient2 = pc.Y != pd.Y ? (y - pc.Y) / (pd.Y - pc.Y) : 1;

            int sx = (int)Interpolate(pa.X, pb.X, gradient1);
            int ex = (int)Interpolate(pc.X, pd.X, gradient2);

            double z1 = Interpolate(pa.Z, pb.Z, gradient1);
            double z2 = Interpolate(pc.Z, pd.Z, gradient2);

            for (int x = sx; x < ex; x++)
            {
                float gradient = (x - sx) / (float)(ex - sx);

                double z = Interpolate(z1, z2, gradient);
                yield return new Point3D(x, y, z);
            }

            for (int x = ex; x < sx; x++)
            {
                float gradient = (x - sx) / (float)(ex - sx);

                double z = Interpolate(z1, z2, gradient);
                yield return new Point3D(x, y, z);
            }
        }
    }
}
