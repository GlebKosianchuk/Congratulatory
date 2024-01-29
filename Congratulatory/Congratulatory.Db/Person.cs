﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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