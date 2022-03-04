using Domain;
using Persistance;
using MediatR;
using System.Threading.Tasks;
using AutoMapper;
namespace Application.Activities
{
    public class Update
    {
        public class Command : IRequest
        {
            public Activity activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Activity old = await _context.Activities.FindAsync(request.activity.Id);
                _mapper.Map(request.activity, old);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}