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
    //Program Class Purpose: To test the new velocity of an object after collision with another object.  
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
            //Instantiates a new version of Program, and creates a Vector3D array, holding 4 vectors.
            Program testProgram = new Program();
            Vector3D[] vectors = new Vector3D[4];

            vectors[0] = testProgram.vector1;
            vectors[1] = testProgram.vector2;
            vectors[2] = testProgram.vector3;
            vectors[3] = testProgram.vector4;

            //This value is used for the while loop below, to ensure every Vector from the array above is cycled through.
            int number = 0;


            //Temp variables used to store a user input from a console.readline().
            float tempX;
            float tempY;
            float tempZ;

            //This loop uses the Vector Array created above so that the User may specify the X, Y, Z values of all of every Vector.
            while (number < 4)
            {
                Console.WriteLine("Please Provide an X value for Vector " + (number + 1));
                tempX = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Y value for Vector " + (number + 1));
                tempY = float.Parse(Console.ReadLine());
                Console.WriteLine("Please Provide an Z value for Vector " + (number + 1));
                tempZ = float.Parse(Console.ReadLine());

                Console.WriteLine();

                //Each Vector correspondingly has it's X,Y,Z components assigned.
                vectors[number].SetRectGivenRect(tempX, tempY, tempZ);

                Console.WriteLine();
                number++;
            }
            //After the While loop is finished, it asks the user for a center point.
            Console.WriteLine();
            Console.WriteLine("Please Provide an X value for the Center Vector");
            tempX = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Y value for the Center Vector");
            tempY = float.Parse(Console.ReadLine());
            Console.WriteLine("Please Provide an Z value for the Center Vector");
            tempZ = float.Parse(Console.ReadLine());

            //These coordinates are then assigned to the centerVector's X,Y,Z components.
            testProgram.centerVector.SetRectGivenRect(tempX, tempY, tempZ);

            Console.ReadLine();
            Console.Clear();
            testProgram.CallSwitch(0);
            Console.ReadLine();
        }

        //This function contains the bulk of the program.  It was created as an easy way to restart the while loop it contains, in event of user inputting invalid data.
        public void CallSwitch(int startingTime)
        {
            //Temp variables for storing user input.
            float tempX;
            float tempY;
            float tempZ;

            int i = startingTime;  //Initially called at Zero, allows this function to be called with a higher initial I value, such as default case in While loop below.
            while (i < 4)
            {
                Console.WriteLine("Vector One:");
                vector1.PrintRect();
                Console.WriteLine();

                Console.WriteLine("Vector Two:");
                vector2.PrintRect();
                Console.WriteLine();

                Console.WriteLine("Vector Three:");
                vector3.PrintRect();
                Console.WriteLine();

                Console.WriteLine("Vector Four:");
                vector4.PrintRect();
                Console.WriteLine();

                //User is prompted to choose one of three operations on their Vectors.
                Console.WriteLine("Please Choose an Operation:");
                Console.WriteLine();
                Console.WriteLine("(1.) Translate the Object");
                Console.WriteLine("(2.) Scale the Object Raw");
                Console.WriteLine("(3.) Scale the Object around it's Center");
                Console.WriteLine("(4.) Rotate the Object around a specified Axis.");

                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());  //User's choice is stored and used in the switch.
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Translating Object");

                        //4D Vectors are created so the User can see a more Mathematical representation of the Vector changes.
                        Vector3D translate1 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate2 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate3 = new Vector3D(0, 0, 0, 0);
                        Vector3D translate4 = new Vector3D(0, 0, 0, 0);

                        //User is Prompted for X, Y, and Z changes, this data is then stored.
                        Console.WriteLine("How much do you want to translate the object's X value by?");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to translate the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector is a temporary vector used to store said variables.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);


                        //The temporary translate Vectors are given data, and printed.
                        translate1.SetRectGivenRect(1, 0, 0, vector1.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector1.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector1.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        //The first Vector is translated and printed.
                        Console.WriteLine("New Vector 1");
                        vector1.MatrixTranslation(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        Console.WriteLine();
                        vector1.PrintRect();

                        Console.ReadLine();

                        //The temporary translate Vectors are given data, and printed.
                        translate1.SetRectGivenRect(1, 0, 0, vector2.GetX() + scaleVector.GetX());
                        translate2.SetRectGivenRect(0, 1, 0, vector2.GetY() + scaleVector.GetY());
                        translate3.SetRectGivenRect(0, 0, 1, vector2.GetZ() + scaleVector.GetZ());
                        translate4.SetRectGivenRect(0, 0, 0, 1);

                        Console.WriteLine();
                        translate1.PrintMatrix();
                        translate2.PrintMatrix();
                        translate3.PrintMatrix();
                        translate4.PrintMatrix();

                        //The Second Vector is translated and printed.
                        Console.WriteLine("New Vector 2");
                        vector2.MatrixTranslation(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        Console.WriteLine();
                        vector2.PrintRect();

                        Console.ReadLine();

                        //And so on....

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
                        vector3.MatrixTranslation(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        Console.WriteLine();
                        vector3.PrintRect();

                        Console.ReadLine();

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
                        vector4.MatrixTranslation(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        Console.WriteLine();
                        vector4.PrintRect();

                        Console.ReadLine();
                        Console.Clear();

                        i++;
                        break;

                    case 2: //User is prompted by how much they'd like to scale the X, Y, and Z components by.
                        Console.WriteLine("How much do you want to Raw Scale the object's X value by?");
                        Console.WriteLine("1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());

                        Console.WriteLine("How much do you want to Raw Scale the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector tempVector is temporarily staffed by tempX, tempY, tempZ.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        //The new Function MatrixRawScale is called on each Vector, with the scaleVector's X,Y,Z,W values called against it.
                        vector1.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector2.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector3.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());
                        vector4.MatrixRawScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW());

                        //Every Vector is then printed out with a label.
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();

                        Console.ReadLine();

                        i++;
                        break;

                    case 3: //User is prompted by how much they'd like to scale the X, Y, and Z components by.
                        Console.WriteLine("Scaling about the Center of the object.");

                        Console.WriteLine("How much do you want to Scale the object's X value by?");
                        Console.WriteLine("(IE: 1.15 would be increasing by 15, while 0.85 would be decreasing by 15%)");
                        tempX = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's Y value by?");
                        tempY = float.Parse(Console.ReadLine());
                        Console.WriteLine("How much do you want to Scale the object's Z value by?");
                        tempZ = float.Parse(Console.ReadLine());

                        //ScaleVector temp Vector is temporarily staffed by tempX, tempY, tempZ.
                        scaleVector.SetRectGivenRect(tempX, tempY, tempZ);

                        //New Function MatrixCenterScale is called by every numbered Vector, using the XYZW of the scaleVector, and the XYZ of the previously defined centerVector.
                        vector1.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector2.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector3.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());
                        vector4.MatrixCenterScale(scaleVector.GetX(), scaleVector.GetY(), scaleVector.GetZ(), scaleVector.GetW(), centerVector.GetX(), centerVector.GetY(), centerVector.GetZ());

                        //All Vectors are then printed and labeled.
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();

                        Console.ReadLine();

                        i++;
                        break;


                    case 4: //Rotations!

                        Vector3D[] vectors = new Vector3D[4];

                        vectors[0] = new Vector3D(vector1.GetX(), vector1.GetY(), vector1.GetZ());
                        vectors[1] = new Vector3D(vector2.GetX(), vector2.GetY(), vector2.GetZ());
                        vectors[2] = new Vector3D(vector3.GetX(), vector3.GetY(), vector3.GetZ());
                        vectors[3] = new Vector3D(vector4.GetX(), vector4.GetY(), vector4.GetZ());

                        Console.WriteLine("How large of an angle would you like to use ? (Degrees)");
                        float angleTheta = float.Parse(Console.ReadLine());

                        angleTheta = vector1.DegreeToRad(angleTheta);
                        Console.WriteLine("Converted to radians: " + angleTheta);


                        Console.WriteLine("What Axis would you like to rotate around?");
                        Console.WriteLine("(1.) X Axis");
                        Console.WriteLine("(2.) Y Axis");
                        Console.WriteLine("(3.) Z Axis");
                        int choice2 = Convert.ToInt32(Console.ReadLine()); //User's choice is stored and used in the switch.
                        switch (choice2)
                        {
                            case 1: // X Axis
                                int vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    tempX = vectors[vectorNumber].GetX();//1X + 0y + 0Z + 0 * 1

                                    //Get angle from axis to vectors, that’s theta

                                    //0X + y * CosTheta + z * -SinTheta + 0 *1
                                    tempY = (vectors[vectorNumber].GetY() * (float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetZ() * -(float)Math.Sin(angleTheta));
                                    //0x + y * SinTheta + Z * CosTheta + 0 *1
                                    tempZ = (vectors[vectorNumber].GetY() * (float)Math.Sin(angleTheta)) + (vectors[vectorNumber].GetZ() * (float)Math.Cos(angleTheta));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }

                                break;
                            case 2: //Y Axis
                                vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    //X * CosTheta + 0Y + Z * SinTheta + 0 * 1
                                    tempX = (vectors[vectorNumber].GetX() * ((float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetZ() * (float)Math.Sin(angleTheta)));
                                    //0X + 1Y + 0Z + 0 * 1
                                    tempY = vectors[vectorNumber].GetY();
                                    //X * -SinTheta + 0Y + Z * CosTheta + 0 * 1
                                    tempZ = (vectors[vectorNumber].GetX() * -(float)Math.Sin(angleTheta) + (vectors[vectorNumber].GetZ() * (float)Math.Cos(angleTheta)));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }
                                break;

                            case 3: //Z Axis
                                vectorNumber = 0;

                                while (vectorNumber < 4)
                                {
                                    //X * CosTheta + Y * -SinTheta + 0Z + 0 * 1
                                    tempX = (vectors[vectorNumber].GetX() * ((float)Math.Cos(angleTheta)) + (vectors[vectorNumber].GetY() * -(float)Math.Sin(angleTheta)));
                                    //X * SinTheta + Y * CosTheta + 0Z + 0 * 1
                                    tempY = (vectors[vectorNumber].GetX() * ((float)Math.Sin(angleTheta)) + (vectors[vectorNumber].GetY() * (float)Math.Cos(angleTheta)));
                                    //0X + 0Y + Z + 0 * 1
                                    tempZ = vectors[vectorNumber].GetZ();
                                    //Vectors[vectorNumber].GetZ() * (Sin( angleTheta) + Math.Cos( angleTheta));

                                    vectors[vectorNumber].SetRectGivenRect(tempX, tempY, tempZ);
                                    vectorNumber++;
                                }
                                break;


                            default:
                                Console.WriteLine("Invalid Input, action cancelled - returning to Matrix menu.");
                                CallSwitch(i);
                                break;

                        }
                        vector1.SetRectGivenRect(vectors[0].GetX(), vectors[0].GetY(), vectors[0].GetZ());
                        vector2.SetRectGivenRect(vectors[1].GetX(), vectors[1].GetY(), vectors[1].GetZ());
                        vector3.SetRectGivenRect(vectors[2].GetX(), vectors[2].GetY(), vectors[2].GetZ());
                        vector4.SetRectGivenRect(vectors[3].GetX(), vectors[3].GetY(), vectors[3].GetZ());
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Vector One:");
                        vector1.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Two:");
                        vector2.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Three:");
                        vector3.PrintRect();
                        Console.WriteLine();

                        Console.WriteLine("Vector Four:");
                        vector4.PrintRect();
                        Console.WriteLine();

                        Console.ReadLine();

                        i++;
                        break;


                    default: //If user selects an invalid choice, it informs them of this and recalls the function without resetting the i value.
                        Console.WriteLine("Invalid Input, please try again.");
                        CallSwitch(i);
                        break;

                }
            }

            //At conclusion of loop, clears console and informs user, before printing out the final results of all the changes.
            Console.Clear();
            Console.WriteLine("Final Result of Operations");

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Vector One:");
            vector1.PrintRect();
            Console.WriteLine();

            Console.WriteLine("Vector Two:");
            vector2.PrintRect();
            Console.WriteLine();

            Console.WriteLine("Vector Three:");
            vector3.PrintRect();
            Console.WriteLine();

            Console.WriteLine("Vector Four:");
            vector4.PrintRect();
            Console.WriteLine();

            Console.ReadLine();

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

        //Returns a cross product of Vectors V and U.
        public Vector3D VectorCrossProduct(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            float outputX = (Vy * Uz) - (Uy * Vz);
            float outputY = -((Vx * Uz) - (Ux * Vz));
            float outputZ = (Vx * Uy) - (Ux * Vy);

            Vector3D output = new Vector3D(outputX, outputY, outputZ);

            return output;
        }

        //Returns the Paralell Projection of Vector V and U.
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

        //Returns the perpinduclar projection of Vector V and U.
        public Vector3D PerpProjection(float Vx, float Vy, float Vz, float Ux, float Uy, float Uz)
        {
            Vector3D output = new Vector3D(Ux, Uy, Uz);
            Vector3D temp = ParaProjection(Vx, Vy, Vz, Ux, Uy, Uz);
            output.SubtractRect(temp.X, temp.Y, temp.Z);

            return output;
        }

        //Returns the closest point on a 3D line to specified point, Q.
        public Vector3D Line3DClosestPoint(Vector3D P, Vector3D Pvector, Vector3D Q)
        {
            Vector3D para = new Vector3D(0, 0, 0);
            Vector3D PQ = new Vector3D(Q.X - P.X, Q.Y - P.Y, Q.Z - P.Z);

            para = para.ParaProjection(PQ.X, PQ.Y, PQ.Z, Pvector.X, Pvector.Y, Pvector.Z);
            Vector3D outputS = new Vector3D(P.X + para.X, P.Y + para.Y, P.Z + para.Z);

            return outputS;
        }

        //Returns the Normal of a Plane.
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

        //Gets the closest point on the plane PRU to the point Q.
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
