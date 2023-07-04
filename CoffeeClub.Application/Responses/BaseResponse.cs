﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string?> ValidationErrors { get; set; }
    }
}
