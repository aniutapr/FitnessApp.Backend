using System;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands;

public class CreateExcersiseCommand : IRequest<Excersise>
{
    public ExcersiseDto ExcersiseDto { get; set; }
}