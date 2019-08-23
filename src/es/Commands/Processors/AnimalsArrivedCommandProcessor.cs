using System;
using System.Linq;
using es.Events;
using model;
using Newtonsoft.Json;

namespace es.Commands.Processors 
{
    public class AnimalsArrivedCommandProcessor : AbstractCommandProcessor<AnimalArrivedCommand>
    {
        public AnimalsArrivedCommandProcessor(IEventStream eventStream, 
            ICommandValidator<AnimalArrivedCommand> validator) 
            : base(eventStream, validator)
        {
        }

        public override void Process(AnimalArrivedCommand command)
        {
            foreach(var a in command.Animals) 
            {
                var any = EventStream.Fetch(a.Id).Any();

                if(!any) 
                {
                    EventStream.Add(a.Id, 
                        nameof(Animal), 
                        EventKind.AnimalCreated, 
                        JsonConvert.SerializeObject(a), 
                        DateTimeOffset.Now);
                }

                var arrived = new AnimalArrivedObservation() 
                {
                    Arrived = command.DateArrived,
                    AnimalId = a.Id,
                    From = command.From
                };

                EventStream.Add(a.Id,
                    nameof(Animal),
                    EventKind.AnimalArrived,
                    JsonConvert.SerializeObject(arrived),
                    command.DateArrived
                );

                var animalUpdated = new Animal() 
                {
                    Id = a.Id,
                    CurrentLocation = command.ArrivedOnto
                };

                EventStream.Add(a.Id,
                    nameof(Animal),
                    EventKind.AnimalUpdated,
                    JsonConvert.SerializeObject(animalUpdated),
                    command.DateArrived
                );
            }
        }
    }
}