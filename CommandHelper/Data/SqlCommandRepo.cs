using AutoMapper;
using CommandHelper.Data;
using CommandHelper.Dtos;
using CommandHelper.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;

namespace CommandHelper.Data
{
    public class SqlCommandRepo : ICommandRepo
    {
        private readonly CommandDbContext context;

        public SqlCommandRepo(CommandDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return context.commands.ToList();
        }


        public Command GetCommandById(int id)
        {
            var obj = context.commands.FirstOrDefault(c => c.Id == id);
            if (obj == null) { return null; }
            else { return obj; }
        }

        public void CreateCommand (Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd)); 
            }

            context.commands.Add(cmd);
            context.SaveChanges();
           
        }


        public bool SaveChanges()
        {
            return (context.SaveChanges()>=0);
        }

        public void CommandUpdate (Command obtainedobj)
        {
            if (obtainedobj == null)
            {
                throw new ArgumentNullException(nameof(obtainedobj));
            }

            var model = context.commands.Attach(obtainedobj);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCommand (Command cmd)
        {
            context.commands.Remove(cmd);
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            
            context.commands.RemoveRange(context.commands);
            context.SaveChanges();
        }
    }
}
