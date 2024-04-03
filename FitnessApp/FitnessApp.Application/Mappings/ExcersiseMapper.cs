using FitnessApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Application.Mapping;

public static class ExcersiseMapper
{
    public static ExcersiseDto ToDto(this Excersise excersise)
    {
        return new ExcersiseDto
        {

            Name = excersise.Name,
            Description = excersise.Description,
            Category = excersise.Category,
            VideoUrlFile = excersise.VideoUrlFile,
            ImageUrlFile = excersise.ImageUrlFile
        };
    }

    public static Excersise ToEntity(this ExcersiseDto excersiseDto)
    {
        return new Excersise
        {
            Id = new Guid(),
            Name = excersiseDto.Name,
            Description = excersiseDto.Description,
            Category = excersiseDto.Category,
            VideoUrlFile=excersiseDto.VideoUrlFile,
            ImageUrlFile = excersiseDto.ImageUrlFile
        };
    }
}