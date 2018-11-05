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
            //Create Vectors
            Vector3D ship = new Vector3D(0, 0, 0);
            Vector3D targetObj = new Vector3D(0, 0, 0);
            Vector3D targetObj2 = new Vector3D(0, 0, 0);
            Vector3D plane1 = new Vector3D(0, 0, 0);
            Vector3D plane2 = new Vector3D(0, 0, 0);
            Vector3D plane3 = new Vector3D(0, 0, 0);

            //Ask user for coordinates for ship, and set.
            Console.WriteLine("Please input an X value for the Ship’s position.");
            float tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Y value for the Ship’s position.");
            float tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the Ship’s position.");
            float tempZ = float.Parse(Console.ReadLine());


            ship.SetRectGivenRect(tempX, tempY, tempZ);

            Console.WriteLine("Ship’s Position:");
            ship.PrintRect();

            Console.ReadLine();
            Console.WriteLine("Please input an X value for the object’s position.");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Y value for the object’s position.");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the object’s position.");
            tempZ = float.Parse(Console.ReadLine());

            targetObj.SetRectGivenRect(tempX, tempY, tempZ);
            targetObj2.SetRectGivenRect(tempX, tempY, tempZ);
            Console.WriteLine("Object’s Position:");
            targetObj.PrintRect();


            Console.ReadLine();
            Console.WriteLine("Please input an X value for the object’s Direction Vector.");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Y value for the object’s Direction Vector.");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the object’s Direction Vector.");
            tempZ = float.Parse(Console.ReadLine());

            targetObj2.SumRect(tempX, tempY, tempZ);
            Console.WriteLine("Object’s Direction Vector:");
            targetObj2.PrintRect();
            Console.ReadLine();

            Vector3D lineS = targetObj.Line3DClosestPoint(targetObj, targetObj2, ship);

            Console.WriteLine("Closest Point: ");
            lineS.PrintRect();
            Console.WriteLine("Distance: " + lineS.GetDistance(ship));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Anything to clear and continue.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please input an X value for the first point’s position.");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Y value for the first point’s position.");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the first point’s position.");
            tempZ = float.Parse(Console.ReadLine());

            plane1.SetRectGivenRect(tempX, tempY, tempZ);
            Console.WriteLine("Point #1 Position:");
            plane1.PrintRect();


            Console.WriteLine("Please input an X value for the second point’s position.");
            tempX = float.Parse(Console.ReadLine());    
            Console.WriteLine("Please input an Y value for the first point’s position.");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the second point’s position.");
            tempZ = float.Parse(Console.ReadLine());

            plane2.SetRectGivenRect(tempX, tempY, tempZ);
            Console.WriteLine("Point #2 Position:");
            plane2.PrintRect();


            Console.WriteLine("Please input an X value for the third point’s position.");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Y value for the third point’s position.");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please input an Z value for the third point’s position.");
            tempZ = float.Parse(Console.ReadLine());

            plane3.SetRectGivenRect(tempX, tempY, tempZ);
            Console.WriteLine("Point #3 Position:");
            plane3.PrintRect();


            //****DETERMINE DISTANCE BETWEEN EACH POINT AND THE SHIP, REPORT CLOSEST POINT, THEN STATE DISTANCE FROM IT TO SHIP * **
            //Call function here.
            Vector3D planeS = ship.PlaneClosestPoint(plane1, plane2, plane3, ship);

            Console.WriteLine("Closest Point: ");
            planeS.PrintRect();
            //Distance is normalized Dot Product of point (S) and spaceship (Q)
            Console.WriteLine("Distance: " + planeS.GetDistance(ship));
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

            //tempX = Math.Round(tempX, 3);
            //tempY = Math.Round(tempY, 3);
            //tempZ = Math.Round(tempY, 3);

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

            float Distance = (vectorRef.GetX() - GetX()) * (vectorRef.X - X)
                + (vectorRef.Y - Y) * (vectorRef.Y - Y)
                + (vectorRef.Z - Z * (vectorRef.Z - Z));


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
            Vector3D temp = VectorCrossProduct(Vx, Vy, Vz, Ux, Uy, Uz);

            temp.X /= Vx * Vx;
            temp.X *= Vx;
            temp.Y /= Vy * Vy;
            temp.Y *= Vy;
            temp.Z /= Vz * Vz;
            temp.Z *= Vz;

            return temp;
        }

        public void PerpProjection(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            Vector3D output = new Vector3D(Ux, Uy, Uz);
            Vector3D temp = ParaProjection(Vx, Vy, Vz, Ux, Uy, Uz);
            output.SubtractRect(temp.X, temp.Y, temp.Z);

        }

        public Vector3D Line3DClosestPoint(Vector3D P, Vector3D Pvector, Vector3D Q)
        {
            Vector3D paraProjection = new Vector3D(0, 0, 0);

            paraProjection = paraProjection.ParaProjection(Pvector.X, Pvector.Y, Pvector.Z, P.X, P.Y, P.Z);
            Vector3D outputS = new Vector3D(P.X + paraProjection.X, P.Y + paraProjection.Y, P.Z + paraProjection.Z);

            return outputS;
        }

        public Vector3D PlaneEquation(Vector3D pointOne, Vector3D pointTwo, Vector3D pointThree)
        {
            Vector3D U = new Vector3D(pointTwo.X - pointOne.X, pointTwo.Y - pointOne.Y, pointTwo.Z - pointOne.Z);
            Vector3D V = new Vector3D(pointThree.X - pointOne.X, pointThree.Y - pointOne.Y, pointThree.Z - pointOne.Z);

            Vector3D Normal = U.VectorCrossProduct(U.X, U.Y, U.Z, V.X, V.Y, V.Z);

            //Normal & U combine into equation of Plane.
            //Problem is returning this...?
            return Normal;
        }

        public Vector3D PlaneClosestPoint(Vector3D P, Vector3D R, Vector3D U, Vector3D Q)
        {
            Vector3D normal = PlaneEquation(P, R, Q);
            Vector3D PQPara = new Vector3D(0, 0, 0);

            Vector3D PQ = new Vector3D(Q.X - P.X, Q.Y - P.Y, Q.Z - P.Z);
            PQPara = PQ.ParaProjection(normal.X, normal.Y, normal.Z, PQ.X, PQ.Y, PQ.Z);
            Vector3D outputS = new Vector3D(Q.X - PQPara.X, Q.Y - PQPara.Y, Q.Z - PQPara.Z);

            return outputS;
        }


    }
}
