
namespace Vectors;

struct Vector2i {
	public int X;
	public int Y;

	public Vector2i(int x, int y){ X = x;  Y = y; }
	public static Vector2i operator -(Vector2i a, Vector2i b) {
		return new(a.X - b.X, a.Y - b.Y);
	}
	public static Vector2u operator +(Vector2u a, Vector2i b) {
		return new((uint)((int)a.X + b.X), (uint)((int)a.Y + b.Y));
	}
}

struct Vector2u {
	public uint X;
	public uint Y;

	public Vector2u(uint x, uint y){ X = x;  Y = y; }
	public static explicit operator Vector2i(Vector2u a) {
		return new() { X = (int)a.X, Y = (int)a.Y };
	}
	public static Vector2u operator -(Vector2u a, Vector2u b) {
		return new(a.X - b.X, a.Y - b.Y);
	}
	public static Vector2u operator +(Vector2u a, Vector2u b) {
		return new(a.X + b.X, a.Y + b.Y);
	}
	public static bool operator ==(Vector2u a, Vector2u b) {
		return a.X == b.X && a.Y == b.Y;
	}
	public static bool operator !=(Vector2u a, Vector2u b) {
		return a.X != b.X || a.Y != b.Y;
	}
  public override string ToString() {
		return $"Vector2u: X = {X}; Y = {Y}";
  }
}