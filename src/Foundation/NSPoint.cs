//
// Copyright 2010, Novell, Inc.
// Copyright 2011, 2012 Xamarin Inc
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Runtime.InteropServices;

// For now, only support MAC64 for NSPoint in order to make sure
// we didn't mess up the 32 bit build
#if MAC64
namespace MonoMac.Foundation {
	[StructLayout(LayoutKind.Sequential)]
	public struct NSPoint {
		
		public static readonly NSPoint Empty;
		
		public NSPoint(System.Drawing.PointF point)
		{
			X = point.X;
			Y = point.Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(NSPoint left, NSPoint right)
		{
			return left.X == right.X && left.Y == right.Y;
		}

		public static bool operator !=(NSPoint left, NSPoint right)
		{
			return left.X != right.X || left.Y != right.Y;
		}
		
		public static NSPoint operator +(NSPoint pt, NSSize sz)
		{
			return new NSPoint (pt.X + sz.Width, pt.Y + sz.Height);
		}

		public static NSPoint operator -(NSPoint pt, NSSize sz)
		{
			return new NSPoint (pt.X - sz.Width, pt.Y - sz.Height);
		}

		public static implicit operator NSPoint (System.Drawing.PointF point)
		{
			return new NSPoint (point.X, point.Y);
		}
		
		public static explicit operator System.Drawing.PointF (NSPoint point)
		{
			return new System.Drawing.PointF ((float)point.X, (float)point.Y);
		}

		public NSPoint(int x, int y)
		{
#if MAC64
			X = (double)x;
			Y = (double)y;
#else
			X = (float)x;
			Y = (float)y;
#endif
		}
#if MAC64
		public NSPoint(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X;
		public double Y;
#else
		public NSPoint(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X;
		public float Y;
#endif
	}
}
#endif