using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TextMatch.Web.Models
{
    public class TestMatchViewModel
    {
        public TestMatchViewModel()
        {
            Output = new List<int>();
        }

        [Display(Name = "Text")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter text.")]
        public string Text { get; set; }

        [Display(Name = "Subtext")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter subtext.")]
        public string SubText { get; set; }
        public IList<int> Output { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}
