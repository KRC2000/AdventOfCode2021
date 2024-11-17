using System.Collections.Generic;
using Vectors;

namespace cs;

class Line {
	public Vector2u Start;
	public Vector2u End;

	public Line() {}
	public Line(uint x1, uint y1, uint x2, uint y2){ Start = new(x1, y1); End = new(x2, y2);}

	public List<Vector2u> GetPoints() {
		List<Vector2u> r = [];
		// Vector2u vec = End - Start;
		Vector2i vec = (Vector2i)End - (Vector2i)Start;
		Vector2i step = new(Math.Sign(vec.X), Math.Sign(vec.Y));
		Vector2u p = Start;
		while (true) {
			r.Add(p);
			if (p == End) break;
			p += step;
		}
		return r;
	}

}

class Program {
	static readonly Dictionary<Vector2u, uint> counter = [];

	static void Main(string[] args) {
		StreamReader s = new("../input");

		string? line = null;
		while (true) {
			line = s.ReadLine();
			if (line == null) break;

			string[] points = line.Split(" -> ");
			string[] start = points[0].Split(',');
			string[] end = points[1].Split(',');
			uint x1 = uint.Parse(start[0]);
			uint y1 = uint.Parse(start[1]);
			uint x2 = uint.Parse(end[0]);
			uint y2 = uint.Parse(end[1]);
			if (x1 != x2 && y1 != y2) continue;

			Line l = new() {
				Start = new(x1, y1),
				End = new(x2, y2)
			};

			foreach (Vector2u p in l.GetPoints()) {
				if (counter.ContainsKey(p)) counter[p]++;
				else counter.Add(p, 1);
			}
		}

		Console.WriteLine(counter.Count);

		uint count = 0;
		foreach (var p in counter) {
			if (p.Value >= 2) count++;
		}

		Console.WriteLine(count);

		s.Close();
	}
}
