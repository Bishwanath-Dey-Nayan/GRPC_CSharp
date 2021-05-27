using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class StudentService : Student.StudentBase
    {
        public StudentService(ILogger<StudentService> logger)
        {
            Logger = logger;
        }

        public ILogger<StudentService> Logger { get; }

        public override Task<StudentModel> GetStudentInfo(StudentLookupModel request, ServerCallContext context)
        {
            StudentModel output = new StudentModel();
            if(request.StudentId == 1)
            {
                output.FirstName = "Rahim";
                output.LastName = "Mia";
            }
            else
            {
                output.FirstName = "Karim";
                output.LastName = "Mia";
            }

            return Task.FromResult(output);
        }
        public override async Task GetStudents(NewStudentRequest request, IServerStreamWriter<StudentModel> responseStream, ServerCallContext context)
        {
            List<StudentModel> students = new List<StudentModel>
            {
                new StudentModel
                {
                    FirstName = "Nayan",
                    LastName = "Dey",
                    EmailAddress = "nayandey07@gmail.com",
                    Age = 25,
                    IsAlive = true
                },
                 new StudentModel
                {
                    FirstName = "Rahim",
                    LastName = "Mia",
                    EmailAddress = "rahim@gmail.com",
                    Age = 26,
                    IsAlive = true
                },
                                  new StudentModel
                {
                    FirstName = "Karim",
                    LastName = "Mia",
                    EmailAddress = "karim@gmail.com",
                    Age = 27,
                    IsAlive = true
                },
            };

            foreach(var stu in students)
            {
               await responseStream.WriteAsync(stu);
            }
        }
    }
}