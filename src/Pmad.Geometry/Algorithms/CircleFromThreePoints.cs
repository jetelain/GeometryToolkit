using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Algorithms
{
	public static class CircleFromThreePoints
	{
        public static Circle<float,Vector2F> Compute(ShapeSettings<float,Vector2F> settings, Vector2F a, Vector2F b, Vector2F c)
        {
            var o = (Vector2F.Min(Vector2F.Min(a, b), c) + Vector2F.Max(Vector2F.Max(a, b), c)) / 2;
            var da = a - o;
            var db = b - o;
            var dc = c - o;
            var d = (da.X * (db.Y - dc.Y) + db.X * (dc.Y - da.Y) + dc.X * (da.Y - db.Y)) * 2;
            if (d == 0)
            {
                // XXX: Fallback to FromTwoPoints ?
                return new (settings, Vector2F.Zero, 0);
            }
            //var x = ((da.X * da.X + da.Y * da.Y) * (db.Y - dc.Y) + (db.X * db.X + db.Y * db.Y) * (dc.Y - da.Y) + (dc.X * dc.X + dc.Y * dc.Y) * (da.Y - db.Y)) / d;
            var x =   (da.LengthSquared()          * (db.Y - dc.Y) + db.LengthSquared()          * (dc.Y - da.Y) + dc.LengthSquared()          * (da.Y - db.Y)) / d;
            //var y = ((da.X * da.X + da.Y * da.Y) * (dc.X - db.X) + (db.X * db.X + db.Y * db.Y) * (da.X - dc.X) + (dc.X * dc.X + dc.Y * dc.Y) * (db.X - da.X)) / d;
            var y =   (da.LengthSquared()          * (dc.X - db.X) + db.LengthSquared()          * (da.X - dc.X) + dc.LengthSquared()          * (db.X - da.X)) / d;
            var p = o + new Vector2F(x, y);
            var sqR = MathF.Max((p - a).LengthSquared(), MathF.Max((p - b).LengthSquared(), (p - c).LengthSquared()));
            return new (settings,p, MathF.Sqrt(sqR));
        }
        public static Circle<double,Vector2D> Compute(ShapeSettings<double,Vector2D> settings, Vector2D a, Vector2D b, Vector2D c)
        {
            var o = (Vector2D.Min(Vector2D.Min(a, b), c) + Vector2D.Max(Vector2D.Max(a, b), c)) / 2;
            var da = a - o;
            var db = b - o;
            var dc = c - o;
            var d = (da.X * (db.Y - dc.Y) + db.X * (dc.Y - da.Y) + dc.X * (da.Y - db.Y)) * 2;
            if (d == 0)
            {
                // XXX: Fallback to FromTwoPoints ?
                return new (settings, Vector2D.Zero, 0);
            }
            //var x = ((da.X * da.X + da.Y * da.Y) * (db.Y - dc.Y) + (db.X * db.X + db.Y * db.Y) * (dc.Y - da.Y) + (dc.X * dc.X + dc.Y * dc.Y) * (da.Y - db.Y)) / d;
            var x =   (da.LengthSquared()          * (db.Y - dc.Y) + db.LengthSquared()          * (dc.Y - da.Y) + dc.LengthSquared()          * (da.Y - db.Y)) / d;
            //var y = ((da.X * da.X + da.Y * da.Y) * (dc.X - db.X) + (db.X * db.X + db.Y * db.Y) * (da.X - dc.X) + (dc.X * dc.X + dc.Y * dc.Y) * (db.X - da.X)) / d;
            var y =   (da.LengthSquared()          * (dc.X - db.X) + db.LengthSquared()          * (da.X - dc.X) + dc.LengthSquared()          * (db.X - da.X)) / d;
            var p = o + new Vector2D(x, y);
            var sqR = Math.Max((p - a).LengthSquared(), Math.Max((p - b).LengthSquared(), (p - c).LengthSquared()));
            return new (settings,p, Math.Sqrt(sqR));
        }
        public static Circle<float,Vector2FS> Compute(ShapeSettings<float,Vector2FS> settings, Vector2FS a, Vector2FS b, Vector2FS c)
        {
            var o = (Vector2FS.Min(Vector2FS.Min(a, b), c) + Vector2FS.Max(Vector2FS.Max(a, b), c)) / 2;
            var da = a - o;
            var db = b - o;
            var dc = c - o;
            var d = (da.X * (db.Y - dc.Y) + db.X * (dc.Y - da.Y) + dc.X * (da.Y - db.Y)) * 2;
            if (d == 0)
            {
                // XXX: Fallback to FromTwoPoints ?
                return new (settings, Vector2FS.Zero, 0);
            }
            //var x = ((da.X * da.X + da.Y * da.Y) * (db.Y - dc.Y) + (db.X * db.X + db.Y * db.Y) * (dc.Y - da.Y) + (dc.X * dc.X + dc.Y * dc.Y) * (da.Y - db.Y)) / d;
            var x =   (da.LengthSquared()          * (db.Y - dc.Y) + db.LengthSquared()          * (dc.Y - da.Y) + dc.LengthSquared()          * (da.Y - db.Y)) / d;
            //var y = ((da.X * da.X + da.Y * da.Y) * (dc.X - db.X) + (db.X * db.X + db.Y * db.Y) * (da.X - dc.X) + (dc.X * dc.X + dc.Y * dc.Y) * (db.X - da.X)) / d;
            var y =   (da.LengthSquared()          * (dc.X - db.X) + db.LengthSquared()          * (da.X - dc.X) + dc.LengthSquared()          * (db.X - da.X)) / d;
            var p = o + new Vector2FS(x, y);
            var sqR = MathF.Max((p - a).LengthSquared(), MathF.Max((p - b).LengthSquared(), (p - c).LengthSquared()));
            return new (settings,p, MathF.Sqrt(sqR));
        }
        public static Circle<double,Vector2DS> Compute(ShapeSettings<double,Vector2DS> settings, Vector2DS a, Vector2DS b, Vector2DS c)
        {
            var o = (Vector2DS.Min(Vector2DS.Min(a, b), c) + Vector2DS.Max(Vector2DS.Max(a, b), c)) / 2;
            var da = a - o;
            var db = b - o;
            var dc = c - o;
            var d = (da.X * (db.Y - dc.Y) + db.X * (dc.Y - da.Y) + dc.X * (da.Y - db.Y)) * 2;
            if (d == 0)
            {
                // XXX: Fallback to FromTwoPoints ?
                return new (settings, Vector2DS.Zero, 0);
            }
            //var x = ((da.X * da.X + da.Y * da.Y) * (db.Y - dc.Y) + (db.X * db.X + db.Y * db.Y) * (dc.Y - da.Y) + (dc.X * dc.X + dc.Y * dc.Y) * (da.Y - db.Y)) / d;
            var x =   (da.LengthSquared()          * (db.Y - dc.Y) + db.LengthSquared()          * (dc.Y - da.Y) + dc.LengthSquared()          * (da.Y - db.Y)) / d;
            //var y = ((da.X * da.X + da.Y * da.Y) * (dc.X - db.X) + (db.X * db.X + db.Y * db.Y) * (da.X - dc.X) + (dc.X * dc.X + dc.Y * dc.Y) * (db.X - da.X)) / d;
            var y =   (da.LengthSquared()          * (dc.X - db.X) + db.LengthSquared()          * (da.X - dc.X) + dc.LengthSquared()          * (db.X - da.X)) / d;
            var p = o + new Vector2DS(x, y);
            var sqR = Math.Max((p - a).LengthSquared(), Math.Max((p - b).LengthSquared(), (p - c).LengthSquared()));
            return new (settings,p, Math.Sqrt(sqR));
        }
        public static Circle<float,Vector2FN> Compute(ShapeSettings<float,Vector2FN> settings, Vector2FN a, Vector2FN b, Vector2FN c)
        {
            var o = (Vector2FN.Min(Vector2FN.Min(a, b), c) + Vector2FN.Max(Vector2FN.Max(a, b), c)) / 2;
            var da = a - o;
            var db = b - o;
            var dc = c - o;
            var d = (da.X * (db.Y - dc.Y) + db.X * (dc.Y - da.Y) + dc.X * (da.Y - db.Y)) * 2;
            if (d == 0)
            {
                // XXX: Fallback to FromTwoPoints ?
                return new (settings, Vector2FN.Zero, 0);
            }
            //var x = ((da.X * da.X + da.Y * da.Y) * (db.Y - dc.Y) + (db.X * db.X + db.Y * db.Y) * (dc.Y - da.Y) + (dc.X * dc.X + dc.Y * dc.Y) * (da.Y - db.Y)) / d;
            var x =   (da.LengthSquared()          * (db.Y - dc.Y) + db.LengthSquared()          * (dc.Y - da.Y) + dc.LengthSquared()          * (da.Y - db.Y)) / d;
            //var y = ((da.X * da.X + da.Y * da.Y) * (dc.X - db.X) + (db.X * db.X + db.Y * db.Y) * (da.X - dc.X) + (dc.X * dc.X + dc.Y * dc.Y) * (db.X - da.X)) / d;
            var y =   (da.LengthSquared()          * (dc.X - db.X) + db.LengthSquared()          * (da.X - dc.X) + dc.LengthSquared()          * (db.X - da.X)) / d;
            var p = o + new Vector2FN(x, y);
            var sqR = MathF.Max((p - a).LengthSquared(), MathF.Max((p - b).LengthSquared(), (p - c).LengthSquared()));
            return new (settings,p, MathF.Sqrt(sqR));
        }
	}
}
