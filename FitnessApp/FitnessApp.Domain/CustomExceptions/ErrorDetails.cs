﻿using System;
using Newtonsoft.Json;

namespace FitnessApp.Domain.CustomExceptions;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}