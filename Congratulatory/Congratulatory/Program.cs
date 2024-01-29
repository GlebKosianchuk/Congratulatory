using Congratulatory.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulatory;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new CongratulatoryDbContext();
    }
}