using System.Threading;
using System.Threading.Tasks;
using DataAssert;
using MediatR;

namespace BusinessLogic
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Unit>
    {
        private readonly AppDbContext _dbContext;

        public AddPersonCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person { Id = request.Id, Name = request.Name };
            await _dbContext.Person.AddAsync(person, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}