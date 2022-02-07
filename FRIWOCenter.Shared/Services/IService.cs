using FRIWOCenter.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace FRIWOCenter.Shared.Services { 
    public interface IService
    {
        int Counter { get; set; }
        ILogger Logger { get; }
    }
}
