using DataAssert;
using MediatR;

namespace BusinessLogic
{
    public class AddPersonNotification : INotification
    {
        public AddPersonNotification(Person person)
        {
            Id = person.Id;
            Name = person.Name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}