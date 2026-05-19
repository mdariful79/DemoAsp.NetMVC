//Console.WriteLine();
using JsonFormattingAssignment;
using JsonFormattingAssignmentTest.TestCase1;
using System.Net;
using System.Numerics;
using static System.Collections.Specialized.BitVector32;

class Program

{

    static void Main()

    {

        var course = new Course

        {

            Title = "C# Mastery",

            Fees = 299.99,

            Teacher = new Instructor

            {

                Name = "Alice Smith",

                Email = "alice@example.com",

                PresentAddress = new Address

                {

                    Street = "123 Main St",

                    City = "Dhaka",

                    Country = "Bangladesh"

                },

                PermanentAddress = new Address

                {

                    Street = "456 Oak Ave",

                    City = "Chittagong",

                    Country = "Bangladesh"

                },

                PhoneNumbers = new List<Phone>

                {

                    new Phone { Number = "1234567", Extension = "01", CountryCode = "+880" },

                    new Phone { Number = "9876543", Extension = "02", CountryCode = "+880" }

                }

            },

            Topics = new List<Topic>

            {

                new Topic

                {

                    Title = "Reflection",

                    Description = "Understanding .NET reflection API",

                    Sessions = new List<Session>

                    {

                        new Session { DurationInHour = 2, LearningObjective = "Load types at runtime" },

                        new Session { DurationInHour = 3, LearningObjective = "Invoke methods dynamically" }

                    }

                },

                new Topic

                {

                    Title = "Serialization",

                    Description = "Custom JSON serializer",

                    Sessions = new List<Session>

                    {

                        new Session { DurationInHour = 4, LearningObjective = "Build recursive serializer" }

                    }

                }

            },

            Tests = new List<AdmissionTest>

            {

                new AdmissionTest

                {

                    StartDateTime = new DateTime(2025, 6, 1, 9, 0, 0),

                    EndDateTime   = new DateTime(2025, 6, 1, 11, 0, 0),

                    TestFees      = 50.0

                }

            }

        };

        string json = JsonFormatter.Convert(course);

        Console.WriteLine(json);

    }

}
