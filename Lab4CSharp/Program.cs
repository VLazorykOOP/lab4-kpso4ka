using System;
using System.Drawing;

namespace Program
{
    class Trapeze
    {
        private int a, b, c, d;
        private readonly int color;

        public Trapeze(int a, int b, int c, int d, int color)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.color = color;
        }

        public string this[int index]
        {
            get
            {
                if (index == 0) return a.ToString();
                else if (index == 1) return b.ToString();
                else if (index == 2) return c.ToString();
                else if (index == 3) return d.ToString();
                else if (index == 4) return color.ToString();
                else return "Error";
            }
            set
            {
                if (index == 0) a = int.Parse(value);
                else if (index == 1) b = int.Parse(value);
                else if (index == 2) c = int.Parse(value);
                else if (index == 3) d = int.Parse(value);
            }
        }

        public static Trapeze operator ++(Trapeze trapeze)
        {
            trapeze.a++;
            trapeze.b++;
            trapeze.c++;
            trapeze.d++;
            return trapeze;
        }

        public static Trapeze operator--(Trapeze trapeze)
        {
            trapeze.a--;
            trapeze.b--;
            trapeze.c--;
            trapeze.d--;
            return trapeze;
        }
        public static bool operator true(Trapeze trapeze)
        {
            if (trapeze.a > 0 && trapeze.b > 0 && trapeze.c > 0 && trapeze.d > 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Trapeze trapeze)
        {
            if (trapeze.a <= 0 && trapeze.b <= 0 && trapeze.c <= 0 && trapeze.d <= 0)
            {
                return false;
            }
            return true;
        }
        public static Trapeze operator *(Trapeze trapeze, int num)
        {
            trapeze.a *= num;
            trapeze.b *= num;
            trapeze.c *= num;
            trapeze.d *= num;
            return trapeze;
        }

        public override string ToString()
        {
            return $"A: {a}, B: {b}, C: {c}, D: {d}, Color: {color}";
        }


        public void Print()
        {
            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}\nD: {d}\nColor: {color}");
        }

        public double P()
        {
            return a + b + c + d;
        }

        public double S()
        {
            double p = P() / 2;
            return ((a + b) / (Math.Abs(a - b) * Math.Sqrt((p - a) * (p - b) * (p - a - c) * (p - a - d))));
        }

        public bool IsSquare()
        {
            if (a == b && b == c && c == d) return true;
            return false;
        }

        public int getA()
        {
            return a;
        }
        public int getB()
        {
            return b;
        }
        public int getC()
        {
            return c;
        }
        public int getD()
        {
            return d;
        }
        public int getColor()
        {
            return color;
        }

        public void setA(int newA)
        {
            a = newA;
        }
        public void setB(int newA)
        {
            b = newA;
        }
        public void setC(int newA)
        {
            c = newA;
        }
        public void setD(int newA)
        {
            d = newA;
        }

    }

    class VectorFloat
    {
        private float[] FloatArray;
        private uint size;
        private int codeError;
        private static uint num_vec;

        public VectorFloat()
        {
            FloatArray = new float[1];
            FloatArray[0] = 0;
            size = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorFloat(uint size)
        {
            FloatArray = new float[size];
            for (var i = 0; i < size; i++)
            {
                FloatArray[i] = 0;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        public VectorFloat(uint size, float num)
        {
            FloatArray = new float[size];
            for (var i = 0; i < size; i++)
            {
                FloatArray[i] = num;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        ~VectorFloat()
        {
            Console.WriteLine("Destructor");
        }

        public void inputArr()
        {
            for (var i = 0; i < size; i++)
            {
                float.TryParse(Console.ReadLine(), out FloatArray[i]);
            }
        }

        public void printArr()
        {
            for (var i = 0; i < size; i++)
            {
                Console.Write($"{FloatArray[i]} ");
            }
            Console.WriteLine();
        }

        public void setArr(float num)
        {
            for (var i = 0; i < size; i++)
            {
                FloatArray[i] = num;
            }
        }

        public uint getSize()
        {
            return size;
        }
        public float this[uint index]
        {
            get
            {
                if (index > size)
                {
                    codeError = -1;
                    return 0;
                }
                return FloatArray[index];
            }
            set
            {
                if (index > size)
                {
                    codeError = -1;
                }
                else
                {
                    FloatArray[index] = value;
                }
            }
        }
        public static VectorFloat operator ++(VectorFloat vectorFloat)
        {
            for (var i = 0; i < vectorFloat.size; i++)
            {
                vectorFloat.FloatArray[i]++;
            }
            return vectorFloat;
        }

        public static VectorFloat operator --(VectorFloat vectorFloat)
        {
            for (var i = 0; i < vectorFloat.size; i++)
            {
                vectorFloat.FloatArray[i]--;
            }
            return vectorFloat;
        }
        public static bool operator true(VectorFloat vectorFloat)
        {
            if (vectorFloat.size != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(VectorFloat vectorFloat)
        {
            if (vectorFloat.size != 0)
            {
                return false;
            }
            return true;
        }
        public static VectorFloat operator +(VectorFloat vectorFloat, int num)
        {
            for (var i = 0; i < vectorFloat.size; i++)
            {
                vectorFloat.FloatArray[i] = vectorFloat.FloatArray[i] + num;
            }
            return vectorFloat;
        }

        public static VectorFloat operator +(VectorFloat a, VectorFloat b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.FloatArray[i] += b.FloatArray[i];
            }
            return a;
        }
        public static VectorFloat operator -(VectorFloat vectoruint, int num)
        {
            for (var i = 0; i < vectoruint.size; i++)
            {
                vectoruint.FloatArray[i] = Convert.ToUInt32(vectoruint.FloatArray[i] - num);
            }
            return vectoruint;
        }

        public static VectorFloat operator -(VectorFloat a, VectorFloat b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.FloatArray[i] -= b.FloatArray[i];
            }
            return a;
        }
        public static VectorFloat operator *(VectorFloat vectoruint, int num)
        {
            for (var i = 0; i < vectoruint.size; i++)
            {
                vectoruint.FloatArray[i] = Convert.ToUInt32(vectoruint.FloatArray[i] * num);
            }
            return vectoruint;
        }

        public static VectorFloat operator *(VectorFloat a, VectorFloat b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.FloatArray[i] *= b.FloatArray[i];
            }
            return a;
        }
        public static VectorFloat operator /(VectorFloat vectoruint, int num)
        {
            for (var i = 0; i < vectoruint.size; i++)
            {
                vectoruint.FloatArray[i] = Convert.ToUInt32(vectoruint.FloatArray[i] / num);
            }
            return vectoruint;
        }

        public static VectorFloat operator /(VectorFloat a, VectorFloat b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.FloatArray[i] /= b.FloatArray[i];
            }
            return a;
        }

    }

       class MatrixFloat
    {
        private float[,] FloatArray;
        private uint n,m;
        private int codeError;
        private static uint num_m;

        public MatrixFloat()
        {
            FloatArray = new float[1,1];
            FloatArray[0,0] = 0;
            n = 1;
            m = 1;
            codeError = 0;
            num_m++;
        }

        public MatrixFloat(uint n, uint m)
        {
            FloatArray = new float[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    FloatArray[i, c] = 0;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        public MatrixFloat(uint n, uint m, float num)
        {
            FloatArray = new float[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    FloatArray[i, c] = num;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        ~MatrixFloat()
        {
            Console.WriteLine("Destructor");
        }

        public void inputMat()
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    float.TryParse(Console.ReadLine(), out FloatArray[i,c]);
                }
            }
        }

        public void PrintMat()
        {
            for (var i = 0; i < n; i++) 
            {
                    for (var c = 0; c < m; c++)
                    {
                        Console.Write($"{FloatArray[i,c]} ");
                    }
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SetMat(uint num)
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    FloatArray[i, c] = num;
                }
            }
        }
        
        public float this[uint i, uint j]
        {
            get
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                    return 0;
                }
                return FloatArray[i,j];
            }
            set
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                }
                else
                {
                    FloatArray[i, j] = value;
                }
            }
        }
        
        public float this[int index]
        {
            //rown = n, column = m
            get
            {
                if (index < n * m - 1)
                {

                    return FloatArray[index / m, (int)(index % m)];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index < n * m - 1)
                {
                    FloatArray[index / m, (int)(index % m)] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }
        
        public static MatrixFloat operator++(MatrixFloat matrixFloat)
        {
            for (var i = 0; i < matrixFloat.n; i++)
            {
                for (var c = 0; c < matrixFloat.m; c++)
                {
                    matrixFloat.FloatArray[i, c]++;
                }
            }

            return matrixFloat;
        }
        
        public static MatrixFloat operator--(MatrixFloat matrixFloat)
        {
            for (var i = 0; i < matrixFloat.n; i++)
            {
                for (var c = 0; c < matrixFloat.m; c++)
                {
                    matrixFloat.FloatArray[i, c]--;
                }
            }
            return matrixFloat;
        }
        public static bool operator true(MatrixFloat matrixFloat)
        {
            if(matrixFloat.n != 0 && matrixFloat.m != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(MatrixFloat matrixFloat)
        {
            if(matrixFloat.n != 0 && matrixFloat.m != 0)
            {
                return false;
            }
            return true;
        }
        public static MatrixFloat operator+(MatrixFloat matrixFloat, int num)
        {
            for (var i = 0; i < matrixFloat.n; i++)
            {
                for (var c = 0; c < matrixFloat.m; c++)
                {
                    matrixFloat.FloatArray[i, c] = Convert.ToUInt32(matrixFloat.FloatArray[i, c] + num);
                }
            }

            return matrixFloat;
        }

        public static MatrixFloat operator+(MatrixFloat a, MatrixFloat b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.FloatArray[i, c] += b.FloatArray[i, c];
                }
            }
            return a;
        }
        public static MatrixFloat operator-(MatrixFloat matrixFloat, int num)
        {
            for (var i = 0; i < matrixFloat.n; i++)
            {
                for (var c = 0; c < matrixFloat.m; c++)
                {
                    matrixFloat.FloatArray[i, c] = Convert.ToUInt32(matrixFloat.FloatArray[i,c] - num);
                }
            }

            return matrixFloat;
        }

        public static MatrixFloat operator-(MatrixFloat a, MatrixFloat b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.FloatArray[i, c] -= b.FloatArray[i, c];
                }
            }
            return a;
        }
        public static MatrixFloat operator*(MatrixFloat matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.FloatArray[i, c] = Convert.ToUInt32(matrixUint.FloatArray[i,c] * num);
                }
            }
            return matrixUint;
        }

        public static MatrixFloat operator*(MatrixFloat a, MatrixFloat b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.FloatArray[i, c] *= b.FloatArray[i, c];
                }
            }
            return a;
        }
        public static MatrixFloat operator/(MatrixFloat matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.FloatArray[i, c] = Convert.ToUInt32(matrixUint.FloatArray[i, c] / num);
                }
            }

            return matrixUint;
        }

        public static MatrixFloat operator/(MatrixFloat a, MatrixFloat b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.FloatArray[i, c] /= b.FloatArray[i, c];
                }
            }
            return a;
        }
    }



    static class Program
    {
        static void Main()
        {
            var arr = new List<Trapeze> {
             new Trapeze(1, 1, 1, 1, 1),
             new Trapeze(11, 15, 4, 4, 2),
             new Trapeze(2, 6, 6, 3, 3),
             new Trapeze(4, 14, 15, 6, 1),
             new Trapeze(2, 2, 2, 2, 2)
            };
            int squares = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine($"Trapezia {i}");
                Console.WriteLine($"P: {arr[i].P()}");
                Console.WriteLine($"S: {arr[i].S()}");
                Console.WriteLine($"Color: {arr[i].getColor()}");
                Console.WriteLine($"isSquare: {arr[i].IsSquare()}");
                if (arr[i].IsSquare()) squares++;
            }
            Console.WriteLine($"Squares: {squares}");
            Console.WriteLine();

            var arrA = new VectorFloat();
            var arrB = new VectorFloat(5, 3);
            Console.WriteLine($"Index[1]: {arrB[1]}");
            Console.WriteLine("Array A: ");
            arrA.printArr();
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrA++;
            Console.WriteLine("A++: ");
            arrA.printArr();
            arrA--;
            Console.WriteLine("A--: ");
            arrA.printArr();
            Console.WriteLine(arrA ? "Array A exists" : "Array A does not exists");
            Console.WriteLine(arrB ? "Array B exists" : "Array B does not exists");
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrB = arrB * 2;
            Console.WriteLine("Array B * 2: ");
            arrB.printArr();
            //----
            var matA = new MatrixFloat();
            var matB = new MatrixFloat(3, 3, 1);
            Console.WriteLine($"Index[1]: {matB[1]}");
            Console.WriteLine("Matrix A: ");
            matA.PrintMat();
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB++;
            Console.WriteLine("Matrix B++: ");
            matB.PrintMat();
            Console.WriteLine(matA ? "Matrix A exists" : "Matrix A does not exists");
            Console.WriteLine(matB ? "Matrix B exists" : "Matrix B does not exists");
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB = matB * 2;
            Console.WriteLine("Matrix B * 2: ");
            matB.PrintMat();
        }
    }
}