using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace yTools
{
    public struct Vector2
    {
        public double x, y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{x},{y}";

        public static implicit operator System.Numerics.Vector2(Vector2 vector2) => new((float) vector2.x, (float) vector2.y);

        public static implicit operator Vector2(System.Numerics.Vector2 vector2) => new(vector2.X, vector2.Y);
    }

    public struct Vector3
    {
        public double x, y, z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() => $"{x},{y}";

        public static implicit operator System.Numerics.Vector3(Vector3 vector3) => new((float)vector3.x, (float)vector3.y, (float)vector3.z);

        public static implicit operator Vector3(System.Numerics.Vector3 vector3) => new(vector3.X, vector3.Y, vector3.Z);
    }
}
