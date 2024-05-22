using System;
using FitnessApp.Domain.Entities;
using MediatR;

namespace FitnessApp.Application.Commands.Excersises
{
	public class UpdateExcersiseCommand:IRequest<Excersise>
	{
        public Excersise Excersise { get; set; }
    }
}

