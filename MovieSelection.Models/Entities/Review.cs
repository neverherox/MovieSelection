﻿namespace MovieSelection.Models.Entities;

public class Review
{
    public int Id { get; set; }

    public string Text { get; set; }

    public int MovieId { get; set; }

    public int UserId { get; set; }
}