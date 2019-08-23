using model;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace es.Commands 
{
    public class AnimalsArrivedCommand : Command 
    {
        public override string CommandType => nameof(AnimalsArrivedCommand);

        public List<Animal> Animals { get; set; }
        public DateTimeOffset DateArrived { get; set; }
        public string From { get; set; }
        public string ArrivedOnto { get; set; }

        public override void Initialise(string json) 
        {
            base.Initialise(json);

            var temp = JsonConvert.DeserializeObject<AnimalsArrivedCommand>(Json);
            Animals = temp.Animals;
            DateArrived = temp.DateArrived;
            From = temp.From;
            ArrivedOnto = temp.ArrivedOnto;
        }
    }
}