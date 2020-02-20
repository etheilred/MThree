using System;

namespace Sem0702
{
    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s)
        {
            Message = s;
        }

        public string Message { get; set; }
        public string NewLoc { get; set; }
    }
}