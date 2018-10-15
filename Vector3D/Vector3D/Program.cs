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

       static double bigG = 6.67e-11;
       static float earthMass = 5.98e+24f; //kg
       static float earthRadius = 6378; //km

        static void Main(string[] args)
        {
            bool oneD = false;
            Console.WriteLine("Enter 1 for 1D problem");

            if (oneD == true)
            {
                //float 
            }
            else
            {

                float time = 10f; //seconds

                Vector3D earthPos = new Vector3D(0,0,0);
                float altitude = 0f;

                //Space ship Attributes
                float mass = 225f;  //kg
                Vector3D acceleration = new Vector3D(0, 0, 0);
                Vector3D newAcceleration = new Vector3D(0, 0, 0);
                Vector3D energyCalculation = new Vector3D(0, 0, 0);
                Vector3D position = new Vector3D(0, 6778, 0); //km
                Vector3D newPosition = new Vector3D(0, 0, 0);
                Vector3D velocity = new Vector3D(0, 0, 0);
                Vector3D newVelocity = new Vector3D(0, 0, 0);




                Console.WriteLine(earthMass);

                //GRAVITY FORMULA
                //F = Gm1m2/r2,
                //Force = earthMass * shipMass / (earthRadius * earthRadius)



                int i = 0;
                while (i < 36000)
                {
                    //VELOCITY VERLET FORMULA.



                    //CALCULATE ENERGY
                    float energyHeading = (float) Math.Atan2(earthPos.GetX(), position.GetX());
                    Console.WriteLine("Energy Heading: " + energyHeading);
                    energyCalculation.SetRectGivenMagHeadPitch((earthMass * mass) / (earthRadius * earthRadius), energyHeading, 0f);
                    //Console.WriteLine("X: " + energyCalculation.GetX() + " Y: " + energyCalculation.GetY());
                    //OUTPUT ALTITUDE AND TOTAL ENERGY EVERY FRAME.
                    
                    //R→new = R→old + V→old Δt + ½ a→old Δt^2


                    newPosition.SetRectGivenRect(position.GetX() + velocity.GetX() * time + 0.5f * acceleration.GetX() * time * time,
                    position.GetY() + velocity.GetY() * time + 0.5f * acceleration.GetY() * time * time, 0);

                    //newPosition.SumRect()

                    Console.WriteLine("Current Position: ");
                    newPosition.PrintRect();

                    //a⃗ new=Fnet⃗  / m.
                    // ACCELERATION BASED OFF OF ENERGY
                    newAcceleration.SetRectGivenRect(energyCalculation.GetX() / mass,
                    energyCalculation.GetY() / mass, 0);


                    //Console.WriteLine("Acceleration:");
                    //newAcceleration.PrintRect();

                    //V→new = V→old + (a→new + a→old) * 0.5 * Δt

                    newVelocity.SetRectGivenRect(velocity.GetX() + (acceleration.GetX() + newAcceleration.GetX()) * 0.5f * time,
                    velocity.GetY() + (acceleration.GetY() + newAcceleration.GetY()) * 0.5f * time, 0);

                    //Console.WriteLine("Current Velocity");
                    //newVelocity.PrintRect();
                    //Console.ReadLine();

                    Vector3D distanceChange = new Vector3D(newPosition.GetX() - position.GetX(), newPosition.GetY() - position.GetY(), 0);
                    float force = (float) Math.Sqrt((distanceChange.GetX() * distanceChange.GetX()) + (distanceChange.GetY() * distanceChange.GetY()));

                    float totalEnergy = GetKE(mass,newVelocity.GetNormalizedPosition()) + GetPE(mass, newPosition);

                    Console.WriteLine("PE: " + GetPE(mass, newPosition));
                    Console.WriteLine("KE: " + GetKE(mass, newVelocity.GetNormalizedPosition()));



                    altitude = newPosition.GetDistance(earthPos, earthRadius);


                    //a→old = a→new
                    acceleration.SetRectGivenRect(newAcceleration.GetX(), newAcceleration.GetY(), 0);
                    velocity.SetRectGivenRect(newVelocity.GetX(), newVelocity.GetY(), 0);
                    position.SetRectGivenRect(newPosition.GetX(), newPosition.GetY(), 0);


                    if (newPosition.GetDistance(earthPos, earthRadius + 1000) <= 0f)                    
                        Console.WriteLine("Ship has burned up in atmosphere. :(");
                    else
                    {
                        Console.WriteLine("Altitude: " + altitude);
                        Console.WriteLine("Energy of Spaceship " + totalEnergy);
                    }


                    i += (int)time;

                    Console.WriteLine("Time Elapsed: " + i + " seconds");
                }

                Console.ReadLine();
            }


        }

        //Calculate Potential Energy. Mass is in KG.  Height is in meters.
        public static float GetPE(float mass, Vector3D position)
        {
            return -1f * (float)bigG * mass * (earthMass / position.GetMag());
            // float PEShip = mass * altitude * 
            //float potentialEnergy(Vector3 pos, float shipmass)
            //return -1f * BigG * shipmass * (starmass / (pos - StarPos).magnitude))

            //Force of Gravity = G * ( ) / (mass^2)

        }
        //Calculate Kinetic Energy
        public static float GetKE(float mass, float velocity)
        {
            float energy = 0.5f * mass * (velocity * velocity);

            return energy;
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

        //Set the X, Y, and Z values of the 
        public void SetRectGivenRect(float inputX, float inputY, float inputZ)
        {
            X = inputX;
            Y = inputY;
            Z = inputZ;
        }
        //Print the X, Y, and Z coordinate of this vector.
        public void PrintRect()
        {
            Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
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

        //Multiples the rect by the input values.
        public void MultiplyRect(float input)
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
            return (float) Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }



    }
}
