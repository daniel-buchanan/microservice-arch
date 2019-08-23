using System;
using System.Collections.Generic;
using model;
using Newtonsoft.Json;

namespace es.Commands 
{
    public class AnimalsLeftCommand : Command 
    {
        public const string Type = nameof(AnimalsLeftCommand);
        public List<Animal> Animals { get; private set; }
        public DateTimeOffset DateLeft { get; private set; }

        public AnimalsLeftCommand() : base(Type) { }

        public override void Initialise(string json) 
        {
            base.Initialise(json);

            var temp = JsonConvert.DeserializeObject<AnimalsLeftCommand>(Json);
            Animals = temp.Animals;
            DateLeft = temp.DateLeft;
        }
    }
}