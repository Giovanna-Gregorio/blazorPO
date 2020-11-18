using System.Collections.Generic;

namespace BlazorPO.Shared
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}