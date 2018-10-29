using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Vector3D
{

    class Program
    {
        Vector3D vector1 = new Vector3D(0, 0, 0, 0);
        Vector3D vector2 = new Vector3D(0, 0, 0, 0);
        Vector3D vector3 = new Vector3D(0, 0, 0, 0);
        Vector3D vector4 = new Vector3D(0, 0, 0, 0);

        Vector3D centerVector = new Vector3D(0, 0, 0, 0);
        Vector3D scaleVector = new Vector3D(1, 1, 1, 1);
        Vector3D translateVector = new Vector3D(1, 1, 1, 1);


        static void Main(string[] args)
        {
            Vector3D pointOne = new Vector3D(4, 2, 0);
            Vector3D pointTwo = new Vector3D(4, 4, 0);
            Vector3D pointThree = new Vector3D(2, 2, 0);
            Vector3D pointFour = new Vector3D(2, 4, 0);

            //1. Design your own 3D object, and give the coordinates of its vertices using homogeneous  //coordinates at a location away from the origin. (To truly be a 3D object, it must have at least   //four noncollinear points. But if you make your object too complicated, you may not be able to  //easily interpret the results.)

            Vector3D centerPoint = new Vector3D(1, 1, 0);
            //Define this mathematically to be center of above points.
            //Add X component of all 4 points, divide by 4, add Y component of all 4 points, divide by 4, Z component is 0 because all 4 Vectors are Zero Z.
            pointOne.PrintRect();
            pointTwo.PrintRect();
            pointThree.PrintRect();
            pointFour.PrintRect();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Raw Scaling X values by 15%");
            //2. Give the 4x4 matrix that would perform a raw scaling of your object with a 15% increase in length in the x-direction, a 25% decrease in the y-direction, and reflecting it in the z-direction.Then do the multiplication on your object and obtain the new coordinates. (Of course, this scaling will have unintended translation effects.)
            Vector3D scaleMatrix = new Vector3D(1.15f, 1.25f, -1f, 1f);

            pointOne.SetRectGivenRect(pointOne.GetX() * 1.15f, pointOne.GetY(), pointOne.GetZ());
            pointTwo.SetRectGivenRect(pointTwo.GetX() * 1.15f, pointTwo.GetY(), pointTwo.GetZ());
            pointThree.SetRectGivenRect(pointThree.GetX() * 1.15f, pointThree.GetY(), pointThree.GetZ());
            pointFour.SetRectGivenRect(pointFour.GetX() * 1.15f, pointFour.GetY(), pointFour.GetZ());

            Console.WriteLine();

            pointOne.PrintRect();
            pointTwo.PrintRect();
            pointThree.PrintRect();
            pointFour.PrintRect();

            Console.WriteLine();

            Console.WriteLine("Raw Scaling Y values by 25%");

            pointOne.SetRectGivenRect(pointOne.GetX(), pointOne.GetY() * 1.25f, pointOne.GetZ());
            pointTwo.SetRectGivenRect(pointTwo.GetX(), pointTwo.GetY() * 1.25f, pointTwo.GetZ());
            pointThree.SetRectGivenRect(pointThree.GetX(), pointThree.GetY() * 1.25f, pointThree.GetZ());
            pointFour.SetRectGivenRect(pointFour.GetX(), pointFour.GetY() * 1.25f, pointFour.GetZ());

            Console.WriteLine();

            pointOne.PrintRect();
            pointTwo.PrintRect();
            pointThree.PrintRect();
            pointFour.PrintRect();

            Console.WriteLine();

            Console.WriteLine("Reflecting Object on Z axis.");

            pointOne.SetRectGivenRect(pointOne.GetX() * -1, pointOne.GetY() * -1, pointOne.GetZ());
            pointTwo.SetRectGivenRect(pointTwo.GetX() * -1, pointTwo.GetY() * -1, pointTwo.GetZ());
            pointThree.SetRectGivenRect(pointThree.GetX() * -1, pointThree.GetY() * -1, pointThree.GetZ());
            pointFour.SetRectGivenRect(pointFour.GetX() * -1, pointFour.GetY() * -1, pointFour.GetZ());

            Console.WriteLine();

            pointOne.PrintRect();
            pointTwo.PrintRect();
            pointThree.PrintRect();
            pointFour.PrintRect();




            ////Get 15% of the value of the lowest 2 X coordinates, and subtract that numberr from their X  //coordinates.   IE:  PointOne.SetRectGivenRect(PointOne.GetX() - tempX, PointOne.GetY(), 0)
            ////Calculate this value for the higher two points, add it to their X.  
            //// IE:  PointThree.SetRectGivenRect(PointThree.GetX() + tempX, PointOne.GetY(), 0)

            ////Get 25% of the value of the lowest 2 Y coordinates, add that number to their Y coordinate.
            ////PointThree.SetRectGivenRect(PointThree.GetX(), PointOne.GetY() + tempY, 0)

            ////Calculate this value for higher two points, subtract from their Y.
            ////PointOne.SetRectGivenRect(PointOne.GetX(), PointOne.GetY() - tempY, 0)

            ////Reflect the Object in the Z axis, so times the X and Y positions by -1.

            //////^ In event above calculations don’t result in raw scaling, instead just multiply their values.
            ////// IE: X * 1.15f, 



            //3. Estimate the center of your object. Translate this center to the origin, then perform the scaling described in question #2, then return the center to the original location. What are the new coordinates?

            ////centerPont = getX of all 4 objects / 4, getY of all 4 objects / 4, get Z of all 4 objects / 4.
            ////
            Console.ReadLine();
            Console.Clear();
            Program testProgram = new Program();
            Vector3D[] vectors = new Vector3D[4];
            int number = 0;
            vectors[0] = testProgram.vector1;
            vectors[1] = testProgram.vector2;
            vectors[2] = testProgram.vector3;
            vectors[3] = testProgram.vector4;
            float tempX;
            float tempY;
            float tempZ;
            while (number < 4)
            {
                Console.WriteLine("Please Provide an X value for Vector " + (number + 1));
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Y value for Vector " + (number + 1));
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Z value for Vector " + (number + 1));
                tempZ = float.Parse(Console.ReadLine());

                Console.WriteLine();

                vectors[number].SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine();
                number++;
            }

            Console.WriteLine();
            Console.WriteLine("Please Provide an X value for the Center Vector");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Y value for the Center Vector");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Z value for the Center Vector");
            tempZ = float.Parse(Console.ReadLine());

            testProgram.centerVector.SetRectGivenRect(tempX, tempY, tempZ);

            Console.ReadLine();
            Console.Clear();
            testProgram.CallSwitch(0);



            //3. Test your code with the operations described in the prelab questions.
            //4. Execute the above program, for your instructor’s verification.
            //initials:
            //5. Save your class files! We will use them again in the rotation lab.
            Console.ReadLine();
        }

        public void CallSwitch(int startingTime)
        {
            //multiplication by a scaling about a center matrix
            //2. Create a program that transforms the object you chose in prelab question #1. Specifically, the program should:
            //ask the user for the vertices of the object
            ////While loop to ask user 4 times. Console.WriteLine(“Input object vertex “ + i);
            //ask the user for the center of the object
            //ask the user to enter the type of transformation(translation or raw scaling or scaling about a center)
            //ask the user for the needed parameters for that type of transformation(i.e.scaling factors, translation directions)
            //perform the transformation
            //report the new vertices
            //report the new center
            //repeatedly ask for new transformations until terminated by the user
            ////Write out each option with “1.” etc in front, user selects by choosing number.  Default switch, incase illegible input, asks again.
            ////Use a Switch statement with seperate cases for each function.


            float tempX;
            float tempY;
            float tempZ;

            int i = startingTime;
            while (i < 4)
            {
                Console.WriteLine("Loop Amount: " + i);

                Console.WriteLine("Please Choose an Operation:");
                Console.WriteLine();
                Console.WriteLine("(1.) Translate the Object");
                Console.WriteLine("(2.) Scale the Object Raw");
                Console.WriteLine("(3.) Scale the Object around it's Center");

                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)

                {
                    case 1:
                        Console.WriteLine("Translating Object");

                        Vector3D translate1 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate2 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate3 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate4 = new Vector3D(0, 0, 0, 0);

                        Console.WriteLine("How much do you want to translate the object's X value by?");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        translate1.SetRectGivenRect(1, 0, 0, vector1.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector1.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector1.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        Console.WriteLine("New Vector 1");
                        vector1.SetRectGivenRect(translate1.GetW(), translate2.GetW(), translate3.GetW());
                        Console.WriteLine();
                        vector1.PrintRect();

                        Console.ReadLine();
                        //Console.Clear();

                        translate1.SetRectGivenRect(1, 0, 0, vector2.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector2.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector2.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        Console.WriteLine("New Vector 2");
                        vector2.SetRectGivenRect(translate1.GetW(), translate2.GetW(), translate3.GetW());
                        Console.WriteLine();
                        vector2.PrintRect();

                        Console.ReadLine();
                        //Console.Clear();

                        translate1.SetRectGivenRect(1, 0, 0, vector3.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector3.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector3.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        Console.WriteLine("New Vector 3");
                        vector3.SetRectGivenRect(translate1.GetW(), translate2.GetW(), translate3.GetW());
                        Console.WriteLine();
                        vector3.PrintRect();

                        Console.ReadLine();
                        //Console.Clear();


                        translate1.SetRectGivenRect(1, 0, 0, vector4.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector4.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector4.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        Console.WriteLine("New Vector 4");
                        vector4.SetRectGivenRect(translate1.GetW(), translate2.GetW(), translate3.GetW());
                        Console.WriteLine();
                        vector4.PrintRect();

                        Console.ReadLine();
                        Console.Clear();

                        i++;
                        break;

                    case 2:
                        Console.WriteLine("How much do you want to Raw Scale the object's X value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Y value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempY = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Z value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempZ = float.Parse(Console.ReadLine());

                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        vector1.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector2.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector3.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector4.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());

                        Console.WriteLine();
                        vector1.PrintRect();
                        vector2.PrintRect();
                        vector3.PrintRect();
                        vector4.PrintRect();

                        i++;
                        break;

                    case 3:
                        Console.WriteLine("Scaling about the Center of the object.");

                        Console.WriteLine("How much do you want to Scale the object's X value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's X value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's X value by?");
                        Console.WriteLine("  (IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempZ = float.Parse(Console.ReadLine());

                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        vector1.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector2.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector3.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector4.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());

                        Console.WriteLine();
                        vector1.PrintRect();
                        vector2.PrintRect();
                        vector3.PrintRect();
                        vector4.PrintRect();

                        i++;
                        break;

                    default:
                        Console.WriteLine("Invalid Input, please try again.");
                        CallSwitch(i);
                        break;

                }
            }

            Console.Clear();
            Console.WriteLine("Final Result of Operations");

            Console.WriteLine();

            vector1.PrintRect();
            vector2.PrintRect();
            vector3.PrintRect();
            vector4.PrintRect();


        }

    }


    //1. Extend your 3D vector class to include the following new methods:
    //a general constructor for a 4D vector
    // ^ DONE

    //a dot product operation using all four components

    //multiplication by a translation matrix

    //multiplication by a raw scaling matrix(IE: 5 * Vector(1, 2,3) = 5, 10 15)
    //	Already Done, is caled “MultiplyRect”  --- Consider rename to ScaleRect?

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

        //Print the X, Y, and Z coordinate of this vector.
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

        //Returns the private W value;
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

        public float DegreeToRad(float degree)
        {
            float rad = degree * (float)Math.PI / 180;

            return rad;
        }

        public float RadtoDegrees(float rad)
        {
            float degrees = 180 / (float)Math.PI;
            return degrees;
        }

        public float GetDistance(Vector3D vectorRef, float size)
        {

            float Distance = (vectorRef.GetX() - GetX()) * (vectorRef.GetX() - GetX())
                + (vectorRef.GetY() - GetY()) * (vectorRef.GetY() - GetY())
                + (vectorRef.GetZ() - GetZ()) * (vectorRef.GetZ() - GetZ());


            return Distance;
        }
        //Gets the heading from the current vector to the specified vector.
        public float GetHeadingOfVector(Vector3D vectorRef)
        {
            double tempHeading = X / Math.Sqrt(X * X + Y * Y);
            tempHeading = Math.Cos(tempHeading);
            return (float)tempHeading;
        }

        public float GetNormalizedPosition()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public void DotProduct4D()
        {

        }

        public void MatrixTranslation(float vectorX, float vectorY, float vectorZ, float vectorW)
        {

        }

        public void MatrixRawScale(float vectorX, float vectorY, float vectorZ, float vectorW)
        {
            X *= vectorX;
            Y *= vectorY;
            Z *= vectorZ;
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


    }
}
