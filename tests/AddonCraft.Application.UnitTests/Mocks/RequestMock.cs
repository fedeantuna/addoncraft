using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AddonCraft.Application.UnitTests.Mocks
{
    [ExcludeFromCodeCoverage]
    public class RequestMock : IRequest<String>
    {
        public Int32 Id { get; set; }
        public String SomeText { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FakeRequestHandler : IRequestHandler<RequestMock, String>
    {
        public async Task<String> Handle(RequestMock request, CancellationToken cancellationToken) => await Task.FromResult("Fake Request Handled!");
    }
}