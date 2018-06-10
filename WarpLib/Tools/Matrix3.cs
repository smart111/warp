﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math.Decompositions;

namespace Warp.Tools
{
    public class Matrix3
    {
        public float M11, M21, M31;
        public float M12, M22, M32;
        public float M13, M23, M33;

        public float3 C1 => new float3(M11, M21, M31);
        public float3 C2 => new float3(M12, M22, M32);
        public float3 C3 => new float3(M13, M23, M33);

        public float3 R1 => new float3(M11, M12, M13);
        public float3 R2 => new float3(M21, M22, M23);
        public float3 R3 => new float3(M31, M32, M33);

        public Matrix3()
        {
            M11 = 1;
            M21 = 0;
            M31 = 0;

            M12 = 0;
            M22 = 1;
            M32 = 0;

            M13 = 0;
            M23 = 0;
            M33 = 1;
        }

        public Matrix3(float m11, float m21, float m31,
                       float m12, float m22, float m32,
                       float m13, float m23, float m33)
        {
            M11 = m11;
            M21 = m21;
            M31 = m31;

            M12 = m12;
            M22 = m22;
            M32 = m32;

            M13 = m13;
            M23 = m23;
            M33 = m33;
        }

        public Matrix3(float[,] m)
        {
            M11 = m[0, 0];
            M21 = m[1, 0];
            M31 = m[2, 0];

            M12 = m[0, 1];
            M22 = m[1, 1];
            M32 = m[2, 1];

            M13 = m[0, 2];
            M23 = m[1, 2];
            M33 = m[2, 2];
        }

        public Matrix3(float[] m)
        {
            M11 = m[0];
            M21 = m[1];
            M31 = m[2];

            M12 = m[3];
            M22 = m[4];
            M32 = m[5];

            M13 = m[6];
            M23 = m[7];
            M33 = m[8];
        }

        public Matrix3(Matrix4 m)
        {
            M11 = m.M11;
            M21 = m.M21;
            M31 = m.M31;

            M12 = m.M12;
            M22 = m.M22;
            M32 = m.M32;

            M13 = m.M13;
            M23 = m.M23;
            M33 = m.M33;
        }

        public Matrix3(float3 v1, float3 v2)
        {
            M11 = v1.X * v2.X;
            M21 = v1.Y * v2.X;
            M31 = v1.Z * v2.X;

            M12 = v1.X * v2.Y;
            M22 = v1.Y * v2.Y;
            M32 = v1.Z * v2.Y;
            
            M13 = v1.X * v2.Z;
            M23 = v1.Y * v2.Z;
            M33 = v1.Z * v2.Z;
        }

        public Matrix3 Transposed()
        {
            return new Matrix3(M11, M12, M13,
                               M21, M22, M23,
                               M31, M32, M33);
        }

        public Matrix3 NormalizedColumns()
        {
            return FromColumns(C1.Normalized(), C2.Normalized(), C3.Normalized());
        }

        public float Determinant()
        {
            return M11 * M22 * M33 + M12 * M23 * M31 + M13 * M21 * M32 -
                  (M13 * M22 * M31 + M11 * M23 * M32 + M12 * M21 * M33);
        }

        public void SVD(out Matrix3 U, out float[] S, out Matrix3 V)
        {
            SingularValueDecompositionF Decomp = new SingularValueDecompositionF(ToMultidimArray(), true, true);

            U = new Matrix3(Decomp.LeftSingularVectors);
            S = Decomp.Diagonal;
            V = new Matrix3(Decomp.RightSingularVectors);
        }

        public float[] ToArray()
        {
            return new[] { M11, M21, M31, M12, M22, M32, M31, M32, M33 };
        }

        public float[,] ToMultidimArray()
        {
            float[,] Result = { { M11, M12, M13 }, { M21, M22, M23 }, { M31, M32, M33 } };
            return Result;
        }

        public string ToMatlabString()
        {
            return $"[{M11}, {M12}, {M13}; {M21}, {M22}, {M23}; {M31}, {M32}, {M33};]";
        }

        public static Matrix3 FromColumns(float3 c1, float3 c2, float3 c3)
        {
            return new Matrix3(c1.X, c1.Y, c1.Z,
                               c2.X, c2.Y, c2.Z,
                               c3.X, c3.Y, c3.Z);
        }

        public static Matrix3 Zero()
        {
            return new Matrix3(0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static Matrix3 Scale(float scaleX, float scaleY, float scaleZ)
        {
            return new Matrix3(scaleX, 0, 0,
                               0, scaleY, 0,
                               0, 0, scaleZ);
        }

        public static Matrix3 RotateX(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);

            return new Matrix3(1, 0, 0, 0, c, s, 0, -s, c);
        }

        public static Matrix3 RotateY(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);

            return new Matrix3(c, 0, -s, 0, 1, 0, s, 0, c);
        }

        public static Matrix3 RotateZ(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);

            return new Matrix3(c, s, 0, -s, c, 0, 0, 0, 1);
        }

        public static Matrix3 RotateAxis(float3 axis, float angle)
        {
            float3 r = axis.Normalized();
            float CT = (float)Math.Cos(angle);
            float ST = (float)Math.Sin(angle);

            return new Matrix3(CT + (1 - CT) * r.X * r.X,       (1 - CT) * r.X * r.Y + r.Z * ST, (1 - CT) * r.X * r.Z - r.Y * ST,
                               (1 - CT) * r.X * r.Y - r.Z * ST, CT + (1 - CT) * r.Y * r.Y,       (1 - CT) * r.Y * r.Z + r.X * ST,
                               (1 - CT) * r.X * r.Z + r.Y * ST, (1 - CT) * r.Y * r.Z - r.X * ST, CT + (1 - CT) * r.Z * r.Z);
        }

        public static Matrix3 Euler(float rot, float tilt, float psi)
        {
            float ca, sa, cb, sb, cg, sg;
            float cc, cs, sc, ss;

            ca = (float)Math.Cos(rot);
            cb = (float)Math.Cos(tilt);
            cg = (float)Math.Cos(psi);
            sa = (float)Math.Sin(rot);
            sb = (float)Math.Sin(tilt);
            sg = (float)Math.Sin(psi);
            cc = cb * ca;
            cs = cb * sa;
            sc = sb * ca;
            ss = sb * sa;

            Matrix3 A = new Matrix3();
            A.M11 = cg * cc - sg * sa;
            A.M12 = cg * cs + sg * ca;
            A.M13 = -cg * sb;
            A.M21 = -sg * cc - cg * sa;
            A.M22 = -sg * cs + cg * ca;
            A.M23 = sg * sb;
            A.M31 = sc;
            A.M32 = ss;
            A.M33 = cb;

            return A;
        }

        public static Matrix3 Euler(float3 angles)
        {
            return Euler(angles.X, angles.Y, angles.Z);
        }

        public static Matrix3 FromPointSets(float3[] original, float3[] transformed)
        {
            Matrix3 H = Matrix3.Zero();
            for (int i = 0; i < original.Length; i++)
                H += new Matrix3(original[i], transformed[i]);

            Matrix3 U, V;
            float[] S;
            H.SVD(out U, out S, out V);

            Matrix3 R = V * U.Transposed();
            if (R.Determinant() < 0)
            {
                V.M13 = -V.M13;
                V.M23 = -V.M23;
                V.M33 = -V.M33;

                R = V * U.Transposed();
            }

            return R;
        }

        public static float3 EulerFromMatrix(Matrix3 a)
        {
            float alpha, beta, gamma;
            float abs_sb, sign_sb;

            abs_sb = (float)Math.Sqrt(a.M13 * a.M13 + a.M23 * a.M23);
            if (abs_sb > 16 * 1.192092896e-07f)
            {
                gamma = (float)Math.Atan2(a.M23, -a.M13);
                alpha = (float)Math.Atan2(a.M32, a.M31);
                if (Math.Abs((float)Math.Sin(gamma)) < 1.192092896e-07f)
                    sign_sb = Math.Sign(-a.M13 / Math.Cos(gamma));
                else
                    sign_sb = (Math.Sin(gamma) > 0) ? Math.Sign(a.M23) : -Math.Sign(a.M23);
                beta = (float)Math.Atan2(sign_sb * abs_sb, a.M33);
            }
            else
            {
                if (Math.Sign(a.M33) > 0)
                {
                    // Let's consider the matrix as a rotation around Z
                    alpha = 0;
                    beta = 0;
                    gamma = (float)Math.Atan2(-a.M21, a.M11);
                }
                else
                {
                    alpha = 0;
                    beta = (float)Math.PI;
                    gamma = (float)Math.Atan2(a.M21, -a.M11);
                }
            }

            return new float3(alpha, beta, gamma);
        }

        public static Matrix3 operator +(Matrix3 o1, Matrix3 o2)
        {
            return new Matrix3(o1.M11 + o2.M11, o1.M21 + o2.M21, o1.M31 + o2.M31,
                               o1.M12 + o2.M12, o1.M22 + o2.M22, o1.M32 + o2.M32,
                               o1.M13 + o2.M13, o1.M23 + o2.M23, o1.M33 + o2.M33);
        }

        public static Matrix3 operator -(Matrix3 o1, Matrix3 o2)
        {
            return new Matrix3(o1.M11 - o2.M11, o1.M21 - o2.M21, o1.M31 - o2.M31,
                               o1.M12 - o2.M12, o1.M22 - o2.M22, o1.M32 - o2.M32,
                               o1.M13 - o2.M13, o1.M23 - o2.M23, o1.M33 - o2.M33);
        }

        public static Matrix3 operator *(Matrix3 o1, Matrix3 o2)
        {
            return new Matrix3(o1.M11 * o2.M11 + o1.M12 * o2.M21 + o1.M13 * o2.M31, o1.M21 * o2.M11 + o1.M22 * o2.M21 + o1.M23 * o2.M31, o1.M31 * o2.M11 + o1.M32 * o2.M21 + o1.M33 * o2.M31,
                               o1.M11 * o2.M12 + o1.M12 * o2.M22 + o1.M13 * o2.M32, o1.M21 * o2.M12 + o1.M22 * o2.M22 + o1.M23 * o2.M32, o1.M31 * o2.M12 + o1.M32 * o2.M22 + o1.M33 * o2.M32,
                               o1.M11 * o2.M13 + o1.M12 * o2.M23 + o1.M13 * o2.M33, o1.M21 * o2.M13 + o1.M22 * o2.M23 + o1.M23 * o2.M33, o1.M31 * o2.M13 + o1.M32 * o2.M23 + o1.M33 * o2.M33);
        }

        public static float3 operator *(Matrix3 o1, float3 o2)
        {
            return new float3(o1.M11 * o2.X + o1.M12 * o2.Y + o1.M13 * o2.Z,
                              o1.M21 * o2.X + o1.M22 * o2.Y + o1.M23 * o2.Z,
                              o1.M31 * o2.X + o1.M32 * o2.Y + o1.M33 * o2.Z);
        }

        public static Matrix3 operator /(Matrix3 o1, float o2)
        {
            return new Matrix3(o1.M11 / o2, o1.M21 / o2, o1.M31 / o2,
                               o1.M12 / o2, o1.M22 / o2, o1.M32 / o2,
                               o1.M13 / o2, o1.M23 / o2, o1.M33 / o2);
        }
    }
}
