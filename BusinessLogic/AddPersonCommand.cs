using MediatR;

namespace BusinessLogic
{
    public class AddPersonCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}