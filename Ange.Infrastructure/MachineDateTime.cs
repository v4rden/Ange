namespace Ange.Infrastructure
{
    using System;
    using Ange.Common;

    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}