﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Entities;
using ToDoListBlazor.Domain.Shared.ViewModels;

namespace ToDoListBlazor.Application.Mappers
{
    public class ToDoMapper : IToDoMapper
    {
        private readonly IUserMapper _userMapper;

        public ToDoMapper(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

        public ToDoViewModel Map(ToDo toDo)
        {
            return new ToDoViewModel
            {
                Id = toDo.EntityId,
                Title = toDo.Title,
                Priority = toDo.Priority,
                IsFinished = toDo.IsFinished,
                Description = toDo.Description,
                CreatedDateTime = toDo.CreatedDateTime,
                FinishedDateTime = toDo.FinishedDateTime,
                AssignedtoUserId = toDo.AssignedtoUserId,
                CreatedByUserId = toDo.CreatedByUserId,
                CreatedBy = toDo.CreatedBy != null ? _userMapper.Map(toDo.CreatedBy) : null,
                AssignedTo = toDo.AssignedTo != null ? _userMapper.Map(toDo.AssignedTo) : null
            };
        }

        public ToDo Map(ToDoViewModel toDo)
        {
            return new ToDo
            {
                EntityId = toDo.Id,
                Title = toDo.Title,
                Priority = toDo.Priority,
                IsFinished = toDo.IsFinished,
                Description = toDo.Description,
                CreatedDateTime = toDo.CreatedDateTime,
                FinishedDateTime = toDo.FinishedDateTime,
                AssignedtoUserId = toDo.AssignedtoUserId,
                CreatedByUserId = toDo.CreatedByUserId,
                CreatedBy = toDo.CreatedBy != null ? _userMapper.Map(toDo.CreatedBy) : null,
                AssignedTo = toDo.AssignedTo != null ? _userMapper.Map(toDo.AssignedTo) : null
            };
        }
    }
}