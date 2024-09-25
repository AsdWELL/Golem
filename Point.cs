namespace GolemApp
{
    public class Point(float x, float y, float z)
    {
        public float X { get; set; } = x;

        public float Y { get; set; } = y;

        public float Z { get; set; } = z;

        public float W { get; set; } = 1;

        public void Deconstruct(out float x, out float y, out float z, out float w)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
