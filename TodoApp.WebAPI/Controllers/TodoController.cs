﻿using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.DTOs;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

namespace TodoApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;
        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
        {
            var todo = await _todoService.GetAllTodosAsync();
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromForm] CreateTodoDto todoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Use AutoMapper to map the DTO directly to the entity
            var newTodo = _mapper.Map<Todo>(todoDto);
            newTodo.OwnerId = User.Identity.Name;

            newTodo = await _todoService.CreateTodoAsync(newTodo);
            return Ok(newTodo);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodoById([FromForm] UpdateTodoDto todoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Use AutoMapper to map the DTO directly to the entity
            var updateTodo = _mapper.Map<Todo>(todoDto);
            updateTodo = await _todoService.UpdateTodoAsync(updateTodo);

            return Ok(updateTodo);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}
