#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidations.Models;

public class Survey
{
    [Required(ErrorMessage ="Name is required.")]
    [MinLength(2,ErrorMessage ="Name must be at least 2 characters long.")]
    public string Name { get;set; }

    [Required(ErrorMessage ="Location is required.")]
    [Display(Name="Dojo Location:")]
    public string DojoLocation { get;set; }

    [Required(ErrorMessage ="Language is required.")]
    [Display(Name="Favorite Language:")]
    public string FavoriteLanguage { get;set; }
    
    [MinLength(21, ErrorMessage ="If Comment added, must be at least 21 characters long.")]
    public string? Comment { get;set; }
}