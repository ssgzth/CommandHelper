using AutoMapper;
using Azure;
using CommandHelper.Data;
using CommandHelper.Dtos;
using CommandHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo command;
        private readonly IMapper mapper;

        public CommandsController(ICommandRepo command, IMapper mapper)
        {
            this.command = command;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = command.GetAllCommands();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = command.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmd)
        {
            var commandModel = mapper.Map<Command>(cmd);
            command.CreateCommand(commandModel);

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, Command cmd)
        {
            var commandModelRepo = command.GetCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }

            commandModelRepo.HowTo = cmd.HowTo;
            commandModelRepo.Line = cmd.Line;
            commandModelRepo.Platform = cmd.Platform;

            command.CommandUpdate(commandModelRepo);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelRepo = command.GetCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(commandToPatch, commandModelRepo);
            command.CommandUpdate(commandModelRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand (int id)
        {
            var commandToDelete = command.GetCommandById(id);
            command.DeleteCommand(commandToDelete);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAll()
        {
            command.DeleteAll();
            return NoContent();
        }
    }
}
