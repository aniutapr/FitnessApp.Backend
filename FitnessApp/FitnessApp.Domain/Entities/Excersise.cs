using System;
using System.ComponentModel;
using FitnessApp.Domain.Enums;

namespace FitnessApp.Domain.Entities
{
	public class Excersise
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }
		public string ImageUrlFile { get; set; }
        public string VideoUrlFile { get; set; }
		public int SuggestedRepeats { get; set; }
		public int SuggestedWeight { get; set; }
    }
}