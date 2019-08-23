using System;
using System.Linq;
using System.Threading.Tasks;
using es.Commands;
using es.Events;
using model;
using Newtonsoft.Json;

namespace api.command_handler.Services.Handlers
{
    public class AnimalsArrivedCommandHandler : CommandHandler<AnimalsArrivedCommand>
    {
        public AnimalsArrivedCommandHandler(IEventStreamApi eventStreamApi, 
            ICommandValidator<AnimalsArrivedCommand> validator) 
            : base(eventStreamApi, validator)
        {
        }

        public override async Task Process(AnimalsArrivedCommand command)
        {
            foreach(var a in command.Animals) 
            {
                var existingEvents = await EventStreamApi.Query(a.Id);
                var any = existingEvents.Any();

                if(!any) 
                {
                    await EventStreamApi.Append(new es.EventPayload() {
                        Subject = a.Id,
                        Aggregate = nameof(Animal), 
                        Kind = EventKind.AnimalCreated, 
                        Data = JsonConvert.SerializeObject(a), 
                        Timestamp = DateTimeOffset.Now
                    });
                }

                var arrived = new AnimalArrivedObservation() 
                {
                    Arrived = command.DateArrived,
                    AnimalId = a.Id,
                    From = command.From
                };

                await EventStreamApi.Append(new es.EventPayload() {
                    Subject = a.Id,
                    Aggregate = nameof(Animal),
                    Kind = EventKind.AnimalArrived,
                    Data = JsonConvert.SerializeObject(arrived),
                    Timestamp = command.DateArrived
                });

                var animalUpdated = new Animal() 
                {
                    Id = a.Id,
                    CurrentLocation = command.ArrivedOnto
                };

                await EventStreamApi.Append(new es.EventPayload() {
                    Subject = a.Id,
                    Aggregate = nameof(Animal),
                    Kind = EventKind.AnimalUpdated,
                    Data = JsonConvert.SerializeObject(animalUpdated),
                    Timestamp = command.DateArrived
                });
            }
        }
    }
}