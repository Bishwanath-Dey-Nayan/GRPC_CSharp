using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var greetClient = new Greeter.GreeterClient(channel);

            //var input = new HelloRequest { Name = "Nayan" };
            //var reply = await greetClient.SayHelloAsync(input);

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var studentClient = new Student.StudentClient(channel);

            var requestedStudent = new StudentLookupModel { StudentId = 1 };
            var student = await studentClient.GetStudentInfoAsync(requestedStudent);
            Console.WriteLine($"{ student.FirstName } {student.LastName}");

            using (var call = studentClient.GetStudents(new NewStudentRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    var stud = call.ResponseStream.Current;

                    Console.WriteLine($"{stud.FirstName} {stud.LastName}: {stud.EmailAddress}");
                }
            }

            Console.ReadKey();
        }
    }
}
