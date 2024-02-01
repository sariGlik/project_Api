using System.ComponentModel.DataAnnotations;
// using PROJECT_API.AllModels;

namespace AllModels;

public class Pizza
{
[StringLength(25),MinLength(1)]
public String? Name {get;set;}
public int Id {get;set;}
public bool IsGluten { get; set; }
}