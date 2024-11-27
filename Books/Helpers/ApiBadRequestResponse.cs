using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.ObjectModel;

namespace Books.Helpers
{
    public class ApiBadRequestResponse : ApiResponse
    {
        //public IEnumerable<string> Errors { get; }
        public Collection<ErrorMessageResponse> MessagesDetails { get; set; }

        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(400)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }
            //Errors = modelState.SelectMany(x => x.Value.Errors)
            //    .Select(x => x.ErrorMessage).ToArray();

            MessagesDetails = new Collection<ErrorMessageResponse>();

            foreach (var state in modelState)
            {
                string field = state.Key;
                var errors = state.Value.Errors;
                foreach (var error in errors)
                {
                    var res = new ErrorMessageResponse
                    {
                        Code = "",
                        Fields = field,
                        Message = error.ErrorMessage
                    };
                    MessagesDetails.Add(res);
                }
            }
        }

        //public ApiBadRequestResponse(IdentityResult identityResult)
        //   : base(400)
        //{
        //    Errors = identityResult.Errors
        //        .Select(x => x.Code + " - " + x.Description).ToArray();
        //}

        public ApiBadRequestResponse(string message)
           : base(400, message)
        {
        }

        public ApiBadRequestResponse(string message, string code)
           : base(400, message, code)
        {
        }

        public class ErrorMessageResponse
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string Fields { get; set; }
        }
    }
}
