namespace Golem
{
    public class Point(float x, float y, float z)
    {
        public float X { get; set; } = x;

        public float Y { get; set; } = y;

        public float Z { get; set; } = z;

        public void Deconstruct(out float x, out float y, out float z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
