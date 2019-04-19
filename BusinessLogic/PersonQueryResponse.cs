using DataAssert;

namespace BusinessLogic
{
    public class PersonQueryResponse
    {
        public PersonQueryResponse(Person person)
        {
            Person = person;
        }

        public Person Person { get; private set; }
    }
}