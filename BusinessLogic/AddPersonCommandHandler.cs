using System.Threading;
using System.Threading.Tasks;
using DataAssert;
using MediatR;

namespace BusinessLogic
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Unit>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMediator _mediator;

        public AddPersonCommandHandler(AppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person { Id = request.Id, Name = request.Name };
            await _dbContext.Person.AddAsync(person, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new AddPersonNotification(person), cancellationToken);

            return Unit.Value;
        }
    }
}