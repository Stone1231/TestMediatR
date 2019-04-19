using System.Threading;
using System.Threading.Tasks;
using DataAssert;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class PersonQueryHandler : IRequestHandler<PersonQuery, PersonQueryResponse>
    {
        private readonly AppDbContext _dbContext;

        public PersonQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonQueryResponse> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Person.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return new PersonQueryResponse(person);
        }
    }
}