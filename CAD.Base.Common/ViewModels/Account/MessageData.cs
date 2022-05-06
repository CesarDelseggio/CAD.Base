using CAD.Base.Common.Resources.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAD.Base.Common.ViewModels.Account
{
    public class MessageData
    {
        [Required(ErrorMessageResourceName = nameof(DataAnnotationsErrorsMessages.Required),
            ErrorMessageResourceType = typeof(DataAnnotationsErrorsMessages))]
        [Display(Name = nameof(DataAnnotationsNames.Name), ResourceType = typeof(DataAnnotationsNames))]
        public string Name { get; set; }

        [Display(Name = nameof(DataAnnotationsNames.Company), ResourceType = typeof(DataAnnotationsNames))]
        public string Company { get; set; }

        [Display(Name = nameof(DataAnnotationsNames.Phone), ResourceType = typeof(DataAnnotationsNames))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = nameof(DataAnnotationsErrorsMessages.Required), 
            ErrorMessageResourceType = typeof(DataAnnotationsErrorsMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(DataAnnotationsErrorsMessages.EmailAddress),
            ErrorMessageResourceType = typeof(DataAnnotationsErrorsMessages))]
        [Display(Name = nameof(DataAnnotationsNames.EmailFrom), ResourceType = typeof(DataAnnotationsNames))]
        public string EmailFrom { get; set; }

        [Display(Name = nameof(DataAnnotationsNames.EmailTo), ResourceType = typeof(DataAnnotationsNames))]
        public string EmailTo { get; set; }

        [Display(Name = nameof(DataAnnotationsNames.Subject), ResourceType = typeof(DataAnnotationsNames))]
        public string Subject { get; set; }

        [Required(ErrorMessageResourceName = nameof(DataAnnotationsErrorsMessages.Required),
            ErrorMessageResourceType = typeof(DataAnnotationsErrorsMessages))]
        [Display(Name = nameof(DataAnnotationsNames.Message), ResourceType = typeof(DataAnnotationsNames))]
        public string Message { get; set; }
    }
}
