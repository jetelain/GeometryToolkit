
namespace Pmad.Geometry.Algorithms
{
	public static class PointInPolygon
	{
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2I> path, Vector2I pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2I.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2I.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2F> path, Vector2F pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2F.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2F.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2L> path, Vector2L pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2L.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2L.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2D> path, Vector2D pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2D.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2D.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2IS> path, Vector2IS pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2IS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2IS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2FS> path, Vector2FS pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2FS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2FS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2LS> path, Vector2LS pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2LS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2LS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2DS> path, Vector2DS pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2DS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2DS.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2FN> path, Vector2FN pt)
        {
            var cnt = path.Count;
            if (cnt < 3) 
            {
                return PointInPolygonResult.Outside;
            }
            bool result = false;
            var ip = path[0];
            for (int i = 1; i <= cnt; ++i)
            {
                var ipNext = (i == cnt ? path[0] : path[i]);
                if (ipNext.Y == pt.Y)
                {
                    if ((ipNext.X == pt.X) || (ip.Y == pt.Y && ((ipNext.X > pt.X) == (ip.X < pt.X))))
                    {
                        return PointInPolygonResult.Boundary;
                    }
                }
                if ((ip.Y < pt.Y) != (ipNext.Y < pt.Y))
                {
                    if (ip.X >= pt.X)
                    {
                        if (ipNext.X > pt.X) 
                        {
                            result = !result;
                        }
                        else
                        {
                            var d = Vector2FN.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                    else
                    {
                        if (ipNext.X > pt.X)
                        {
                            var d = Vector2FN.CrossProduct(ip - pt, ipNext - pt);
                            if (d == 0) 
                            {
                                return PointInPolygonResult.Boundary;
                            }
                            else if ((d > 0) == (ipNext.Y > ip.Y))
                            {
                                result = !result;
                            }
                        }
                    }
                }
                ip = ipNext;
            }
            return result ? PointInPolygonResult.Inside : PointInPolygonResult.Outside;
        }
	}
}
