using System;
using System.Collections.Generic;
using model;
using Newtonsoft.Json;

namespace es.Commands 
{
    public class AnimalsUpdatedCommand : Command 
    {
        public List<Animal> Animals { get; private set; }
        public DateTimeOffset DateUpdated { get; private set; }

        public override void Initialise(string json) 
        {
            base.Initialise(json);

            var temp = JsonConvert.DeserializeObject<AnimalsUpdatedCommand>(Json);
            Animals = temp.Animals;
            DateUpdated = temp.DateUpdated;
        }
    }
}