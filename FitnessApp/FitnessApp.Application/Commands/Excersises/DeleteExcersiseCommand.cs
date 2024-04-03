using System;
using MediatR;

namespace FitnessApp.Application.Commands.Excersises
{
	public class DeleteExcersiseCommand:IRequest<Unit>
	{
        public Guid Id { get; set; }
    }
}