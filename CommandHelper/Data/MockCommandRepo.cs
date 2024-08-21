/*using CommandHelper.Models;

namespace CommandHelper.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        List<Command> commands = new List<Command>
            {
                new Command { Id = 0 , HowTo= "Boil an egg " , Line="Boil water", Platform= "kettle and pan"},
                new Command { Id = 1 , HowTo= "cook an omlete" , Line="Dont boil and water and use oil on the pan", Platform= "kettle and pan"},
                new Command { Id = 2, HowTo = "cook rice", Line = "wash rise, rinse the rise and then add water then pressure cook for 5 min", Platform = "pressure cooker" }
            };

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Command> ICommandRepo.GetAllCommands()
        {
          
            return commands;
        }

        Command ICommandRepo.GetCommandById(int id)
        {
            var commandItem = commands.Find(c => c.Id == id);
            return commandItem;
        }
    }
}*/
