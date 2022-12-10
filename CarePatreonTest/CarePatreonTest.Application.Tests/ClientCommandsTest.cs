using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Exceptions;
using CarePatreonTest.Application.Tests.TestInfra;
using CarePatreonTest.Core.Entities;
using MediatR;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePatreonTest.Application.Tests
{
    public class ClientCommandsTest : IClassFixture<ClientCommandsTestFixture>
    {
        private readonly ClientCommandsTestFixture fixture;

        public ClientCommandsTest(ClientCommandsTestFixture fixture)
        {
            this.fixture = fixture;
        }

        #region CreateClientCommand

        [Fact]
        public async void CreateClient_FirstNameIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = null,
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_FirstNameIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = string.Empty,
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_LastNameIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = null,
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_LastNameIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = string.Empty,
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_EmailIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = null,
            }));
        }

        [Fact]
        public async void CreateClient_EmailIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = string.Empty,
            }));
        }

        [Fact]
        public async void CreateClient_EmailIsInvalid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "email",
            }));
        }

        [Fact]
        public async void CreateClient_PhoneNumberIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = null,
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_PhoneNumberIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = string.Empty,
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_PhoneNumberIsInvalid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "dfsdfsdf",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void CreateClient_ClientIsValid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();
            var clientDomainEventRepository = this.fixture.Provider.GetService<IRepository<ClientDomainEvent>>();

            var res = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "2343312322",
                Email = "dhavedayao@gmail.com",
            });

            var domainEvent = clientDomainEventRepository.GetAsync(x => x.ClientId == res.Client.Id);

            Assert.NotNull(res);
            Assert.NotNull(res.Client);
            Assert.NotNull(domainEvent);
        }

        #endregion CreateClientCommand

        #region UpdateClientCommand

        [Fact]
        public async void UpdateClient_FirstNameIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = null,
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_FirstNameIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = string.Empty,
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_LastNameIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = null,
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_LastNameIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = string.Empty,
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_EmailIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = null,
            }));
        }

        [Fact]
        public async void UpdateClient_EmailIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = string.Empty,
            }));
        }

        [Fact]
        public async void UpdateClient_EmailIsInvalid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "email",
            }));
        }

        [Fact]
        public async void UpdateClient_PhoneNumberIsNull()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = null,
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_PhoneNumberIsEmpty()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = string.Empty,
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_PhoneNumberIsInvalid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            await Assert.ThrowsAsync<BadRequestException>(async () => await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "dfsdfsdf",
                Email = "dhavedayao@gmail.com",
            }));
        }

        [Fact]
        public async void UpdateClient_ClientIsValid()
        {
            var mediator = this.fixture.Provider.GetService<IMediator>();
            var clientDomainEventRepository = this.fixture.Provider.GetService<IRepository<ClientDomainEvent>>();

            var newClient = await mediator.Send(new CreateClientCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "123123232",
                Email = "dhavedayao@gmail.com",
            });

            var res = await mediator.Send(new UpdateClientCommand
            {
                Id = newClient.Client.Id,
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                PhoneNumber = "2343312322",
                Email = "dhavedayao2@gmail.com",
            });

            var domainEvent = clientDomainEventRepository.GetAsync(x => x.ClientId == res.Client.Id);

            Assert.NotNull(res);
            Assert.NotNull(res.Client);
            Assert.Equal(res.Client.FirstName, "TestFirstName2");
            Assert.Equal(res.Client.LastName, "TestLastName2");
            Assert.Equal(res.Client.PhoneNumber, "2343312322");
            Assert.Equal(res.Client.Email, "dhavedayao2@gmail.com");
            Assert.NotNull(domainEvent);
        }

        #endregion UpdateClientCommand
    }
}
