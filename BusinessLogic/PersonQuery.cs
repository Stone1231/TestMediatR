using MediatR;

namespace BusinessLogic
{
    public class PersonQuery : IRequest<PersonQueryResponse>
    {
        public int Id { get; set; }
    }
}