﻿namespace BookNest.Domain.Entities
{
	public class Villa
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }
		public int Sqmeters { get; set; }
		public int Occupancy { get; set; }
		public string? ImageUrl { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}