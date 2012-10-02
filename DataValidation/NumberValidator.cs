using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace WNSNotifier.DataValidation
{
    /// <summary>
    /// Custom Uri validator.
    /// </summary>
    public class NumberValidator:Validator<int>
    {



        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>
        protected override void DoValidate(int objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if(objectToValidate == 0)
            {
                return;
            }

            if(!DataValidator.IsNumeric(objectToValidate.ToString()))
            {
                LogValidationResult(validationResults,"Port is not valid.",currentTarget,key);
            }
        }

        /// <summary>
        /// Gets the message template to use when logging results no message is supplied.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override string DefaultMessageTemplate
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UriValidator" /> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public NumberValidator(string tag):base(string.Empty,tag)
        {
                
        }

    }

    /// <summary>
    /// Uri Validation Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NumberValidationAttribute:ValidatorAttribute
    {

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new UriValidator(Tag);
        }
    }
}
