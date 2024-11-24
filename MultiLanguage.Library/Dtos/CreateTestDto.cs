using System.ComponentModel.DataAnnotations;

namespace MultiLanguage.Library.Dtos
{
    public class CreateTestDto
    {
        [Required(ErrorMessage = nameof(UIMessages.RequiredField))]
        public string Name { get; set; }
    }
}

