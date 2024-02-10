namespace yTools
{
    public static class Vectors
    {
        public struct Vector2
        {
            public double X, Y;

            public Vector2(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString() => $"{X},{Y}";

            public static explicit operator System.Numerics.Vector2(Vector2 vector2) => new System.Numerics.Vector2((float)vector2.X, (float)vector2.Y);

            public static implicit operator Vector2(System.Numerics.Vector2 vector2) => new Vector2(vector2.X, vector2.Y);
        }

        public struct Vector3
        {
            public double X, Y, Z;

            public Vector3(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public override string ToString() => $"{X},{Y}";

            public static explicit operator System.Numerics.Vector3(Vector3 vector3) => new System.Numerics.Vector3((float)vector3.X, (float)vector3.Y, (float)vector3.Z);

            public static implicit operator Vector3(System.Numerics.Vector3 vector3) => new Vector3(vector3.X, vector3.Y, vector3.Z);
        }
    }
}
