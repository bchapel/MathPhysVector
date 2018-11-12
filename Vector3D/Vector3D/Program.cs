using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//Author: Bowen Chapel October 29th, 2018.
//Vector3D Class/Program: This namespace contains the Vector3D class and the relevant test program to this lab.  
//The Vector3D class is the basic building block of a custom physics engine.  It allows the storing of an X, Y, Z, coordinate for keeping track of an object, as well as holding numerous
//functions for either modifying the vector or calculations between it and other vectors.
namespace Vector3D
{
    //Program Class Purpose: To test translation, scaling, and center-scaling functions added to the Vector3D class.
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Press 1. to enter Scenario one: Reflection, or anything else for Scenario Two: Two Objects");
            //Scenario One
            if (Console.ReadLine() == "1")
            {

                Vector3D iVelocity = new Vector3D(0, 0, 0);

                Vector3D fVelocity = new Vector3D(0, 0, 0);

                float E = 0f;

                Vector3D vector1 = new Vector3D(0, 0, 0);
                Vector3D vector2 = new Vector3D(0, 0, 0);



                Console.WriteLine("What is the X Velocity of the object? (M/S)");
                float tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Y Velocity of the object? (M/S)");
                float tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Z Velocity of the object? (M/S)");
                float tempZ = float.Parse(Console.ReadLine());
                iVelocity.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine("What is the coefficient of Restitution, E?");
                E = float.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("What is the X coordinate of Vector One?");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Y coordinate of Vector One?");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Z coordinate of Vector One?");
                tempZ = float.Parse(Console.ReadLine());
                vector1.SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine();

                Console.WriteLine("What is the X coordinate of Vector Two?");
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Y coordinate of Vector Two?");
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("What is the Z coordinate of Vector Two?");
                tempZ = float.Parse(Console.ReadLine());

                vector2.SetRectGivenRect(tempX, tempY, tempZ);

                Vector3D normal = vector1.VectorCrossProduct(vector1.GetX(), vector1.GetY(), vector1.GetZ(), vector2.GetX(), vector2.GetY(), vector2.GetZ());
                Vector3D normalNormalized = new Vector3D(normal.GetX() / normal.GetNormalizedPosition(), normal.GetY() / normal.GetNormalizedPosition(), normal.GetZ() / normal.GetNormalizedPosition());

                fVelocity.SetRectGivenRect(
                    iVelocity.GetX() - (E + 1) * (iVelocity.DotProduct3D(normalNormalized.GetX(), normalNormalized.GetY(), normalNormalized.GetZ())) * normalNormalized.GetX(),
                    iVelocity.GetY() - (E + 1) * (iVelocity.DotProduct3D(normalNormalized.GetX(), normalNormalized.GetY(), normalNormalized.GetZ())) * normalNormalized.GetY(),
                    iVelocity.GetZ() - (E + 1) * (iVelocity.DotProduct3D(normalNormalized.GetX(), normalNormalized.GetY(), normalNormalized.GetZ())) * normalNormalized.GetZ());

                Console.WriteLine("Final Velocity of Object (m/S)");
                fVelocity.PrintRect();

            }
            //Scenario Two
            else
            {
                float massObj1 = 0f;
                float iVelocityObj1 = 0f;
                float fVelocityObj1 = 0f;

                float iVelocityObj2 = 0f;
                float fVelocityObj2 = 0f;
                float massObj2 = 0f;

                float E = 0f;


                Console.WriteLine("What is the Mass of Object One?  (KG)");
                massObj1 = float.Parse(Console.ReadLine());

                Console.WriteLine("What is the Velocity of Object One? (M/S)");
                iVelocityObj1 = float.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("What is the Mass of Object Two? (KG)");
                massObj2 = float.Parse(Console.ReadLine());

                Console.WriteLine("What is the Velocity of Object Two? (M/S)");
                iVelocityObj2 = float.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("What is the coefficient of Restitution, E?");
                E = float.Parse(Console.ReadLine());

                fVelocityObj1 = ((massObj1 - (E * massObj2)) * iVelocityObj1 + (1 + E) * massObj2 * iVelocityObj2) / (massObj1 + massObj2);
                fVelocityObj2 = fVelocityObj1 + (E * (iVelocityObj1 - iVelocityObj2));

                Console.WriteLine();

                Console.WriteLine("Velocity of Object One: " + fVelocityObj1 + " m/s");
                Console.WriteLine("Velocity of Object Two: " + fVelocityObj2 + " m/s");

                //Theoretically the above works.
            }

            Console.WriteLine();
            Console.ReadLine();

        }
    }

    class Vector3D
    {
        //Stored X, Y, Z, coordinates of this Vector.
        private float X;
        private float Y;
        private float Z;
        private float W = 1;

        private float pitch;
        private float heading;

        //Initializing the X, Y, and Z values for this vector. 
        public Vector3D(float initX, float initY, float initZ)
        {
            X = initX;
            Y = initY;
            Z = initZ;
        }
        //Overloaded constructor allowing for additional defining of a W value.
        public Vector3D(float initX, float initY, float initZ, float initW)
        {
            X = initX;
            Y = initY;
            Z = initZ;
            W = initW;
        }

        //Set the X, Y, and Z values of the 
        public void SetRectGivenRect(float inputX, float inputY, float inputZ)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
        }

        //Overloaded SetRectGivenRect function, allowing for inputing a W value.
        public void SetRectGivenRect(float inputX, float inputY, float inputZ, float inputW)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
            W = inputW;
        }
        //Print the X, Y, and Z coordinate of this vector.
        public void PrintRect()
        {
            Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
        }

        //PrintMatrix lets the user print all Vector values, even W.  
        //This was made as a seperate function rather than an Overload, because W is present in all Vector3s.
        public void PrintMatrix()
        {
            Console.WriteLine("(" + X + ", " + Y + ", " + Z + ", " + W + ")");
        }
        //Print the magnitude of this vector. Square Root of ( x*x + y*y + z*z)
        public void PrintMag()
        {
            float magnitude = GetMag();
            Console.WriteLine("Magnitude: " + magnitude);
        }
        //Return the private X value.
        public float GetX()
        {
            return X;
        }
        //Return the private Y value.
        public float GetY()
        {
            return Y;
        }
        //Return the private Z value.
        public float GetZ()
        {
            return Z;
        }

        //Returns the private W value.
        public float GetW()
        {
            return W;
        }

        //Calculate and return the magnitude of the vector.
        public float GetMag()
        {

            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        //Calculate and return the SQUARED magnitude of the vector.
        public float GetMagSq()
        {
            return (X * X) + (Y * Y) + (Z * Z);
        }


        public void SetRectGivenPolar(float mag, double angle)
        {
            double tempX = mag * Math.Cos(angle);
            double tempY = mag * Math.Sin(angle);


            X = (float)tempX;
            Y = (float)tempY;
            //Polar form is 2D!
            Z = 0;
        }
        //Adds the input xyz values to the X Y Z of this vector.
        public void SumRect(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        //Subtracts the input values from the Vector.
        public void SubtractRect(float x, float y, float z)
        {
            X -= x;
            Y -= y;
            Z -= z;
        }

        //Scales/Multiplies the rect by the input values.
        public void ScaleRect(float input)
        {
            X *= input;
            Y *= input;
            Z *= input;
        }

        public void SetRectGivenMagHeadPitch(float mag, double heading, double pitch)
        {
            if (mag < 0)
                mag = mag * -1;

            double tempX = mag * Math.Cos(heading) * Math.Cos(pitch);
            double tempY = mag * Math.Sin(heading) * Math.Cos(pitch);
            double tempZ = mag * Math.Sin(pitch);

            //tempX = Math.Round(tempX, 3);
            //tempY = Math.Round(tempY, 3);
            //tempZ = Math.Round(tempY, 3);

            X = (float)tempX;
            Y = (float)tempY;
            Z = (float)tempZ;
        }

        public void SumRectGivenMagHeadPitch(float mag, double heading, double pitch)
        {
            if (mag < 0)
                mag = mag * -1;

            double tempX = mag * Math.Cos(heading) * Math.Cos(pitch);
            double tempY = mag * Math.Sin(heading) * Math.Cos(pitch);
            double tempZ = mag * Math.Sin(pitch);

            X += (float)tempX;
            Y += (float)tempY;
            Z += (float)tempZ;
        }

        public void PrintPolar()
        {
            PrintMag();
            //Calculating Angle for Polar form
            Console.WriteLine("Angle: " + Math.Tan(X / Y));
        }

        public void PrintMagheadPitch()
        {
            Console.WriteLine("Pitch: " + GetPitch());
            Console.WriteLine("Heading: " + GetHeading());
            Console.WriteLine("Magnitude: " + GetMag());
        }

        public void PrintDirection()
        {
            Console.WriteLine("Alpha: " + GetAlpha());
            Console.WriteLine("Beta: " + GetBeta());
            Console.WriteLine("Gamma: " + GetGamma());
        }


        public float GetPitch()
        {
            double tempPitch = Z / GetMag();
            tempPitch = Math.Sin(tempPitch);
            return (float)tempPitch;
        }

        //GetHeading needs to be modified to make X on left.
        public float GetHeading()
        {

            double tempHeading = X / Math.Sqrt(X * X + Y * Y);
            tempHeading = Math.Cos(tempHeading);
            return (float)tempHeading;
        }

        public float GetAlpha()
        {
            float alpha = 1;
            return alpha;
        }

        public float GetBeta()
        {
            float beta = 1;
            return beta;
        }

        public float GetGamma()
        {
            float gamma = 1;
            return gamma;
        }

        //Converts the input degrees back into radians.
        public float DegreeToRad(float degree)
        {
            float rad = degree * (float)Math.PI / 180;

            return rad;
        }

        //Converts the input Radians into degrees.
        public float RadtoDegrees(float rad)
        {
            float degrees = 180 / (float)Math.PI;
            return degrees;
        }

        //Gets the Distance between 
        public float GetDistance(Vector3D vectorRef)
        {

            float Distance = (float)Math.Sqrt((vectorRef.X - X) * (vectorRef.X - X)
                + (vectorRef.Y - Y) * (vectorRef.Y - Y)
                + (vectorRef.Z - Z) * (vectorRef.Z - Z));


            return Distance;
        }
        //Gets the heading from the current vector to the specified vector.
        public float GetHeadingOfVector(Vector3D vectorRef)
        {
            double tempHeading = X / Math.Sqrt(X * X + Y * Y);
            tempHeading = Math.Cos(tempHeading);
            return (float)tempHeading;
        }

        //Normalizes the position of the Vector to be positive.
        public float GetNormalizedPosition()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }
        //Does a Dot Product but in 3D.
        public float DotProduct3D(float inputX, float inputY, float inputZ)
        {
            float tempX = X * inputX;
            float tempY = Y * inputY;
            float tempZ = Z * inputZ;

            return tempX + tempY + tempZ;
        }

        //Does a Dot Product but in 4D.
        public float DotProduct4D(float inputX, float inputY, float inputZ, float inputW)
        {
            float tempX = X * inputX;
            float tempY = Y * inputY;
            float tempZ = Z * inputZ;
            float tempW = W * inputW;

            return tempX + tempY + tempZ + tempW;
        }

        //Translates this vector's components by values from another Matrix.
        public void MatrixTranslation(float vectorX, float vectorY, float vectorZ, float vectorW)
        {
            X += vectorX;
            Y += vectorY;
            Z += vectorZ;
            W += vectorW;
        }

        //Scales this vector by a Matrix. 
        public void MatrixRawScale(float vectorX, float vectorY, float vectorZ, float vectorW)
        {
            X *= vectorX;
            Y *= vectorY;
            Z *= vectorZ;
            W *= vectorW;
        }

        //Scales the object around the Center point by the first specified Vector, with the second specified vector being the center point..
        public void MatrixCenterScale(float vectorX, float vectorY, float vectorZ, float vectorW, float centerX, float centerY, float centerZ)
        {
            X -= centerX;
            Y -= centerY;
            Z -= centerZ;

            X *= vectorX;
            Y *= vectorY;
            Z *= vectorZ;

            X += centerX;
            Y += centerY;
            Z += centerZ;
        }

        public Vector3D VectorCrossProduct(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            float outputX = (Vy * Uz) - (Uy * Vz);
            float outputY = -((Vx * Uz) - (Ux * Vz));
            float outputZ = (Vx * Uy) - (Ux * Vy);

            Vector3D output = new Vector3D(outputX, outputY, outputZ);

            return output;
        }

        public Vector3D ParaProjection(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            Vector3D temp = new Vector3D(Vx, Vy, Vz);
            //float 

            float scalar = temp.DotProduct3D(Ux, Uy, Uz) / ((Ux * Ux) + (Uy * Uy) + (Uz * Uz));

            temp.X *= scalar;
            temp.Y *= scalar;
            temp.Z *= scalar;

            Console.WriteLine();
            Console.WriteLine("Para Projection: ");
            temp.PrintRect();
            Console.WriteLine();

            return temp;
        }

        public Vector3D PerpProjection(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            Vector3D output = new Vector3D(Ux, Uy, Uz);
            Vector3D temp = ParaProjection(Vx, Vy, Vz, Ux, Uy, Uz);
            output.SubtractRect(temp.X, temp.Y, temp.Z);

            return output;
        }

        public Vector3D Line3DClosestPoint(Vector3D P, Vector3D Pvector, Vector3D Q)
        {
            Vector3D para = new Vector3D(0, 0, 0);
            Vector3D PQ = new Vector3D(Q.X - P.X, Q.Y - P.Y, Q.Z - P.Z);

            para = para.ParaProjection(PQ.X, PQ.Y, PQ.Z, Pvector.X, Pvector.Y, Pvector.Z);
            Vector3D outputS = new Vector3D(P.X + para.X, P.Y + para.Y, P.Z + para.Z);

            return outputS;
        }

        public Vector3D PlaneEquation(Vector3D pointOne, Vector3D pointTwo, Vector3D pointThree)
        {
            Vector3D U = new Vector3D(pointTwo.X - pointOne.X, pointTwo.Y - pointOne.Y, pointTwo.Z - pointOne.Z);
            Vector3D V = new Vector3D(pointThree.X - pointOne.X, pointThree.Y - pointOne.Y, pointThree.Z - pointOne.Z);

            Vector3D Normal = U.VectorCrossProduct(U.X, U.Y, U.Z, V.X, V.Y, V.Z);
            Normal.SetRectGivenRect((float)Math.Sqrt(Normal.X * Normal.X), (float)Math.Sqrt(Normal.Y * Normal.Y), (float)Math.Sqrt(Normal.Z * Normal.Z));

            //Normal & U combine into equation of Plane.
            //Problem is returning this...?
            return Normal;
        }

        public Vector3D PlaneClosestPoint(Vector3D P, Vector3D R, Vector3D U, Vector3D Q)
        {
            Vector3D normal = PlaneEquation(P, R, U);
            Vector3D PQPerp = new Vector3D(0, 0, 0);

            Vector3D PQ = new Vector3D(Q.X - P.X, Q.Y - P.Y, Q.Z - P.Z);
            PQPerp = PQ.PerpProjection(normal.X, normal.Y, normal.Z, PQ.X, PQ.Y, PQ.Z);
            Vector3D outputS = new Vector3D(Q.X - PQPerp.X, Q.Y - PQPerp.Y, Q.Z - PQPerp.Z);

            return outputS;
        }


    }
}
