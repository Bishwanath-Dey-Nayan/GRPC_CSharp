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
    }
}