namespace Domain.Exceptions.StudentExceptions
{
    public sealed class StudentNotFound : NotFoundException
    {
        public StudentNotFound(string message) : base(message)
        {
        }
    }
}
