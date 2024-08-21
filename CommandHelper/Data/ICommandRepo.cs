using CommandHelper.Dtos;
using CommandHelper.Models;

namespace CommandHelper.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        void CreateCommand(Command cmd);

        void CommandUpdate (Command cmd);

        void DeleteCommand(Command cmd);
    }
}
