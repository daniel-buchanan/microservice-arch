namespace es.Commands 
{
    static class CommandFinder 
    {
        public static ICommand FromType(string type, string json) 
        {
            ICommand command;

            switch(type) 
            {
                case AnimalsArrivedCommand.Type:
                    command = new AnimalsArrivedCommand();
                    break;
                case AnimalsLeftCommand.Type:
                    command = new AnimalsLeftCommand();
                    break;
                case AnimalsUpdatedCommand.Type:
                    command = new AnimalsUpdatedCommand();
                    break;
                default:
                    command = null;
                    break;
            }

            if(command != null) command.Initialise(json);

            return command;
        }
    }
}