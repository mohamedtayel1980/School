using System;

namespace Utilities.Paging
{
    public class StudentParametersPaging: PagingParamiters
    {
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = ((uint)DateTime.Now.Year-1950);
        public bool ValidAge => MaxAge > MinAge;
        public string Name { get; set; }
    }
}
