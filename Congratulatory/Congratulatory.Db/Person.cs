﻿using System.ComponentModel.DataAnnotations;

namespace Congratulatory.Db;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public DateOnly Date { get; set; }
}