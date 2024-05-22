using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Mapping
{
    public static class ExerciseAdapter
    {
        public static ExcersiseDto ToDto(this Excersise exercise)
        {
            return new ExcersiseDto
            {
                Name = exercise.Name,
                Description = exercise.Description,
                Category = exercise.Category,
                VideoUrlFile = exercise.VideoUrlFile,
                ImageUrlFile = exercise.ImageUrlFile
            };
        }

        public static Excersise ToEntity(this ExcersiseDto exerciseDto)
        {
            return new Excersise
            {
                Id = new Guid(), 
                Name = exerciseDto.Name,
                Description = exerciseDto.Description,
                Category = exerciseDto.Category,
                VideoUrlFile = exerciseDto.VideoUrlFile,
                ImageUrlFile = exerciseDto.ImageUrlFile
            };
        }
    }
}
