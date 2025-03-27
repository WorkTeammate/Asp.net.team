using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public OperationResult()
        {
            IsSuccessful = false;
        }
        public OperationResult Successful(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccessful = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSuccessful = false;
            Message = message;
            return this;
        }

    }
}
